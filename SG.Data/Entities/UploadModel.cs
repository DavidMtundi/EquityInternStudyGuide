using SG.Data.Entities.SG.Data.Entities;
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
        [JsonIgnore]
        public virtual ContentCreatorModel? ContentCreator { get; set; }
        [JsonIgnore]
        public virtual LearningMaterialModel? LearningMaterial { get; set; }
    }
}
