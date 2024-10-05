using EventManagementDB.DOMAIN.Core.Entities;
using EventManagementDB.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _22200136_20100798_PC01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesControler : ControllerBase
    {
        private readonly IAttendeesRepository _attendeesRepository;

        public AttendeesControler(IAttendeesRepository attendeesRepository)
        {
            _attendeesRepository = attendeesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Attendees attendee)
        {
            int attendeId = await _attendeesRepository.Insert(attendee);
            return Ok(attendeId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _attendeesRepository.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizers()
        {
            IEnumerable<Attendees> attendees = await _attendeesRepository.GetOrganizers();
            return Ok(attendees);
        }

    }
}
