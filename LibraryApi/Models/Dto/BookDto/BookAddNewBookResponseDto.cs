namespace LibraryApi.Models.Dto.BookDto
{
    public class BookAddNewBookResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
