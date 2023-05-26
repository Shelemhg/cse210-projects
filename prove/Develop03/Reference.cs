/*
Exceeding Requirements:


For this program I:


1. Added the posibility for the user to type any scripture or text he wishes and then work with it to run the program.

2. The program can take both scriptures or random texts.
*/




public class Reference {
    private string _book;
    private string _chapter;
    private string _verse;

    public string Display(){
        return _book + " " + _chapter + ":" + _verse;
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