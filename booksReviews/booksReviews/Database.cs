using System.Data.SqlClient;
namespace booksReviews;

public class Database
{
    private SqlConnection con = new SqlConnection(Constants.connect);

    public async Task AddBookAsync(VolumeInfo? BookModel, string Id)
    {
        var sql =
            "insert into public.\"booksData\"(\"Id\"\"Title\"\"Authors\"\"Categories\"\"PublishedDate\"\"Description\"\"Rating\")" +
            $"values (@Id, @Title, @Authors, @Categories, @PublishedDate @Description, @Rating)";
        SqlCommand comm = new SqlCommand(sql, con);
        comm.Parameters.AddWithValue("Id", Id );
        comm.Parameters.AddWithValue("Title", BookModel.Title);
        comm.Parameters.AddWithValue("Authors", BookModel.Authors);
        comm.Parameters.AddWithValue("Categories", BookModel.Categories);
        comm.Parameters.AddWithValue("Description", BookModel.Description);
        comm.Parameters.AddWithValue("Rating", BookModel.Rating);
        comm.Parameters.AddWithValue("PublishedDate", BookModel.PublishedDate);
        await con.OpenAsync();
        await comm.ExecuteNonQueryAsync();
        await con.CloseAsync();
    }
}