using System;

public class Cycling : Activity
{
    private double _speed; // in kph

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    protected override double CalculateDistance() => (_speed * GetMinutes()) / 60;
    
    protected override double CalculateSpeed() => _speed;
    
    protected override double CalculatePace() => 60 / _speed;
}
