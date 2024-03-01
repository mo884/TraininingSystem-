using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.BLL.Feature.Interface;
using TraininingSystem.BLL.ModelVM.TrackVM;
using TraininingSystem.BLL.ModelVM.TraineeVM;
using TraininingSystem.DAL.Databae;
using TraininingSystem.DAL.Entity;

namespace TraininingSystem.BLL.Feature.Reposoratory
{
    public class TraineeRepo : ITraineeRepo
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper Mapper;


        public TraineeRepo(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext=applicationDbContext;
            Mapper=mapper;
        }
        public void Create(CreateTraineVM model)
        {
            applicationDbContext.Add(Mapper.Map<Trainee>(model));
            applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var Data = applicationDbContext.Trainees.Where(a => a.ID ==id).FirstOrDefault();
            applicationDbContext.Trainees.Remove(Data);
            applicationDbContext.SaveChanges();
        }

        public void Edit(EditTraineWithTracksVM model)
        {
            var Data = Mapper.Map<Trainee>(model);
            applicationDbContext.Update(Data);
            applicationDbContext.SaveChanges();
        }

        public List<GetAllTraineeVM> GetAll()
        {
            var Data = applicationDbContext.Trainees.Include(a => a.Trak).Include(a => a.Courses).ToList();
            return Mapper.Map<List<GetAllTraineeVM>>(Data);
        }

        public GetTraineeByIdVM GetById(int id)
        {
            var Data = applicationDbContext.Trainees.Include(a => a.Trak).Where(q => q.ID==id).FirstOrDefault();
            var Traine = Mapper.Map<GetTraineeByIdVM>(Data);
            return Traine;
        }

      
    }
}
