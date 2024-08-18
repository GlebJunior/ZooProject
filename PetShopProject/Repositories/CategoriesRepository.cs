using PetShopProject.Data;
using PetShopProject.Models;
namespace PetShopProject.Repositories
{
    public class CategoriesRepository : IRepository<Category>
    {
        private readonly DataBase database;

        public CategoriesRepository(DataBase dataBase)
        {
            database = dataBase;
        }

        public void Add(Category entity)
        {
            database.Categories.Add(entity);
            database.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = database.Categories.Find(id);
            if (category != null)
            {
                database.Categories.Remove(category);
                database.SaveChanges();
            }
        }

        public Category? Get(int id)
        {
            return database.Categories
                .FirstOrDefault(c => c.CategoryId == id);
        }

        public IQueryable<Category> GetAll()
        {
            return database.Categories;
        }

        public void Update(Category entity)
        {
            var existingCategory = database.Categories.Find(entity.CategoryId);
            if (existingCategory != null)
            {
                existingCategory.Name = entity.Name;
                database.SaveChanges();
            }
        }
    }
}
