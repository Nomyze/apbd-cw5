using Microsoft.AspNetCore.Mvc;
namespace apbd4.Controllers;

using apbd4.Database;
using apbd4.Models;

[Route("[controller]")]
[ApiController]
public class VisitsController : ControllerBase {
    private static IDatabase db = new MockDb();

    [HttpGet("{id}")]
    public IActionResult GetVisit(int id) {
        return Ok(db.GetVisits(id));
    }

    [HttpPost]
    public IActionResult AddVisit(Visit v) {
        db.AddVisit(v);

        return Ok(v);
    }
}
