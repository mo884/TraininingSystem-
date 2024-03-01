using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.BLL.ModelVM.TrackVM;

namespace TraininingSystem.BLL.Feature.Interface
{
    public interface ITrackRepo
    {
        List<GetAllTrackVM> GetAll();
        void Create(CreateTrackVM model);
        GetTrackByIdVM GetById(int id);
        void Edit(EditTrackVM model);

        void Delete(int id);
    }
}
