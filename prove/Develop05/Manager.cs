class Manager{
    private int _totalScore;
    private int _totalNumberOfChecklists;
    private List<Goal> _goals;

    public Manager(){
        
        _totalScore = 0;
        _goals = new List<Goal>();
        _totalNumberOfChecklists = 0;
    }

    public void AddItemToChecklist(Goal checklistGoal1){
        
        string input;
        do{
            
            Console.Clear();
            DisplaySingleChecklist(checklistGoal1);
            // Console.ResetColor();
            // checklistGoal1.DisplayChecklistItems();
            Console.WriteLine("\n\nAdd at least one Item for the goal\nor Hit ENTER to Go Back: \n");
            input = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(input)){
                checklistGoal1.AddItem(input, false);
            }

        }while(!string.IsNullOrWhiteSpace(input) || checklistGoal1.GetNumberOfItems() == 0);
    }

    public void CreateChecklistGoal(){
        string description;
        do{
            Console.Clear();
            Console.Write("Please type the name of the goal:\n\n");
            description = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(description)){
                ChecklistGoal checklistGoal1 = new ChecklistGoal(description);
                _goals.Add(checklistGoal1);
                AddItemToChecklist(checklistGoal1);
                _totalNumberOfChecklists++;
                int bonusPoints = 0;
                
                do{
                    Console.Clear();
                    DisplaySingleChecklist(checklistGoal1);
                    Console.WriteLine("\nHow many Bonus Points should you gain upon completion?");
                    string res3 = Console.ReadLine();
                    if(int.TryParse(res3, out bonusPoints)){                        
                        checklistGoal1.SetBonusPoints(bonusPoints);
                    }
                    Console.Clear();
                }while(bonusPoints == 0);
            }
        }while(string.IsNullOrWhiteSpace(description));        
    }

    public void CreateEternalGoal(){

        string description;
        do{
            Console.Clear();
            Console.Write("Please type the description of the goal:\n\n");
            description = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(description)){
                EternalGoal simplegoal1 = new EternalGoal(description);
                _goals.Add(simplegoal1);
            }
        }while(string.IsNullOrWhiteSpace(description));  
    }

    public void CreateSimpleGoal(){

        string description;

        do{
            Console.Clear();
            Console.Write("Please type the description of the goal:\n\n");
            description = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(description)){
                SimpleGoal simplegoal1 = new SimpleGoal(description);
                _goals.Add(simplegoal1);
            }
        }while(string.IsNullOrWhiteSpace(description));  
    }

    public void DisplayAllChecklists(){
        
        if(_totalNumberOfChecklists == 0){
            Console.WriteLine("No Checklists saved. Try Adding a new one.");
            Thread.Sleep(2000);
            return;
        }
        
        int i = 1;

        foreach(var goal in _goals){

            if(goal.GetTypeOfGoal() == "Checklist Goal"){
                
                Console.WriteLine("- - - - - - - - - - ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(i + ". ");
                Console.ResetColor();
                DisplaySingleChecklist(goal);
            }
            i++;
        }
    }

    public void DisplaySingleChecklist(Goal checklist){

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(checklist.GetGoalDescription());                    
        Console.ResetColor();
        Console.WriteLine("    Checklist Goal");
        Console.WriteLine("Created: " + checklist.GetDateCreated());
        Console.WriteLine("Points: " + checklist.GetPoints());
        checklist.DisplayItemsOnChecklist();
        Console.ResetColor();
    }

    public void DisplayAllGoals(){

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
                    Console.WriteLine(i + ". " + goal.GetGoalDescription() + "  -  Pending");                    
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
                    Console.WriteLine(i + ". " + goal.GetGoalDescription());                    
                    Console.ResetColor();
                    Console.WriteLine("    Eternal Goal");
                    Console.WriteLine("Created: " + goal.GetDateCreated());
                    Console.WriteLine("Points: " + goal.GetPoints());
                    goal.DisplayItemsOnChecklist();
                    Console.ResetColor();
                    break;
                    
                case "Checklist Goal":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(i + ". " + goal.GetGoalDescription());                    
                    Console.ResetColor();
                    Console.WriteLine("    Checklist Goal");
                    Console.WriteLine("Created: " + goal.GetDateCreated());

                    if(goal.GetPorcentCompleted() == 100){
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Completed: "+ goal.GetPorcentCompleted() + " %");
                        Console.ResetColor();
                    }
                    else{
                        Console.WriteLine("Completed: "+ goal.GetPorcentCompleted() + " %");
                    }
                    Console.WriteLine("Possible Bonus Points: " + goal.GetBonusPoints());
                    Console.WriteLine("Points: " + goal.GetPoints());
                    goal.DisplayItemsOnChecklist();
                    Console.ResetColor();
                    break;
                default:
                    Console.WriteLine("Goal Type not found");
                    break;
            }
            i++;
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
        Console.WriteLine("5. Save Goals to File");
        Console.WriteLine("6. Load Goals from File");
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

    public int GetNumberOfChecklists(){
        return _totalNumberOfChecklists;
    }
    
    public int GetScore(){
        
        int total = 0;
        foreach(Goal goal in _goals){
            total += goal.GetPoints();
        }
        return total;
    }

    public void LoadGoalsFromFile(string fileName){

        _goals.Clear();
        
        using (StreamReader reader = new StreamReader(fileName)){

            while (!reader.EndOfStream){
                string goalType = reader.ReadLine();
                string goalDescription = reader.ReadLine();
                DateTime dateCreated = DateTime.Parse(reader.ReadLine());
                DateTime dateCompleted = DateTime.Parse(reader.ReadLine());
                int points = int.Parse(reader.ReadLine());
                bool completed = bool.Parse(reader.ReadLine());

                Goal goal;

                switch (goalType){
                    case "Simple Goal":
                        goal = new SimpleGoal(goalDescription);
                        break;
                    case "Checklist Goal":
                        goal = new ChecklistGoal(goalDescription);
                        break;
                    case "Eternal Goal":
                        goal = new EternalGoal(goalDescription);
                        break;
                    default:
                        // Skip unknown goal types
                        continue;
                }

                goal.SetDateCreated(dateCreated);
                goal.SetDateCompleted(dateCompleted);
                goal.SetPoints(points);
                goal.SetCompleted(completed);

                if (goal is ChecklistGoal checklistGoal){
                    int bonusPoints = int.Parse(reader.ReadLine());
                    int itemCount = int.Parse(reader.ReadLine());

                    for (int i = 0; i < itemCount; i++){
                        string item = reader.ReadLine();
                        bool isCompleted = bool.Parse(reader.ReadLine());
                        checklistGoal.AddItem(item, isCompleted);
                    }
                    goal.SetBonusPoints(bonusPoints);
                }
                else if (goal is EternalGoal eternalGoal){

                    int eventCount = int.Parse(reader.ReadLine());

                    for (int i = 0; i < eventCount; i++){
                        DateTime eventDate = DateTime.Parse(reader.ReadLine());
                        bool isCompleted = bool.Parse(reader.ReadLine());
                        eternalGoal.RecordEvent(eventDate, isCompleted);
                    }
                }

                _goals.Add(goal);
            }
        }
        Console.WriteLine("Goals loaded from file.");
        
    }

    public void SaveToFile(string fileName){
        
        using (StreamWriter writer = new StreamWriter(fileName + ".txt")){
            foreach (Goal goal in _goals){
                writer.WriteLine(goal.GetGoalType());
                writer.WriteLine(goal.GetGoalDescription());
                writer.WriteLine(goal.GetDateCreated());
                writer.WriteLine(goal.GetDateCompleted());
                writer.WriteLine(goal.GetPoints());
                writer.WriteLine(goal.GetGoalStatus());

                if (goal is ChecklistGoal checklistGoal){
                    
                    writer.WriteLine(goal.GetBonusPoints());
                    writer.WriteLine(checklistGoal.GetChecklistItems().Count);

                    foreach (var item in checklistGoal.GetChecklistItems()){
                        writer.WriteLine(item.Key);
                        writer.WriteLine(item.Value);
                    }
                }
                else if (goal is EternalGoal eternalGoal)
                {
                    writer.WriteLine(eternalGoal.GetRecordedEvents().Count);
                    foreach (KeyValuePair<DateTime, bool> record in eternalGoal.GetRecordedEvents())
                    {
                        writer.WriteLine(record.Key);
                        writer.WriteLine(record.Value);
                    }
                }
            }
        }
    }
}