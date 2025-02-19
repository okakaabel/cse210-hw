using System;

public class Running : Activity
{
    private double _distance; // in kilometers

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    protected override double CalculateDistance() => _distance;
    
    protected override double CalculateSpeed() => (_distance / GetMinutes()) * 60;
    
    protected override double CalculatePace() => GetMinutes() / _distance;
}
