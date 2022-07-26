using Microsoft.EntityFrameworkCore;
using SG.Data.Entities;
using SG.Data.Entities.SG.Data.Entities;
using SG.Data.EntityMaps;

namespace SG.Repo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ContentCreatorMap(modelBuilder.Entity<ContentCreatorModel>());
            new LearningMaterialMap(modelBuilder.Entity<LearningMaterialModel>());
            new InternMap(modelBuilder.Entity<InternModel>());
            new UploadMap(modelBuilder.Entity<UploadModel>());
        }


    }
}