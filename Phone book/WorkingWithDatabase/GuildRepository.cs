using Microsoft.Data.SqlClient;

namespace Phone_book.WorkingWithDatabase;

public class GuildRepository
{
    private string connectionString = "Server=.;Database=Exhibition;User Id=sa;Password=123;TrustServerCertificate=True;";

    public void GetAll(string keyword)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = $@"
                Select *
                From guild
                Where title like N'%' + @Keyword + N'%'
            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Keyword", keyword);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Identity: {reader["id"]}: Name: {reader["title"]}");
                }
            }
            connection.Close();
        }
    }

    public void Insert(GuildEntity entity)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = $@"
                INSERT INTO [guild]
                (
                    [id]
                    ,[title]
                    ,[country_id]
                    ,[deleted]
                    ,[created_at]
                    ,[created_by]
                    ,[modified_at]
                    ,[modified_by]
                    ,[version]
                )
                VALUES
                (
                     @Id
                    ,@Title
                    ,@CountryId
                    ,@Deleted
                    ,@CreatedAt
                    ,@CreatedBy
                    ,@ModifiedAt
                    ,@ModifiedBy
                    ,@Version
                )
            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Id", entity.Id);
            command.Parameters.AddWithValue("Title", entity.Title);
            command.Parameters.AddWithValue("CountryId", entity.CountryId);
            command.Parameters.AddWithValue("Deleted", entity.Deleted);
            command.Parameters.AddWithValue("CreatedAt", entity.CreatedAt);
            command.Parameters.AddWithValue("CreatedBy", entity.CreatedBy);
            command.Parameters.AddWithValue("ModifiedAt", entity.ModifiedAt);
            command.Parameters.AddWithValue("ModifiedBy", entity.ModifiedBy);
            command.Parameters.AddWithValue("Version", entity.Version);

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
