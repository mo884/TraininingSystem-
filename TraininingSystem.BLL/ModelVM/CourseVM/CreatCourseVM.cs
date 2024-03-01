using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.DAL.Entity;

namespace TraininingSystem.BLL.ModelVM.CourseVM
{
    public class CreatCourseVM
    {
        public double Grade { get; set; }
        public List<Topic>? Topics { get; set; }
        [ForeignKey("Trainee")]
        public int? TraineID { get; set; }
    }
}
