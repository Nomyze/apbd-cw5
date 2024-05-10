using Microsoft.AspNetCore.Mvc;

namespace Controllers;
using Repositories;
using Models;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase {
    private IRepository _repo; 

    public BooksController(IRepository repo) {
        _repo = repo;
    }

    [HttpGet("{id}/genres")]
    public async Task<IActionResult> getGenres(int id) {
        Book book = await _repo.getGenre(id);

        if (book == null) {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> addBook(string title, List<int> iGens) {
        Book book = await _repo.addBook(title, iGens);

        if(book == null) {
            return NotFound();
        }
        return Ok(book);
    }
}


