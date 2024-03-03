using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraininingSystem.BLL.Feature.Interface;
using TraininingSystem.BLL.Mapping;
using TraininingSystem.BLL.ModelVM.CourseVM;
using TraininingSystem.DAL.Entity;

namespace TraininingSystem.PLL.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseRepo courseRepo;

        private readonly IMapper Mapper;

        public ITraineeRepo TraineeRepo { get; }

        public CourseController(ICourseRepo courseRepo, IMapper mapper,ITraineeRepo traineeRepo)
        {
            this.courseRepo=courseRepo;
            Mapper=mapper;
            TraineeRepo=traineeRepo;
        }
        public IActionResult Index()
        {
            return View(courseRepo.getAllCourseVMs());
        }
        public IActionResult Delete(int id)
        {
            if (id !=0 &&id !=null)
            {
                courseRepo.Delete(id);
                return RedirectToAction("Index", "Course");

            }
            return NotFound();
        }

        public IActionResult getById(int id)
        {
            return View(courseRepo.getbyId(id));
        }
        [HttpGet]
        public IActionResult Create()
        {

            var trainers = TraineeRepo.GetAll();
            ViewBag.Trainers = new SelectList(trainers, "ID", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatCourseVM creatCourseVM)
        {
            if(ModelState.IsValid)
            {
                courseRepo.Create(creatCourseVM);
                return RedirectToAction("Index", "Course");
            }

            ViewBag.Trainers = TraineeRepo.GetAll();
            return View(creatCourseVM);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var trainers = TraineeRepo.GetAll();
            ViewBag.Trainers = new SelectList(trainers, "ID", "Name");
            var course = Mapper.Map<EditCourseVM>(courseRepo.getbyId(id));
            return View(course);
        }
        [HttpPost]
        public IActionResult Edit(EditCourseVM editCourseVM)
        {
            if (ModelState.IsValid)
            {
                courseRepo.Edit(editCourseVM);
                return RedirectToAction("Index", "Course");
            }
            var trainers = TraineeRepo.GetAll();

            ViewBag.Trainers = new SelectList(trainers, "ID", "Name");
            return View(editCourseVM);
        }
    }
}
