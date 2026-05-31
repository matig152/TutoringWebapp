using Microsoft.AspNetCore.Mvc;
using TutoringWebapp.Application.Services;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutorAvailabilityController : Controller
    {
        private readonly ITutorAvailabilityService _tutorAvailabilityService;

        public TutorAvailabilityController(ITutorAvailabilityService tutorAvailabilityService)
        {
            _tutorAvailabilityService = tutorAvailabilityService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TutorAvailabilityDto>> Get()
        {
            var result = _tutorAvailabilityService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<TutorAvailabilityDto> GetById(Guid id)
        {
            var result = _tutorAvailabilityService.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Guid> Create(CreateTutorAvailabilityDto dto)
        {
            var id = _tutorAvailabilityService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, TutorAvailabilityDto dto)
        {
            var success = _tutorAvailabilityService.Update(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var success = _tutorAvailabilityService.Delete(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
