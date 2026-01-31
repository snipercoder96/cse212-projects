using System.Collections;
using System.Transactions;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1

        /*
        Solution:
        - create a newNode for inserting towards the end
        - use a loop that checks if the next head isnt null
        - if it is null, add a newNode
        - the next tail should point to the new node
        - the new node should point to the tail node
        - the newnode should be equal to the tail
        */

        Node newNode = new(value);

        if (_head is null)
        {
            _head = newNode;
        }
        else
        {
            Node current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode; 
            newNode.Prev = current;
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        /*
        Solution:
        - Check if the head equals the tail, if so, then set the head and tail to null
        - otherwise get the previous tail (variable) to be equal the previous tail
        - then the next previous tail to be set to null 
        - Finally, the tail to be set to be eqaul to the previous tail
          */

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        } 
        else { 
            Node prevTail = _tail.Prev; 
            prevTail.Next = null;
            _tail = prevTail;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        /*
        Solution:
        - First store the head in a varivable for looping
        - loop throughout the nodes and set a check so it isnt null
        - if the check isnt null and if the value equals the head, call the RemoveHead() method
        - else if the current value equals the tail, remove the tail using the RemoveTail() method
        - otherwise if both the casesof the head and tail doesnt call, create varaibles
          containing the previous node and next nodes
        - set the previous node.next equal to the next node, and set the next node.previous to the previous node
        - return after removing the first match
        - current must be equal to the next node
        */

        Node current = _head;

        while (current != null)
        {
            if (current.Data == value)
            {

                if (current == _head)
                {
                    RemoveHead();
                } else if (current == _tail){
                    RemoveTail();
                }
                else
                {
                    Node prevNode = current.Prev;
                    Node nextNode = current.Next;

                    prevNode.Next = nextNode;
                    nextNode.Prev = prevNode;
                }
                return;

            }

            current = current.Next;  
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        /*
        Solution:
        - set the head variable to be equal to the  curret for looping
        - first check if the linked list is empty, if so, add the head and tail to be null
        - loop throught the linked list to check if its not equal to null
        - if the current data equals the old value, reset the current data to be equal to the new value
        - otherwise get the next node 
        */

        Node current = _head;

        if (_head == null) return;
        

        while (current != null)
        {
            if (current.Data == oldValue)
            {
                current.Data = newValue;
            }

            current = current.Next;
        }

    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        /*
        Solution:
        - create a varaibel containing the tail for looping backwards from the tail
        - while the current tail isnt null, return the current data
        - get the previous node.
        */

        Node current = _tail;
        while (current is not null)
        {
            yield return current.Data;
            current = current.Prev;
        }
         // replace this line with the correct yield return statement(s)
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}