class EternalGoal : Goal{
    private Dictionary<DateTime, Boolean> _records;

    public EternalGoal(){
        _goalType = "Eternal Goal";
        _records = new Dictionary<DateTime, bool>();
    }
    
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

        int eventCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < eventCount; i++){
            DateTime eventDate = DateTime.Parse(reader.ReadLine());
            bool isCompleted = bool.Parse(reader.ReadLine());
            SaveEvent(eventDate, isCompleted);
        }
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
    public override void SaveGoalInfo(StreamWriter writer){
        writer.WriteLine(GetGoalType());
        writer.WriteLine(GetGoalDescription());
        writer.WriteLine(GetDateCreated());
        writer.WriteLine(GetDateCompleted());
        writer.WriteLine(GetPossiblePoints());
        writer.WriteLine(GetPoints());
        writer.WriteLine(GetGoalStatus());
            
        writer.WriteLine(GetRecordedEvents().Count);
        foreach (KeyValuePair<DateTime, bool> record in GetRecordedEvents())
        {
            writer.WriteLine(record.Key);
            writer.WriteLine(record.Value);
        }
    }
}