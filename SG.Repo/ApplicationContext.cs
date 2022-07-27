using Microsoft.EntityFrameworkCore;
using SG.Data.Entities;
using SG.Data.Entities.SG.Data.Entities;

namespace SG.Repo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<ContentCreatorModel>? ContentCreatorModels { get; set; }
        public DbSet<InternModel>? InternModels { get; set; }
        public DbSet<UploadModel>? UploadModels { get; set; }
        public DbSet<LearningMaterialModel> LearningMaterialModels { get; set; }


    }
}