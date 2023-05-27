class Scripture {
    public Reference _reference = new Reference();
    public List<Word> _words = new List<Word>();
    public int _wordCount = 0;
    public List<int> _hiddenWordsList = new List<int>();
    // private List<int> _delPerTurn = new List<int>();
    private Stack<int> _delPerTurn = new Stack<int>();
    public int _hiddenUpTo = -1;

//  Default constructor in case user rejects typing his own scripture
    public Scripture(){
        
        string defaultScripture = "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them.";

        saveScripture(defaultScripture);
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

    public int GenerateAmountToHide(){
        
        Random rnd = new Random();
        int amountToHide;
        if(_hiddenWordsList.Count() < _wordCount * .6){
                amountToHide = rnd.Next(_wordCount/10, _wordCount/5);
            }
            else if(_hiddenWordsList.Count() < _wordCount * .15){
                amountToHide = rnd.Next(_wordCount/20, _wordCount/10);
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
        return amountToHide;
    }
//  Main method
    public void HideWords(){
          // Obtain the total number of words in the _word variable.
                        
            //  1. Select the number of X number of words to hide, the range depends on visible words.
            int amountToHide = GenerateAmountToHide();
            //  The number of words deleted this turn was amountToHide
            _delPerTurn.Push(amountToHide);
            //  Create an array of the same X size as the words we are going to hide.
            // selectedWords.Clear();
            // Array.Clear(selectedWords, 0, selectedWords.Length);
            
            int[] selectedWords = new int[amountToHide];
            // 2. Here we select WHAT words will be hidden. So, we fill the array with random numbers, from 0 to the last word in the array.
            Random rndWordSelection = new Random();

            for (int i = 0; i < amountToHide; i++){
                selectedWords[i] = rndWordSelection.Next(0, _wordCount - 1);
            }
            // Now we know 1. How many words we are going to hide and 2.What words are those.

            //  Now we iterate thorugh the list and hide those words.
            for (int i = 0; i < amountToHide; i++){               
                if(_words[selectedWords[i]]._hidden == false){
                    _words[selectedWords[i]]._hidden = true;
                    _hiddenWordsList.Add(selectedWords[i]);
                }else{
                    for(int j = _hiddenUpTo + 1; j < _wordCount; j++){
                        //  Starting from 0, if the word is visible, hide it 
                        if(_words[j]._hidden == false){
                            _words[j]._hidden = true;
                            _hiddenWordsList.Add(j);
                            _hiddenUpTo = j;
                            break;
                        }
                        _hiddenUpTo = j;
                        //  If the word is now hidden or was hidden, we started from 0, so, Update _hiddenUpTo;                        
                    }
                }
            }
            // for(int i = 0; i < amountToHide; i++ ){
            //     // Are all the words hidden? then ignore this for loop
            //     if(_hiddenUpTo > _wordCount){
            //         Console.WriteLine("BRAKE");
            //         break;
            //     }
            //     if(_words[selectedWords[i]]._hidden == false){
            //         _words[selectedWords[i]]._hidden = true;
            //         _hiddenWordsList.Add(selectedWords[i]);
            //     }else{
            //         for(int j = _hiddenUpTo;j < _wordCount; j++, _hiddenUpTo++){
            //             if(_words[j]._hidden == false){
            //                 _words[j]._hidden = true;
            //                 _hiddenWordsList.Add(j);
            //                 break;
            //             }                        
            //         }
            //     }                
            // }
            
    }

    public void UnhideWords(){
        // Console.WriteLine("Unhide");
        // If there are still hidden words...
        // if (_hiddenWordsList.Count() > 0 && _hiddenWordsList[_hiddenWordsList.Count - 1] < _words.Count){
            if (_hiddenWordsList.Count() > 0 ){
            // Iterate j from 0 up to the number of words deleted the last turn, so we can unhide that many
            for(int j = 0;j < _delPerTurn.Peek(); j++){
                //  Not too important but: CHECK if the word you just unhide has a smaller index than _hiddenUpTo, so you can update _hiddenUpTo with that new value.
                if(_hiddenWordsList[_hiddenWordsList.Count()-1] <= _hiddenUpTo){
                    _hiddenUpTo = _hiddenWordsList[_hiddenWordsList.Count()-1]-1;
                }
                //???????? It fails some times, like 1 in 20 attempts, wtf
                //  From the list of all the hidden words, UNHIDE the last one
                _words[_hiddenWordsList[_hiddenWordsList.Count()-1]]._hidden = false;
                //  Because it has been unhiden, now REMOVE the index from the list
                _hiddenWordsList.RemoveAt(_hiddenWordsList.Count()-1);
            }
            _delPerTurn.Pop();
        }
    }
}