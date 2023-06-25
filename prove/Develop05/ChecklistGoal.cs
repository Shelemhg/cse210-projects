class ChecklistGoal : Goal{
    private Dictionary<string, Boolean> _records;
    private int _bonusPoints;

    public ChecklistGoal(string description) : base(description){
        
        _goalType = "Checklist Goal";
        _goalDescription = description;
        _points = 0;
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
                Console.WriteLine("    " + i + ". "+ record.Key + " - Completed");
            }else{
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    " + i + ". "+ record.Key + " - Pending");
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

    public int GetPorcentCompleted(){
        double total = 0;
        int percent = 0;
        int itemsCompleted = 0;
        foreach(KeyValuePair<string, Boolean> record in _records){
            if(record.Value == true){
                itemsCompleted ++;
            }
        }
        total = itemsCompleted /_records.Count() * 100;
        percent = (int)Math.Round(total);

        if(percent == 100){
            _completed = true;
            _points += _bonusPoints;
        }
        return percent;
    }
    
    public void UpdateItem(int itemSelected){
        
        int i = 1;
        foreach(KeyValuePair<string, Boolean> item in _records){
            if(i == itemSelected && _records[item.Key] == false ){
                _records[item.Key] = true;
                _points += 20;
                break;
            }
            i++;
        }
    }
    public void SetBonusPoints(int points){
         _bonusPoints = points;
    }
}