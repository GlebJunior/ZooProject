using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopProject.Models;
using PetShopProject.Repositories;

namespace PetShopProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnimalsRepository _animalsRepository;
        private readonly CommentsRepository _commentsRepository;

        public HomeController(AnimalsRepository animalsRepository, CommentsRepository commentsRepository)
        {
            _animalsRepository = animalsRepository;
            _commentsRepository = commentsRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Animal> TopTwoAnimals = _animalsRepository.GetAll()
                .AsNoTracking()
                .ToList()
                .OrderByDescending(x => x.Comments?.Count)
                .Take(2);
            var AnimalsPictures = TopTwoAnimals.Select(animal => new
            {
                animal.AnimalId,
                PictureBase64 = Convert.ToBase64String(animal.PictureName!)
            });
            var AnimalsAndPictures = TopTwoAnimals.Zip(AnimalsPictures, (animal, image) => new
            {
                Animal = animal,
                Image = image
            });
            ViewBag.animalsAndPictures = AnimalsAndPictures;
            return View();
        }
    }
}
