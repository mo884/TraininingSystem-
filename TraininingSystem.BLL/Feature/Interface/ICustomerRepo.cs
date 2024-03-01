using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.BLL.ModelVM.CustomerVM;

namespace TraininingSystem.BLL.Feature.Interface
{
    public interface ICustomerRepo
    {
        List<GetCustomerVM> GetAll();
        void create(CustomerVM customer);   
        void update(CustomerVM customer);
        CustomerVM getById(int id);
        void delete(int id);
    }
}
