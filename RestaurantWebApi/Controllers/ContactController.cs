using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DTOs.ContactDTOs;
using RestaurantWeb.Services;

namespace RestaurantWeb.Controllers;

[ApiController]
[Route("Contact")]
public class ContactController(ContactService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var contactDto = service.GetById(id);
        if (contactDto.FirstName is null)
            return NotFound();
        return Ok(contactDto);
    }

    [HttpGet]
    public List<ContactDto> GetAll()
    {
        return service.GetAll();
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateContactDto contactDto)
    {
        var (validationResult, createContact) = service.Create(contactDto);
        if (validationResult is not null)
        {
            var errors = validationResult.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage });
            return BadRequest(new { Errors = errors });
        }

        return Created($"/api/contact/{createContact.Id}", createContact);
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var result = service.TryDelete(id);
        if (!result)
            return BadRequest();
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(Guid id, [FromBody] UpdateContactDto contactDto)
    {
        var result = service.TryUpdate(id, contactDto);
        if (!result)
            return BadRequest();
        return Ok();
    }

    [HttpPatch]
    public IActionResult UpdateSpecificProperties(Guid id, PatchUpdateContactDto contactDto)
    {
        var result = service.TryUpdateSpecificProperties(id, contactDto);
        if (!result)
            return BadRequest();
        return Ok();
    }
}