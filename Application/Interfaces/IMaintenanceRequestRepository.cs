using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Interfaces;

public interface IMaintenanceRequestRepository : IRepository<MaintenanceRequest>
{
    Task<IEnumerable<MaintenanceRequest>> GetByRoomIdAsync(int roomId);
    Task<IEnumerable<MaintenanceRequest>> GetByStatusAsync(string status);
    Task<IEnumerable<MaintenanceRequest>> GetByPriorityAsync(string priority);
}
