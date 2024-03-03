using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraininingSystem.BLL.Feature.Interface;
using TraininingSystem.BLL.ModelVM.TrackVM;

namespace TraininingSystem.PLL.Controllers
{
    [Authorize]
    public class TrackController : Controller
    {
        private readonly ITrackRepo trackRepo;

        private readonly IMapper Mapper;

        public TrackController(ITrackRepo trackRepo,IMapper mapper)
        {
            this.trackRepo=trackRepo;
            Mapper=mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(trackRepo.GetAll());
        }
        public IActionResult getById(int id)
        {
            return View(trackRepo.GetById(id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTrackVM createTrackVM)
        {
           if(ModelState.IsValid)
           {
                trackRepo.Create(createTrackVM);
                return RedirectToAction("Index", "Track");
           }
           return View(createTrackVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Data = Mapper.Map<EditTrackVM>(trackRepo.GetById(id));
            return View(Data);
        }

        [HttpPost]
        public IActionResult Edit(EditTrackVM editTrackVM)
        {
            if (ModelState.IsValid)
            {
                trackRepo.Edit(editTrackVM);
                return RedirectToAction("Index", "Track");
            }
            return View(editTrackVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id !=0 &&id !=null)
            {
                trackRepo.Delete(id);
                return RedirectToAction("Index", "Track");

            }
            return NotFound();
        }
    }
}
