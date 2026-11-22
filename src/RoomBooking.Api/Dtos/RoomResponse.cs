namespace RoomBooking.Api.Dtos;

public record RoomResponse(
    int Id, string Name,
    int Capacity, bool IsActive,
    DateTime CreatedAtUtc
);