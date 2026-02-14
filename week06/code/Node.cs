public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        /*
        solution:
        - if value less than data, move to the left part
        - check if empty
        - check if value greater than right, if right is null, 
            add the new node otherwise insert the value there
        - if value == data return nothing to remove duplicates*/

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        else 
        {
            return;
        }
    }

    public bool Contains(int value)
    {
        // TODO start problem 2

        /*
        - check if the same value equals the data then return true
        - if value less than data, if left is null return false otherwise return left.Contains the value
        - search right if null retur false otherwise return right.Contains value
        - use recursive solution to find this problem
        */
        if (value == Data)
        {
            // Found the value
            return true;
        }
        else if (value < Data)
        {
            // Search left subtree
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else // value > Data
        {
            // Search right subtree
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
    }


    public int GetHeight()
    {
        /*
        Solution:
        - lets initialte a leftheight, rightheight varaibles, check first that the nodes isnt null, if so return 0,
            otherwise recurse the call
        - otherwise, return 1 + the maximum tees height either left or right
         */
        int leftHeight = (Left is null) ? 0 : Left.GetHeight();
        int rightHeight = (Right is null) ? 0 : Right.GetHeight();


        return 1 + Math.Max(leftHeight, rightHeight);
    }

}