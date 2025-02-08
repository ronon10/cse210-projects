using System;
using System.Collections.Generic;
using System.Threading;

// Base class for mindfulness activities
abstract class MindfulnessActivity
{
    protected int duration;

    public void Start()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {GetType().Name} Activity");
        Console.WriteLine(GetDescription());
        Console.Write("Enter duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        Thread.Sleep(3000);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("Well done! You have completed the activity.");
        Console.WriteLine($"Activity: {GetType().Name}, Duration: {duration} seconds");
        Thread.Sleep(3000);
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected abstract string GetDescription();
    protected abstract void PerformActivity();
}

// Breathing Activity
class BreathingActivity : MindfulnessActivity
{
    protected override string GetDescription()
    {
        return "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.";
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Inhale... ");
            ShowCountdown(3);
            Console.Write("Exhale... ");
            ShowCountdown(3);
        }
    }
}

// Reflection Activity
class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] prompts =
    {
        "Think of a time when you helped someone.",
        "Think of a time when you overcame a challenge.",
        "Think of a time when you were truly proud of yourself."
    };
    
    private static readonly string[] questions =
    {
        "Why was this experience meaningful?",
        "How did you feel afterward?",
        "What did you learn from this?"
    };

    protected override string GetDescription()
    {
        return "This activity will help you reflect on moments in your life where you showed strength and resilience.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Length)]);
        Thread.Sleep(3000);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(questions[random.Next(questions.Length)]);
            Thread.Sleep(5000);
        }
    }
}

// Listing Activity
class ListingActivity : MindfulnessActivity
{
    private static readonly string[] prompts =
    {
        "List the people you appreciate.",
        "List your personal strengths.",
        "List things that make you happy."
    };

    protected override string GetDescription()
    {
        return "This activity will help you reflect on the positive things in your life by listing as many as possible.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Length)]);
        ShowCountdown(5);

        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            responses.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {responses.Count} items!");
    }
}

// Program Main Menu
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    Thread.Sleep(2000);
                    continue;
            }

            activity.Start();
        }
    }
}
