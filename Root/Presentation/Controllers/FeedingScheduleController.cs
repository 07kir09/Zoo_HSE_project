using Root.Application.Services;
using Root.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Root.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class FeedingScheduleController : ControllerBase
{
    private readonly FeedingOrganizationService _feedingService;
    private readonly IFeedingScheduleRepository _scheduleRepo;

    public FeedingScheduleController(
        FeedingOrganizationService feedingService,
        IFeedingScheduleRepository scheduleRepo)
    {
        _feedingService = feedingService;
        _scheduleRepo = scheduleRepo;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_scheduleRepo.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var schedule = _scheduleRepo.GetById(id);
        if (schedule == null) return NotFound();
        return Ok(schedule);
    }

    [HttpPost]
    public IActionResult CreateSchedule([FromBody] FeedingScheduleCreateModel model)
    {
        var schedule = _feedingService.CreateFeedingSchedule(
            model.AnimalId,
            model.FeedingTime,
            model.FoodType
        );
        return CreatedAtAction(nameof(GetById), new { id = schedule.Id }, schedule);
    }

    // Отметить, что время кормления наступило
    [HttpPost("{scheduleId}/feed")]
    public IActionResult HandleFeedingTime(Guid scheduleId)
    {
        _feedingService.HandleFeedingTime(scheduleId);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSchedule(Guid id)
    {
        _scheduleRepo.Delete(id);
        return NoContent();
    }
}

public class FeedingScheduleCreateModel
{
    public Guid AnimalId { get; set; }
    public DateTime FeedingTime { get; set; }
    public string FoodType { get; set; }
}