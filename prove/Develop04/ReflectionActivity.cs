public class ReflectionActivity : Activity{
    private List<string> _questions;
    private int _timePerQuestion;
    
    public ReflectionActivity(){
       
       _activityName ="Reflection Activity";
        _activityDescription = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n";
       
        _prompts = new List<string>();
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");
        _questions = new List<string>{"Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"};
        // Here we set how long we wait per question
        _timePerQuestion = 5000;
        _activityDuration = _timePerQuestion * _questions.Count();
    }

    public void RunReflection(){
        
        Random rnd = new Random();
        // Select a random message, and then send it to the Display Prompt and Questions, for their use.
        int numSelected = rnd.Next(0, _prompts.Count()-1);

        Console.Clear();
        DisplayStartingMessage();
        Thread.Sleep(2000);

        SetDuration();      
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DisplayPrompt(numSelected);
        Thread.Sleep(3000);

        DisplayQuestions(numSelected);
        Console.Clear(); 

        
        _numOfActivities += 1;
        DateTime endTime = DateTime.Now;
        TimeSpan elapsedTime = endTime - startTime;
        _activityDuration = Math.Round(elapsedTime.TotalSeconds, 1);
        DisplayEndingMessage();
        Thread.Sleep(4000);
        Console.Clear();
    }

    private void DisplayQuestions(int numSelected){
        DateTime endTime = DateTime.Now.AddSeconds(_activityDuration); 
        int i = 0;
        do{
            Console.Write(_questions[i] + "\n");
            i++;
            DisplaySpinner();
            Console.Clear();
            DisplayPrompt(numSelected);
            if(i == _questions.Count()-1){
                i = 0;
            }
        }while(DateTime.Now < endTime);
          
    }

    private void DisplaySpinner(){
        int interval = 250;
        int timmer = _timePerQuestion;
        do{
            Console.Write("| ");
            Thread.Sleep(interval);
            Console.Write("\b\b/ ");
            Thread.Sleep(interval);
            Console.Write("\b\b--");
            Thread.Sleep(interval);
            Console.Write("\b\b\\ ");
            Thread.Sleep(interval);
            Console.Write("\b\b");
            timmer -= 1000;
        }while(timmer > 0);
    }
}