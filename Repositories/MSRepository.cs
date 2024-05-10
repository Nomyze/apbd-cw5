using Microsoft.Data.SqlClient;
using System.Data;
namespace Repositories;
using Models;

public class MSRepository : IRepository
{
    private readonly IConfiguration _configuration;
    
    public MSRepository(IConfiguration _conf) {
        _configuration = _conf;
    }

    public async Task<Book> getGenre(int id) {
        string title = "";
        List<string> genres = new List<string>();
        using(SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"))) {
            string query = "select b.title, g.name from books b join books_genres bg on b.PK = FK_book join genres g on bg.FK_genre = g.PK where b.PK = @id;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using(SqlDataReader reader = await command.ExecuteReaderAsync()) {
                while(reader.Read()) {
                    IDataRecord dRec = (IDataRecord) reader;
                    title = dRec.GetString(0);
                    string genre = (dRec)
                        .GetString(1);
                    genres.Add(genre);
                }
            }
            connection.Close();
        }
        Book ret = new Book(id, title, genres);
        if(title == "") {
            return null;
        }
        return ret;
    }

    public async Task<Book> addBook(string title, List<int> genres) {
        int id_b = -1;
        using(SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"))) {
            connection.Open();
            string query = "INSERT INTO books (title) VALUES (@title);";

            using(SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@title", title);
                
                Int32 added = await command.ExecuteNonQueryAsync();
                if(added == 0) 
                    Console.Error.WriteLine("Failed to add animal");
            }
            connection.Close();
        }
        using(SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"))) {
            connection.Open();
            string query = "select pk from books where title = @title;";

            using(SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@title", title);
                using(SqlDataReader reader = await command.ExecuteReaderAsync()) {
                    while(reader.Read()) {
                        IDataRecord dRec = (IDataRecord) reader;
                        id_b = dRec.GetInt32(0);
                    }
                }
            }
            connection.Close();
        }


        for(int i = 0; i < genres.Count(); i++) {
            using(SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"))) {
                connection.Open();
                string query = "INSERT INTO books_genres (FK_book, FK_genre) VALUES (@id_b, @id_g);";
                using(SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@id_b", id_b);
                    command.Parameters.AddWithValue("@id_g", genres[i]);
                    Int32 added = await command.ExecuteNonQueryAsync();
                    if(added == 0) 
                        Console.Error.WriteLine("Failed to add genres");
                }
                connection.Close();
            }
        }
        return await getGenre(id_b);

    }
}
