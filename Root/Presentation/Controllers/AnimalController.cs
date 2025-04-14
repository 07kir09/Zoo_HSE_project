using Microsoft.AspNetCore.Mvc;
using Root.Application.Services;
using Root.Domain.Entities;
using Root.Domain.Interfaces;

namespace Root.Presentation.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepo;
        private readonly AnimalTransferService _transferService;

        public AnimalController(IAnimalRepository animalRepo, AnimalTransferService transferService)
        {
            _animalRepo = animalRepo;
            _transferService = transferService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var animals = _animalRepo.GetAll();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var animal = _animalRepo.GetById(id);
            if (animal == null) return NotFound();
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] AnimalCreateModel model)
        {
            var animal = new Animal(
                model.Species,
                model.Name,
                model.DateOfBirth,
                model.Sex,
                model.FavoriteFood,
                model.IsHealthy
            );

            _animalRepo.Add(animal);
            return CreatedAtAction(nameof(GetById), new { id = animal.Id }, animal);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(Guid id)
        {
            _animalRepo.Delete(id);
            return NoContent();
        }

        [HttpPost("{animalId}/transfer/{newEnclosureId}")]
        public IActionResult TransferAnimal(Guid animalId, Guid newEnclosureId)
        {
            _transferService.TransferAnimal(animalId, newEnclosureId);
            return Ok();
        }
    }

    // DTO-модель для создания животного
    public class AnimalCreateModel
    {
        public string Species { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string FavoriteFood { get; set; }
        public bool IsHealthy { get; set; }
    }