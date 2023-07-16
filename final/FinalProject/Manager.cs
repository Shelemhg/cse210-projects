class Manager : Employee {
    
    public Manager(int id, string firstName, string lastName, string email, string phoneNumber, string address, string zipCode, string city, string state, string country, string position){
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
        Console.WriteLine($"{FirstName} {LastName} - {Position}");
        DisplayHorizontalLine();
        Console.WriteLine("1. New Cart");
        Console.WriteLine("2. Check Item Price");
        DisplayHorizontalLine();
        Console.WriteLine("3. Add New Item");
        Console.WriteLine("4. Show Store Inventory");
        DisplayHorizontalLine();
        Console.WriteLine("5. Add New Employee");
        Console.WriteLine("6. Show Employees' Info");
        DisplayHorizontalDots();
        Console.WriteLine("0. Logout");
    }
}