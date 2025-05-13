using FluentValidation;
using RestaurantWeb.DTOs.TableDTOs;

namespace RestaurantWeb.Validations;

public class TableDtoValidator : AbstractValidator<CreateTableDto>
{
    public TableDtoValidator()
    {
        RuleFor(c => c.Capacity)
            .NotEmpty();
        RuleFor(c => c.Number)
            .NotEmpty();
        RuleFor(c => c.Type)
            .NotEmpty();
    }
}