// Pointers to Pointers
// C allows multiple levels of indirection with pointers:
#include <stdio.h>

int main() {
    int num = 10;
    int *ptr = &num;      // Pointer to num
    int **ptr_to_ptr = &ptr;  // Pointer to the pointer
    
    printf("Value of num: %d\n", &num);
    printf("Value using *ptr: %d\n", ptr);
    printf("Value using **ptr_to_ptr: %d\n", *ptr_to_ptr);
    
    **ptr_to_ptr = 20;  // Change value through double pointer
    printf("New value of num: %d\n", num);
    
    return 0;
}