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
    public class OrganizersRepository : IOrganizersRepository
    {
        private readonly EventManagementDbContext _dbContext;

        public OrganizersRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Attendees>> GetOrganizers()
        {
            var organizers = await _dbContext.Organizers.ToListAsync();
            return organizers;
        }

        public async Task<int> Insert(Attendees organizers)
        {
            await _dbContext.Organizers.AddAsync(organizers);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? organizers.Id : -1;
        }

        public async Task<bool> Delete(int id)
        {
            var organizers = await _dbContext
                            .Organizers
                            .FirstOrDefaultAsync(c => c.Id == id);

            if (organizers == null) return false;

            _dbContext.Organizers.Remove((Attendees)organizers);
            int rows = await _dbContext.SaveChangesAsync();
            return (rows > 0);

        }

    }
}
