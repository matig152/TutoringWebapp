using Microsoft.AspNetCore.Mvc;
using TutoringWebapp.Application.Services;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutorController : Controller
    {
        private readonly ITutorService _tutorService;

        public TutorController(ITutorService tutorService)
        {
            _tutorService = tutorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TutorDto>> Get()
        {
            var result = _tutorService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<TutorDto> GetById(Guid id)
        {
            var result = _tutorService.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Guid> Create(CreateTutorDto dto)
        {
            var id = _tutorService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, TutorDto dto)
        {
            var success = _tutorService.Update(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var success = _tutorService.Delete(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
