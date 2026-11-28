using Microsoft.EntityFrameworkCore;
using RoomBooking.Api.Data;
using RoomBooking.Api.Entities;

namespace RoomBooking.Api.Repositories;

public class RoomRepository(AppDbContext context) : IRoomRepository
{
    public void Add(Room room) => context.Rooms.Add(room);

    public Task<bool> ExistsByNameAsync(string name, int? excludeId = null, CancellationToken ct = default)
        => context.Rooms.AnyAsync(
            r => r.Name.ToLower() == name.ToLower()
            && (excludeId == null || r.Id != excludeId), ct);
    public async Task<IReadOnlyList<Room>> GetAllAsync(CancellationToken ct = default)
        => await context.Rooms.AsNoTracking().OrderBy(r => r.Name).ToListAsync(ct);

    public Task<Room?> GetByIdAsync(int id, CancellationToken ct = default)
        => context.Rooms.FirstOrDefaultAsync(r => r.Id == id, ct);
}