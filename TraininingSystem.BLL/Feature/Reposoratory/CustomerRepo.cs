using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.BLL.Feature.Interface;
using TraininingSystem.BLL.ModelVM.CustomerVM;
using TraininingSystem.DAL.Databae;
using TraininingSystem.DAL.Entity;

namespace TraininingSystem.BLL.Feature.Reposoratory
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper Mapper;


        public CustomerRepo(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext=applicationDbContext;
            Mapper=mapper;
        }

        public void create(CustomerVM customer)
        {
            var customerEntity = Mapper.Map<Customer>(customer);
            applicationDbContext.Customers.Add(customerEntity);
            applicationDbContext.SaveChanges();
        }

        public void delete(int id)
        {
            var customerEntity = applicationDbContext.Customers.Find(id);
            if (customerEntity != null)
            {
                applicationDbContext.Customers.Remove(customerEntity);
                applicationDbContext.SaveChanges();
            }
        }

        public List<GetCustomerVM> GetAll()
        {
            return Mapper.Map<List<GetCustomerVM>>(applicationDbContext.Customers.ToList());
        }
        public CustomerVM getById(int id)
        {
            var customerEntity = applicationDbContext.Customers.Find(id);
            return Mapper.Map<CustomerVM>(customerEntity);
        }

        public void update(CustomerVM customer)
        {
            var customerEntity = Mapper.Map<Customer>(customer);
            applicationDbContext.Attach(customerEntity);
            applicationDbContext.Entry(customerEntity).State = EntityState.Modified;
            applicationDbContext.SaveChanges();
        }
    }
}
