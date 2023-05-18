public class Fraction{
    public int _top;
    public int _bottom;

    public Fraction(){
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int num){
        _top = num;
        _bottom = 1;
    }
    public Fraction(int num, int den){
        _top = num;
        _bottom = den;
    }
}