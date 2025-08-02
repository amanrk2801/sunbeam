// Pointers and Arrays
// Arrays and pointers are closely related in C:
#include <stdio.h>

int main() {
    int arr[5] = {10, 20, 30, 40, 50};
    
    printf("Using array notation:\n");
    for(int i = 0; i < 5; i++) {
        printf("%d ", arr[i]);
    }
    
    printf("\nUsing pointer notation:\n");
    for(int i = 0; i < 5; i++) {
        printf("%d ", (arr + i));
    }
    
    return 0;
}