using DogsApp.Infrastructure.Data;
using DogsApp.Infrastructure.Data.Domain;
using DogsApp.Models.Dog;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogsApp.Controllers
{
    public class DogController : Controller
    {
        private readonly ApplicationDbContext _context;
            public DogController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Dogs
        public ActionResult Index()
        {
            List<DogAllViewModel> dogs = _context.Dogs.Select(x => new DogAllViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age,
                Breed = x.Breed,
                Pictures = x.Picture
            }).ToList();
            return View(dogs);
        }

        // GET: Dogs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dogFromDb = new Dog
                {
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Picture = bindingModel.Pictures

                };
                _context.Dogs.Add(dogFromDb);
                _context.SaveChanges();

                return RedirectToAction("Success");
            }
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }
        // GET: Dogs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dogs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dogs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
