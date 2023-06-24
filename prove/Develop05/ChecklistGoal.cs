class ChecklistGoal : Goal{
    private Dictionary<string, Boolean> _records;

    public ChecklistGoal(string description) : base(description){
        _goalType = "Checklist Goal";
        _goalDescription = description;
        _points = 0;
        _dateCreated = DateTime.Now;
        _records = new Dictionary<string, bool>();
    }

    // public override void RecordEvent(Boolean completed){
    //     _records.Add(DateTime.Now, completed);
    // }
    public override void DisplayGoal(){
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
    }

    public void AddItem(string description){
        _records.Add(description, false);
    }

    public int GetNumberOfItems(){
        return _records.Count();
    }

    public override void UpdateItem(int itemSelected){
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
}