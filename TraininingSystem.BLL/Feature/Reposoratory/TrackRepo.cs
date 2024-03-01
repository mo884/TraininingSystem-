using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.BLL.Feature.Interface;
using TraininingSystem.BLL.ModelVM.TrackVM;
using TraininingSystem.DAL.Databae;
using TraininingSystem.DAL.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TraininingSystem.BLL.Feature.Reposoratory
{
    public class TrackRepo : ITrackRepo
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper Mapper;


        public TrackRepo(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext=applicationDbContext;
            Mapper=mapper;
        }

      
        public List<GetAllTrackVM> GetAll()
        {
            var Data = applicationDbContext.Traces.ToList();
            return Mapper.Map<List<GetAllTrackVM>>(Data);
        }

        public void Create(CreateTrackVM model)
        {
            var Data = Mapper.Map<Track>(model);
            applicationDbContext.Traces.Add(Data);
            applicationDbContext.SaveChanges();
        }

        public GetTrackByIdVM GetById(int id)
        {
            var Data = applicationDbContext.Traces.Where(a => a.ID==id).FirstOrDefault();
           return Mapper.Map<GetTrackByIdVM>(Data);
        }

        public void Edit(EditTrackVM model)
        {
          var Data =  Mapper.Map<Track>(model);
            applicationDbContext.Update(Data);
            applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
           var Data = applicationDbContext.Traces.Where(a => a.ID ==id).FirstOrDefault();
            applicationDbContext.Traces.Remove(Data);
            applicationDbContext.SaveChanges();

        }
    }
}
