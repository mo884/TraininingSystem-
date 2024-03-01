using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.DAL.Entity.Enum;
using TraininingSystem.DAL.Entity;

namespace TraininingSystem.BLL.ModelVM.CustomerVM
{
    public record GetCustomerVM(int ID,
                            string Name,
                            Gender Gender,
                            string Email,
                            string PhoneNum,
                            IEnumerable<Product>? Products);
}
