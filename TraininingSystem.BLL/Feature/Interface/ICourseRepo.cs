using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.BLL.ModelVM.CourseVM;

namespace TraininingSystem.BLL.Feature.Interface
{
    public interface ICourseRepo
    {
        List<GetAllCourseVM> getAllCourseVMs();
        void Create(CreatCourseVM creatCourseVM);
        void Edit(EditCourseVM editCourseVM);

        GetCourseByIDVM getbyId(int id);

        void Delete(int id);
    }
}
