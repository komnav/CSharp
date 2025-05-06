using Microsoft.AspNetCore.Mvc;
using RestaurantWebApi.DTOs.TableDTOs;
using RestaurantWebApi.Model;
using RestaurantWebApi.Model.Enums;

namespace RestaurantWebApi.Controllers;

[ApiController]
[Route("Table")]
public class TableController : Controller
{
    private static readonly List<Table> Tables =
    [
        new Table
        {
            Id = 1,
            Number = 1,
            Capacity = 100,
            Type = TableType.Cabin
        },
        new Table
        {
            Id = 2,
            Number = 2,
            Capacity = 50,
            Type = TableType.Table
        },
        new Table
        {
            Id = 3,
            Number = 3,
            Capacity = 10,
            Type = TableType.Cabin
        }
    ];

    [HttpPost]
    public IActionResult CreateTable([FromBody] CreateTable? createTable)
    {
        if (createTable is null)
            return BadRequest("Table is null");

        var createdTable = new Table
        {
            Number = createTable.Number,
            Capacity = createTable.Capacity,
            Type = createTable.Type,
        };
        return Ok();
    }
}