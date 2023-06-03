public class Assignment{
    public string _studentName;
    protected string _topic;

    protected Assignment(string name, string topic){
        _studentName = name;
        _topic = topic;
    }
    
    public string GetSummary(){
        return _studentName;
    }
}