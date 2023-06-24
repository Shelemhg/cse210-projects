class Manager{
    private int _totalScore;
    private List<Goal> _goals;

    public Manager(){
        
        _totalScore = 0;
        _goals = new List<Goal>();
    }

    public void AddItemToChecklist(Goal checklistGoal1){
        
        string input;
        do{
            Console.Clear();
            Console.WriteLine("Add at least one Item for the goal\nor Hit ENTER to Go Back: \n");
            input = Console.ReadLine();

            if(input.Replace(" ", "") != "" && input.ToLower() != ""){
                checklistGoal1.AddItem(input);
            }

        }while(input.Replace(" ", "") == "" && checklistGoal1.GetNumberOfItems() == 0);
    }

    public void CreateChecklistGoal(){
        string description;
        do{
            Console.Clear();
            Console.Write("Please type the name of the goal:\n\n");
            description = Console.ReadLine();
            if(description.Replace(" ", "") != ""){
                ChecklistGoal checklistGoal1 = new ChecklistGoal(description);
                _goals.Add(checklistGoal1);
                AddItemToChecklist(checklistGoal1);
            }
        }while(description.Replace(" ", "") == "");        
    }

    public void CreateEternalGoal(){

        string description;
        do{
            Console.Clear();
            Console.Write("Please type the description of the goal:\n\n");
            description = Console.ReadLine();
            if(description.Replace(" ", "") != ""){
                EternalGoal simplegoal1 = new EternalGoal(description);
                _goals.Add(simplegoal1);
            }
        }while(description.Replace(" ", "") == "");  
    }

    public void CreateSimpleGoal(){

        string description;
        do{
            Console.Clear();
            Console.Write("Please type the description of the goal:\n\n");
            description = Console.ReadLine();
            if(description.Replace(" ", "") != ""){
                SimpleGoal simplegoal1 = new SimpleGoal(description);
                _goals.Add(simplegoal1);
            }
        }while(description.Replace(" ", "") == "");  
    }

    public void DisplayChecklists(){
        
        if(_goals.Count() == 0){
            Console.WriteLine("No Goals saved. Try Adding a new goal.");
            Thread.Sleep(2000);
            return;
        }
        int i = 1;

        foreach(var goal in _goals){

            if(goal.GetTypeOfGoal() == "Checklist Goal"){
                
                Console.WriteLine("- - - - - - - - - - ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(i + ". " + goal.GetDescription());                    
                Console.ResetColor();
                Console.WriteLine("    Checklist Goal");
                Console.WriteLine("Created: " + goal.GetDateCreated());
                Console.WriteLine("Points: " + goal.GetPoints());
                goal.DisplayGoal();
                Console.ResetColor();
            }
            i++;
        }
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
                    Console.WriteLine(i + ". " + goal.GetDescription() + "  -  Pending");                    
                    Console.ResetColor();
                    Console.WriteLine("    Simple Goal");
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
                    Console.WriteLine("    Eternal Goal");
                    Console.WriteLine("Created: " + goal.GetDateCreated());
                    Console.WriteLine("Points: " + goal.GetPoints());
                    goal.DisplayGoal();
                    Console.ResetColor();
                    break;
                    
                case "Checklist Goal":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(i + ". " + goal.GetDescription());                    
                    Console.ResetColor();
                    Console.WriteLine("    Checklist Goal");
                    Console.WriteLine("Created: " + goal.GetDateCreated());
                    Console.WriteLine("Completed: "+ goal.GetPorcentCompleted() + " %");
                    Console.WriteLine("Points: " + goal.GetPoints());
                    goal.DisplayGoal();
                    Console.ResetColor();
                    break;
                default:
                    Console.WriteLine("Goal Type not found");
                    break;
            }
            i++;
            // Thread.Sleep(500);
        }
    }

    public void DisplayMenu(){
        
        Console.Clear();
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - ");
        Console.WriteLine("-    E T E R N A L     Q U E S T    -");
        Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. Display Goals");
        Console.WriteLine("3. Record Event");
        Console.WriteLine("4. Add Items to Existing Checklist Goal");
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

    public void DisplayTotalScore(){
        
        Console.WriteLine("- - - - - - - - - - - - - - - -");
        Console.WriteLine("- - - - - - - - - - - - - - - -\n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("        TOTAL SCORE: " + GetScore());
        Console.ResetColor();
        Console.WriteLine("\n- - - - - - - - - - - - - - - -");
        Console.WriteLine("- - - - - - - - - - - - - - - -\n");   
    }
    
    public Goal GetGoal(int selected){
        
        return _goals[selected-1];
    }
    
    public int GetNumberOfGoals(){
        
        return _goals.Count();
    }

    public int GetScore(){
        
        int total = 0;
        foreach(Goal goal in _goals){
            total += goal.GetPoints();
        }
        return total;
    }
}