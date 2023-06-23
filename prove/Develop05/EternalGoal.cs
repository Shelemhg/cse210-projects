class EternalGoal : Goal{
    private Dictionary<DateTime, Boolean> _records;

    protected EternalGoal(string description) : base(description){
        
    }

    public void RecordEvent(DateTime date, Boolean completed){
        _records.Add(date, completed);
    }
    public void DisplayGoal(){
        foreach(var record in _records){
            if(record.Value == true){                
                Console.WriteLine(record.Key + " : Completed");
            }else{
                Console.WriteLine(record.Key + " : Not completed");
            }
        }
    }
}