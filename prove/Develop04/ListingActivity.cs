public class ListingActivity : Activity{
    private int _timePerQuestion;
    
    public ListingActivity(){
        _prompts = new List<string>();
        _prompts.Add("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        _prompts.Add("Listing Activity");
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }







    public void RunListing(){
        Console.Clear();
        DisplayStartingMessage();
        Thread.Sleep(3000);
        SetDuration();
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

    private void DisplaySpinner(){
        // int interval = 250;
        // int currentTime = _timePerQuestion;
        do{
            
            
        }while(timmer > 0);
    }
}