using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

class DataBaseManager{

    private const string connectionString = "Data Source=posdb.db";

    private Product CreateProductFromReader(SQLiteDataReader reader){
        
        int barcode = reader.GetInt32(1);
        int categoryId = reader.GetInt32(2);
        string productName = reader.GetString(3);
        string productDescription = reader.GetString(4);
        float price = reader.GetFloat(5);
        int stock = reader.GetInt32(6);
        string brand = reader.GetString(7);
        DateTime createdAt = reader.GetDateTime(8);
        DateTime modifiedAt = reader.GetDateTime(9);

        Product product = new Product(barcode, categoryId, productName, productDescription, price, stock, brand, createdAt, modifiedAt);
        return product;
    }

    
    public SQLiteConnection CreateDatabaseConnection(){

        return new SQLiteConnection(connectionString);
    }

    static string GetHashedPassword(string password)
    {
        // Use a strong hashing algorithm like BCrypt or SHA256
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }

    private void HandleException(Exception ex){

        Console.WriteLine($"An error occurred: {ex.Message}");
    }

    public Employee IsLoginValid(string employeeNumber, string password){
        
        // string hashedPassword = GetHashedPassword(password);
        
        using (var connection = CreateDatabaseConnection()){

            connection.Open();

            string query = "SELECT * FROM employee WHERE id = @id;";
            using (var command = new SQLiteCommand(query, connection)){

                command.Parameters.AddWithValue("@id", employeeNumber);

                using (var reader = command.ExecuteReader()){

                    if (reader.Read()){

                        string id = (string)reader["id"];
                        string firstName = (string)reader["first_Name"];
                        string lastName = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        string phoneNumber = (string)reader["phone_number"];
                        string address = (string)reader["address"];
                        string zipCode = (string)reader["zip_code"];
                        string city = (string)reader["city"];
                        string state = (string)reader["state"];
                        string country = (string)reader["country"];
                        string position = (string)reader["position"];
                        string storedHash = (string)reader["password"];

                        string hashedPassword = GetHashedPassword(password);

                        if (storedHash == hashedPassword){

                            if (position == "CASHIER"){
                                return new Cashier(id, firstName, lastName, email, phoneNumber, address, zipCode, city, state, country, position);
                            }
                            else if (position == "MANAGER"){

                                return new Manager(id, firstName, lastName, email, phoneNumber, address, zipCode, city, state, country, position);
                            }
                        }
                    }
                }
            }

            

            connection.Close();

        }
        return null;
    }

    private Product RetrieveProductByBarcode(SQLiteConnection connection, int barcode){
        
        using (var command = connection.CreateCommand()){

            command.CommandText = "SELECT * FROM product WHERE barcode = @Barcode";
            command.Parameters.AddWithValue("@Barcode", barcode);

            using (var reader = command.ExecuteReader()){

                if (reader.Read()){
                    return CreateProductFromReader(reader);
                    // return reader;
                }

                return null;
            }
        }
    }

   public void UpdateProductStock(int barcode, int stockDifference){

        using (var connection = CreateDatabaseConnection()){
            
            connection.Open();

            using (var command = connection.CreateCommand()){

                command.CommandText = "UPDATE product SET stock = stock + @StockDifference WHERE barcode = @Barcode";
                command.Parameters.AddWithValue("@StockDifference", stockDifference);
                command.Parameters.AddWithValue("@Barcode", barcode);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 1){
                    
                    Console.WriteLine("Stock UPDATED successfully.");
                }else{
                    
                    Console.WriteLine("Stock update FAILED. Item not found.");
                }
            }

            connection.Close();
        }
        
    }

    public Product SearchBarcode(int barcode, Cart cart){

        using (var connection = CreateDatabaseConnection()){

            connection.Open();
            var product = RetrieveProductByBarcode(connection, barcode);
            connection.Close();

            return product;        
        }
    }


}