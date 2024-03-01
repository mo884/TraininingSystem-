using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraininingSystem.DAL.Entity;
using TraininingSystem.DAL.Entity.Enum;
using TraininingSystem.BLL.ModelVM.TrackVM;

namespace TraininingSystem.BLL.ModelVM.TraineeVM
{
    public class CreateTraineWithTracksVM
    {
        [Required]
        [MinLength(2, ErrorMessage = "Min 2 letter")]
        public string Name { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        public DateTime? Birthdate { get; set; }
        [ForeignKey("Trak")]
        public int? TrakID { get; set; }
        public List<GetAllTrackVM>? Traks { get; set; }
    }
}
