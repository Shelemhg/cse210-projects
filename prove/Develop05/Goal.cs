class Goal {
    protected string _goalType;
    protected string _goalDescription;    
    protected DateTime _dateCreated;
    protected DateTime _dateCompleted;
    protected int _points;
    protected Boolean _completed;
         
    public Goal(string description){
        _goalDescription = description;
    }

    public virtual void AddItem(string description){}
    
    public virtual void DisplayGoal(){}
    
    public DateTime GetDateCompleted(){
        return _dateCompleted;
    }
    
    public DateTime GetDateCreated(){
        return _dateCreated;
    }

    public string GetDescription(){
        return _goalDescription;
    }
    
    public Boolean GetGoalStatus(){
        return _completed;
    }
    
    public int GetPoints(){
        return _points;
    }
    
    public string GetTypeOfGoal(){
        return _goalType;
    }
    
    public virtual void MarkCompleted(){}
    
    public virtual void RecordEvent(Boolean completed){}

    public virtual void UpdateItem(int itemSelected){}
}