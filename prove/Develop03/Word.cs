
public class Word {
    
    private string _word = "";
    private Boolean _hidden = false;

    public string Display(){
        return _word;
    }
    public Word(string word){
        _word = word;
    }
}