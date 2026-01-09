# Big O Notation

- Describes the worst case scenario
- pronounced as big oh of n.
- Big O O(?) of something entails how many operations will it take to execute in terms of n! (n - The size of the input)

- If a function has O(n) performance, then we also say that the function has `linear` performance
- drop lesser exponents like (in this example) the n2 and the n. Therefore, O(2n3 - 7n2 + 13n - 15) = O(n3). This code likely has a loop, within a loop, within a loop.

## Rule of thumb
1. Nested Loops multiply, serial loops (one after the other) we add (n)
2. Drop constant coefficeint eg O(2n) => O(n)
3. Drop lesser exponents 

O(n) = walking up a hill.
O(n²) = climbing a mountain that gets exponentially steeper the higher you go.