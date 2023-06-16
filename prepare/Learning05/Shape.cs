class Shape{
    protected string _color;

    public Shape(string color){
        _color = color;
    }
    public virtual string GetColor(){
        return _color;
    }
    public virtual double GetArea(){
        return 0;
    }

}