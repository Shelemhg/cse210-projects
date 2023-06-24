class Manager{
    private int _totalScore;
    private List<Goal> _goals;

    public Manager(){
        _totalScore = 0;
        _goals = new List<Goal>();
    }
    public void DisplayMenu(){
        Console.Clear();
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - ");
        Console.WriteLine("-    E T E R N A L     Q U E S T    -");
        Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. Display Goals");
        Console.WriteLine("3. Add Event");
        Console.WriteLine("4. Save Goal");
        Console.WriteLine(". . . . . . . . . . . .");
        Console.WriteLine("0. Exit\n");
    }
    
    public void DisplayTypeOfGoals(){
        Console.Clear();        
        Console.WriteLine("- - - - - - - - - - - - ");
        Console.WriteLine("Select the Goal to add: ");
        Console.WriteLine("- - - - - - - - - - - - ");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine(". . . . . . . . . . . .");
        Console.WriteLine("Hit ENTER to Go Back\n");
    }

    public void CreateSimpleGoal(){
        
        Console.Write("Please type the description of the goal:\n\n");
        string description = Console.ReadLine();
        SimpleGoal simplegoal1 = new SimpleGoal(description);
        _goals.Add(simplegoal1);
    }

    public void CreateEternalGoal(){
        Console.Write("Please type the description of the goal:\n\n");
        string description = Console.ReadLine();
        EternalGoal simplegoal1 = new EternalGoal(description);
        _goals.Add(simplegoal1);
    }

    public void CreateChecklistGoal(){
        Console.Write("Please type the description of the goal:\n\n");
        string description = Console.ReadLine();
        EternalGoal simplegoal1 = new EternalGoal(description);
        _goals.Add(simplegoal1);
    }

    public void DisplayGoals(){

        if(_goals.Count() == 0){
            Console.WriteLine("No Goals saved. Try Adding a new goal.");
            Thread.Sleep(2000);
            return;
        }

        int i = 1;

        foreach(var goal in _goals){
            Console.WriteLine("- - - - - - - - - - ");
            
            switch(goal.GetTypeOfGoal()){
                case "Simple Goal":
                    if(goal.GetGoalStatus()){
                        Console.ForegroundColor = ConsoleColor.Green;
                    }else{
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.WriteLine(i + ". " + goal.GetDescription());                    
                    Console.ResetColor();
                    Console.WriteLine("Type: Simple Goal");
                    Console.WriteLine("Created: " + goal.GetDateCreated());
                    if(goal.GetGoalStatus()){
                        Console.WriteLine("COMPLETED: " + goal.GetDateCompleted());
                    }
                    Console.WriteLine("Points: " + goal.GetPoints());
                    break;
                
                case "Eternal Goal":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(i + ". " + goal.GetDescription());                    
                    Console.ResetColor();
                    Console.WriteLine("Type: Eternal Goal");
                    Console.WriteLine("Created: " + goal.GetDateCreated());
                    Console.WriteLine("Points: " + goal.GetPoints());
                    goal.DisplayGoal();
                    Console.ResetColor();
                    break;
                case "Checklist Goal":
                    break;
                default:
                    Console.WriteLine("Goal Type not found");
                    break;
            }
            i++;
            // Thread.Sleep(500);
        }
    }

    public int GetNumberOfGoals(){
        return _goals.Count();
    }

    public Goal GetGoal(int selected){
        return _goals[selected-1];
    }

    public void RecordEvent(int goalSelected){

    }
}