// Common Pointer Pitfalls and Best Practices
// 1. Null Pointer Dereferencing:
#include <stdio.h>

int main() {
    int *ptr = NULL;
    
    // Avoid this - will cause a segmentation fault
    // printf("%d", *ptr);
    
    // Always check before dereferencing
    if(ptr != NULL) {
        printf("%d", *ptr);
    } else {
        printf("Pointer is NULL\n");
    }
    
    return 0;
}