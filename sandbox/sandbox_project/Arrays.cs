using System.Linq;
public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static void Run()
    {
        double[] array = MultiplesOf(3, 5);
        Console.WriteLine("<double> {" + string.Join(", ", array) + "}");
    }
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.


        /*
        Solution:
            - create multiples array variable : double
            - fixed array → result(variable name : int) → based on the length eg int result = int[length]; 
            - loop (for loop) through the length of the array
            - multiples is equal to the number * index added to 1 
            - return multiples array.
        */

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.


        /*
        Solution:
            - create a variable named rotatedList
            - loop through using the for loop : int using the data.Count counter
            - Inside a loop create 2 variables that return a list of skippedList (takes the last n of elements)
            - Creaate another variable called remainingList that takes a list of elements subtract data length from the amount
            - (use Linq ) for slicing → .TakeLast(amount).ToList(); the data list
            - replace the current List with the concatenation (using LINQ → list1.Concat(list2).ToList()) of the kept part and the skipped part.
            - show the list to the console and use Join seperated by the comma
        */

        List<int> rotatedList = new List<int>();

        for (int i = 0; i < data.Count; i++)
        {
            List<int> skippedList = data.TakeLast(amount).ToList();
            List<int> remainingList = data.Take(data.Count - amount).ToList();

            rotatedList = skippedList.Concat(remainingList).ToList();
        }

        Console.WriteLine("<List> {" + string.Join(", ", rotatedList) + "}");
        
    }
}

