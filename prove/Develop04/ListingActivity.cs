public class ListingActivity : Activity{
    private List<string> _ideas;
    
    public ListingActivity(){
        
        _activityName ="Listing Activity";
        _activityDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n";
        _pause = 8; // In seconds

        _prompts = new List<string>();
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
        _ideas = new List<string>();
    }

    public void RunListing(){
        Random rnd = new Random();
        // Select a random message. Then send it to the Display Prompt and Questions, for their use.
        int numSelected = rnd.Next(0, _prompts.Count()-1);

        Console.Clear();
        DisplayStartingMessage();
        Thread.Sleep(3000);
        
        SetDuration();
        Console.Clear();

        for(int i = _pause; i > 0; i--){
            Console.Clear();
            // Console.Write("\nPonder the prompt.\n");
            DisplayPrompt(numSelected);
            Console.Write("The activity will begin in: ");
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        DateTime startTime = DateTime.Now;
        GetIdeas(numSelected);
        Console.Clear();

        DateTime endTime = DateTime.Now;
        TimeSpan elapsedTime = endTime - startTime;
        _activityDuration = Math.Round(elapsedTime.TotalSeconds, 1);

        DisplayIdeas();
        Thread.Sleep(3000);

        
        _numOfActivities += 1;
        DisplayEndingMessage();        
        Thread.Sleep(5000);
        Console.Clear();
    }

    private void GetIdeas(int numSelected){
        
        DateTime endTime = DateTime.Now.AddSeconds(_activityDuration); 
        do{
            Console.Clear();
            DisplayPrompt(numSelected);
            Console.Write("\nType your idea and hit Enter:\n");
            _ideas.Add(Console.ReadLine());
        }while(DateTime.Now < endTime);
    }

    private void DisplayIdeas(){
        for(int i = 0; i < _ideas.Count(); i++){
            Console.Write(i+1 + ". " + _ideas[i] + "\n");
        }
    }
}