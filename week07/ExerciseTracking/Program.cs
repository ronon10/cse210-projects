using System;
using System.Collections.Generic;


abstract class Activity
{
    private DateTime _date;
    private int _duration;

    public Activity(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public DateTime Date => _date;
    public int Duration => _duration;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_duration} min) - " +
               $"Distância: {GetDistance():0.0} km, Velocidade: {GetSpeed():0.0} km/h, Ritmo: {GetPace():0.00} min/km";
    }
}


class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int duration, double distance)
        : base(date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / Duration) * 60;
    public override double GetPace() => Duration / _distance;
}


class Cycling : Activity
{
    private double _speed; 

    public Cycling(DateTime date, int duration, double speed)
        : base(date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * Duration) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;
}


class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int duration, int laps)
        : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * 50) / 1000.0;
    public override double GetSpeed() => (GetDistance() / Duration) * 60;
    public override double GetPace() => Duration / GetDistance();
}


class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 4), 45, 20.0),
            new Swimming(new DateTime(2022, 11, 5), 40, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
