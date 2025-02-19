using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Abstract methods to be implemented by derived classes
    protected abstract double CalculateDistance();
    protected abstract double CalculateSpeed();
    protected abstract double CalculatePace();

    // Public getters that use the abstract methods
    public double GetDistance() => CalculateDistance();
    public double GetSpeed() => CalculateSpeed();
    public double GetPace() => CalculatePace();

    // Virtual method to be overridden in derived classes for custom summary formatting
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, " +
               $"Pace: {GetPace():F1} min per km";
    }

    protected int GetMinutes() => _minutes;
}
