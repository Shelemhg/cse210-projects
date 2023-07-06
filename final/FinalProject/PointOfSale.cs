class PointOfSale{
    

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
        
        DisplayHorizontalDots();
        DisplayHorizontalDots();
        Console.WriteLine("0. Exit");
    }

}