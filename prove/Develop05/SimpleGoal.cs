class SimpleGoal : Goal{
    // public Boolean _completed;

    public SimpleGoal(string description) : base(description){
        _goalType = "Simple Goal";
        _goalDescription = description;
        _points = 0;
        _dateCreated = DateTime.Now;
    }

    public override void DisplayGoal(){
        Console.Clear();
        Console.WriteLine("Goal: " + _goalDescription);
        Console.WriteLine("Completed: " + _completed);
        Console.WriteLine("Date: " + _dateCreated);
        Console.WriteLine("Points: " + _points);
    }

    public void CompleteSimpleGoal(){
        _completed = true;
        _points = 100;
    }
}