using RestaurantWeb.DTOs.OrderDTOs;
using FluentValidation.Results;


namespace RestaurantWeb.Services;

public interface IOrderService
{
    Task<List<OrderDto>> GetAll();

    Task<OrderDto> GetById(Guid id);

    Task<OrderDto> Create(CreateOrderDto orderDto);

    Task<bool> TryUpdate(Guid id, UpdateOrderDto updateOrder);

    Task<bool> TryUpdateSpecificProperties(Guid id, PatchUpdateOrderDto entity);

    Task<bool> TryDelete(Guid id);
}