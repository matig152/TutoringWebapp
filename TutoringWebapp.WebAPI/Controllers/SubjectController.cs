using Microsoft.AspNetCore.Mvc;
using TutoringWebapp.Application.Services;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubjectDto>> Get()
        {
            var result = _subjectService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<SubjectDto> GetById(int id)
        {
            var result = _subjectService.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<int> Create(CreateSubjectDto dto)
        {
            var id = _subjectService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, SubjectDto dto)
        {
            var success = _subjectService.Update(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var success = _subjectService.Delete(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
