public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
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
            - Test edge cases, if the data is empty, return nothing
            - Normalize the amount (avoid rotating more than needed)
            - Slice the list into two parts (one that will contain the skipped and the remaining)
            - The skipped list will return a list
            - Take the remaining list and concatenate with the skipped list
            - Output the result
        */

        if (data == null || data.Count == 0) return; 
         
        amount = amount % data.Count; 

        List<int> skippedList = data.TakeLast(amount).ToList();
        
        List<int> remainingList = data.Take(data.Count - amount).ToList();

        List<int> rotatedList = skippedList.Concat(remainingList).ToList();

        data.Clear(); data.AddRange(rotatedList); 
        
        Console.WriteLine("==================== Rotated List =======================");
        Console.WriteLine("<List> {" + string.Join(", ", data) + "}");

    
    }
}