using Microsoft.AspNetCore.Mvc;
using EventManagementDB.DOMAIN.Core.Interfaces;
using EventManagementDB.DOMAIN.Core.Entities;

namespace EventManagementDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private readonly IAttendeesRepository _repository;

        public AttendeesController(IAttendeesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendees>>> GetAttendees()
        {
            return Ok(await _repository.GetAttendees());
        }

        [HttpPost]
        public async Task<ActionResult<Attendees>> CreateAttendee(Attendees attendee)
        {
            var id = await _repository.Insert(attendee);
            return CreatedAtAction(nameof(_repository.GetById), new { id }, attendee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAttendee(int id)
        {
            return await _repository.Delete(id);
        }
    }
}