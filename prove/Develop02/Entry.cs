
public class Entry {
    
    // public DateTime _date = DateTime.Now;
    public string _date = "";
    public string _prompt = "";
    public string _response = "";

    public void Display(){
        Console.WriteLine(_date + "\n" + _prompt + '\n' + _response);
    }
}