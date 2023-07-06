class ChecklistGoal : Goal{
    private Dictionary<string, Boolean> _records;
    private int _bonusPoints;
    private int _percentCompleted;

    public ChecklistGoal(){
        _goalType = "Checklist Goal";
        _records = new Dictionary<string, bool>();
        _points = 0;
        _possiblePoints = 0;
        _percentCompleted = 0;
    }

    public ChecklistGoal(string description) : base(description){
        
        _goalType = "Checklist Goal";
        _goalDescription = description;
        _points = 0;
        _possiblePoints = 0;
        _dateCreated = DateTime.Now;
        _records = new Dictionary<string, bool>();
    }

    public void AddItem(string description, Boolean completed){
        
        _records.Add(description, completed);   
             
        if(_completed){
            _completed = false;
            _points -= _bonusPoints;
        }
        CalculatePercentCompleted();
    }

    private void CalculatePercentCompleted(){
        
        double total = 0;
        int percent = 0;
        int itemsCompleted = 0;
        foreach(KeyValuePair<string, Boolean> record in _records){
            if(record.Value == true){
                itemsCompleted ++;
            }
        }
        if(_records.Count() != 0){
            total = itemsCompleted * 100/_records.Count();
        }else{
            total = 0;
        }
        percent = (int)Math.Round(total);

        if(percent == 100){
            _completed = true;
            _points += _bonusPoints;
        }
        _percentCompleted = percent;
    }

    public override void DisplayGoal(int i){
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(i + ". " + GetGoalDescription());                    
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("      Checklist Goal");
        Console.WriteLine("Created: " + GetDateCreated());

        if(GetPercentCompleted() == 100){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Completed: "+ GetPercentCompleted() + " %");
            Console.ResetColor();
        }
        else{
            Console.WriteLine("Completed: "+ GetPercentCompleted() + " %");
        }

        Console.WriteLine("Possible Bonus Points: " + GetBonusPoints());
        Console.WriteLine("Possible Points per Item: " + GetPossiblePoints());
        Console.ResetColor();
        Console.WriteLine("POINTS: " + GetPoints());

        DisplayItemsOnChecklist();
        
        Console.ResetColor();
    }

    public void DisplayItemsOnChecklist(){
        
        int i = 1;

        foreach(var record in _records){

            if(record.Value == true){  
                Console.ForegroundColor = ConsoleColor.Green;              
                Console.WriteLine("      " + i + ". "+ record.Key + " - Completed");

            }else{
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("      " + i + ". "+ record.Key + " - Pending");
            }
            
            i++;
        }
        Console.ResetColor();
    }

    public void DisplaySingleChecklist(){

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(GetGoalDescription());                    
        Console.ResetColor();
        Console.WriteLine("    Checklist Goal");
        Console.WriteLine("Created: " + GetDateCreated()); 
        Console.WriteLine("Completed: "+ GetPercentCompleted() + " %");       
        Console.WriteLine("Possible Bonus Points: " + GetBonusPoints());
        Console.WriteLine("Possible Points per Item: " + GetPossiblePoints());
        Console.WriteLine("Points: " + GetPoints());
        
        DisplayItemsOnChecklist();

        Console.ResetColor();
    }

    public int GetNumberOfItems(){
        return _records.Count();
    }

    public Dictionary<string, Boolean> GetChecklistItems(){
        return _records;
    }
    
    public int GetBonusPoints(){
        return _bonusPoints;
    }
    
    public bool GetItemCompletionStatus(string item){
        if (_records.ContainsKey(item))
            return _records[item];
        return false;
    }

    public int GetPercentCompleted(){
        
        return _percentCompleted;
    }
    
    public override void LoadGoal(StreamReader reader){
        
        string goalDescription = reader.ReadLine();
        DateTime dateCreated = DateTime.Parse(reader.ReadLine());
        DateTime dateCompleted = DateTime.Parse(reader.ReadLine());
        int possiblePoints = int.Parse(reader.ReadLine());
        int points = int.Parse(reader.ReadLine());
        bool completed = bool.Parse(reader.ReadLine());

        SetGoalDescription(goalDescription);
        SetDateCreated(dateCreated);
        SetDateCompleted(dateCompleted);
        SetPossiblePoints(possiblePoints);
        SetPoints(points);
        SetCompleted(completed);

        int bonusPoints = int.Parse(reader.ReadLine());
        int itemCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < itemCount; i++){
            string item = reader.ReadLine();
            bool isCompleted = bool.Parse(reader.ReadLine());
            AddItem(item, isCompleted);
        }
        SetBonusPoints(bonusPoints);
        CalculatePercentCompleted();

    }

    public Boolean UpdateItem(int itemSelected){
        
        int i = 0;
        foreach(KeyValuePair<string, Boolean> item in _records){
            if(i+1 == itemSelected){
                if(_records[item.Key] == false ){
                    _records[item.Key] = true;
                    _points += _possiblePoints;
                    return true;
                }else{
                    Console.WriteLine("Item ALREADY COMPLETED, please select a different one.");
                    Thread.Sleep(3000);
                    return false;
                }
            }
            i++;
        }
        return false;
    }
    
    public override Boolean RecordEvent(){
        string selection;
        Boolean changed = false;
        do{
            Console.Clear();
            DisplaySingleChecklist();
            int numberSelected;
        
            Console.WriteLine("Select one Item to mark as done, or Hit ENTER to go Back:\n");
            selection = Console.ReadLine();

            if(selection != "" && int.TryParse(selection, out numberSelected)){
                Boolean updatedItem = UpdateItem(numberSelected);
                if(updatedItem){
                    changed = true;
                    CalculatePercentCompleted();
                    if(_percentCompleted == 100){
                        Console.WriteLine("\nCONGRATULATIONS!! YOU HAVE FINISHED THIS CHECKLIST GOAL!!\n");
                        Thread.Sleep(3000);
                    }
                }
            }
        }while(selection != "" && _percentCompleted != 100);
        return changed;
    }

    public void SetBonusPoints(int points){
        
        _bonusPoints = points;
    }

    public override void SaveGoalInfo(StreamWriter writer){
        writer.WriteLine(GetGoalType());
        writer.WriteLine(GetGoalDescription());
        writer.WriteLine(GetDateCreated());
        writer.WriteLine(GetDateCompleted());
        writer.WriteLine(GetPossiblePoints());
        writer.WriteLine(GetPoints());
        writer.WriteLine(GetGoalStatus());
            
        writer.WriteLine(GetBonusPoints());
        writer.WriteLine(GetChecklistItems().Count);

        foreach (var item in GetChecklistItems()){
            writer.WriteLine(item.Key);
            writer.WriteLine(item.Value);
        }
    }
}