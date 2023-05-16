using LibraryApi.Models.Dto.WriterDto;
using LibraryApi.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetWriter()
        {
            MyContext context = new MyContext();

            List<GetAllWritersResponseDto> writer = new List<GetAllWritersResponseDto>();

            writer = context.Writers.Select(x => new GetAllWritersResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                SurName = x.SurName,
                Description = x.Description,

            }).ToList();

            return Ok(writer);

        }
        [HttpPost]

        public IActionResult AddRequestRepost(AddNewWriterRequestDtos writerrequest)
        {
            MyContext context = new MyContext();
         
            Writer writer = new Writer();
            writer.SurName = writerrequest.SurName;
            writer.Description = writerrequest.Description;
            writer.Name = writerrequest.Name;

            context.Writers.Add(writer);
            context.SaveChanges();



            //List<AddNewWriterResponseDto> writers = context.Writers.Select(x => new AddNewWriterResponseDto()
            //{
            //    Name = x.Name,
            //    Id = x.Id,
                
                

            //}).ToList();

            return Ok(writer);

        }
        [HttpGet("{id}")]

        public IActionResult GetWriterById(int id)
        {
            MyContext context = new MyContext();
            Writer writers = context.Writers.FirstOrDefault(x => x.Id == id);

            if (writers == null)
            {
                return NotFound(id + " No'lu id veri tabanında bulunamamıştır.");
            }else
            {
                GetWriterByIdResponseDto ResponseWriter = new GetWriterByIdResponseDto();
                ResponseWriter.Name = writers.Name;
                ResponseWriter.SurName = writers.SurName;

                return Ok(ResponseWriter);

            }
           
        }
        [HttpDelete]

        public IActionResult DeleteWriterById(int id)
        {
            MyContext context = new MyContext();
            Writer writers = context.Writers.FirstOrDefault(x=>x.Id == id);

            if (writers == null)
            {

                return NotFound(id + " No'lu id veritabanında bulunamamıştır.");

            }else
            {
                context.Writers.Remove(writers);
                context.SaveChanges();
                return Ok();
            }



        }




    }
}