using System;

public class Swimming : Activity
{
    private int _laps;
    private const double LAP_LENGTH_KM = 0.05; // 50 meters = 0.05 km

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    protected override double CalculateDistance() => _laps * LAP_LENGTH_KM;
    
    protected override double CalculateSpeed() => (CalculateDistance() / GetMinutes()) * 60;
    
    protected override double CalculatePace() => GetMinutes() / CalculateDistance();
}
