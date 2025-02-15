using System;
using System.Collections.Generic;
using System.IO;


abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
}

// Simple Goal
class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        IsCompleted = true;
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X]" : "[ ]";
    }
}

// Eternal Goal
class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
    
    }

    public override string GetStatus()
    {
        return "[∞]";
    }
}

// Checklist Goal
class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; private set; }
    public int BonusPoints { get; private set; }

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        CurrentCount++;
        if (CurrentCount >= TargetCount)
        {
            IsCompleted = true;
        }
    }

    public override string GetStatus()
    {
        return IsCompleted ? "[X]" : $"[{CurrentCount}/{TargetCount}]";
    }
}


class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int totalPoints = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordGoalEvent(string goalName)
    {
        foreach (var goal in goals)
        {
            if (goal.Name == goalName)
            {
                goal.RecordEvent();
                totalPoints += goal.Points;
                break;
            }
        }
    }

    public void ShowGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.GetStatus()} {goal.Name}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Total Score: {totalPoints}");
    }
}


class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        
        manager.AddGoal(new SimpleGoal("Run a marathon", 1000));
        manager.AddGoal(new EternalGoal("Read scriptures", 100));
        manager.AddGoal(new ChecklistGoal("Go to the temple", 50, 10, 500));
        
        manager.ShowGoals();
        manager.RecordGoalEvent("Read scriptures");
        manager.ShowScore();
    }
}
