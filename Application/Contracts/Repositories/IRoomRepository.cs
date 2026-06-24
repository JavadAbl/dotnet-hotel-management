using Application.Contracts.Repositories;
using Domain.Models;
using Domain.Enums;

namespace Application.Contracts;

public interface IRoomRepository : IRepository<Room>
{
    Task<IEnumerable<Room>> GetRoomsByStatusAsync(RoomStatus status);
    Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime checkIn, DateTime checkOut);
    Task<Room?> GetRoomWithDetailsAsync(int roomId);
}
