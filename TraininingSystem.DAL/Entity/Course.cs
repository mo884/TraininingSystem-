using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraininingSystem.DAL.Entity
{
    [Table("Course")]
    public class Course
    {
        public int ID { get; set; }
        public double Grade { get; set; }
        public List<Topic>? Topics { get; set; }
        [ForeignKey("Trainee")]
        public int? TraineID { get; set; }
        public Trainee? Trainee { get; set; }
    }
}
