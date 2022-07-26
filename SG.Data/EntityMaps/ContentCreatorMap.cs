using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SG.Data.Entities.SG.Data.Entities;

namespace SG.Data.EntityMaps
{
    public class ContentCreatorMap
    {
        public ContentCreatorMap(EntityTypeBuilder<ContentCreatorModel> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.WorkEmail).IsRequired();
            entityBuilder.Property(t => t.Department).IsRequired();
            entityBuilder.Property(t => t.Role).IsRequired();
            entityBuilder.Property(t => t.DateAdded).IsRequired();
            entityBuilder.Property(t => t.DateModified).IsRequired();
        }
    }
}
