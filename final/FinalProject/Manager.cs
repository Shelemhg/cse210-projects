class Manager : Employee {
    
    public Manager(string id, string firstName, string lastName, string email, string phoneNumber, string address, string zipCode, string city, string state, string country, string position){
        _id = id;
        _firstName = firstName;
        _lastName = lastName;
        _email = email; 
        _phoneNumber = phoneNumber;
        _address = address;
        _zipCode = zipCode;
        _city = city;
        _state = state;
        _country = country;
        _position = position;
    }

    private Boolean AddNewItem(){

        string input = "";
        int barcode;
        do{
            Console.Clear();
            DisplayHorizontalLine();
            Console.WriteLine("- -    A D D    N E W    I T E M   - -");
            DisplayHorizontalLine();
            Console.WriteLine("\nType the BARCODE or Hit ENTER to return:\n");
            input = Console.ReadLine();

            if(int.TryParse(input, out barcode)){

                Product product = _dataBaseManager.SearchBarcode(barcode);

                if(product == null){
                    
                    do{ 
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nBarcode {barcode} NOT FOUND\n");
                        Console.ResetColor();
                        Console.WriteLine("Would you like to add it? (y/n)\n");
                        input = Console.ReadLine();

                        if(input == "y"){

                            Product newProduct = PromptNewProductDetails(barcode);
                            
                            _dataBaseManager.AddProductToDatabase(newProduct);
                            break;
                        }

                    }while(input != "" && input != "n");

                }else{
                    
                    int newStock;
                    string inputNewStock;

                    do{
                        Console.Clear();
                        DisplayProductInfo(product);
                        DisplayHorizontalLine();
                        Console.WriteLine("How many NEW ITEMS should be added to STOCK?\n");
                        inputNewStock = Console.ReadLine(); 
                        
                        if(int.TryParse(inputNewStock, out newStock)){
                            _dataBaseManager.UpdateProductStock(product.Barcode, newStock);
                            Console.Clear();
                            product = _dataBaseManager.SearchBarcode(barcode);
                            DisplayProductInfo(product);
                            DisplayHorizontalLine();
                            Console.WriteLine($"\n{inputNewStock} Items added to the stock of {product.Barcode}\n");
                            Thread.Sleep(4000);
                            break;
                        }
                    }while(input != "");
                }
            }

        }while(input != "");
        
        return false;
    }

    public override void DisplayMenu(){
        
        DisplayHorizontalLine();
        Console.WriteLine("- -   P O I N T   O F   S A L E   - -");
        DisplayHorizontalLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"        {FirstName} {LastName} - {Position}");
        Console.ResetColor();
        DisplayHorizontalLine();
        Console.WriteLine("1. New Cart");
        Console.WriteLine("2. Check Item Price");
        DisplayHorizontalLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("3. Add New Item");
        Console.WriteLine("4. Show Store Inventory");
        Console.ResetColor();
        DisplayHorizontalLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("5. Add New Employee");
        Console.WriteLine("6. Show Employees' Info");
        Console.ResetColor();
        DisplayHorizontalDots();
        Console.WriteLine("0. Logout\n");
    }

    private void DisplayProductInfo(Product product){

        Console.WriteLine("Product Information:");
        DisplayHorizontalLine();

        Console.WriteLine($"Barcode: {product.Barcode,-15} | Category ID: {product.CategoryId,-15} | Product Name: {product.ProductName}");
        DisplayHorizontalDots();

        Console.WriteLine($"Description: {product.ProductDescription}");
        DisplayHorizontalDots();

        Console.WriteLine($"Price: {product.Price:C2,-15} | Stock: {product.Stock,-15} | Brand: {product.Brand}");
        DisplayHorizontalDots();

        Console.WriteLine($"Created At: {product.CreatedAt,-15} | Modified At: {product.ModifiedAt,-15}");
        DisplayHorizontalDots();
    }
    
    private bool DeleteItem(){

        string input = "";
        int barcode;

        do{
            Console.Clear();
            DisplayHorizontalLine();
            Console.WriteLine("- -    D E L E T E    I T E M   - -");
            DisplayHorizontalLine();
            Console.WriteLine("\nType the BARCODE of the item to DELETE:\n");
            input = Console.ReadLine();

            if (int.TryParse(input, out barcode)){

                Product product = _dataBaseManager.SearchBarcode(barcode);

                if (product != null){

                    Console.Clear();
                    DisplayProductInfo(product);
                    DisplayHorizontalLine();
                    Console.WriteLine("Do you want to delete this item? (y/n)\n");
                    input = Console.ReadLine();

                    if (input == "y"){
                        _dataBaseManager.DeleteProductFromDatabase(barcode);
                        return true;
                    }
                }else{
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nItem with barcode {barcode} NOT FOUND\n");
                    Console.ResetColor();
                    Thread.Sleep(3000);
                }
            }

        } while (input != "" && input != "n");

        return false;
    }

    private int GetValidNumberInput(string prompt){

        int value;

        while (true){

            Console.Write(prompt);

            if(int.TryParse(Console.ReadLine(), out value)){
                break;
            }

            Console.Clear();
            Console.WriteLine("Invalid input. Please enter a valid numeric value.");
        }

        return value;
    }

    private float GetValidFloatInput(string prompt){

        float value;

        while (true){

            Console.Write(prompt);

            if (float.TryParse(Console.ReadLine(), out value)){

                break;
            }

            Console.Clear();
            Console.WriteLine("Invalid input. Please enter a valid numeric value.");
        }

        return value;
    }

    public override void LoadPointOfSale(){
        
        string menuChoice = null;

        do{
            Console.Clear();
            DisplayMenu();
            Console.WriteLine("Select one option and hit ENTER:\n");
            menuChoice = Console.ReadLine();

            switch(menuChoice){

                //  New Cart
                case "1":
                    LoadNewCart();
                    break;
                //  Check Item Price
                case "2":
                    CheckPrice();
                    break;
                //  Check Item Price
                case "3":
                    AddNewItem();
                    break;
                //  Check Item Price
                case "4":
                    // CheckPrice();
                    break;
                //  Check Item Price
                case "5":
                    // CheckPrice();
                    break;
                //  Check Item Price
                case "6":
                    // CheckPrice();
                    break;
            }


        }while(menuChoice != "0");

        Console.Clear();
    }
    
    private Product PromptNewProductDetails(int barcode){

        Console.Clear();
        DisplayHorizontalLine();
        Console.WriteLine("Enter the details for the new product:");
        DisplayHorizontalLine();

        // int barcode = GetValidNumberInput("\nBarcode:\n");
        int categoryId = GetValidNumberInput("Category ID:\n");
        
        Console.Write("Product Name:\n");
        string productName = Console.ReadLine();

        Console.Write("Description:\n");
        string productDescription = Console.ReadLine();

        float price = GetValidFloatInput("Price:\n");
        int stock = GetValidNumberInput("Stock:\n");

        Console.Write("Brand:\n");
        string brand = Console.ReadLine();

        
        DateTime createdAt = DateTime.Now;
        DateTime modifiedAt = DateTime.Now;

        Product newProduct = new Product(barcode, categoryId, productName, productDescription, price, stock, brand, createdAt, modifiedAt);

        

        return newProduct;
    }
}