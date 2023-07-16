class Employee : Person{

    protected string _position;
    private List<Cart> _carts;
    private Store _store;
    public DataBaseManager _dataBaseManager;

    public string Position { get { return _position; }}
   


    protected void CheckPrice(){
        
        Cart cart = new Cart();
        
        string input = null;
        int barcode = 0;

        do{
            Console.Clear();
            DisplayHorizontalLine();
            Console.WriteLine("- - -   C H E C K    P R I C E   - - -");
            DisplayHorizontalLine();

            Console.WriteLine("\nType Barcode or Hit ENTER to return:\n");
            input = Console.ReadLine();
            
            if(input == ""){
                break;
            }

            if(int.TryParse(input, out barcode)){
                                      
                try{
                            
                    Product product = _dataBaseManager.SearchBarcode(barcode);

                    if(product != null){

                        DisplayHorizontalLine();
                        Console.WriteLine("\n" + product.ProductName + "  -  $" + product.Price + "\n");
                        DisplayHorizontalLine();
                        Thread.Sleep(2000);

                    }else{

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nProduct NOT FOUND");
                        Console.ResetColor();
                    }
                    
                }catch(Exception ex){
                    HandleException(ex);
                }

            }else{

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nProduct NOT FOUND");
                Console.ResetColor();
                Thread.Sleep(2000);
            }

        }while(input != "");
    }

    protected void DisplayHorizontalLine(){
        
        Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
    }

    protected void DisplayHorizontalDots(){
        
        Console.WriteLine(". . . . . . . . . . . . . . . . . . .");
    }

    public virtual void DisplayMenu(){

        DisplayHorizontalLine();
        Console.WriteLine("- -   P O I N T   O F   S A L E   - -");
        DisplayHorizontalLine();
         Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"        {FirstName} {LastName} - {Position}");
        Console.ResetColor();
        DisplayHorizontalLine();
        Console.WriteLine("1. New Cart");
        Console.WriteLine("2. Check Item Price");
        DisplayHorizontalDots();
        Console.WriteLine("0. Logout\n");
    }
    
    protected void LoadNewCart(){
        
        Cart cart = new Cart();
        
        string input = null;
        int barcode = 0;

        while(true){

            Console.Clear();
            Console.WriteLine("Items go from barcode: 1000-1012\n");
            DisplayHorizontalLine();
            Console.WriteLine("- - -   S C A N    I T E M S    - - -");
            DisplayHorizontalLine();
            
            cart.DisplayItems();
            DisplayHorizontalDots();
            cart.DisplayTotal();
            DisplayHorizontalDots();

            Console.WriteLine("\nPress \"0\" and hit ENTER to go to Checkout.");
            // Console.WriteLine("Press \"3\" to scan and DELETE an Item.");
            Console.WriteLine("\nType Barcode:\n");
            input = Console.ReadLine();

            if(int.TryParse(input, out barcode)){
                                      
                switch(input){

                    case "0":
                        Boolean result = cart.Checkout();

                        if(result){

                            foreach(var item in cart.Items){

                                _dataBaseManager.UpdateProductStock(item.Barcode, -1);
                            }

                            Console.WriteLine("\nCome back soon!");
                            Thread.Sleep(6000);
                            return;

                        }else{
                            break;
                        }                        
                    
                    case "3":
                        // DeleteItem(barcode);
                        break;
                    
                    default:

                        try{
                            
                            Product product = _dataBaseManager.SearchBarcode(barcode);

                            if(product != null){

                                cart.AddItem(product);
                            
                            }else{

                                Console.WriteLine("\nProduct NOT FOUND");
                                Thread.Sleep(2000);
                            }

                        }catch(Exception ex){
                            HandleException(ex);
                        }

                        break;

                }
            }
            

        }
    }

    public virtual void LoadPointOfSale(){
        
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
            }


        }while(menuChoice != "0");

        Console.Clear();
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

    // private void PrintRecit(Store store, Terminal terminal, DateTime date, Person employee, Cart cart){

}