using Microsoft.AspNetCore.Mvc;
namespace apbd4.Controllers;

using apbd4.Models;
using apbd4.Database;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase {

    [HttpGet]
    public IActionResult GetAnimals() {
        List<Animal> animals = new MockDb().Animals;
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id) {
        return Ok();
    }
}
