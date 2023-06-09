public class BreathingActivity : Activity{
    
    public BreathingActivity(){
        _prompts = new List<string>();
        _prompts.Add("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        _prompts.Add("Breading Activity");
        _pause = 1000;
    }
    public void RunBreathing(){
        Console.Clear();
        DisplayStartingMessage();
        SetDuration();
        PauseToBegin();
        int timmer = _activityDuration;

        do{
            BreadIn();
            BreadOut();
            timmer -=10000;
        }while(timmer > 0);

        DisplayEndingMessage();
    }

    private void BreadIn(){
        Console.Write("Breath In...\n  ");
        for(int i = 4;i >= 0; i--){            
            Thread.Sleep(1000);
            Console.Write("\b\b" + i + " ");
        }
        Console.Clear();     
    }
    private void BreadOut(){
        Console.Write("Breath Out...\n  ");
        for(int i = 4;i >= 0; i--){
            Thread.Sleep(1000);
            Console.Write("\b\b" + i + " ");
        }
        Console.Clear();   
    }
}