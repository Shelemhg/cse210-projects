public class Activity{
    protected string _name;
    protected string _description;
    protected int _activityDuration;
    protected int _pause;
    protected List<string> _prompts;

    protected void SetDuration(){
        Console.Write("\nPlease type the duration of the activity in seconds (minimum 10): ");
        _activityDuration = Convert.ToInt32(Console.ReadLine());
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
        Console.Write(_description + "\n");
    }

    protected void DisplayEndingMessage(){
        Console.Write("You have completed " + _activityDuration + " seconds of the " + _name);
    }
}