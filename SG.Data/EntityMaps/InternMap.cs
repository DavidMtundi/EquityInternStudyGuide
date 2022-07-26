using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SG.Data.Entities;

namespace SG.Data.EntityMaps
{
    public class InternMap
    {
        public InternMap(EntityTypeBuilder<InternModel> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.DateAdded).IsRequired();
            entityBuilder.Property(t => t.DateModified).IsRequired();
            entityBuilder.Property(t => t.PFNumber).IsRequired();
            entityBuilder.Property(t => t.Department).IsRequired();
            entityBuilder.Property(t => t.WorkEmail).IsRequired();


        }
    }
}
