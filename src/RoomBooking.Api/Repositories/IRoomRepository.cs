using RoomBooking.Api.Entities;

namespace RoomBooking.Api.Repositories;

public interface IRoomRepository
{
    Task<Room?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<Room>> GetAllAsync(CancellationToken ct = default);
    Task<bool> ExistsByNameAsync(string name, int? excludeId = null, CancellationToken ct = default);
    void Add(Room room);
}