using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using RestaurantWeb.DTOs.OrderDTOs;
using RestaurantWeb.DTOs.ReservationDTOs;
using RestaurantWeb.Exceptions;
using RestaurantWeb.Infrastructure.Repositories;
using RestaurantWeb.Model;

namespace RestaurantWeb.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<List<OrderDto>> GetAll()
    {
        var orders = await _orderRepository.GetAll();
        return orders.Select(s => new OrderDto()
        {
            Id = s.Id,
            TableId = s.TableId,
            FoodId = s.FoodId,
            MenuItem = s.MenuItem,
            DateTime = s.DateTime,
            Status = s.Status
        }).ToList();
    }

    public async Task<OrderDto> GetById(Guid id)
    {
        var reservation = await _orderRepository.GetById(id);
        return new OrderDto()
        {
            Id = reservation.Id,
            TableId = reservation.TableId,
            FoodId = reservation.FoodId,
            MenuItem = reservation.MenuItem,
            DateTime = reservation.DateTime,
            Status = reservation.Status
        };
    }

    public async Task<OrderDto> Create(CreateOrderDto orderDto)
    {
        var createOrder = new Order()
        {
            TableId = orderDto.TableId,
            FoodId = orderDto.FoodId,
            MenuItem = orderDto.MenuItem,
            DateTime = orderDto.DateTime,
            Status = orderDto.Status
        };
        var create = await _orderRepository.Create(createOrder);
        if (create < 0)
            throw new ResourceWasNotCreatedException(nameof(createOrder));

        return new OrderDto()
        {
            Id = createOrder.Id,
            TableId = createOrder.TableId,
            FoodId = createOrder.FoodId,
            MenuItem = createOrder.MenuItem,
            DateTime = createOrder.DateTime,
            Status = createOrder.Status
        };
    }

    public async Task<bool> TryUpdate(Guid id, UpdateOrderDto updateOrderDto)
    {
        var update = await _orderRepository.TryUpdate(
            id,
            updateOrderDto.TableId,
            updateOrderDto.FoodId,
            updateOrderDto.DateTime,
            updateOrderDto.Status);
        if (!update)
            throw new ResourceWasNotUpdatedException(nameof(updateOrderDto));

        return true;
    }

    public async Task<bool> TryUpdateSpecificProperties(Guid id, PatchUpdateOrderDto entity)
    {
        var serverSide = await _orderRepository.GetById(id);
        var properties = entity.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(entity);
            if (value is not null)
            {
                var oldProperty = serverSide.GetType().GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serverSide, value);
            }
        }

        var update = await _orderRepository.TryUpdate(
            id,
            serverSide.TableId,
            serverSide.FoodId,
            serverSide.DateTime,
            serverSide.Status);
        if (!update)
            throw new ResourceWasNotUpdatedException(nameof(entity));

        return true;
    }

    public async Task<bool> TryDelete(Guid id)
    {
        var delete = await _orderRepository.Delete(id);
        if (delete < 0)
            return false;
        return true;
    }
}