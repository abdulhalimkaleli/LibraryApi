using LibraryApi.Models.Dto.BookDto;
using LibraryApi.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IActionResult ButunKitaplar()
        {
            MyContext context = new MyContext();
            List<BookGetAllBooksResponseDto> books = new List<BookGetAllBooksResponseDto>();

            books = context.Books.Select(x => new BookGetAllBooksResponseDto()
            {
                Id=x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();

            return Ok(books);

        }
        [HttpPost]

        public IActionResult AddRequest(BookAddNewBookRequestDtos girilenveritipi)
        {
            MyContext context = new MyContext();

            Book book = new Book();

            book.Name = girilenveritipi.Name;
            book.Description = girilenveritipi.Description;
            book.PublishDate = girilenveritipi.PublishDate;

            context.Books.Add(book);
            context.SaveChanges();


            List<BookAddNewBookResponseDto> books = context.Books.Select(x => new BookAddNewBookResponseDto()
            {
                Name = x.Name,
                Description = x.Description,
                PublishDate = x.PublishDate,
                Id = x.Id

            }).ToList();

            return Ok(books);

        }

        [HttpGet ("{id}")]

        public IActionResult GetBookById(int id) {

            MyContext context = new MyContext();
            Book book = context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound(id + " No'lu id veri tabanında  bulunamamıştır.");
            }else
            {
                BookGetBookByIdResponseDto ResponseBook = new BookGetBookByIdResponseDto();

                ResponseBook.Name = book.Name;
                ResponseBook.Description = book.Description;
                ResponseBook.Id = book.Id;

                return Ok(ResponseBook);
              
            }


        
        }

        [HttpDelete]

        public IActionResult DeleteBookById(int id)
        {
            MyContext context = new MyContext();
            Book book = context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound(id + " No'lu id veri tabanında  bulunamamıştır.");

            }else
            {
                context.Books.Remove(book);
                context.SaveChanges();
                return Ok();

            }


        }

    }
}
