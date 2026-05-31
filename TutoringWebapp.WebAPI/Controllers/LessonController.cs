using Microsoft.AspNetCore.Mvc;
using TutoringWebapp.Application.Services;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LessonDto>> Get()
        {
            var result = _lessonService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<LessonDto> GetById(Guid id)
        {
            var result = _lessonService.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Guid> Create(CreateLessonDto dto)
        {
            var id = _lessonService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, LessonDto dto)
        {
            var success = _lessonService.Update(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var success = _lessonService.Delete(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
