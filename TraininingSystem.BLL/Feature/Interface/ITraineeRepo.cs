using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.BLL.ModelVM.TrackVM;
using TraininingSystem.BLL.ModelVM.TraineeVM;

namespace TraininingSystem.BLL.Feature.Interface
{
    public interface ITraineeRepo
    {
        List<GetAllTraineeVM> GetAll();
        void Create(CreateTraineVM model);
        GetTraineeByIdVM GetById(int id);
        void Edit(EditTraineWithTracksVM model);

        void Delete(int id);
    }
}
