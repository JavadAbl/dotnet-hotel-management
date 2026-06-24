using Application.Contracts.Repositories;
using Domain.Models;

namespace Application.Contracts;

public interface IRoomRepository : IRepository<Room>
{
    Task<IEnumerable<Room>> GetRoomsByStatusAsync(string status);
    Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut);
    Task<Room?> GetRoomWithDetailsAsync(int roomId);
}
