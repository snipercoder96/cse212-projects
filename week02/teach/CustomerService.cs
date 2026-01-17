/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Add customers until max size is reached
        // Expected Result: Queue should contain 3 customers
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(3);
        cs1._queue.Add(new CustomerService.Customer("Alice", "A001", "Login issue"));
        cs1._queue.Add(new CustomerService.Customer("Bob", "B002", "Payment failed"));
        cs1._queue.Add(new CustomerService.Customer("Charlie", "C003", "Password reset"));
        Console.WriteLine(cs1);
        // Defect(s) Found: Condition in AddNewCustomer uses > instead of >=, allowing one extra
        Console.WriteLine("=================");

        // Test 2
        // Scenario: Serve a customer from the queue
        // Expected Result: First customer removed, next customer printed
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(5);
        cs2._queue.Add(new CustomerService.Customer("Dave", "D004", "Account locked"));
        cs2._queue.Add(new CustomerService.Customer("Eve", "E005", "Billing error"));
        cs2.ServeCustomer();
        Console.WriteLine(cs2);
        // Defect(s) Found: ServeCustomer removes index 0 then tries to access index 0 again
        Console.WriteLine("=================");

        // Test 3
        // Scenario: Initialize with invalid max size
        // Expected Result: Default max size of 10 applied
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(0);
        Console.WriteLine(cs3);
        // Defect(s) Found: None
        Console.WriteLine("=================");

        // Test 4
        // Scenario: ToString on empty queue
        // Expected Result: size=0 max_size=10 => 
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(10);
        Console.WriteLine(cs4);
        // Defect(s) Found: None
        Console.WriteLine("=================");
    }




    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}