using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SG.Data.Entities
{
    public class LearningMaterialModel : BaseModel
    {
        [ForeignKey("UploadId")]
        public Guid UploadModelId { get; set; }
        [JsonIgnore]
        public UploadModel? Uploadmodel { get; set; }

        [ForeignKey("InternId")]
        public Guid InternId { get; set; }
        [JsonIgnore]
        public InternModel? InternModel { get; set; }
        public string? WorkEmail { get; set; }
        public bool IsChecked { get; set; }
    }

}
