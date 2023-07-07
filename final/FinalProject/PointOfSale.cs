class PointOfSale{
    
    public void CreateNewCart(){
        Cart cart = new Cart();
        LoadItems();
    }

    public void DisplayHorizontalLine(){
        
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - -");
    }

    private void DisplayHorizontalDots(){
        
        Console.WriteLine(". . . . . . . . . . . . . . . . . . . . . .");
    }

    public void DisplayMenu(){

        DisplayHorizontalLine();
        Console.WriteLine("- - -    P O I N T   O F   S A L E    - - -");
        DisplayHorizontalLine();
        Console.WriteLine("1. New Cart");
        Console.WriteLine("2. Check Item Price");
        Console.WriteLine("2. Check Item Price");
        
        DisplayHorizontalDots();
        DisplayHorizontalDots();
        Console.WriteLine("0. Exit");
    }
    
    public void DisplayItems(){


    }

    private void LoadItems(){
        string barcode = null;
        do{
            Console.Clear();
            DisplayHorizontalLine();
            Console.WriteLine("- - -      L O A D    I T E M S       - - -");
            DisplayHorizontalLine();
            DisplayItems();
            DisplayHorizontalDots();
            Console.WriteLine("\nType Barcode:\n");
            barcode = Console.ReadLine();
            
            

        }while(barcode != "");
    }

}