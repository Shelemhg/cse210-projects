class Goal {
    
    protected string _goalType;
    protected string _goalDescription;    
    protected DateTime _dateCreated;
    protected DateTime _dateCompleted;
    protected int _possiblePoints;
    protected int _points;
    protected Boolean _completed;
         
    public Goal(){}
    
    public Goal(string description){
        _goalDescription = description;
    }
    
    public virtual void DisplayGoal(int i){
        if(GetGoalStatus()){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(i + ". " + GetGoalDescription() + "  -  COMPLETED");
        }else{
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(i + ". " + GetGoalDescription() + "  -  Pending");    
        }
                        
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("      Simple Goal");
        Console.WriteLine("Created: " + GetDateCreated());
        if(GetGoalStatus()){
            Console.WriteLine("COMPLETED: " + GetDateCompleted());
        }
        Console.WriteLine("Possible Points: " + GetPossiblePoints());
        Console.ResetColor();
        Console.WriteLine("POINTS: " + GetPoints());
    }

    public DateTime GetDateCompleted(){
        return _dateCompleted;
    }
    
    public DateTime GetDateCreated(){
        return _dateCreated;
    }

    public string GetGoalDescription(){
        return _goalDescription;
    }
    
    public Boolean GetGoalStatus(){
        return _completed;
    }

    public string GetGoalType(){
        return _goalType;
    }
       
    public int GetPossiblePoints(){
        
        return _possiblePoints;
    }

    public int GetPoints(){
        return _points;
    }
    
    public string GetTypeOfGoal(){
        return _goalType;
    }
    
    public virtual void LoadGoal(StreamReader reader){
        
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
    }
    
    public virtual void MarkCompleted(){}

    public virtual Boolean RecordEvent(){
        string res;
        do{
            Console.Clear();
            Console.Write("Was the goal '" + GetGoalDescription() + "' Completed? (y/n):\n\n");
            res = Console.ReadLine();

            if(res.ToLower() =="y"){
                MarkCompleted();
                Console.Write("\nThe goal was marked as COMPLETED!!\n");
                Thread.Sleep(2000);
                Console.Clear();
                return true;
            }
            else if(res.ToLower() == "n"){
                Console.Write("\nNo problem, keep it up! :D\n\n");
                Thread.Sleep(3000);
                return false;
            }
            
        }while(res != "y" || res !="n");

        return false;
    }

    public virtual void SaveGoalInfo(StreamWriter writer){
        writer.WriteLine(GetGoalType());
        writer.WriteLine(GetGoalDescription());
        writer.WriteLine(GetDateCreated());
        writer.WriteLine(GetDateCompleted());
        writer.WriteLine(GetPossiblePoints());
        writer.WriteLine(GetPoints());
        writer.WriteLine(GetGoalStatus());
    }

    public void SetCompleted(Boolean completed){
        _completed = completed;
    }

    public void SetDateCompleted(DateTime dateCompleted){
        _dateCompleted = dateCompleted;
    }
    
    public void SetDateCreated(DateTime dateCreated){
        _dateCreated = dateCreated;
    }

    public void SetGoalDescription(string description){
        _goalDescription = description;
    }

    public void SetPoints(int points){
        _points = points;
    }

    public void SetPossiblePoints(int points){
        _possiblePoints = points;
    }
}