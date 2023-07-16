class Store
{
    private string _storeID;
    private string _storeName;
    private string _storeAddress;
    private string _email;
    private string _phoneNumber;
    private string _zipCode;

    public Store(){
        
        _storeID = "1111";
        _storeName = "SAMPLE STORE";
        _storeAddress = "123 Main St";
        _email = "example@store.com";
        _phoneNumber = "123-456-7890";
        _zipCode = "12345";
    }
    
    public string ID { get { return _storeID; } private set { _storeID = value; } }

    public string Name { get { return _storeName; } set { _storeName = value; } }

    public string Address { get { return _storeAddress; } set { _storeAddress = value; } }

    public string Email { get { return _email; } set { _email = value; } }

    public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }

    public string ZipCode { get { return _zipCode; } set { _zipCode = value; } }
}