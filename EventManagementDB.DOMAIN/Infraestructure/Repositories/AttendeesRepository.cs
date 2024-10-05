using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagementDB.DOMAIN.Core.Entities;
using EventManagementDB.DOMAIN.Core.Interfaces;
using EventManagementDB.DOMAIN.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EventManagementDB.DOMAIN.Infraestructure.Repositories
{
    public class AttendeesRepository : IAttendeesRepository
    {
        private readonly EventManagementDbContext _dbContext;

        public AttendeesRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Attendees>> GetOrganizers()
        {
            var attendees = await _dbContext.Attendees.ToListAsync();
            return attendees;
        }

        public async Task<int> Insert(Attendees attendee)
        {
            await _dbContext.Attendees.AddAsync(attendee);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? attendee.Id : -1;
        }

        public async Task<bool> Delete(int id)
        {
            var attendee = await _dbContext.Attendees.FirstOrDefaultAsync(c => c.Id == id);

            if (attendee == null)
                return false;

            _dbContext.Attendees.Remove(attendee);

            try
            {
                int rows = await _dbContext.SaveChangesAsync();
                return rows > 0;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
