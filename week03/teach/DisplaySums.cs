public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);
        // Should show something like (order does not matter):
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
        // Should show something like (order does not matter):
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time.  We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>
    private static void DisplaySumPairs(int[] numbers) {
        // TODO Problem 2 - This should print pairs of numbers in the given array


        /*
        How can you solve the problem using a set data structure?
        - We can solve the problem in multiple ways, the first way is the time complexity of O(n),
        instead of O(n^2) we could approach a set, thus as mentioned earlier, this reduces duplication,
        making performance way faster and optimized.

        Solution:
        - create target variable equal to 10
        - create complement variable that will subtraact 10 from its actual value(currentNumber) 
            ( done inside the loop)
        - create a set variable (name it according to meaningfulness)
        - iterate through the numbers using for loop
        - if complement equals target
        - Show the current number and complement to the console
        - add the complement variable to the set
   
        */

        int target = 10;
        var pairedNumbers = new HashSet<int>();

        for (int i = 0; i < numbers.Length; ++i)
        {
            int currentNumber = numbers[i];
            int complement = target - currentNumber;

            if (pairedNumbers.Contains(complement))
            {
                Console.WriteLine($"{currentNumber} {complement}");
            }
            pairedNumbers.Add(currentNumber);
        }
        

    }
}