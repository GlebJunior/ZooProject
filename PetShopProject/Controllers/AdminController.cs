using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopProject.Models;
using PetShopProject.Repositories;
using System.Security.Claims;

namespace PetShopProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly AnimalsRepository _animalsRepository;
        private readonly CategoriesRepository _categoriesRepository;




        public AdminController(AnimalsRepository animalsRepository, CategoriesRepository categoriesRepository)
        {
            _animalsRepository = animalsRepository;
            _categoriesRepository = categoriesRepository;
        }



        [Route("LoginPage")]
        public IActionResult LoginPage(string state) 
        {

            if (state == "Failure")
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Redirect("/LoginPage");
            }
            if(user.UserName == "admin" && user.Password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var identity = new ClaimsIdentity(claims, "AuthCookie");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                var authProperties = new AuthenticationProperties();
                authProperties.IsPersistent = false;
                await HttpContext.SignInAsync("AuthCookie", claimsPrincipal, authProperties);
                return Redirect("/Admin");
            }
            else if(user.UserName == "user" && user.Password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "User")
                };
                var identity = new ClaimsIdentity(claims, "AuthCookie");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                var authProperties = new AuthenticationProperties();
                authProperties.IsPersistent = false;
                await HttpContext.SignInAsync("AuthCookie", claimsPrincipal, authProperties);
                return Redirect("/Home");

            }
            var errorString = "Failure";
            return Redirect($"/LoginPage?state={errorString}");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("AuthCookie");
            return Redirect("/Home");
        }

        [Authorize(Policy = "IsAdministrator")]
        public IActionResult Index(string? categoryId)
        {

            int.TryParse(categoryId, out int id);

            ViewBag.selectedCategoryId = id == 0 ? 1 : id;
            id = ViewBag.selectedCategoryId;
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
            ViewBag.categories = _categoriesRepository.GetAll();
            return View();
        }

        public IActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    using var memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);
                    animal.PictureName = memoryStream.ToArray();
                }
                _animalsRepository.Add(animal);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int animalId, int categoryId)
        {
            Animal? animal = _animalsRepository.Get(animalId);
            if(animal != null)
            {
                _animalsRepository.Delete(animalId);
            }
            return RedirectToAction("Index", "Admin", new { categoryId });
        }

        public IActionResult Edit(Animal animal)
        {
             Animal? _animal = _animalsRepository.Get(animal.AnimalId);
            if (_animal != null)
            {
                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files[0];
                    using var memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);
                    animal.PictureName = memoryStream.ToArray();
                }
                if (animal.PictureName.Length == 0)
                {
                    animal.PictureName = _animal.PictureName;
                }
                _animalsRepository.Update(animal);
            }
            return RedirectToAction("Index", "Admin", new { animal.CategoryId });
        }
    }
}
