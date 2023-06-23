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
        Console.WriteLine("0. Exit\n");
    }

    public void CreateSimpleGoal(){
        Console.Clear();
        Console.Write("Please type the description of the goal: ");
        string description = Console.ReadLine();
        SimpleGoal simplegoal1 = new SimpleGoal(description);
        _goals.Add(simplegoal1);
    }

    public void CreateEternalGoal(){

    }

    public void CreateChecklistGoal(){

    }

    public void DisplayGoals(){
        Console.Clear();        
        Console.WriteLine("- - - - - - - - - - - - - -");
        Console.WriteLine("- -  A D D   E V E N T - -");
        Console.WriteLine("- - - - - - - - - - - - - -\n\n");

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
                    Console.WriteLine(i + ". " + goal.GetDescription());
                    Console.WriteLine("Type: Simple Goal");
                    Console.WriteLine("Date: " + goal.GetDateCreated());
                    break;
                case "Eternal Goal":
                    break;
                case "Checklist Goal":
                    break;
                default:
                    Console.WriteLine("Goal Type not found");
                    break;
            }
            i++;
            Thread.Sleep(1000);

        }
        Thread.Sleep(2000);
    }
}