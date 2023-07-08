using System.Data.SQLite;

class PointOfSale{

    private List<Cart> _carts;

    public PointOfSale(){
        
        _carts = new List<Cart>();
    }
    
    public void LoadNewCart(){
        
        Cart cart = new Cart();
        
        string input = null;
        Boolean itemFound;
        int barcode = 0;

        do{
            Console.Clear();
            DisplayHorizontalLine();
            Console.WriteLine("- - -      L O A D    I T E M S       - - -");
            DisplayHorizontalLine();
            
            DisplayItems(cart);
            DisplayHorizontalDots();
            Console.WriteLine("\nType Barcode:\n");
            input = Console.ReadLine();

            if(int.TryParse(input, out barcode)){                        
                itemFound = SearchBarcode(barcode, cart);
            }

            
            
            

        }while(input != "");
    }

    public void DisplayHorizontalLine(){
        
        Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
    }

    private void DisplayHorizontalDots(){
        
        Console.WriteLine(". . . . . . . . . . . . . . . . . . .");
    }

    public void DisplayMenu(){

        DisplayHorizontalLine();
        Console.WriteLine("- -   P O I N T   O F   S A L E   - -");
        DisplayHorizontalLine();
        Console.WriteLine("1. New Cart");
        Console.WriteLine("2. Check Item Price");
        Console.WriteLine("2. Check Item Price");
        
        DisplayHorizontalDots();
        DisplayHorizontalDots();
        Console.WriteLine("0. Exit");
    }
    
    public void DisplayItems(Cart cart){
        
        int i = 1;
        foreach(Product item in cart.Items){
            Console.WriteLine(i + ". " + item.ProductName + "  -  ");
        }

    }

    public Boolean SearchBarcode(int barcode, Cart cart){

        try{
            using (var connection = CreateDatabaseConnection()){
                connection.Open();

                var product = RetrieveProductByBarcode(connection, barcode);
                connection.Close();

                if (product != null){
                    cart.AddItem(product);
                    return true;
                }           
            }
        }
        catch (Exception ex){
            
            HandleException(ex);
        }
        return false;
    }

    private Product CreateProductFromReader(SQLiteDataReader reader){
        
        int barcode = reader.GetInt32(1);
        int categoryId = reader.GetInt32(2);
        string productName = reader.GetString(3);
        string productDescription = reader.GetString(4);
        int stock = reader.GetInt32(5);
        string brand = reader.GetString(6);
        DateTime createdAt = reader.GetDateTime(7);
        DateTime modifiedAt = reader.GetDateTime(8);

        Product product = new Product(barcode, categoryId, productName, productDescription, stock, brand, createdAt, modifiedAt);
        return product;
    }

    private void DisplayBarcodeNotFoundMessage(){
        
        Console.WriteLine("Barcode not found.");
    }

    private void DisplayProductInformation(Product product){

        Console.WriteLine($"Product Name: {product.ProductName}");
        Console.WriteLine($"Brand: {product.Brand}");
        Console.WriteLine($"Stock: {product.Stock}");
    }

    private void HandleException(Exception ex){

        Console.WriteLine($"An error occurred: {ex.Message}");
    }

    private Product RetrieveProductByBarcode(SQLiteConnection connection, int barcode){
        
        using (var command = connection.CreateCommand()){

            command.CommandText = "SELECT * FROM product WHERE barcode = @Barcode";
            command.Parameters.AddWithValue("@Barcode", barcode);

            using (var reader = command.ExecuteReader()){

                if (reader.Read()){
                    return CreateProductFromReader(reader);
                }

                return null;
            }
        }
    }


    private SQLiteConnection CreateDatabaseConnection(){

        string connectionString = "Data Source=posdb.db";
        return new SQLiteConnection(connectionString);
    }


}