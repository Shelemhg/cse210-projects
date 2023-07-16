using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

class DataBaseManager{

    private const string connectionString = "Data Source=posdb.db";

    public void AddProductToDatabase(Product product){

        using (var connection = CreateDatabaseConnection()){

            connection.Open();
            int rowsAffected;

            using (var command = connection.CreateCommand()){

                command.CommandText = "INSERT INTO product (barcode, category_id, product_name, product_description, price, stock, brand, created_at, modified_at) " +
                                    "VALUES (@Barcode, @CategoryId, @ProductName, @ProductDescription, @Price, @Stock, @Brand, @CreatedAt, @ModifiedAt)";
                
                command.Parameters.AddWithValue("@Barcode", product.Barcode);
                command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                // command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Price", product.Price.ToString("F2"));
                // command.Parameters.AddWithValue("@price", String.Format("{0:F2}", product.Price));

                command.Parameters.AddWithValue("@Stock", product.Stock);
                command.Parameters.AddWithValue("@Brand", product.Brand);
                command.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);
                command.Parameters.AddWithValue("@ModifiedAt", product.ModifiedAt);

                rowsAffected = command.ExecuteNonQuery();
            }

            connection.Close();

            if (rowsAffected == 1){

                Console.WriteLine("Product ADDED to the Database SUCCESSFULLY.");
                Thread.Sleep(3000);
                
            }else{

                Console.WriteLine("FAILED to add the product to the database.");
                Thread.Sleep(3000);
            }
        }
    }

    private Product CreateProductFromReader(SQLiteDataReader reader){
        
        long barcode = (long)reader["barcode"];
        long categoryId = (long)reader["category_id"];
        string productName = (string)reader["product_name"];
        string productDescription = (string)reader["product_description"];
        // float price = (float)reader["price"];
        // string priceAsString = (string)reader["price"];
        // float price = float.Parse(priceAsString);
        decimal price = (decimal)reader["price"];
        long stock = (long)reader["stock"];
        string brand = (string)reader["brand"];
        
        string createdAtString = (string)reader["created_at"];
        DateTime createdAt = DateTime.Parse(createdAtString);
        string modifiedAtString = (string)reader["modified_at"];
        DateTime modifiedAt = DateTime.Parse(modifiedAtString);

        Product product = new Product(barcode, categoryId, productName, productDescription, (float)price, stock, brand, createdAt, modifiedAt);
        return product;
    }

    public SQLiteConnection CreateDatabaseConnection(){

        return new SQLiteConnection(connectionString);
    }

    public void DeleteProductFromDatabase(int barcode){

        using (var connection = CreateDatabaseConnection()){

            connection.Open();

            using (var command = connection.CreateCommand()){

                command.CommandText = "DELETE FROM product WHERE barcode = @Barcode";
                command.Parameters.AddWithValue("@Barcode", barcode);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 1){

                    Console.WriteLine("Product DELETED successfully.");
                }else{

                    Console.WriteLine($"Product {barcode} NOT FOUND.");
                }
            }

            connection.Close();
        }
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

   public void UpdateProductStock(long barcode, int stockDifference){

        using (var connection = CreateDatabaseConnection()){
            connection.Open();

            using (var command = connection.CreateCommand()){

                command.CommandText = "UPDATE product SET stock = stock + @StockDifference, modified_at = @ModifiedAt WHERE barcode = @Barcode";
                command.Parameters.AddWithValue("@StockDifference", stockDifference);
                command.Parameters.AddWithValue("@ModifiedAt", DateTime.Now); // Set the modified date to the current date
                command.Parameters.AddWithValue("@Barcode", barcode);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 1){

                    Console.WriteLine("Stock and Modified Date UPDATED successfully.");

                }else{

                    Console.WriteLine("Stock update FAILED. Item not found.");
                }
            }

            connection.Close();
        }
    }

    public Product SearchBarcode(int barcode){

        using (var connection = CreateDatabaseConnection()){

            connection.Open();
            var product = RetrieveProductByBarcode(connection, barcode);
            connection.Close();

            return product;        
        }
    }


}