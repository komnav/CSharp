using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.UserDTOs;
using RestaurantWeb.Model;
namespace RestaurantWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    List<User> _users = [];

    [HttpPost]
    public IActionResult Create(CreateUser user)
    {
        
        return Ok();
    }

    [HttpGet]
    public IEnumerable<User> GetAll()
    {
        return _users.ToList();
    }

    [HttpGet("{id}")]
    public int GetById(int id)
    {
        var client = _users.FirstOrDefault(x => x.Id == id);
        if (client != null) return client.Id;
        else
            return 0;
    }

    [HttpDelete]
    public int Delete(int id)
    {
        var deleteUser = _users.FirstOrDefault(x => x.Id == id);
        if (deleteUser != null) _users.Remove(deleteUser);
        return 1;
    }

    [HttpPut("{id}")]
    public bool Update(int id, [FromBody] User user)
    {
        var client = _users.First(x => x.Id == id);
        client.UserName = user.UserName;
        return true;
    }
}