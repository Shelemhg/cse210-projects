class Person
{
    protected string _id;
    protected string _firstName;
    protected string _lastName;
    protected string _email;
    protected string _phoneNumber;
    protected string _address;
    protected string _zipCode;
    protected string _city;
    protected string _state;
    protected string _country;

    public string ID { get { return _id; } private set { _id = value; } }

    public string FirstName { get { return _firstName; } set { _firstName = value; } }

    public string LastName { get { return _lastName; } set { _lastName = value; } }

    public string Email { get { return _email; } set { _email = value; } }

    public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }

    public string Address { get { return _address; } set { _address = value; } }

    public string ZipCode { get { return _zipCode; } set { _zipCode = value; } }
}