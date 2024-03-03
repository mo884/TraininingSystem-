using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraininingSystem.BLL.ModelVM.AccountVM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "invalid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Name Required")]
        [MaxLength(50, ErrorMessage = "Min Len 50")]
        public string UserName { get; set; }

        [MinLength(6, ErrorMessage = "Min len 6")]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
