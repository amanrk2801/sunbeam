// Function Pointers
// You can create pointers to functions and call them indirectly:
#include <stdio.h>

// Function declarations
int add(int a, int b) {
    return a + b;
}

int subtract(int a, int b) {
    return a - b;
}

int main() {
    // Declare a function pointer
    int (*operation)(int, int);
    
    // Point to add function
    operation = add;
    printf("Result of add: %d\n", operation(5, 3));
    
    // Point to subtract function
    operation = subtract;
    printf("Result of subtract: %d\n", operation(5, 3));
    
    return 0;
}