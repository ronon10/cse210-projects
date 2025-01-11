using System;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("What was your percentage grade?: ");
        string valueFromUser = Console.ReadLine();
        int percent = int.Parse(valueFromUser);

        string letter = "";

        if (percent >= 90)
        {
            letter = "Congrats - A";
        }
        else if (percent >= 80)
        {
            letter = "Congrats - B";
        }
        else if (percent >= 70)
        {
            letter = "Congrats - C";
        }
        else if (percent >= 60)
        {
            letter = "You dont pass - D";
        }
        else 
        {
            letter = "Tray again - F";
        }
        Console.WriteLine($"Your grade is: {letter}.");

        if (percent >= 70)
        {
            Console.WriteLine("Congradulations!! You pass");
        }
        else
        {
            Console.WriteLine("Tray again next semester");
        }
    
    
    
    
    }

}