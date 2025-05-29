using FluentValidation.Results;
using RestaurantWeb.DTOs.OrderDTOs;

namespace RestaurantWeb.Services;

public class OrderService : IOrderService
{
    public List<OrderDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public OrderDto GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public (ValidationResult validationResult, OrderDto dto) Create(CreateOrderDto orderDto)
    {
        throw new NotImplementedException();
    }

    public bool TryUpdate(Guid id, UpdateOrderDto updateOrder)
    {
        throw new NotImplementedException();
    }

    public bool TryUpdateSpecificProperties(Guid id, PatchUpdateOrderDto entity)
    {
        throw new NotImplementedException();
    }

    public bool TryDelete(Guid id)
    {
        throw new NotImplementedException();
    }
}