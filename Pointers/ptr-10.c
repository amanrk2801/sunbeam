// Common Pointer Pitfalls and Best Practices
// Dangling Pointers:
#include <stdio.h>
#include <stdlib.h>

int main() {
    int *ptr = (int*)malloc(sizeof(int));
    *ptr = 10;
    
    printf("Value: %d\n", *ptr);
    
    free(ptr);  // Memory is freed
    
    // DANGEROUS: Accessing freed memory
    // printf("Value after free: %d\n", *ptr);  // Undefined behavior
    
    // Set to NULL after freeing
    ptr = NULL;
    
    return 0;
}