#include <iostream>
using namespace std;

int main1()
{
    int num1 = 10;  // 'num1' is a regular integer
    int num2 = 20;  // 'num2' is a regular integer

    int *ptr;       // 'ptr' is a pointer to an integer
    
    ptr = &num1;    // 'ptr' now points to 'num1'
    *ptr = 30;      // Modifies the value of 'num1' through the pointer, so 'num1' becomes 30

    num1 = 40;      // Directly modifies 'num1' to 40, after it was modified via the pointer
    
    ptr = &num2;    // Now 'ptr' points to 'num2'
    
    cout << "num1: " << num1 << endl;  // Output: num1 is 40 (after direct modification)
    cout << "num2: " << num2 << endl;  // Output: num2 is still 20 (unchanged by the pointer)
    cout << "Value pointed by ptr: " << *ptr << endl;  // Output: Value pointed by ptr is 20 (value of num2)
    
    return 0;
}

int main2()
{
    int num1 = 10;       // 'num1' is a regular integer
    int const num2 = 20; // 'num2' is a constant integer

    const int *ptr;      // 'ptr' is a pointer to a constant integer (we can't modify what it points to)

    ptr = &num1;         // 'ptr' now points to 'num1' (a regular integer, but we cannot modify its value through the pointer)

    // *ptr = 30;         // This will not work because 'ptr' points to a constant integer, and we can't modify its value through 'ptr'.

    num1 = 30;           // This works because 'num1' is a regular integer, not constant.

    ptr = &num2;         // Now 'ptr' points to 'num2' (a constant integer), so we can't modify its value through 'ptr'

    cout << "num1: " << num1 << endl;                 // num1 is now 30 (modified directly)
    cout << "num2: " << num2 << endl;                 // num2 is still 20 (unchanged since it's constant)
    cout << "Value pointed by ptr: " << *ptr << endl; // Output will be 20 (value of num2)

    return 0;
}

int main3()
{
    const int num1 = 10; // 'num1' is a constant integer
    const int num2 = 20; // 'num2' is a constant integer

    const int *const ptr = &num1; // 'ptr' is a constant pointer to a constant integer, initialized to point to 'num1'

    // num1 = 30; // error
    // ptr = &num2;  // This line won't work because 'ptr' is a constant pointer, so we cannot change its address
    // *ptr = 40;    // This line won't work because 'ptr' points to a constant integer, so we cannot modify its value

    cout << "Value pointed by ptr: " << *ptr << endl; // This will print the value of 'num1'
}
