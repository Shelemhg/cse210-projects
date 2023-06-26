class EternalGoal : Goal{
    private Dictionary<DateTime, Boolean> _records;

    public EternalGoal(string description) : base(description){
        
        _goalType = "Eternal Goal";
        _goalDescription = description;
        _points = 0;
        _possiblePoints = 0;
        _dateCreated = DateTime.Now;
        _records = new Dictionary<DateTime, bool>();
    }

    public void DisplayItemsOnChecklist(){
        
        foreach(var record in _records){
            if(record.Value == true){  
                Console.ForegroundColor = ConsoleColor.Green;              
                Console.WriteLine("      " + record.Key + " : Completed");
            }else{
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("      " + record.Key + " : Not completed");
            }

        }
    }

    public Dictionary<DateTime, Boolean> GetRecordedEvents(){
        return _records;
    }
    
    public void RecordEvent(DateTime date, Boolean completed){
        
        _records.Add(date, completed);

        if(completed){
            _points += _possiblePoints;
        }
    }
    public void SaveEvent(DateTime date, Boolean completed){
        
        _records.Add(date, completed);
    }
    
}