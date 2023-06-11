public class Activity{
    protected string _activityName;
    protected string _activityDescription;
    protected double _activityDuration;
    protected int _pause;
    protected List<string> _prompts;
    protected int _numOfActivities = 0;

    protected void SetDuration(){
        int number;
        bool isPositiveInt;
        
        do{
            Console.Clear();
            DisplayStartingMessage();
            Console.Write("\nPlease type the duration of the activity in seconds (min. 10s): ");
            string input = Console.ReadLine();
            isPositiveInt = int.TryParse(input, out number) && number > 0;
        }while(!isPositiveInt);
        _activityDuration = number;
    }

    protected void PauseToBegin(){
        
        for(int i = _pause; i > 0; i--){
            // DisplayStartingMessage();
            Console.Clear();
            Console.Write("The activity will begin in: ");
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
    }

    protected void DisplayStartingMessage(){
        Console.Write(_activityDescription + "\n");
    }

    protected void DisplayEndingMessage(){
        Console.Write("You have completed " + _activityDuration + " seconds of the " + _activityName + ". And a total of " + _numOfActivities + " activities.");
    }
    protected void DisplayPrompt(int numSelected){
        Console.Write("- - - - - - - - - - - - - - - - - - - - -");
        Console.Write("\n" + _prompts[numSelected]);
        Console.Write("\n- - - - - - - - - - - - - - - - - - - - -\n");
    }
}