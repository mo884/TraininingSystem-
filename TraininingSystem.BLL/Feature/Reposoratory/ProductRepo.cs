using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.BLL.Feature.Interface;
using TraininingSystem.BLL.Mapping;
using TraininingSystem.BLL.ModelVM.ProductVM;
using TraininingSystem.DAL.Databae;
using TraininingSystem.DAL.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TraininingSystem.BLL.Feature.Reposoratory
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper Mapper;


        public ProductRepo(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext=applicationDbContext;
            Mapper=mapper;
        }

        public void Create(ProductVM createProductVM)
        {
            applicationDbContext.Products.Add(Mapper.Map<Product>(createProductVM));
            applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = applicationDbContext.Products.Where(a => a.ID==id).FirstOrDefault();
            applicationDbContext.Products.Remove(data);
            applicationDbContext.SaveChanges();

        }

        public void Edit(ProductVM editProductVM)
        {
            var data = applicationDbContext.Products.Where(a => a.ID==editProductVM.ID).FirstOrDefault();

            if (editProductVM.ImageFile == null)
            {
                editProductVM.Image = data.Image;
            }
            data.Image = editProductVM.Image;
            data.CustID =editProductVM.CustID;
            data.Price=editProductVM.Price;
            data.Description = editProductVM.Description;
            data.Name   = editProductVM.Name;
            applicationDbContext.SaveChanges();

        }

        public List<GetAllProductVM> getAll()
        {
            return Mapper.Map<List<GetAllProductVM>>(applicationDbContext.Products.ToList());
        }

        public List<ProductVM> GetByName(string name)
        {
            return Mapper.Map<List<ProductVM>>(applicationDbContext.Products.Where(a => a.Name==name).ToList());
        }

        public ProductVM GetProductById(int Id)
        {
            return Mapper.Map<ProductVM>(applicationDbContext.Products.Where(a=>a.ID==Id).FirstOrDefault());
        }
    }
}
