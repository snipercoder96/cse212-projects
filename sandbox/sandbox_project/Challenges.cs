
/*
Solution
    - Start with an array
    - use a for loop to iterate through
    - If the array is full multply the array length by 2 and create a new varaible storing the new array
    - add the old array elements to the new elements, preserving their space
    - create a variable that keeps count of how many resizing it has occured by n elements
*/

public static class Challenges
{
    public static void Run()
    {

    }

    public static int[] ResizingArray(int initialSize, int n)
    {
        int[] array = new int[initialSize];
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            
            if (count == array.Length)
            {
                int[] newArray = new int[array.Length * 2];
                for (int j = 0; j < array.Length; j++)
                {
                    newArray[j] = array[j];
                }
                array = newArray; 
            }

            array[count] = i;
            count++;
        }

        return array;
    }

}