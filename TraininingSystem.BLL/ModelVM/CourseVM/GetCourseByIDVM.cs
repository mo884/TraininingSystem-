using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.DAL.Entity;

namespace TraininingSystem.BLL.ModelVM.CourseVM
{
    public class GetCourseByIDVM
    {
        public int ID { get; set; }
        public double Grade { get; set; }
        public int? TraineID { get; set; }
        public Trainee ?Trainee { get; set; }
        public List<Topic>? Topics { get; set; }

    }
}
