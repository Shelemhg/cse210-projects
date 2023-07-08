class Cart{

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
    }


    public void AddItem(Product product){
        _items.Add(product);
    }

    
}