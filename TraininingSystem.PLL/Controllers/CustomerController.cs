using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TraininingSystem.BLL.Feature.Interface;
using TraininingSystem.BLL.ModelVM.CustomerVM;
using TraininingSystem.PLL.Models;

namespace TraininingSystem.PLL.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo CustomerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            
            CustomerRepo=customerRepo;
        }

        public IActionResult Index()
        {
            return View(CustomerRepo.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerVM customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepo.create(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = CustomerRepo.getById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(CustomerVM customer)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    CustomerRepo.update(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Details(int id)
        {
            var customer = CustomerRepo.getById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

      
        [HttpGet]
        public IActionResult Delete(int id)
        {
            CustomerRepo.delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            var customer = CustomerRepo.getById(id);
            return customer != null;
        }


    }
}
