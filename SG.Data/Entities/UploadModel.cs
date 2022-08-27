using Newtonsoft.Json;
using SG.Data.Entities.SG.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SG.Data.Entities
{
    public class UploadModel : BaseModel
    {
        public string? Title { get; set; }
        public string? Department { get; set; }
        //  public List<string>? Content { get; set; }
        public string? Summary { get; set; }
        public double Duration { get; set; }
        [ForeignKey("ContentCreatorId")]
        public Guid ContentCreatorId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public ContentCreatorModel? ContentCreator { get; set; }
        public string? ContentCreatorName { get; set; }

        [NotMapped]
        public List<String>? Content
        {
            get;
            set;
        }
        [System.Text.Json.Serialization.JsonIgnore]
        public string Contents
        {
            get
            {
                if (Content == null)
                {
                    Content = new List<String>();
                }
                return JsonConvert.SerializeObject(Content);
            }
            set
            {
                Content = JsonConvert.DeserializeObject<List<String>>(value)!;
            }
        }


    }
}
