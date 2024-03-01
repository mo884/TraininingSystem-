using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.BLL.Feature.Interface;
using TraininingSystem.BLL.ModelVM.CourseVM;
using TraininingSystem.DAL.Databae;
using TraininingSystem.DAL.Entity;

namespace TraininingSystem.BLL.Feature.Reposoratory
{
    public class CourseRepo : ICourseRepo
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper Mapper;


        public CourseRepo(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext=applicationDbContext;
            Mapper=mapper;
        }

        public void Create(CreatCourseVM creatCourseVM)
        {
            var course = Mapper.Map<Course>(creatCourseVM);

            applicationDbContext.Courses.Add(course);

            applicationDbContext.SaveChanges();

            if (creatCourseVM.Topics != null && creatCourseVM.Topics.Any())
            {
                var LastCourse = applicationDbContext.Courses.OrderByDescending(a => a.ID).FirstOrDefault();

                foreach (var topic in creatCourseVM.Topics)
                {
                    topic.CourseID = LastCourse.ID;
                  
                        course.Topics.Add(topic);
                   
                   
                }
            }

            // Save changes again to reflect the association between course and topics
            applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = applicationDbContext.Courses.FirstOrDefault(a => a.ID == id);
            if (course != null)
            {
                var topics = applicationDbContext.Topics.Where(t => t.CourseID == id);
                applicationDbContext.Topics.RemoveRange(topics);

                applicationDbContext.Courses.Remove(course);
                applicationDbContext.SaveChanges();
            }
        }

        public void Edit(EditCourseVM editCourseVM)
        {
           var course= Mapper.Map<Course>(editCourseVM);
            applicationDbContext.Courses.Update(course);
            applicationDbContext.SaveChanges();
        }

        public List<GetAllCourseVM> getAllCourseVMs()
        {
            return Mapper.Map<List<GetAllCourseVM>>(applicationDbContext.Courses.Include(a => a.Trainee).Include(a=>a.Topics).ToList());
        }

        public GetCourseByIDVM getbyId(int id)
        {
            var data = applicationDbContext.Courses.Include(a=>a.Trainee).Include(a => a.Topics).Where(a => a.ID==id).FirstOrDefault();
            var mapperData = Mapper.Map<GetCourseByIDVM>(data);
            return mapperData;
        }
    }
}
