namespace LibraryApi.Models.Dto.WriterDto
{
    public class GetAllWritersResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string? Description { get; set; }

    }
}
