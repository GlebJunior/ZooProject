using Microsoft.EntityFrameworkCore;
using PetShopProject.Data;
using PetShopProject.Models;

namespace PetShopProject.Repositories
{
    public class CommentsRepository : IRepository<Comment>
    {
        private readonly DataBase database;

        public CommentsRepository(DataBase dataBase)
        {
            database = dataBase;
        }

        public void Add(Comment entity)
        {
            database.Comments.Add(entity);
            database.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = database.Comments.Find(id);
            if (comment != null)
            {
                database.Comments.Remove(comment);
                database.SaveChanges();
            }
        }

        public Comment? Get(int id)
        {
            return database.Comments
                .Include(c => c.AnimalId)
                .FirstOrDefault(c => c.CommentId == id);
        }

        public IQueryable<Comment> GetAll()
        {
            return database.Comments
                .Include(c => c.AnimalId);
        }

        public void Update(Comment entity)
        {
            var existingComment = database.Comments.Find(entity.CommentId);
            if (existingComment != null)
            {
                existingComment.AnimalId = entity.AnimalId;
                existingComment.CommentText = entity.CommentText;
                database.SaveChanges();
            }
        }
    }
}
