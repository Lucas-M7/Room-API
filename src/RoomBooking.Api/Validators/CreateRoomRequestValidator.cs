using FluentValidation;
using RoomBooking.Api.Dtos;
using RoomBooking.Api.Entities;

namespace RoomBooking.Api.Validators;

public class CreateRoomRequestValidator : AbstractValidator<CreateRoomRequest>
{
    public CreateRoomRequestValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(Room.NameMaxLength)
                .WithMessage($"Nome deve ter no máximo {Room.NameMaxLength} caracteres.");

        RuleFor(r => r.Capacity)
            .GreaterThan(0).WithMessage("Capacidade deve ser maior que zero.");
    }
}