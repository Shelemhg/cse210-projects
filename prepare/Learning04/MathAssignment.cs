public class MathAssignment : Assignment{
    
    private string _textbookSection;
    private string _problems;

    MathAssignment(string name,string topic, string textbook, string problem) : base( textbook, problem){
        _studentName = name;
        _topic = topic;
    }
    public string GetHomeworkList(){
        return "got Homework List";
    }
    
}
