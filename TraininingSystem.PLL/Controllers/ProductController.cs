using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraininingSystem.BLL.Feature.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TraininingSystem.BLL.Feature.Reposoratory;
using TraininingSystem.BLL.ModelVM.ProductVM;
using TraininingSystem.BLL.ModelVM.TrackVM;
using TraininingSystem.Helper;
using Microsoft.AspNetCore.Authorization;

namespace TraininingSystem.PLL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo productRepo;
        private readonly ICustomerRepo customerRepo;

        public ProductController(IProductRepo productRepo,ICustomerRepo customerRepo)
        {
            this.productRepo=productRepo;
            this.customerRepo=customerRepo;
        }
        public IActionResult Index()
        {
            return View(productRepo.getAll());
        }

        public IActionResult Search(string name)
        {
            return View(productRepo.GetByName(name));
        }
        [Authorize]
        public IActionResult Create()
        {
            var Data = customerRepo.GetAll();
            ViewBag.Customer = new SelectList(Data, "ID", "Name");

            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(ProductVM createProductVM)
        {
            if (ModelState.IsValid)
            {
                createProductVM.Image = FileUploader.UploadFile("files", createProductVM.ImageFile);
                productRepo.Create(createProductVM);
                return RedirectToAction("Index", "Product");
            }
            var Data = customerRepo.GetAll();
            ViewBag.Customer = new SelectList(Data, "ID", "Name");
            return View(createProductVM);
        }
        [Authorize]
        public IActionResult Edit(int id)
    {
        var Data = customerRepo.GetAll();
        ViewBag.Customer = new SelectList(Data, "ID", "Name");

        return View(productRepo.GetProductById(id));
    }
        [Authorize]
        [HttpPost]
    public IActionResult Edit(ProductVM editProductVM)
    {
        if (ModelState.IsValid)
        {
            editProductVM.Image = FileUploader.UploadFile("files", editProductVM.ImageFile);
            productRepo.Edit(editProductVM);
            return RedirectToAction("Index", "Product");
        }
        var Data = customerRepo.GetAll();
        ViewBag.Customer = new SelectList(Data, "ID", "Name");
        return View(editProductVM);
    }

        [Authorize]
        public IActionResult Select(int id)
        {
            var Data = productRepo.GetProductById(id);
            return View(Data);
        }

        public IActionResult Delete(int id)
        {
            productRepo.Delete(id);
            return RedirectToAction("Index", "Product");
        }
    }
}
