class EternalGoal : Goal{
    private Dictionary<DateTime, Boolean> _records;

    public EternalGoal(string description) : base(description){
        
        _goalType = "Eternal Goal";
        _goalDescription = description;
        _points = 0;
        _dateCreated = DateTime.Now;
        _records = new Dictionary<DateTime, bool>();
    }

    public override void DisplayItemsOnChecklist(){
        
        foreach(var record in _records){
            if(record.Value == true){  
                Console.ForegroundColor = ConsoleColor.Green;              
                Console.WriteLine("    " + record.Key + " : Completed");
            }else{
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    " + record.Key + " : Not completed");
            }

        }
    }

    public Dictionary<DateTime, Boolean> GetRecordedEvents(){
        return _records;
    }
    
    public override void RecordEvent(DateTime date, Boolean completed){
        
        _records.Add(date, completed);
        _points += 50;
    }
    
}