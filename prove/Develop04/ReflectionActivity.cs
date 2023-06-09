public class ReflectionActivity : Activity{
    
    public ReflectionActivity(){
        _prompts = new List<string>();
        _prompts.Add("This activity will help you relax by walking your through reflection in and out slowly. Clear your mind and focus on your reflection.");
        _prompts.Add("Reflection Activity");
    }
    public void RunReflection(){
        Console.Write(_prompts[0]);
        SetDuration();
        PauseToBegin();
        int timmer = _duration;

        do{
            BreadIn();
            BreadOut();
            timmer -=10000;
        }while(timmer > 0);

        DisplayEndingMessage();
    }

    private void BreadIn(){
        Console.Write("Breath In...\n ");
        for(int i = 4;i >= 0; i--){
            Console.Write("\b" + i);
            Thread.Sleep(1000);
        }
        Console.Clear();     
    }
    private void BreadOut(){
        Console.Write("Breath Out...\n ");
        for(int i = 4;i >= 0; i--){
            Console.Write("\b" + i);
            Thread.Sleep(1000);
        }
        Console.Clear();   
    }
}