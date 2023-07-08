class Product{

    private int _productId;
    private int _barcode;
    private int _categoryId;
    private string _productName;
    private string _productDescription;
    private float _price;
    private int _stockQuantity;
    private string _brand;
    private DateTime _createdAt;
    private DateTime _modifiedAt;


    public Product(){
        
    }

    public Product(int barcode, int categoryId, string productName, string productDescription, float price, int stockQuantity, string brand, DateTime createdAt, DateTime modifiedAt){

        _barcode = barcode;
        _categoryId = categoryId;
        _productName = productName;
        _productDescription = productDescription;
        _price = price;
        _stockQuantity = stockQuantity;
        _brand = brand;
        _createdAt = createdAt;
        _modifiedAt = modifiedAt;
    }

    public int Barcode { get { return _barcode; } private set { _barcode = value; } }

    public int CategoryId { get { return _categoryId; } private set { _categoryId = value; } }

    public DateTime CreatedAt { get { return _createdAt; } private set { _createdAt = value; } }

    public DateTime ModifiedAt { get { return _modifiedAt; } private set { _modifiedAt = value; } }

    public string Brand { get { return _brand; } private set { _brand = value; } }

    public string ProductDescription { get { return _productDescription; } private set { _productDescription = value; } }

    public float Price { get { return _price; } private set { _price = value; } }

    public string ProductName { get { return _productName; } private set { _productName = value; } }

    public int ProductId { get { return _productId; } private set { _productId = value; } }

    public int Stock { get { return _stockQuantity; } private set { _stockQuantity = value; } }


}