using Application.Contracts.Repositories;
using Domain.Models;

namespace Application.Contracts;

public interface IMaintenanceRequestRepository : IRepository<MaintenanceRequest>
{
    Task<IEnumerable<MaintenanceRequest>> GetByRoomIdAsync(int roomId);
    Task<IEnumerable<MaintenanceRequest>> GetByStatusAsync(string status);
    Task<IEnumerable<MaintenanceRequest>> GetByPriorityAsync(string priority);
}
