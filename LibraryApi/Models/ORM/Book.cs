namespace LibraryApi.Models.ORM
{
    public class Book:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
