class ChecklistGoal : Goal{
    private Dictionary<string, Boolean> _records;
    private int _bonusPoints;

    public ChecklistGoal(){
        _goalType = "Checklist Goal";
        _records = new Dictionary<string, bool>();
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
        
        double total = 0;
        int percent = 0;
        int itemsCompleted = 0;
        foreach(KeyValuePair<string, Boolean> record in _records){
            if(record.Value == true){
                itemsCompleted ++;
            }
        }
        // total = itemsCompleted * 100/_records.Count() ;
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
        return percent;
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

    }

    public void UpdateItem(int itemSelected){
        
        int i = 1;
        foreach(KeyValuePair<string, Boolean> item in _records){
            if(i == itemSelected && _records[item.Key] == false ){
                _records[item.Key] = true;
                _points += _possiblePoints;
                break;
            }
            i++;
        }
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