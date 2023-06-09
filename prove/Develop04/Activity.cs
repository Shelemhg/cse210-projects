public class Activity{
    public string _name;
    public string _description;
    public int _activityDuration;
    protected int _pause;
    public int _startTime;
    public List<string> _prompts;

    protected void SetDuration(){
        Console.Write("\nPlease type the duration of the activity in seconds (min 10): ");
        _activityDuration = Convert.ToInt32(Console.ReadLine()) * 1000;
    }
    protected void PauseToBegin(){
        Console.Write("\nThe activity will begin in 5 seconds.");
        Thread.Sleep(_pause);
        Console.Clear();
    }
    protected void DisplayStartingMessage(){
        Console.Write(_prompts[0]);
    }
    protected void DisplayEndingMessage(){
        Console.Write("You have completed " + _activityDuration/1000 + " seconds of the " + _prompts[1]);
        Thread.Sleep(3000);
        Console.Clear();
    }
}