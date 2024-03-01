using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraininingSystem.BLL.Feature.Interface;
using TraininingSystem.BLL.ModelVM.TrackVM;
using TraininingSystem.BLL.ModelVM.TraineeVM;

namespace TraininingSystem.PLL.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepo trainRepo;

        private readonly IMapper Mapper;
        private readonly ITrackRepo trackRepo;

        public TraineeController(ITraineeRepo trainRepo, IMapper mapper,ITrackRepo trackRepo)
        {
            this.trainRepo=trainRepo;
            Mapper=mapper;
            this.trackRepo=trackRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(trainRepo.GetAll());
        }
        [HttpGet]

        public IActionResult getById(int id)
        {
            return View(trainRepo.GetById(id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateTraineWithTracksVM createTraineWithTracksVM = new CreateTraineWithTracksVM();
            createTraineWithTracksVM.Traks = trackRepo.GetAll();
            return View(createTraineWithTracksVM);
        }

        [HttpPost]
        public IActionResult Create(CreateTraineWithTracksVM createTrackVM)
        {
            if (ModelState.IsValid)
            {
                var Data = Mapper.Map<CreateTraineVM>(createTrackVM);
                trainRepo.Create(Data);
                return RedirectToAction("Index", "Trainee");
            }
            createTrackVM.Traks = trackRepo.GetAll();

            return View(createTrackVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Data = Mapper.Map<EditTraineWithTracksVM>(trainRepo.GetById(id));
            Data.Traks = trackRepo.GetAll();


            return View(Data);
        }

        [HttpPost]
        public IActionResult Edit(EditTraineWithTracksVM editTrackVM)
        {
            if (ModelState.IsValid)
            {
                trainRepo.Edit(editTrackVM);
                return RedirectToAction("Index", "Trainee");
            }
            return View(editTrackVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id !=0 &&id !=null)
            {
                trainRepo.Delete(id);
                return RedirectToAction("Index", "Trainee");

            }
            return NotFound();
        }
    }
}
