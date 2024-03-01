using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.DAL.Entity;

namespace TraininingSystem.BLL.ModelVM.CourseVM
{
   
        public record GetAllCourseVM(int ID, double Grade, List<Topic>? Topics, string TraineName)
        {
            public GetAllCourseVM() : this(default, default, default, default)
            {
            }
        }
   

}
