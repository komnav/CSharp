using RestaurantWeb.DTOs.OrderDTOs;
using FluentValidation.Results;


namespace RestaurantWeb.Services;

public interface IOrderService
{
    List<OrderDto> GetAll();

    OrderDto GetById(Guid id);

    (ValidationResult validationResult, OrderDto dto) Create(CreateOrderDto orderDto);

    bool TryUpdate(Guid id, UpdateOrderDto updateOrder);

    bool TryUpdateSpecificProperties(Guid id, PatchUpdateOrderDto entity);

    bool TryDelete(Guid id);
}