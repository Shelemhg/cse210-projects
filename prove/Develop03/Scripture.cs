class Scripture {
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    //  defined in SaveScripture Function
    public int _wordCount = 0;
    // public List<int> _hiddenWordsList = new List<int>();
    public Stack<int> _hiddenWordsList = new Stack<int>();
    // private List<int> _delPerTurn = new List<int>();
    private Stack<int> _delPerTurn = new Stack<int>();
    private int _hiddenUpTo = -1;

//  Default constructor in case user rejects typing his own scripture
    public Scripture(){
        
        string defaultScripture = "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them.";

        saveScripture(defaultScripture);
        _reference = new Reference("Ether", "12", "27");
    }
//  Constructor in case user decides to type his own scripture
    public Scripture(string newScripture){
        saveScripture(newScripture);
    }
//  Method that takes the any text as argument, then saves all the words in the _words List variable of the Scripture class.
    public void saveScripture(string newScripture){
        
        string[] words = newScripture.Split(' ');
        
        foreach (var word in words){
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
        _wordCount = _words.Count();
    }

// Method that prints to Console all the words saved in the _words list.
    public void DisplayScripture(){

        string scripture = "";
        foreach(var word in _words){
            scripture += " " + word.Display();
        }
        
        Console.WriteLine(scripture);
        
    }

    public void DisplayReference(){
        Console.WriteLine(_reference.Display());
    }

    private int GenerateAmountToHide(){
        
        Random rnd = new Random();
        int amountToHide;
        if(_hiddenWordsList.Count() < _wordCount * .6){
                amountToHide = rnd.Next(_wordCount/15, _wordCount/7);
            }
            else if(_hiddenWordsList.Count() < _wordCount * .15){
                amountToHide = rnd.Next(_wordCount/23, _wordCount/15);
            }
            else if(_hiddenWordsList.Count() > 3){
                amountToHide = 3;
            }else{
                amountToHide = 1;
            }
            // If the random No. amountToHide happens to be larger than words Visible, then HIDE ONLY the visible amount
            if(amountToHide > _wordCount - _hiddenWordsList.Count()){
               amountToHide = _wordCount - _hiddenWordsList.Count();
            }
            if(amountToHide == 0){
                amountToHide = 1;
            }
        return amountToHide;
    }
//  Main method
    public void HideWords(){                        
        //  1. Select the number of X number of words to hide, the range depends on visible words.
        int amountToHide = GenerateAmountToHide();
        //  The number of words deleted this turn was amountToHide
        _delPerTurn.Push(amountToHide);
        //  Create an array of the same X size as the words we are going to hide.            
        int[] selectedWords = new int[amountToHide];
        // 2. Here we select WHAT words will be hidden. So, we fill the array with random numbers, from 0 to the last word in the array.
        Random rndWordSelection = new Random();

        for (int i = 0; i < amountToHide; i++){
            selectedWords[i] = rndWordSelection.Next(0, _wordCount - 1);
        }
        // Now we know 1. How many words we are going to hide and 2.What words are those we iterate thorugh the list and hide those words.
        for (int i = 0; i < amountToHide; i++){               
            if(_words[selectedWords[i]]._hidden == false){
                _words[selectedWords[i]]._hidden = true;
                _hiddenWordsList.Push(selectedWords[i]);
            }else{
                for(int j = _hiddenUpTo + 1; j < _wordCount; j++, _hiddenUpTo++){
                    //  Starting from 0: If the word is visible, hide it 
                    if(_words[j]._hidden == false){
                        _words[j]._hidden = true;
                        _hiddenWordsList.Push(j);
                        // _hiddenUpTo = j;
                        break;
                    }                        
                    //  If the word is now hidden or was hidden initially, we started from 0, so, UPDATE _hiddenUpTo;     
                    // _hiddenUpTo = j;                   
                }
            }
        }
    }

    public void UnhideWords(){
        // If there are still hidden words...
            if (_hiddenWordsList.Count() > 0 ){
            // Iterate j from 0 up to the number of words deleted the last turn, so we can unhide that many
            for(int j = 0;j < _delPerTurn.Peek(); j++){
                //  CHECK if the word you just unhide has a smaller index than _hiddenUpTo, if that's the case UPDATE _hiddenUpTo with that new value.
                if(_hiddenWordsList.Peek() <= _hiddenUpTo){
                    _hiddenUpTo = _hiddenWordsList.Peek() - 1;
                }
                //  From the list of all the hidden words, UNHIDE the last one
                _words[_hiddenWordsList.Peek()]._hidden = false;
                //  Because it has been unhiden, now REMOVE the index from the list
                _hiddenWordsList.Pop();
            }
            _delPerTurn.Pop();
        }
    }
}