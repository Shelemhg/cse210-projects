public class BreathingActivity : Activity{
    
    public BreathingActivity(){
        
        _activityName ="Breathing Activity";
        _activityDescription = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.\n";
        _prompts = new List<string>();
        _pause = 5; // In seconds
    }

    public void RunBreathing(){
        Console.Clear();
        
        DisplayStartingMessage();
        Thread.Sleep(4000);

        SetDuration();
        Console.Clear();

        PauseToBegin();
        double timmer = _activityDuration;

        do{
            Console.Clear();
            BreadIn();
            BreadOut();
            timmer -=10;
        }while(timmer > 0);
        if (_activityDuration < 10){
            _activityDuration = 10;
        }        
        _numOfActivities += 1;
        DisplayEndingMessage();        
        Thread.Sleep(4000);
        Console.Clear();
        _numOfActivities += 1;
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