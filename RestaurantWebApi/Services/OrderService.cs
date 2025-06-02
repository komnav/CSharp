using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RestaurantWeb.DTOs.OrderDTOs;
using RestaurantWeb.Infrastructure.Repositories;
using RestaurantWeb.Model;

namespace RestaurantWeb.Services;

public class OrderService(
    IOrderRepository orderRepository,
    IMapper mapper,
    IServiceProvider serviceProvider) : IOrderService
{
    public List<OrderDto> GetAll()
    {
        var getAllOrder = orderRepository.GetAll();
        var map = mapper.Map<List<OrderDto>>(getAllOrder);
        return map;
    }

    public OrderDto GetById(Guid id)
    {
        var getById = orderRepository.GetById(id);
        var map = mapper.Map<OrderDto>(getById);
        return map;
    }

    public (ValidationResult validationResult, OrderDto dto) Create(CreateOrderDto orderDto)
    {
        var validator = serviceProvider.GetService<IValidator<CreateOrderDto>>();
        if (validator != null)
        {
            var result = validator.Validate(orderDto);
            if (!result.IsValid)
            {
                return (result, null);
            }
        }

        var newOrder = new Order
        {
            TableId = orderDto.TableId,
            FoodId = orderDto.FoodId,
            MenuItem = orderDto.MenuItem,
            DateTime = orderDto.DateTime,
            Status = orderDto.Status
        };
        orderRepository.Create(newOrder);

        var map = mapper.Map<OrderDto>(newOrder);
        return (null, map);
    }

    public bool TryUpdate(Guid id, UpdateOrderDto updateOrder)
    {
        var getOrder = orderRepository.GetById(id);
        var map = mapper.Map(updateOrder, getOrder);
        orderRepository.TryUpdate(id, map);
        return true;
    }

    public bool TryUpdateSpecificProperties(Guid id, PatchUpdateOrderDto entity)
    {
        var serverSideOrder = orderRepository.GetById(id);
        var serverOrder = serverSideOrder.GetType();
        var properties = entity.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(entity);
            if (value is not null)
            {
                var oldProperty = serverSideOrder.GetType().GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serverSideOrder, value);
            }
        }

        orderRepository.TryUpdate(id, serverSideOrder);
        mapper.Map(serverSideOrder, entity);
        return true;
    }

    public bool TryDelete(Guid id)
    {
        var tryDelete = orderRepository.Delete(id);
        return tryDelete is not null;
    }
}