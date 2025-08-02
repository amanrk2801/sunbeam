// Dynamic Memory Allocation
// Pointers are essential for dynamic memory allocation:
#include <stdio.h>
#include <stdlib.h>

int main() {
    int *ptr;
    int n = 5;
    
    // Allocate memory for 5 integers
    ptr = (int*)malloc(n * sizeof(int));
    
    if(ptr == NULL) {
        printf("Memory allocation failed\n");
        return 1;
    }
    
    // Store values in allocated memory
    for(int i = 0; i < n; i++) {
        ptr[i] = i * 10;
    }
    
    // Print the values
    for(int i = 0; i < n; i++) {
        printf("%d ", ptr[i]);
    }
    
    // Free the allocated memory
    free(ptr);
    
    return 0;
}