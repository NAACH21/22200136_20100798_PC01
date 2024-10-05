using EventManagementDB.DOMAIN.Core.Entities;

namespace EventManagementDB.DOMAIN.Core.Interfaces
{
    public interface IOrganizersRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Attendees>> GetOrganizers();
        Task<int> Insert(Attendees organizers);
    }
}