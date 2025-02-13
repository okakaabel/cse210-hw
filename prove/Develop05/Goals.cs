using System;

// Base class for all goals
public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _basePoints;
    protected bool _isComplete;
    internal object mBasePoints;

    public Goal(string name, string description, int basePoints)
    {
        _name = name;
        _description = description;
        _basePoints = basePoints;
        _isComplete = false;
    }

    public abstract int RecordEvent();
    public abstract string GetStatusString();
    
    public string GetName() => _name;
    public bool IsComplete() => _isComplete;
}

// Simple one-time goal
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int basePoints) 
        : base(name, description, basePoints) { }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _basePoints;
        }
        return 0;
    }

    public override string GetStatusString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_name} - {_description}";
    }
}

// Eternal goal that can be repeated indefinitely
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int basePoints) 
        : base(name, description, basePoints) { }

    public override int RecordEvent()
    {
        return _basePoints;
    }

    public override string GetStatusString()
    {
        return $"[ ] {_name} - {_description} (Eternal)";
    }
}

// Checklist goal that needs to be completed multiple times
public class ChecklistGoal : Goal
{
    private int _target;
    private int _current;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int basePoints, int target, int bonusPoints) 
        : base(name, description, basePoints)
    {
        _target = target;
        _current = 0;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        _current++;
        if (_current == _target)
        {
            _isComplete = true;
            return _basePoints + _bonusPoints;
        }
        return _basePoints;
    }

    public override string GetStatusString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_name} - {_description} (Completed {_current}/{_target} times)";
    }
}