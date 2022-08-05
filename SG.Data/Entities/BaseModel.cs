namespace SG.Data.Entities
{
    public class BaseModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}
