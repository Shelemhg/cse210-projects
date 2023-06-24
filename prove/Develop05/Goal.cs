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
    public virtual void SaveGoal(){}
    public virtual void LoadGoal(){}
    public virtual void DisplayScore(){}
    public virtual void DisplayGoal(){}
    public virtual void RecordEvent(Boolean completed){}

    public string GetTypeOfGoal(){
        return _goalType;
    }
    public string GetDescription(){
        return _goalDescription;
    }
    public DateTime GetDateCreated(){
        return _dateCreated;
    }
    public DateTime GetDateCompleted(){
        return _dateCompleted;
    }
    public Boolean GetGoalStatus(){
        return _completed;
    }
    public int GetPoints(){
        return _points;
    }
    public virtual void MarkCompleted(){}
    public virtual void UpdateItem(int itemSelected){}
    public virtual void AddItem(string description){}
}