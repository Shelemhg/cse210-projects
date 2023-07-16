using System.Data.SQLite;

class PointOfSale{

    private List<Cart> _carts;
    private Store _store;
    private DataBaseManager _dataBaseManager;

    public PointOfSale(){

        _carts = new List<Cart>();
        _store = new Store();
        _dataBaseManager = new DataBaseManager();

    }
    
    public Boolean Checkout(Cart cart){
        
        string inputCheckout = "";
        float payment;

        do{
            Console.Clear();
            DisplayHorizontalLine();
            Console.WriteLine("- -        C H E C K O U T        - -");
            DisplayHorizontalLine();
            DisplayItems(cart);
            DisplayHorizontalLine();
            DisplayTotal(cart);

            Console.WriteLine("Enter Money received:\n");
            inputCheckout = Console.ReadLine();

            if(float.TryParse(inputCheckout, out payment)){

                if(cart.TotalCost <= payment){
                    DateTime currentDateTime = DateTime.Now;
                    CompleteTransaction(_store, currentDateTime, cart);
                    return true;
                }else{

                    Console.WriteLine("Insufficent amount. Please try again.");
                    Thread.Sleep(2000);
                }
            }


        }while(inputCheckout != "");

        return false;
    }

    private void CompleteTransaction(Store store, DateTime date, Cart cart){
        
        PrintRecit(store, date, cart);

        foreach(var item in cart.Items){

            _dataBaseManager.UpdateProductStock(item.Barcode, -1);
        }
        Console.Clear();
        Console.WriteLine("Come back soon!");
        Thread.Sleep(2000);
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

            Console.WriteLine(i + ". " + item.ProductName + "  -  $" + item.Price);
            i++;
        }

    }

    public void DisplayTotal(Cart cart){

        DisplayHorizontalDots();
        Console.WriteLine("TOTAL: $" + cart.TotalCost);
        DisplayHorizontalDots();
    }

    // public void LoadNewCart(){
        
    //     Cart cart = new Cart();
        
    //     string input = null;
    //     // Boolean itemFound;
    //     int barcode = 0;

    //     do{
    //         Console.Clear();
    //         DisplayHorizontalLine();
    //         Console.WriteLine("- - -      L O A D    I T E M S       - - -");
    //         DisplayHorizontalLine();
            
    //         DisplayItems(cart);
    //         DisplayTotal(cart);

    //         Console.WriteLine("\nPress \"0\" and hit ENTER to go to Checkout.");
    //         Console.WriteLine("Press \"3\" to scan and DELETE an Item.");
    //         Console.WriteLine("\nType Barcode:\n");
    //         input = Console.ReadLine();

    //         if(int.TryParse(input, out barcode)){
                                      
    //             switch(input){

    //                 case "0":
    //                     Boolean result = Checkout(cart);

    //                     if(result){
    //                         return;
    //                     }else{
    //                         break;
    //                     }                        
                    
    //                 case "3":
    //                     // DeleteItem(barcode);
    //                     break;
                    
    //                 default:

    //                     try{
                            
    //                         Product product = _dataBaseManager.SearchBarcode(barcode, cart);

    //                         if(product != null){
    //                             cart.AddItem(product);
    //                         }else{
    //                             Console.WriteLine("\nProduct NOT FOUND");
    //                             Thread.Sleep(2000);
    //                         }
    //                         // itemFound = SearchBarcode(barcode, cart);
    //                     }catch(Exception ex){
    //                         HandleException(ex);
    //                     }

    //                     break;

    //             }
    //         }
            

    //     }while(input != "");
    // }

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
    private void PrintRecit(Store store, DateTime date, Cart cart){

        DisplayHorizontalLine();
        Console.WriteLine("- -      " + store.Name + "     - -");
        Console.WriteLine(date);
        // Console.WriteLine(store.Address + " - " + store.PhoneNumber);
        // Console.WriteLine("ST# {store.ID} OP# {employee.ID} ");
        DisplayHorizontalLine();
        DisplayTotal(cart);


    }



}