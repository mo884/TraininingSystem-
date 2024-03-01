using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.DAL.Entity;

namespace TraininingSystem.BLL.ModelVM.ProductVM
{
   
    public record GetAllProductVM(int ID,
                      string Name,
                      string Image,
                      decimal Price,
                      string Description,
                      int CustID,
                      Customer? Customer);
}
