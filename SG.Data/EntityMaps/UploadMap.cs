using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SG.Data.Entities;
using SG.Data.Entities.SG.Data.Entities;

namespace SG.Data.EntityMaps
{
    public class UploadMap
    {
        public UploadMap(EntityTypeBuilder<UploadModel> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.DateAdded).IsRequired();
            entityBuilder.Property(t => t.DateModified).IsRequired();
            entityBuilder.Property(t => t.Title).IsRequired();
            entityBuilder.Property(t => t.Department).IsRequired();
            entityBuilder.Property(t => t.Content).IsRequired();
            entityBuilder.Property(t => t.Summary).IsRequired();
            entityBuilder.Property(t => t.Duration).IsRequired();
            entityBuilder.HasOne(t => t.ContentCreator).WithOne(u => u.Uploadmodel).HasForeignKey<ContentCreatorModel>(x => x.Id).IsRequired();

        }
    }
}
