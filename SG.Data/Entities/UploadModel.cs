using SG.Data.Entities.SG.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SG.Data.Entities
{
    public class UploadModel : BaseModel
    {
        public string? Title { get; set; }
        public string? Department { get; set; }
        public string? Content { get; set; }
        public string? Summary { get; set; }
        public double Duration { get; set; }
        [ForeignKey("ContentCreatorId")]
        public Guid ContentCreatorId { get; set; }
        [JsonIgnore]
        public ContentCreatorModel? ContentCreator { get; set; }

    }
}
