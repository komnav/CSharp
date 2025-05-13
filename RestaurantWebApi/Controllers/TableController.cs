using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.TableDTOs;
using RestaurantWeb.Extensions;
using RestaurantWeb.Model;
using RestaurantWeb.Repositories;
using RestaurantWeb.Validations;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("Table")]
public class TableController : ControllerBase
{
    private readonly ITableRepository _tableRepository;
    private readonly IMapper _mapper;
    private readonly TableDtoValidator _validator;

    public TableController(ITableRepository tableRepository, [FromServices] IMapper mapper)
    {
        _tableRepository = tableRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<TableDto> GetAll()
    {
        var table = _tableRepository.GetAll();
        var tableDto = _mapper.Map<IEnumerable<TableDto>>(table);
        return tableDto;
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var table = _tableRepository.GetById(id);
        var result = _mapper.Map<TableDto>(table);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create(
        CreateTableDto createTableDto)
    {
        var validation = _validator.Validate(createTableDto);
        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }
        var createTables = new Table
        {
            Number = createTableDto.Number,
            Capacity = createTableDto.Capacity,
            Type = createTableDto.Type
        };
        _tableRepository.Create(createTables);
        return Ok(createTables.ToDto());
    }

    [HttpPut]
    public IActionResult Update
    (Guid id, UpdateTableDto updateTableDto,
        [FromServices] MapsterMapper.IMapper mapper)
    {
        var table = _tableRepository.GetById(id);

        table.Number = updateTableDto.Number;
        table.Capacity = updateTableDto.Capacity;
        table.Type = updateTableDto.Type;

        mapper.Map(updateTableDto, table);
        _tableRepository.TryUpdate(id, table);
        return Ok(table.ToDto());
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(
        Guid id, PatchUpdateTableDto updateTableDto
    )
    {
        var serviceTable = _tableRepository.GetById(id);

        var serviceTableType = serviceTable.GetType();
        var properties = updateTableDto.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(updateTableDto);
            if (value is not null)
            {
                var oldProperty = serviceTableType.GetProperty(property.Name);
                if (oldProperty?.CanWrite == true)
                    oldProperty.SetValue(serviceTable, value);
            }
        }

        _tableRepository.TryUpdate(id, serviceTable);
        return Ok(serviceTable.ToDto());
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var deleteTable = _tableRepository.Delete(id);
        return Ok(deleteTable.ToDto());
    }
}