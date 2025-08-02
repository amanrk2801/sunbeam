// Pointer Arithmetic
// Pointers can be incremented and decremented, which moves them to the next or previous memory location of their data type.
#include <stdio.h>

int main() {
    int arr[5] = {10, 20, 30, 40, 50};
    int *ptr = arr;  // Points to the first element
    
    for(int i = 0; i < 5; i++) {
        printf("Value at arr[%d]: %d\n", i, arr);
        ptr++;  // Move to next integer location
    }
    
    return 0;
}