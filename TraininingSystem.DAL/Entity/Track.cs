using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraininingSystem.DAL.Entity
{
    [Table("Track")]

    public class Track
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Min 2 letter")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public List<Trainee> Trainees { get; set; }

    }
}
