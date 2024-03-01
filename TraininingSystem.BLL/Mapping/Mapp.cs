using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.BLL.ModelVM.CourseVM;
using TraininingSystem.BLL.ModelVM.CustomerVM;
using TraininingSystem.BLL.ModelVM.ProductVM;
using TraininingSystem.BLL.ModelVM.TrackVM;
using TraininingSystem.BLL.ModelVM.TraineeVM;
using TraininingSystem.DAL.Entity;

namespace TraininingSystem.BLL.Mapping
{
    public class Mapp:Profile
    {
        public Mapp()
        {
            CreateMap<Track, GetAllTrackVM>();

            CreateMap<Track, CreateTrackVM>();

            CreateMap<Track, EditTrackVM>();
            CreateMap<EditTrackVM, Track>();

            CreateMap<Track, GetTrackByIdVM>();
            CreateMap<GetTrackByIdVM, EditTrackVM>();


            CreateMap<Trainee, GetAllTraineeVM>();

            CreateMap<CreateTraineWithTracksVM, CreateTraineVM>();
            CreateMap<CreateTraineVM, Trainee>();

            CreateMap<EditTraineWithTracksVM, Trainee>();
            CreateMap<Trainee, EditTraineWithTracksVM>();


            CreateMap<Trainee, GetTraineeByIdVM>();
            CreateMap<GetTraineeByIdVM, Trainee>();

            CreateMap<EditTraineWithTracksVM, GetTraineeByIdVM>();
            CreateMap<GetTraineeByIdVM, EditTraineWithTracksVM>();

            CreateMap<Trainee, GetTraineeByIdVM>()
              .ForMember(dest => dest.TrackName, opt => opt.MapFrom(src => src.Trak != null ? src.Trak.Name : ""));

            CreateMap<EditTraineWithTracksVM, GetTraineeByIdVM>()
                .ForMember(dest => dest.TrackName, opt => opt.MapFrom(src => src.Traks != null && src.Traks.Any() ? src.Traks.FirstOrDefault().Name : ""));

            CreateMap<Course, GetAllCourseVM>()
               .ForMember(dest => dest.TraineName, opt => opt.MapFrom(src => src.Trainee != null ? src.Trainee.Name : null));

            CreateMap<Course, CreatCourseVM>()
      .ForMember(dest => dest.Grade, opt => opt.MapFrom(src => src.Grade))
      .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics))
      .ForMember(dest => dest.TraineID, opt => opt.MapFrom(src => src.TraineID));
      CreateMap<CreatCourseVM, Course>();


            CreateMap<GetCourseByIDVM, EditCourseVM>();
            CreateMap<Course, GetCourseByIDVM>();

            CreateMap<EditCourseVM, Course>();


            CreateMap<Product,GetAllProductVM>();
            CreateMap<Customer, GetCustomerVM>();

            CreateMap< ProductVM,Product>();
            CreateMap<Product, ProductVM >();


            CreateMap<Customer , CustomerVM>();
            CreateMap<CustomerVM, Customer>();


        }
    }
}
