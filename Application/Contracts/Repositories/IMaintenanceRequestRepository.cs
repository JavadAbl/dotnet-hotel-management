using Application.Contracts.Repositories;
using Domain.Models;
using Domain.Enums;

namespace Application.Contracts;

public interface IMaintenanceRequestRepository : IRepository<MaintenanceRequest>
{
    Task<IEnumerable<MaintenanceRequest>> GetByRoomIdAsync(int roomId);
    Task<IEnumerable<MaintenanceRequest>> GetByStatusAsync(MaintenanceStatus status);
    Task<IEnumerable<MaintenanceRequest>> GetByPriorityAsync(MaintenancePriority priority);
}
