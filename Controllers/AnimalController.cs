using Microsoft.AspNetCore.Mvc;
namespace apbd4.Controllers;

using apbd4.Database;
using apbd4.Models;

[Route("[controller]")]
[ApiController]
public class AnimalsController : ControllerBase {
    private static IDatabase db = new MockDb();

    [HttpGet]
    public IActionResult GetAnimals() {
        var animals = db.GetList();
        return Ok(animals);
    }

    [HttpGet("{id}")]
    public IActionResult GetAnimal(int id) {
        var animal = db.GetById(id);
        if(animal == null) {
            return NotFound();
        }
        return Ok(animal);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id) {
        Animal? animal = db.GetById(id);
        if(animal == null) {
            return NotFound();
        }
        
        db.Delete(animal);
        return Ok();
    }
    [HttpPost]
    public IActionResult AddAnimal(Animal animal){
        db.Add(animal);
        return Ok(animal);
    }
    [HttpPut("{id}")]
    public IActionResult EditAnimal(int id, Animal animal) {
        animal.id = id;
        db.EditById(animal);
        return NoContent();
    }
}
