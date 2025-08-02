// Pointers to Structures
// Pointers are commonly used with structures:
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct Person {
    char name[50];
    int age;
};

int main() {
    struct Person *personPtr;
    printf("%d\n", sizeof(struct  Person)); // 56 
    
    // Allocate memory for a Person structure
    personPtr = (struct Person*)malloc(sizeof(struct Person));
    
    // Access structure members using pointer
    strcpy(personPtr->name, "John");  // Arrow operator
    personPtr->age = 30;
    
    printf("Name: %s\n", personPtr->name);
    printf("Age: %d\n", personPtr->age);
    
    // Free allocated memory
    free(personPtr);
    
    return 0;
}