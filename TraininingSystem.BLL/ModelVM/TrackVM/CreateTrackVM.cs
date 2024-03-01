using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraininingSystem.BLL.ModelVM.TrackVM
{
    public class CreateTrackVM
    {
        [Required]
        [MinLength(2,ErrorMessage ="Min letter 2")]
        public string Name { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Max letter 200")]
        public string Description { get; set; }

    }
}
