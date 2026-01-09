# Arrays and Dynamic Arrays

## Fixed array

- A fixed array is a collection of data put in memory with the following properties:

- The fixed array cannot grow or shrink after it is created.

- Each item in the fixed array is the same size

- Each item in the fixed array is contiguous (i.e. right next to each other) in memory.

memory(index) = startingAddress + (index * itemSize)



1. What is item size?
- Item size is the amount of memory (in bytes) required to store a single element in the array.

- It depends entirely on the data type of the array:

- int in C# or Java → typically 4 bytes

- double → typically 8 bytes

- char → typically 2 bytes (in C#) or 1 byte (in C)

- bool → often 1 byte, though sometimes optimized differently


2. To create a fixed array in C#, you allocate the array with a size and type, and then add items by index:

``` c#
var numbers = new int[3]; // this line adds a fixed array with number of 3 items inside

numbers[0] = 1;
numbers[1] = 2;
numbers[2] = 3;

// OR

var numbers = new[] {1, 2, 3};
```

## Dynamic arrays

``` c#
var list = new List<int>(); Console.WriteLine(list.Count); // 0 (no items yet) 
Console.WriteLine(list.Capacity); // often starts at 0 or 4 depending on runtime
```

To properly grow the array, we have to complete the following steps:

- Create a new array twice as big as the original array. Usually a dynamic array starts with capacity 0 and then increases in the following pattern: 0, 1, 2, 4, 8, 16, 32, 64, 128, etc.
- Copy all the values from the original smaller array into the new larger array.
- Delete the original smaller array.
- Add the new item to the larger array.


1. Inserting to dynamic arrays

- if we insert a value at the beginning of the array, all other items will need to move to the next index (i.e. move to the right).

2. Deleting from the Dynamic Array

- If we wanted to delete an item from the array, we would need to move all items after the item removed to the previous index (i.e. move to the left). As a special case, if we wanted to remove the last item in the array, we would not need to move any other items. 

Table of info 

insert(index, value)	Adds "value" to the specified index and moves subsequent items to the next index.	myList.Insert(index, value)
remove(index)	Removes the item at the specified index and moves subsequent items to the previous index.	myList.Remove(index)
size()	Return the size of the dynamic array.	myList.Count
capacity()	Return the capacity of the dynamic array.	myList.Capacity
empty()	Returns true if the length of the dynamic array is zero.	myList.Count == 0


``` c#
// This is for a list
for (var index = 0; index < myList.Count; ++index)
{
  Console.WriteLine(myList[index]);
}

// This is for an array
for (var index = 0; index < myArray.Length; ++index)
{
  Console.WriteLine(myArray[index]);
} 

// We use Count for a list & array is Length

```



## Lists vs Arrays
Dynamic arrays seem like they are so much more useful, so is there ever a reason to use a fixed array? Of course!

### Advantages of Dynamic Arrays
- Expandable
- Advantages of Fixed Arrays
- Faster memory allocation if you know how much to store
- Dynamic arrays need to expand and copy the contents once they experience overflow
- Consumes slightly less memory as there is less metadata in an array