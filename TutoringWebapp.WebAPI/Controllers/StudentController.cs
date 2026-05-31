using Microsoft.AspNetCore.Mvc;
using TutoringWebapp.SharedKernel.Dto;
using TutoringWebapp.Application.Services;

namespace TutoringWebapp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> Get()
        {
            var result = _studentService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDto> GetById(Guid id)
        {
            var result = _studentService.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Guid> Create(CreateStudentDto dto)
        {
            var id = _studentService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, StudentDto dto)
        {
            var success = _studentService.Update(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var success = _studentService.Delete(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
