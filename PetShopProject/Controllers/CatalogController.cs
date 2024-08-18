using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopProject.Models;
using PetShopProject.Repositories;

namespace PetShopProject.Controllers
{
    public class CatalogController : Controller
    {
        private readonly AnimalsRepository _animalsRepository;
        private readonly CategoriesRepository _categoriesRepository;
        private readonly CommentsRepository _commentsRepository;
        public CatalogController(AnimalsRepository animalsRepository, CategoriesRepository categoriesRepository, CommentsRepository commentsRepository)
        {
            _animalsRepository = animalsRepository;
            _categoriesRepository = categoriesRepository;
            _commentsRepository = commentsRepository;
        }

        [Route("Catalog/{animalId?}")]
        public IActionResult Index(string? animalId, int? categoryId)
        {
            if (int.TryParse(animalId, out int id) && id > 0)
            {
                var animal = _animalsRepository.Get(id);
                if (animal == null)
                {
                    GetAnimalsById(categoryId);
                    return View();
                }
                else
                {
                    ViewBag.animalImage = Convert.ToBase64String(animal.PictureName!);
                    Category animalCategory = _categoriesRepository.Get(animal.CategoryId)!;
                    ViewBag.categoryName = animalCategory.Name;
                    return View(animal);
                }
            }
            ViewBag.categories = _categoriesRepository.GetAll();
            GetAnimalsById(categoryId);
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(string commentBody, int animalId)
        {
            if(!string.IsNullOrEmpty(commentBody))
            {
                var comment = new Comment
                {
                    CommentText = commentBody,
                    AnimalId = animalId
                };
                _commentsRepository.Add(comment);
            }
            return RedirectToAction("Index", "Catalog", new { animalId });
        }

        private void GetAnimalsById(int? id)
        {
            ViewBag.selectedCategoryid = id ?? 1;
            id = ViewBag.selectedCategoryid;
            var allAnimals = _animalsRepository.GetAll()
                .AsNoTracking()
                .Where(a => a.CategoryId == id)
                .ToList();
            var AnimalsPictures = allAnimals.Select(animal => new
            {
                animal.AnimalId,
                PictureBase64 = Convert.ToBase64String(animal.PictureName!)
            });
            var AnimalsAndPictures = allAnimals.Zip(AnimalsPictures, (animal, image) => new
            {
                Animal = animal,
                Image = image
            }).ToList();
            ViewBag.animalsAndPictures = AnimalsAndPictures;
            ViewBag.animalId = 0;
		}
    }
}
