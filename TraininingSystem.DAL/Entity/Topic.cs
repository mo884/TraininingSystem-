using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraininingSystem.DAL.Entity
{
    [Table("Topic")]

    public class Topic
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("Course")]
        public int? CourseID { get; set; }
        public Course? Course { get; set; }
    }
}
