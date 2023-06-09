class Manager{
    private int _totalScore;
    private int _totalNumberOfChecklists;
    private List<Goal> _goals;
    private string _lastFileUsed;
    private Boolean _unsavedChanges;

    public Manager(){
        
        _totalScore = 0;
        _goals = new List<Goal>();
        _totalNumberOfChecklists = 0;
        _unsavedChanges = false;
        _lastFileUsed = "";
    }

    public void AddItemToChecklist(ChecklistGoal checklistGoal1){
        
        string input;
        
        do{
            
            Console.Clear();
            DisplaySingleChecklist(checklistGoal1);
            Console.WriteLine("\n\nAdd at least one Item for the goal\nThen hit ENTER to finish: \n");
            input = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(input)){
                checklistGoal1.AddItem(input, false);
            }

        }while(!string.IsNullOrWhiteSpace(input) || checklistGoal1.GetNumberOfItems() == 0);
    }

    public void AddUnsavedChanges(){

        _unsavedChanges = true;
    }

    public void CreateChecklistGoal(){
        
        string description;

        do{
            Console.Clear();
            Console.Write("Please type the name of the Checklist goal:\n\n");
            description = Console.ReadLine();
            
            if(!string.IsNullOrWhiteSpace(description)){
                AddUnsavedChanges();
                ChecklistGoal checklistGoal1 = new ChecklistGoal(description);
                _goals.Add(checklistGoal1);
                AddItemToChecklist(checklistGoal1);
                _totalNumberOfChecklists++;

                string res;
                int points = 0;
                
                do{
                    Console.Clear();
                    Console.WriteLine("\nHow many Points should you gain upon the completion of each item?\n");
                    res = Console.ReadLine();
                    
                    if(int.TryParse(res, out points)){                        
                        checklistGoal1.SetPossiblePoints(points);
                    }
                    Console.Clear();
                }while(points == 0);

                int bonusPoints = 0;
                
                do{
                    Console.Clear();
                    DisplaySingleChecklist(checklistGoal1);
                    Console.WriteLine("\nHow many Bonus Points should you gain upon Full Completion?\n");
                    string res3 = Console.ReadLine();
                    
                    if(int.TryParse(res3, out bonusPoints)){                        
                        checklistGoal1.SetBonusPoints(bonusPoints);
                    }
                    Console.Clear();
                }while(bonusPoints == 0);

                break;
            }
        }while(description != "");        
    }

    public void CreateEternalGoal(){

        string description;
        do{
            Console.Clear();
            Console.Write("Please type the description of the Eternal goal:\n\n");
            description = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(description)){
                AddUnsavedChanges();
                EternalGoal simpleGoal = new EternalGoal(description);
                _goals.Add(simpleGoal);

                string res;
                int possiblePoints = 0;
                
                do{
                    Console.Clear();
                    Console.WriteLine("How many Points should you gain upon each completion?\n");
                    res = Console.ReadLine();
                    
                    if(int.TryParse(res, out possiblePoints)){                        
                        simpleGoal.SetPossiblePoints(possiblePoints);
                    }
                    Console.Clear();
                }while(possiblePoints == 0);

                break;
            }
        }while(description != "");  
    }

    public void CreateSimpleGoal(){

        string description;

        do{
            Console.Clear();
            Console.Write("Please type the description of the Simple goal:\n\n");
            description = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(description)){
                AddUnsavedChanges();
                SimpleGoal simpleGoal = new SimpleGoal(description);
                _goals.Add(simpleGoal);

                string res;
                int points = 0;
                
                do{
                    Console.Clear();
                    Console.WriteLine("How many Points should you gain upon completion?\n");
                    res = Console.ReadLine();
                    
                    if(int.TryParse(res, out points)){                        
                        simpleGoal.SetPossiblePoints(points);
                    }
                    Console.Clear();
                }while(points == 0);

                break;
            }
        }while(description != "");  
    }

    public void DisplayAllChecklists(){
        
        if(_totalNumberOfChecklists == 0){
            Console.WriteLine("No Checklists saved. Try Adding a new one.");
            Thread.Sleep(2000);
            return;
        }
        
        int i = 1;

        foreach(var goal in _goals){

            if(goal is ChecklistGoal checklistGoal){
                
                Console.WriteLine("- - - - - - - - - - ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(i + ". ");
                Console.ResetColor();
                DisplaySingleChecklist(checklistGoal);
            }
            i++;
        }
    }
     public void DisplayAllGoals(){

        if(_goals.Count() == 0){
            Console.WriteLine("No Goals saved. Try Adding a new goal.");
            Thread.Sleep(2000);
            return;
        }

        int i = 1;

        foreach(var goal in _goals){
            Console.WriteLine("");
            DisplayHorizontalLine();

            if(goal.GetTypeOfGoal() != "Simple Goal" && goal.GetTypeOfGoal() != "Eternal Goal" && goal.GetTypeOfGoal() != "Checklist Goal"){
                Console.WriteLine("Goal Type not found");
            }else{
                goal.DisplayGoal(i);
            }           
            
            i++;
        }
    }

    public void DisplaySingleChecklist(ChecklistGoal checklistGoal){

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(checklistGoal.GetGoalDescription());                    
        Console.ResetColor();
        Console.WriteLine("    Checklist Goal");
        Console.WriteLine("Created: " + checklistGoal.GetDateCreated()); 
        Console.WriteLine("Completed: "+ checklistGoal.GetPercentCompleted() + " %");       
        Console.WriteLine("Possible Bonus Points: " + checklistGoal.GetBonusPoints());
        Console.WriteLine("Possible Points per Item: " + checklistGoal.GetPossiblePoints());
        Console.WriteLine("Points: " + checklistGoal.GetPoints());
        
        checklistGoal.DisplayItemsOnChecklist();

        Console.ResetColor();
    }

    public void DisplayHorizontalLine(){
        
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - -");
    }

    private void DisplayHorizontalDots(){
        
        Console.WriteLine(". . . . . . . . . . . . . . . . . . . . . .");
    }

    public void DisplayMenu(){
        
        Console.Clear();

        if(_goals.Count() == 0){
            
            DisplayHorizontalLine();
            Console.WriteLine("- - -    E T E R N A L    Q U E S T   - - -");
            DisplayHorizontalLine();
            Console.WriteLine("1. Create New Goal");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("2. Display Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Add Items to Existing Checklist Goal");
            Console.ResetColor();
            
            DisplayHorizontalDots();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("5. Save Goals to File");
            Console.ResetColor();
            Console.WriteLine("6. Load Goals from File");
            DisplayHorizontalDots();
            Console.WriteLine("0. Exit");

        }else{
            DisplayHorizontalLine();
            Console.WriteLine("- - -    E T E R N A L    Q U E S T   - - -");
            DisplayHorizontalLine();
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Display Goals");
            Console.WriteLine("3. Record Event");

            if(_totalNumberOfChecklists == 0){
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("4. Add Items to Existing Checklist Goal");
                Console.ResetColor();

            }else{                
                Console.WriteLine("4. Add Items to Existing Checklist Goal");
            }

            DisplayHorizontalDots();
            Console.WriteLine("5. Save Goals to File");
            Console.WriteLine("6. Load Goals from File");
            DisplayHorizontalDots();
            Console.WriteLine("0. Exit");
        }
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
        Console.WriteLine("\nHit ENTER to Go Back\n");
    }

    public void DisplayTotalScore(){
        
        Console.WriteLine("");
        DisplayHorizontalLine();

        if(_lastFileUsed != ""){
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("         Last File Used: \"" + _lastFileUsed + "\"");
            Console.ResetColor();
        }
        DisplayHorizontalLine();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("              TOTAL SCORE: " + GetScore());
        Console.ResetColor();
        DisplayHorizontalLine();
        if(_unsavedChanges){
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("        Changes Pending To Be Saved");
            Console.ResetColor();
        }
        DisplayHorizontalLine();   
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
    
    private int GetScore(){
        
        int total = 0;

        foreach(Goal goal in _goals){
            total += goal.GetPoints();
        }

        return total;
    }
    
    private void SaveChanges(){
        
        _unsavedChanges = false;
    }

    public Boolean GetUnsavedChanges(){
        return _unsavedChanges;
    }

    private void LoadGoalsFromFile(string fileName){

        _goals.Clear();
        
        using (StreamReader reader = new StreamReader(fileName)){

            while (!reader.EndOfStream){  
                     
                string goalType = reader.ReadLine();

                switch (goalType){
                    case "Simple Goal":
                        SimpleGoal goal = new SimpleGoal();                      
                        goal.LoadGoal(reader);
                        _goals.Add(goal);
                        break;

                    case "Checklist Goal":
                        ChecklistGoal checklistGoal = new ChecklistGoal();
                        checklistGoal.LoadGoal(reader);
                        _goals.Add(checklistGoal);
                        _totalNumberOfChecklists++;                        
                        break;

                    case "Eternal Goal":
                        EternalGoal eternalGoal = new EternalGoal();
                        eternalGoal.LoadGoal(reader);
                        _goals.Add(eternalGoal);
                        break;

                    default:
                        // Skip unknown goal types
                        continue;
                }
            }
        }
        Console.WriteLine("\nGoals loaded from file.");
        
    }

    public string StartFileLoad(string fileNameToLoad){
        
        do{
            Console.Clear();
            DisplayHorizontalLine();
            Console.WriteLine("- - -   L O A D   F R O M   F I L E   - - -");
            DisplayHorizontalLine();
            Console.WriteLine("\nType the name of the file to load and hit ENTER\n(Do not include the file extension)\n\nOr just hit ENTER to go Back.\n");
            fileNameToLoad = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(fileNameToLoad)){
                
                if(File.Exists(fileNameToLoad + ".txt")){

                    LoadGoalsFromFile(fileNameToLoad + ".txt");
                    _lastFileUsed = fileNameToLoad;
                    Console.Clear();
                    DisplayAllGoals();
                    DisplayTotalScore();
                    Console.WriteLine("\n\nPress ENTER to go back");
                    Console.ReadLine();
                    fileNameToLoad = "";
                    SaveChanges();
                    break;
                }
                else{
                    Console.WriteLine("\nFile \"" + fileNameToLoad + "\" NOT found. Please try again.");
                    Thread.Sleep(2000);
                }
            }
        }while(fileNameToLoad !="");

        return fileNameToLoad;
    }

    public void SaveToFile(string fileName){
        
        SaveChanges();
        using (StreamWriter writer = new StreamWriter(fileName + ".txt")){

            foreach (Goal goal in _goals){
                goal.SaveGoalInfo(writer);
            }
            _lastFileUsed = fileName;
        }
    }
}