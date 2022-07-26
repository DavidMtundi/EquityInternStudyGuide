using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SG.Data.Entities;

namespace SG.Data.EntityMaps
{
    public class LearningMaterialMap
    {
        public LearningMaterialMap(EntityTypeBuilder<LearningMaterialModel> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.IsChecked);
            entityBuilder.Property(t => t.DateAdded).IsRequired();
            entityBuilder.Property(t => t.DateModified).IsRequired();
            entityBuilder.Property(t => t.WorkEmail).IsRequired();
            entityBuilder.HasOne(t => t.Uploadmodel).WithOne(u => u.LearningMaterial).HasForeignKey<UploadModel>(x => x.Id).IsRequired();

        }
    }
}
