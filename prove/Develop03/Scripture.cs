class Scripture {
    public Reference _reference = new Reference();
    public List<Word> _words = new List<Word>();
    public int _wordCount = 0;
    // public int _visibleWords = 0;
    public int _amountToHide = 0;    
    public List<int> _hiddenWordsList = new List<int>();
    private List<int> _numHiddenList = new List<int>();
    public int hiddenUpTo = 0;

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
        
        // _hiddenWordsList.Clear();
            
            Random rnd = new Random();
            //  1. Select the number of X number of words to hide, ranging from 1 to 1/5 of the total
            
            _amountToHide = 0;

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
            _numHiddenList.Add(_amountToHide);

            // Console.WriteLine("AMOUNT TO HIDE: " + _amountToHide);
            //  Create an array of the same X size as the words we are going to hide.
            int[] selectedWords = new int[_amountToHide];
            
            Random randFill = new Random();
            // 2. Here we select WHAT words will be hidden. So, we fill the array with random numbers, from 0 to the last word in the array.

            // Console.WriteLine("Amount to hide: " + _amountToHide);
            for (int i = 0; i < _amountToHide; i++){
                selectedWords[i] = randFill.Next(0, _wordCount - 1);
            }
            // Now we know 1. How many words we are going to hide and 2.What words are those.

            //  Now we iterate thorugh the list and hide those words.
            for(int i = 0; i < _amountToHide; i++ ){
                
                if(_words[selectedWords[i]]._hidden == false){
                    _words[selectedWords[i]]._hidden = true;
                    _hiddenWordsList.Add(selectedWords[i]);
                    // Console.WriteLine("hidden word: " + _words[selectedWords[i]]._word);
                }else{
                    for(int j = hiddenUpTo;j < _wordCount; j++, hiddenUpTo++){
                        // Console.WriteLine("PALABRA: " + j + " = " + _words[j]._word);
                        if(_words[j]._hidden == false){
                            _words[j]._hidden = true;
                            _hiddenWordsList.Add(j);
                            // Console.WriteLine("hidden word: " + _words[j]._word);
                            break;
                        }
                        if(hiddenUpTo >= _wordCount){
                            // _amountToHide = 0;
                            // key = "quit";
                            break;
                        }
                    }
                }                
            }



            // Console.WriteLine("No. of hidden WORDS: " + _hiddenWordsList.Count());
            // for(int i = 0; i<_hiddenWordsList.Count(); i++){
            //     Console.WriteLine(_hiddenWordsList[i] + " : " + _words[_hiddenWordsList[i]]._word);
            // }
            // _visibleWords -= _amountToHide;
            // Console.WriteLine("WORDS VISIBLE: " + _visibleWords);
            // Console.WriteLine("hiddenUpTo: " + hiddenUpTo);
            // Console.Clear();
            
            // Console.WriteLine("HIDDEN WORDS: " + _hiddenWordsList);
            // for(int i = 0; i<_hiddenWordsList.Count(); i++){
            //     Console.WriteLine(_hiddenWordsList[i]);
                
                
            // }
            // for(int i = 0; i<_numHiddenList.Count(); i++){
            //     Console.WriteLine("NumHidden: "+ _numHiddenList[i]);
                
                
            // }
            // Console.WriteLine("Items: "+ _numHiddenList.Count());
            
    }

    public void unhideWords(){
        // Console.WriteLine("No. of hidden WORDS: " + _hiddenWordsList.Count());
        //     for(int i = 0; i<_hiddenWordsList.Count(); i++){
        //         Console.WriteLine(_hiddenWordsList[i] + " : " + _words[_hiddenWordsList[i]]._word);
        //     }

        if(_hiddenWordsList.Count() > 0){

            for(int j = 0;j < _numHiddenList[_numHiddenList.Count()-1]; j++){
                _words[_hiddenWordsList[_hiddenWordsList.Count()-1]]._hidden = false;
                _hiddenWordsList.RemoveAt(_hiddenWordsList.Count()-1);
            }
            
        // Console.WriteLine("I'm going to unhide: " + _numHiddenList[_numHiddenList.Count()-1]);
            _numHiddenList.RemoveAt(_numHiddenList.Count()-1);
            // Console.WriteLine("No. of hidden WORDS: " + _hiddenWordsList.Count());
            // for(int i = 0; i<_hiddenWordsList.Count(); i++){
            //     Console.WriteLine(_hiddenWordsList[i] + " : " + _words[_hiddenWordsList[i]]._word);
            // }
        }
        // for(int i = 0; i<_numHiddenList.Count(); i++){
        //         Console.WriteLine("NumHidden: "+ _numHiddenList[i]);
            
                
        //     }
    }
}