namespace Models;

public class Book {
    public int id {get; set;}
    public string title {get; set;} = "";
    public List<string> genres {get; set;} = new List<string>();
    public Book(int id, string title, List<string> genres) {
        this.id = id;
        this.title = title;
        this.genres = genres;
    }
}
