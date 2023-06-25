class SimpleGoal : Goal{

    public SimpleGoal(string description) : base(description){
       
        _goalType = "Simple Goal";
        _goalDescription = description;
        _points = 0;
        _dateCreated = DateTime.Now;
    }

    public void DisplayItemsOnChecklist(){
        
        Console.Clear();
        Console.WriteLine("Goal: " + _goalDescription);
        Console.WriteLine("Completed: " + _completed);
        Console.WriteLine("Date: " + _dateCreated);
        Console.WriteLine("Points: " + _points);
    }

    public override void MarkCompleted(){
        
        _completed = true;
        _points = 100;
    }
}