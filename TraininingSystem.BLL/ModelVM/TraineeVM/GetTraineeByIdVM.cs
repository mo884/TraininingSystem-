using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.DAL.Entity.Enum;
using TraininingSystem.DAL.Entity;

namespace TraininingSystem.BLL.ModelVM.TraineeVM
{
    public record GetTraineeByIdVM(int ID, string Name, Gender Gender, string Email, string Phone, DateTime Birthdate, string TrackName)
    {
        public GetTraineeByIdVM() : this(default, default, default, default, default, default, default)
        {
        }
    }
}
