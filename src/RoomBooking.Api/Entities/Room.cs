namespace RoomBooking.Api.Entities;

public class Room
{
    public const int NameMaxLength = 30;

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int Capacity { get; private set; }
    public bool IsActive { get; private set; } = true;
    public DateTime CreatedAtUtc { get; private set; }
    public ICollection<Booking> Bookings { get; private set; } = [];

    private Room() { }

    public Room(string name, int capacity, DateTime nowUtc)
    {
        ValidateDetails(name, capacity);

        Name = name;
        Capacity = capacity;
        CreatedAtUtc = nowUtc;
    }

    public void Update(string name, int capacity)
    {
        ValidateDetails(name, capacity);

        Name = name;
        Capacity = capacity;
    }

    private static void ValidateDetails(string name, int capacity)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        if (name.Length > NameMaxLength)
            throw new ArgumentException(
                $"O nome deve ter no máximo {NameMaxLength} caracteres.", nameof(name));

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacity);
    }
}