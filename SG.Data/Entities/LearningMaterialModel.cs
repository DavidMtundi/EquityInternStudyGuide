namespace SG.Data.Entities
{
    public class LearningMaterialModel : BaseModel
    {
        //[ForeignKey("UploadId")]
        //public Guid UploadId { get; set; }
        // [JsonIgnore]
        public UploadModel? Uploadmodel { get; set; }
        public string? WorkEmail { get; set; }
        public bool IsChecked { get; set; }
    }

}
