using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.BLL.ModelVM.ProductVM;

namespace TraininingSystem.BLL.Feature.Interface
{
    public interface IProductRepo
    {
        List<GetAllProductVM> getAll();
        void Create(ProductVM createProductVM);
        void Edit(ProductVM editProductVM);
        ProductVM GetProductById(int Id);
        void Delete(int id);

        List<ProductVM> GetByName(string name);
    }
}
