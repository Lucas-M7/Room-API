namespace RoomBooking.Api.Entities;

public class Room
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int Capacity { get; private set; }
    public bool IsActive { get; private set; } = true;
    public DateTime CreatedAtUtc { get; private set; }
    public ICollection<Booking> Bookings { get; private set; } = [];

    private Room() { }

    public Room(string name, int capacity, DateTime nowUtc)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacity);

        Name = name;
        Capacity = capacity;
        CreatedAtUtc = CreatedAtUtc;
    }
}