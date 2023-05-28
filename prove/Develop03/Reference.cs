public class Reference {
    private string _book;
    private string _chapter;
    private string _verse;

    public string Display(){
        return "- " + _book + " " + _chapter + ":" + _verse;
    }

    public Reference(){        
    }
    public Reference(string book){
        _book = book;
    }
    public Reference(string book, string chapter){
        _book = book;
        _chapter = chapter;
    }
    public Reference(string book, string chapter, string verse){
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }
}