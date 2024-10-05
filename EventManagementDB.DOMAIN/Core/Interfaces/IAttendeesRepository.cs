﻿using EventManagementDB.DOMAIN.Core.Entities;

namespace EventManagementDB.DOMAIN.Core.Interfaces
{
    public interface IAttendeesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Attendees>> GetOrganizers();
        Task<int> Insert(Attendees attendee);
        Task<Attendees> GetById(int id); 
    }

}