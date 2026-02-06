using System;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        void SayHello(int count)
        {
            if(count <= 0) return;
            Console.WriteLine("Hello");
            SayHello(count - 1); // ❌ no base case, never reduces the problem
        }

        SayHello(5);

    }
}