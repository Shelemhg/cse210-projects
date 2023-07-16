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
}