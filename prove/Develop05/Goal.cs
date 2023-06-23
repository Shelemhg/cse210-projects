class Goal {
    protected string _goalType;
    protected string _goalDescription;    
    protected DateTime _dateCreated;
    protected int _points;

    public Goal(string description){
        _goalDescription = description;
    }
    public virtual void RecordEvent(){}
    public virtual void SaveGoal(){}
    public virtual void LoadGoal(){}
    public virtual void DisplayScore(){}
    public virtual void DisplayGoal(){}

    public string GetTypeOfGoal(){
        return _goalType;
    }
    public string GetDescription(){
        return _goalDescription;
    }
    public DateTime GetDateCreated(){
        return _dateCreated;
    }
}