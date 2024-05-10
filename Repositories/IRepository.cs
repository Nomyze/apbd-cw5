
namespace Repositories;
using Models;

public interface IRepository {
    public Task<Book> getGenre(int id);
    public Task<Book> addBook(string title, List<int> genres);
}
