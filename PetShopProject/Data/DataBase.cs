using Microsoft.EntityFrameworkCore;
using PetShopProject.Models;

namespace PetShopProject.Data
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions<DataBase> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }

        private InitializeData initData = new InitializeData();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<byte[]> imagesData = initData.AnimalImages();

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = initData.categoryNames[0] },
                new Category { CategoryId = 2, Name = initData.categoryNames[1] },
                new Category { CategoryId = 3, Name = initData.categoryNames[2] },
                new Category { CategoryId = 4, Name = initData.categoryNames[3] },
                new Category { CategoryId = 5, Name = initData.categoryNames[4] }
            );
            modelBuilder.Entity<Animal>().HasData(
                new Animal
                { AnimalId = 1, Name = initData.animalNames[0], Age = initData.animalAges[0], PictureName = imagesData[0], Description = initData.animalDescriptions[0], CategoryId = initData.animalCategories[0] },

                new Animal
                { AnimalId = 2, Name = initData.animalNames[1], Age = initData.animalAges[1], PictureName = imagesData[1], Description = initData.animalDescriptions[1], CategoryId = initData.animalCategories[1] },

                new Animal
                { AnimalId = 3, Name = initData.animalNames[2], Age = initData.animalAges[2], PictureName = imagesData[2], Description = initData.animalDescriptions[2], CategoryId = initData.animalCategories[2] },

                new Animal
                { AnimalId = 4, Name = initData.animalNames[3], Age = initData.animalAges[3], PictureName = imagesData[3], Description = initData.animalDescriptions[3], CategoryId = initData.animalCategories[3] },

                new Animal
                { AnimalId = 5, Name = initData.animalNames[4], Age = initData.animalAges[4], PictureName = imagesData[4], Description = initData.animalDescriptions[4], CategoryId = initData.animalCategories[4] },

                new Animal
                { AnimalId = 6, Name = initData.animalNames[5], Age = initData.animalAges[5], PictureName = imagesData[5], Description = initData.animalDescriptions[5], CategoryId = initData.animalCategories[5] },

                new Animal
                { AnimalId = 7, Name = initData.animalNames[6], Age = initData.animalAges[6], PictureName = imagesData[6], Description = initData.animalDescriptions[6], CategoryId = initData.animalCategories[6] },

                new Animal
                { AnimalId = 8, Name = initData.animalNames[7], Age = initData.animalAges[7], PictureName = imagesData[7], Description = initData.animalDescriptions[7], CategoryId = initData.animalCategories[7] },

                new Animal
                { AnimalId = 9, Name = initData.animalNames[8], Age = initData.animalAges[8], PictureName = imagesData[8], Description = initData.animalDescriptions[8], CategoryId = initData.animalCategories[8] },

                new Animal
                { AnimalId = 10, Name = initData.animalNames[9], Age = initData.animalAges[9], PictureName = imagesData[9], Description = initData.animalDescriptions[9], CategoryId = initData.animalCategories[9] },

                new Animal
                { AnimalId = 11, Name = initData.animalNames[10], Age = initData.animalAges[10], PictureName = imagesData[10], Description = initData.animalDescriptions[10], CategoryId = initData.animalCategories[10] },

                new Animal
                { AnimalId = 12, Name = initData.animalNames[11], Age = initData.animalAges[11], PictureName = imagesData[11], Description = initData.animalDescriptions[11], CategoryId = initData.animalCategories[11] },

                new Animal
                { AnimalId = 13, Name = initData.animalNames[12], Age = initData.animalAges[12], PictureName = imagesData[12], Description = initData.animalDescriptions[12], CategoryId = initData.animalCategories[12] },

                new Animal
                { AnimalId = 14, Name = initData.animalNames[13], Age = initData.animalAges[13], PictureName = imagesData[13], Description = initData.animalDescriptions[13], CategoryId = initData.animalCategories[13] },

                new Animal
                { AnimalId = 15, Name = initData.animalNames[14], Age = initData.animalAges[14], PictureName = imagesData[14], Description = initData.animalDescriptions[14], CategoryId = initData.animalCategories[14] }


            );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1, CommentText = initData.commentsText[0], AnimalId = initData.commentsAnimalIds[0] },
                new Comment { CommentId = 2, CommentText = initData.commentsText[1], AnimalId = initData.commentsAnimalIds[1] },
                new Comment { CommentId = 3, CommentText = initData.commentsText[2], AnimalId = initData.commentsAnimalIds[2] },
                new Comment { CommentId = 4, CommentText = initData.commentsText[3], AnimalId = initData.commentsAnimalIds[3] },
                new Comment { CommentId = 5, CommentText = initData.commentsText[4], AnimalId = initData.commentsAnimalIds[4] },
                new Comment { CommentId = 6, CommentText = initData.commentsText[5], AnimalId = initData.commentsAnimalIds[5] },
                new Comment { CommentId = 7, CommentText = initData.commentsText[6], AnimalId = initData.commentsAnimalIds[6] },
                new Comment { CommentId = 8, CommentText = initData.commentsText[7], AnimalId = initData.commentsAnimalIds[7] },
                new Comment { CommentId = 9, CommentText = initData.commentsText[8], AnimalId = initData.commentsAnimalIds[8] },
                new Comment { CommentId = 10, CommentText = initData.commentsText[9], AnimalId = initData.commentsAnimalIds[9] },
                new Comment { CommentId = 11, CommentText = initData.commentsText[10], AnimalId = initData.commentsAnimalIds[10] },
                new Comment { CommentId = 12, CommentText = initData.commentsText[11], AnimalId = initData.commentsAnimalIds[11] },
                new Comment { CommentId = 13, CommentText = initData.commentsText[12], AnimalId = initData.commentsAnimalIds[12] },
                new Comment { CommentId = 14, CommentText = initData.commentsText[13], AnimalId = initData.commentsAnimalIds[13] },
                new Comment { CommentId = 15, CommentText = initData.commentsText[14], AnimalId = initData.commentsAnimalIds[14] },
                new Comment { CommentId = 16, CommentText = initData.commentsText[15], AnimalId = initData.commentsAnimalIds[15] },
                new Comment { CommentId = 17, CommentText = initData.commentsText[16], AnimalId = initData.commentsAnimalIds[16] },
                new Comment { CommentId = 18, CommentText = initData.commentsText[17], AnimalId = initData.commentsAnimalIds[17] },
                new Comment { CommentId = 19, CommentText = initData.commentsText[18], AnimalId = initData.commentsAnimalIds[18] },
                new Comment { CommentId = 20, CommentText = initData.commentsText[19], AnimalId = initData.commentsAnimalIds[19] },
                new Comment { CommentId = 21, CommentText = initData.commentsText[20], AnimalId = initData.commentsAnimalIds[20] },
                new Comment { CommentId = 22, CommentText = initData.commentsText[21], AnimalId = initData.commentsAnimalIds[21] },
                new Comment { CommentId = 23, CommentText = initData.commentsText[22], AnimalId = initData.commentsAnimalIds[22] },
                new Comment { CommentId = 24, CommentText = initData.commentsText[23], AnimalId = initData.commentsAnimalIds[23] },
                new Comment { CommentId = 25, CommentText = initData.commentsText[24], AnimalId = initData.commentsAnimalIds[24] },
                new Comment { CommentId = 26, CommentText = initData.commentsText[25], AnimalId = initData.commentsAnimalIds[25] },
                new Comment { CommentId = 27, CommentText = initData.commentsText[26], AnimalId = initData.commentsAnimalIds[26] },
                new Comment { CommentId = 28, CommentText = initData.commentsText[27], AnimalId = initData.commentsAnimalIds[27] },
                new Comment { CommentId = 29, CommentText = initData.commentsText[28], AnimalId = initData.commentsAnimalIds[28] },
                new Comment { CommentId = 30, CommentText = initData.commentsText[29], AnimalId = initData.commentsAnimalIds[29] },
                new Comment { CommentId = 31, CommentText = initData.commentsText[30], AnimalId = initData.commentsAnimalIds[30] },
                new Comment { CommentId = 32, CommentText = initData.commentsText[31], AnimalId = initData.commentsAnimalIds[31] },
                new Comment { CommentId = 33, CommentText = initData.commentsText[32], AnimalId = initData.commentsAnimalIds[32] },
                new Comment { CommentId = 34, CommentText = initData.commentsText[33], AnimalId = initData.commentsAnimalIds[33] }
            );
        }
    }
}
