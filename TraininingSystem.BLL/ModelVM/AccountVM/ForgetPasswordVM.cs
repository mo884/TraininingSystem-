using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraininingSystem.BLL.ModelVM.AccountVM
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "invalid email")]
        public string Email { get; set; }
        public string? Password { get; set; }
    }
}
