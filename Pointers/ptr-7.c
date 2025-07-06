// Void Pointers
// Void pointers can point to any data type:
#include <stdio.h>

int main() {
    int num = 10;
    float f = 3.14;
    void *vptr;
    printf("%d\n", sizeof (vptr)); // 4 bytes
    
    vptr = &num;  // Point to integer
    printf("Integer value: %d\n", *((int*)vptr));  // Casting required
    
    vptr = &f;    // Point to float
    printf("Float value: %.2f\n", *((float*)vptr));  // Casting required
    
    return 0;
}