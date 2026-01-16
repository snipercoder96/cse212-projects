using System;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.
        

        Console.WriteLine();

        Console.WriteLine("================ Rotate list ======================");
        List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Arrays.RotateListRight( list, 9);

        Console.WriteLine("\n======================\nMysteryStack1\n======================");
        Console.WriteLine(MysteryStack1.Run("racecar"));
        Console.WriteLine(MysteryStack1.Run("stressed"));
        Console.WriteLine(MysteryStack1.Run("a nut for a jar of tuna"));

        Console.WriteLine("\n======================\nMysteryStack2\n======================");
        Console.WriteLine(MysteryStack2.Run("5 3 7 + *"));
        Console.WriteLine(MysteryStack2.Run("6 2 + 5 3 - /"));
        try
        {
            MysteryStack2.Run("3 +");
            Console.WriteLine("WRONG: expected ApplicationException: Invalid Case 1!");
        }
        catch (ApplicationException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            MysteryStack2.Run("5 0 /");
            Console.WriteLine("WRONG: expected ApplicationException: Invalid Case 2!");
        }
        catch (ApplicationException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            MysteryStack2.Run("3 8 %");
            Console.WriteLine("WRONG: expected ApplicationException: Invalid Case 3!");
        }
        catch (ApplicationException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            MysteryStack2.Run("5 3 4 +");
            Console.WriteLine("WRONG: expected ApplicationException: Invalid Case 4!");
        }
        catch (ApplicationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}