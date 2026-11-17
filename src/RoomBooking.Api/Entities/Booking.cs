namespace RoomBooking.Api.Entities;

public class Booking
{
    public int Id { get; private set; }
    public int RoomId { get; }
    public Room Room { get; private set; } = null!;
    public string ReservedBy { get; private set; } = string.Empty;
    public DateTime StartUtc { get; private set; }
    public DateTime EndUtc { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime? CancelledAtUtc { get; private set; }
    public string? CancellationReason { get; set; }
    public DateTime CreatedAtUtc { get; set; }

    private Booking() { }

    public Booking(int roomId, string reservedBy, DateTime startUtc, 
    DateTime endUtc, DateTime nowUtc)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(reservedBy);
        if (endUtc <= startUtc)
            throw new ArgumentException("O horário final deve ser posterior ao inicial.");

        RoomId = roomId;
        ReservedBy = reservedBy;
        StartUtc = startUtc;
        EndUtc = endUtc;
        Status = BookingStatus.Active;
        CreatedAtUtc = nowUtc;
    }

    public void Cancel(string reason, DateTime nowUtc)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(reason);

        if (Status == BookingStatus.Cancelled)
            throw new InvalidOperationException("A reserva já está cancelada.");

        Status = BookingStatus.Cancelled;
        CancelledAtUtc = nowUtc;
        CancellationReason = reason;
    }
}