class Goal {
    
    protected string _goalType;
    protected string _goalDescription;    
    protected DateTime _dateCreated;
    protected DateTime _dateCompleted;
    protected int _possiblePoints;
    protected int _points;
    protected Boolean _completed;
         
    public Goal(string description){
        _goalDescription = description;
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
    
    public virtual void MarkCompleted(){}

    public void SetCompleted(Boolean completed){
        _completed = completed;
    }

    public void SetDateCompleted(DateTime dateCompleted){
        _dateCompleted = dateCompleted;
    }
    
    public void SetDateCreated(DateTime dateCreated){
        _dateCreated = dateCreated;
    }

    public void SetPoints(int points){
        _points = points;
    }

    public void SetPossiblePoints(int points){
        _possiblePoints = points;
    }
}