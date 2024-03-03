using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Diagnostics;
using TraininingSystem.BLL.ModelVM.AccountVM;
using TraininingSystem.DAL.Entity;

namespace TraininingSystem.PLL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }




        #region Registration

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {

            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                IsAgree = model.IsAgree,
                FullName = model.FullName
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);
        }


        #endregion


        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {

            var userName = await userManager.FindByNameAsync(model.UserName);
            var userEmail = await userManager.FindByEmailAsync(model.Email);

            dynamic result;

            if (userEmail != null)
            {
                result = await signInManager.PasswordSignInAsync(userEmail, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Track");
                }

            }
            else if(userName !=null)
            {
                result = await signInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Track");
                }

            }

           
            else
            {
                ModelState.AddModelError("", "Invalid UserName Or Password");

            }

            return View(model);
        }

        #endregion


        #region Sign Out

        [HttpGet]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        #endregion


        #region Forget Password

        public IActionResult ForgetPassword()
        {
            ViewBag.Massage=null;

            return View();
        }

      

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {

                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                model.Password =user.PasswordHash;
                ViewBag.Massage="Done";
                return View(model);
            }
            ViewBag.Massage="Email not true";

            return View(model);
        }

        #endregion



       
    }
}
