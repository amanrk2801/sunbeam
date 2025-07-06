// Basic Pointer Concepts
// A pointer is a variable that stores the memory address of another variable.
#include <stdio.h>
int main(){
    int num = 10;
    int *ptr = &num; 

    printf("Value of num: %d\n", num);
    printf("Address of num: %p\n", &num);
    printf("Value of ptr (address it points to): %p\n", ptr);
    printf("Value pointed to by ptr: %d\n", *ptr);

    // Changing value using the pointer 
    *ptr = 20;
    printf("New value of num: %d\n", num);
    return 0;
}

// C:\Users\amank\OneDrive\Desktop\Sunbeam-Labs\Extras\cpp>g++ 1.c

// C:\Users\amank\OneDrive\Desktop\Sunbeam-Labs\Extras\cpp>a.exe
// Value of num: 10
// Address of num: 0061FF18
// Value of ptr (address it points to): 0061FF18
// Value pointed to by ptr: 10
// New value of num: 20