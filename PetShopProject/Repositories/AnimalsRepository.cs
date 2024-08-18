using Microsoft.EntityFrameworkCore;
using PetShopProject.Data;
using PetShopProject.Models;

namespace PetShopProject.Repositories
{
    public class AnimalsRepository : IRepository<Animal>
    {
        private readonly DataBase database;

        public AnimalsRepository(DataBase dataBase)
        {
            database = dataBase;
        }

        public void Add(Animal entity)
        {
            database.Animals.Add(entity);
            database.SaveChanges();
        }
        public void Delete(int id)
        {
            var animal = database.Animals.Find(id);
            if (animal != null)
            {
                database.Animals.Remove(animal);
                database.SaveChanges();
            }
        }

        public Animal? Get(int id)
        {
            return database.Animals
                .Include(a => a.Comments)
                .FirstOrDefault(a => a.AnimalId == id);
        }

        public IQueryable<Animal> GetAll()
        {
            return database.Animals
                .Include(a => a.Comments);
        }

        public void Update(Animal entity)
        {
            var existingAnimal = database.Animals.Find(entity.AnimalId);
            if (existingAnimal != null)
            {
                existingAnimal.Name = entity.Name;
                existingAnimal.Age = entity.Age;
                existingAnimal.PictureName = entity.PictureName;
                existingAnimal.Description = entity.Description;
                existingAnimal.CategoryId = entity.CategoryId;
                database.SaveChanges();
            }
        }
    }
}
