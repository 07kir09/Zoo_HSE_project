using Microsoft.AspNetCore.Mvc;
using Root.Domain.Entities;
using Root.Domain.Interfaces;

namespace Root.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class EnclosureController : ControllerBase
{
    private readonly IEnclosureRepository _enclosureRepo;

    public EnclosureController(IEnclosureRepository enclosureRepo)
    {
        _enclosureRepo = enclosureRepo;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_enclosureRepo.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var enclosure = _enclosureRepo.GetById(id);
        if (enclosure == null) return NotFound();
        return Ok(enclosure);
    }

    [HttpPost]
    public IActionResult AddEnclosure([FromBody] EnclosureCreateModel model)
    {
        var enclosure = new Enclosure(model.Type, model.Size, 0, model.MaxCapacity);
        _enclosureRepo.Add(enclosure);

        return CreatedAtAction(nameof(GetById), new { id = enclosure.Id }, enclosure);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEnclosure(Guid id)
    {
        _enclosureRepo.Delete(id);
        return NoContent();
    }

    // Дополнительные методы, например, CleanUp
    [HttpPost("{id}/cleanup")]
    public IActionResult CleanUp(Guid id)
    {
        var enclosure = _enclosureRepo.GetById(id);
        if (enclosure == null) return NotFound();

        enclosure.CleanUp();
        _enclosureRepo.Update(enclosure);
        return Ok();
    }
}

public class EnclosureCreateModel
{
    public string Type { get; set; }
    public double Size { get; set; }
    public int MaxCapacity { get; set; }
}