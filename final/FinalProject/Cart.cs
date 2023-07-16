public class Cart{

    private List<Product> _items;
    private int _numberOfItems;
    private float _totalDiscount;
    private float _tax;
    private float _totalCost;


    public List<Product> Items { get { return _items; } private set { _items = value; } }

    public int NumberOfItems { get { return _numberOfItems; } private set { _numberOfItems = value; } }

    public float Discount { get { return _totalDiscount; } private set { _totalDiscount = value; } }

    public float Tax { get { return _tax; } private set { _tax = value; } }

    public float TotalCost { get { return _totalCost; } private set { _totalCost = value; } }


    public Cart(){
        _items = new List<Product>();
        _totalCost = 0;
    }

    public void AddItem(Product product){
        _items.Add(product);
        _totalCost += product.Price;
    }

    public Boolean Checkout(){
        
        string inputCheckout = "";
        float payment;

        do{
            Console.Clear();
            DisplayHorizontalLine();
            Console.WriteLine("- -        C H E C K O U T        - -");
            DisplayHorizontalLine();
            DisplayItems();
            DisplayHorizontalLine();
            DisplayTotal();
            DisplayHorizontalLine();
            Console.WriteLine("Enter Money received:\n");
            inputCheckout = Console.ReadLine();

            if(float.TryParse(inputCheckout, out payment)){

                if(TotalCost <= payment){

                    DateTime currentDateTime = DateTime.Now;
                    double result = payment - TotalCost;
                    double change = Math.Round(result,2);
                    Console.WriteLine($"\nCHANGE: {change}\n");
                    // CompleteTransaction(dataBaseManager, currentDateTime);
                    Console.Clear();
                    PrintRecit(currentDateTime);
                    
                    return true;

                }else{

                    Console.WriteLine("\nInsufficent amount. Please try again.\n");
                    Thread.Sleep(2000);
                }
            }

        }while(inputCheckout != "");

        return false;
    }

    protected void DisplayHorizontalLine(){
        
        Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
    }

    public void DisplayItems(){
        
        int i = 1;

        foreach(Product item in _items){

            Console.WriteLine(i + ". " + item.ProductName + "  -  $" + item.Price);
            i++;
        }

    }

    public void DisplayTotal(){
        
        Console.WriteLine("TOTAL: $" + _totalCost);
    }

    private void PrintRecit( DateTime date){

        DisplayHorizontalLine();
        Console.WriteLine("- -          R E C E I P T        - -");
        Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
        Console.WriteLine("- -   C O R N E R    S T O R E    - -");
        Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
        Console.WriteLine(date);
        // Console.WriteLine(store.Address + " - " + store.PhoneNumber);
        // Console.WriteLine("ST# {store.ID} OP# {employee.ID} ");
        DisplayHorizontalLine();
        DisplayTotal();
    }




    public void RemoveItem(){}
    public void CreateTicket(){}

    
}