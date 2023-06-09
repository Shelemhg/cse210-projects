public class ReflectionActivity : Activity{
    private List<string> _questions;
    private int _timePerQuestion;
    
    public ReflectionActivity(){
        _prompts = new List<string>();
        _prompts.Add("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        _prompts.Add("Reflection Activity");
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
        Console.Clear();
        DisplayStartingMessage();
        Thread.Sleep(3000);
        Random rnd = new Random();
        // Select a random message ignoring the first 2 indexes, as they are the description and name of the activity, and send it to the Display Prompt and Questions, for their use.
        int selected = rnd.Next(2, _prompts.Count()-1);
        DisplayPrompt(selected);
        DisplayQuestions(selected);
        DisplayEndingMessage();
    }

    private void DisplayPrompt(int selected){
        Console.Write("- - - - - - - - - - - - - - - - - - - - -");
        Console.Write("\n" + _prompts[selected]);
        Console.Write("\n- - - - - - - - - - - - - - - - - - - - -\n");
    }
    private void DisplayQuestions(int selected){
        for(int i = _questions.Count()-1;i >= 0; i--){
            Console.Write(_questions[i] + "\n");
            DisplaySpinner();
            Console.Clear();
            DisplayPrompt(selected);
        }
        Console.Clear();   
    }

    private void DisplaySpinner(){
        int interval = 250;
        int timmer = _timePerQuestion;
        do{
            Console.Write("|");
            Thread.Sleep(interval);
            Console.Write("\b/");
            Thread.Sleep(interval);
            Console.Write("\b--");
            Thread.Sleep(interval);
            Console.Write("\b\b\\");
            Thread.Sleep(interval);
            Console.Write("\b");
            timmer -= 1000;
        }while(timmer > 0);
    }
}