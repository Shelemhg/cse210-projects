class Scripture {
    public Reference _reference = new Reference();
    public List<Word> _words = new List<Word>();
    public int _wordCount = 0;
    public List<int> _hiddenWordsList = new List<int>();
    private List<int> _delPerTurn = new List<int>();
    public int hiddenUpTo = 0;
    private int[] selectedWords;

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
        // _visibleWords = _wordCount;
    }
// Method that prints to Console all the words saved in the _words list.
    public void DisplayScripture(){

        string scripture = "";
        foreach(var word in _words){
            scripture += " " + word.Display();
        }
        
        Console.WriteLine(scripture);
        
    }
//  Main method
    public void HideWords(){
          // Obtain the total number of words in the _word variable.
            int _amountToHide;
            Random rnd = new Random();
            //  1. Select the number of X number of words to hide, ranging from 1 to 1/5 of the total

            if(_hiddenWordsList.Count() < _wordCount * .6){
                _amountToHide = rnd.Next(_wordCount/10, _wordCount/5);
            }
            else if(_hiddenWordsList.Count() < _wordCount * .15){
                _amountToHide = rnd.Next(_wordCount/20, _wordCount/10);
            }
            else if(_hiddenWordsList.Count() > 3){
                _amountToHide = 3;
            }else{
                _amountToHide = 1;
            }
            _delPerTurn.Add(_amountToHide);

            //  Create an array of the same X size as the words we are going to hide.
            selectedWords = new int[_amountToHide];

            Random randFill = new Random();
            // 2. Here we select WHAT words will be hidden. So, we fill the array with random numbers, from 0 to the last word in the array.

            for (int i = 0; i < _amountToHide; i++){
                selectedWords[i] = randFill.Next(0, _wordCount - 1);
            }
            // Now we know 1. How many words we are going to hide and 2.What words are those.

            //  Now we iterate thorugh the list and hide those words.
            for(int i = 0; i < _amountToHide; i++ ){
                // Are all the words hidden? then ignore this for loop
                if(hiddenUpTo > _wordCount){
                    Console.WriteLine("BRAKE");
                    break;
                }
                if(_words[selectedWords[i]]._hidden == false){
                    _words[selectedWords[i]]._hidden = true;
                    _hiddenWordsList.Add(selectedWords[i]);
                }else{
                    for(int j = hiddenUpTo;j < _wordCount; j++, hiddenUpTo++){
                        if(_words[j]._hidden == false){
                            _words[j]._hidden = true;
                            _hiddenWordsList.Add(j);
                            break;
                        }                        
                    }
                }                
            }
            
    }

    public void UnhideWords(){
        Console.WriteLine("Unhide");
        // If there are still hidden words...
        if(_hiddenWordsList.Count() > 0){
            // Iterate j from 0 up to the number of words deleted the last turn, so we can unhide that many
            for(int j = 0;j < _delPerTurn[_delPerTurn.Count()-1]; j++){
                //????????
                //  From the list of all the hidden words, UNHIDE the last one
                _words[_hiddenWordsList[_hiddenWordsList.Count()-1]]._hidden = false;
                
                //  Not too important but: CHECK if the word you just unhide has a smaller index than hiddenUpTo, so you can update hiddenUpTo with that new value.
                if(_hiddenWordsList[_hiddenWordsList.Count()-1] < hiddenUpTo -1){
                    hiddenUpTo = _hiddenWordsList[_hiddenWordsList.Count()-1];
                }
                //  Because it has been unhiden, now REMOVE the index from the list
                _hiddenWordsList.RemoveAt(_hiddenWordsList.Count()-1);
            }
            _delPerTurn.RemoveAt(_delPerTurn.Count()-1);
        }
    }
}