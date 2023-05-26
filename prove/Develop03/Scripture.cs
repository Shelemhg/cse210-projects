class Scripture {
    public Reference _reference = new Reference();
    public List<Word> _words = new List<Word>();
    public int _visibleWords;
    public int wordCount;
    private List<int> _hiddenWords = new List<int>();

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
        wordCount = _words.Count();
        _visibleWords = wordCount;
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
    public void StartHidding(){
          // Obtain the total number of words in the _word variable.
        int hiddenUpTo = 0;
        _hiddenWords.Clear();
            
            Random rnd = new Random();
            //  1. Select the number of X number of words to hide, ranging from 1 to 1/5 of the total
            
            int amountToHide;

            if(_visibleWords > 15){
                amountToHide = rnd.Next(3, _visibleWords/5);
            }
            else if(_visibleWords > 6){
                amountToHide = 3;
            }
            else{
                amountToHide = 2;
            }


            // Console.WriteLine("AMOUNT TO HIDE: " + amountToHide);
            //  Create an array of the same X size as the words we are going to hide.
            int[] selectedWords = new int[amountToHide];
            
            Random randFill = new Random();
            // 2. Here we select WHAT words will be hidden. So, we fill the array with random numbers, from 0 to the last word in the array.
            for (int i = 0; i < amountToHide; i++){
                selectedWords[i] = randFill.Next(0, wordCount - 1);
            }
            // Now we know 1. How many words we are going to hide and 2.What words are those.

            //  Now we iterate thorugh the list and hide those words.
            for(int i = 0; i < amountToHide; i++ ){
                
                if(_words[selectedWords[i]]._hidden == false){
                    _words[selectedWords[i]]._hidden = true;
                    _hiddenWords.Add(selectedWords[i]);
                }else{
                    for(int j = hiddenUpTo;j < wordCount; j++, hiddenUpTo++){
                        // Console.WriteLine("PALABRA: " + j + " = " + _words[j]._word);
                        if(_words[j]._hidden == false){
                            _words[j]._hidden = true;
                            _hiddenWords.Add(j);
                            break;
                        }
                        if(hiddenUpTo >= wordCount){
                            amountToHide = 0;
                            // key = "quit";
                            break;
                        }
                    }
                }
            }
            _visibleWords -= amountToHide;
            Console.WriteLine("WORDS VISIBLE: " + _visibleWords);
            // Console.WriteLine("hiddenUpTo: " + hiddenUpTo);
            // Console.Clear();
            DisplayScripture();
            // Console.WriteLine("HIDDEN WORDS: " + _hiddenWords);
            // for(int i = 0; i<_hiddenWords.Count; i++){
            //     Console.WriteLine(_hiddenWords[i]);
            // }
    }
}