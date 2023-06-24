class ChecklistGoal : Goal{
    private Dictionary<DateTime, Boolean> _records;

    public ChecklistGoal(string description) : base(description){
        _goalType = "Eternal Goal";
        _goalDescription = description;
        _points = 0;
        _dateCreated = DateTime.Now;
        _records = new Dictionary<DateTime, bool>();
    }

    public override void RecordEvent(Boolean completed){
        _records.Add(DateTime.Now, completed);
    }
    public override void DisplayGoal(){
        foreach(var record in _records){
            if(record.Value == true){  
                Console.ForegroundColor = ConsoleColor.Green;              
                Console.WriteLine(record.Key + " : Completed");
            }else{
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(record.Key + " : Not completed");
            }

        }
    }
}