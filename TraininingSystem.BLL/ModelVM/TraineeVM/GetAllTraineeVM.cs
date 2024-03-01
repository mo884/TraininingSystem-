using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.DAL.Entity;
using TraininingSystem.DAL.Entity.Enum;

namespace TraininingSystem.BLL.ModelVM.TraineeVM
{
    public record GetAllTraineeVM(int ID ,string Name , Gender Gender, string Email, string Phone, DateTime Birthdate, Track? Trak, List<Course> Courses)
    {
    }
}
