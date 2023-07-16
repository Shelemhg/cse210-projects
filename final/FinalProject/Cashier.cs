class Cashier : Employee {

    public Cashier(){
        
    }

    public Cashier(string id, string firstName, string lastName, string email, string phoneNumber, string address, string zipCode, string city, string state, string country, string position){
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
}