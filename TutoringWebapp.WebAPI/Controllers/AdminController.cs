using Microsoft.AspNetCore.Mvc;
using TutoringWebapp.Application.Services;
using TutoringWebapp.SharedKernel.Dto;

namespace TutoringWebapp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AdminDto>> Get()
        {
            var result = _adminService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<AdminDto> GetById(Guid id)
        {
            var result = _adminService.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Guid> Create(CreateAdminDto dto)
        {
            var id = _adminService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, AdminDto dto)
        {
            var success = _adminService.Update(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var success = _adminService.Delete(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
