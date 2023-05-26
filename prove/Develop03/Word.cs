
public class Word {
    
    public string _word;
    public Boolean _hidden = false;

    public string Display(){
        if(_hidden == true){
            string wordHidden = null;
            int numOfLetters = _word.Count();
            for(int i = 0; i < numOfLetters; i++){
                wordHidden += "_";
            }
            return wordHidden;
        }else{
            return _word;
        }
        
    }
    public Word (string word){
        _word = word;
    }
}