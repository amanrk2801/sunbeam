#include <iostream>
#include <memory>
using namespace std;

void demonstrateBasicPointers() {
    cout << "\n==== BASIC POINTERS ====\n";
    
    // Declaring and initializing a variable
    int num = 10;
    cout << "Variable num: " << num << endl;
    cout << "Address of num: " << &num << endl;
    
    // Declaring and initializing a pointer
    int* ptr = &num;
    cout << "Pointer ptr holds address: " << ptr << endl;
    cout << "Value at the address ptr points to (dereferencing): " << *ptr << endl;
    
    // Modifying value using pointer
    *ptr = 20;
    cout << "After *ptr = 20, num = " << num << endl;
}

void demonstratePointerArithmetic() {
    cout << "\n==== POINTER ARITHMETIC ====\n";
    
    int arr[5] = {10, 20, 30, 40, 50};
    int* ptr = arr; // points to the first element
    
    cout << "Array elements using pointer arithmetic:\n";
    for (int i = 0; i < 5; i++) {
        cout << "arr[" << i << "] = " << *(ptr + i) << " at address " << (ptr + i) << endl;
    }
    
    // Incrementing pointers
    cout << "\nIncrementing pointer:\n";
    cout << "Initially ptr points to: " << *ptr << " at address " << ptr << endl;
    ptr++;
    cout << "After ptr++, ptr points to: " << *ptr << " at address " << ptr << endl;
}

void demonstrateNullPointers() {
    cout << "\n==== NULL POINTERS ====\n";
    
    int* ptr = nullptr; // Modern C++ null pointer (C++11 and later)
    
    cout << "Value of nullptr pointer: " << ptr << endl;
    
    // Checking for null before dereferencing
    if (ptr != nullptr) {
        cout << "Value at ptr: " << *ptr << endl; // This won't execute
    } else {
        cout << "Cannot dereference nullptr (would cause segmentation fault)" << endl;
    }
    
    // Assigning a value to the pointer
    int num = 100;
    ptr = &num;
    cout << "After assignment, ptr points to: " << *ptr << endl;
}

void demonstratePointerToPointer() {
    cout << "\n==== POINTER TO POINTER ====\n";
    
    int num = 42;
    int* ptr1 = &num;      // pointer to int
    int** ptr2 = &ptr1;    // pointer to pointer to int
    
    cout << "num = " << num << endl;
    cout << "Address of num = " << &num << endl;
    cout << "ptr1 = " << ptr1 << endl;
    cout << "Address of ptr1 = " << &ptr1 << endl;
    cout << "ptr2 = " << ptr2 << endl;
    
    // Dereferencing
    cout << "\nDereferencing:\n";
    cout << "*ptr1 = " << *ptr1 << endl;        // value of num
    cout << "*ptr2 = " << *ptr2 << endl;        // value of ptr1 (address of num)
    cout << "**ptr2 = " << **ptr2 << endl;      // value of num
    
    // Modifying the original value through double pointer
    **ptr2 = 100;
    cout << "\nAfter **ptr2 = 100:\n";
    cout << "num = " << num << endl;
}

void modifyValueUsingPointer(int* ptr) {
    *ptr = *ptr * 2; // Double the value
}

void demonstrateFunctionPointers() {
    cout << "\n==== FUNCTION POINTERS ====\n";
    
    // Function pointer declaration
    void (*funcPtr)(int*) = modifyValueUsingPointer;
    
    int num = 25;
    cout << "Before function call: num = " << num << endl;
    
    // Call function through pointer
    funcPtr(&num);
    
    cout << "After function call: num = " << num << endl;
}

void demonstrateConstPointers() {
    cout << "\n==== CONST POINTERS ====\n";
    
    int x = 10, y = 20;
    
    // Pointer to constant (can't modify the value pointed to)
    const int* ptr1 = &x;
    cout << "const int* ptr1 points to: " << *ptr1 << endl;
    // *ptr1 = 30; // Error: can't modify value
    ptr1 = &y; // But can change where it points
    cout << "After changing ptr1 to point to y: " << *ptr1 << endl;
    
    // Constant pointer (can't change where it points)
    int* const ptr2 = &x;
    cout << "int* const ptr2 points to: " << *ptr2 << endl;
    *ptr2 = 30; // Can modify the value
    cout << "After *ptr2 = 30, x = " << x << endl;
    // ptr2 = &y; // Error: can't change where it points
    
    // Constant pointer to constant (can't change pointer or value)
    const int* const ptr3 = &y;
    cout << "const int* const ptr3 points to: " << *ptr3 << endl;
    // *ptr3 = 50; // Error: can't modify value
    // ptr3 = &x;  // Error: can't change where it points
}

void demonstrateSmartPointers() {
    cout << "\n==== SMART POINTERS (C++11 and later) ====\n";
    
    // Unique pointer (exclusive ownership)
    cout << "-- Unique Pointer --\n";
    unique_ptr<int> uniquePtr = make_unique<int>(42);
    cout << "uniquePtr value: " << *uniquePtr << endl;
    
    // No need to manually delete, memory is freed when uniquePtr goes out of scope
    
    // Shared pointer (shared ownership)
    cout << "\n-- Shared Pointer --\n";
    shared_ptr<int> sharedPtr1 = make_shared<int>(100);
    cout << "sharedPtr1 value: " << *sharedPtr1 << endl;
    cout << "sharedPtr1 reference count: " << sharedPtr1.use_count() << endl;
    
    {
        shared_ptr<int> sharedPtr2 = sharedPtr1; // Reference count increases
        cout << "Inside nested scope:\n";
        cout << "sharedPtr2 value: " << *sharedPtr2 << endl;
        cout << "Reference count: " << sharedPtr1.use_count() << endl;
        
        // Modify value through sharedPtr2
        *sharedPtr2 = 200;
        cout << "After modification via sharedPtr2, sharedPtr1 value: " << *sharedPtr1 << endl;
    } // sharedPtr2 goes out of scope, reference count decreases
    
    cout << "\nAfter nested scope, reference count: " << sharedPtr1.use_count() << endl;
    
    // Weak pointer (non-owning reference)
    cout << "\n-- Weak Pointer --\n";
    weak_ptr<int> weakPtr = sharedPtr1;
    cout << "weakPtr expired? " << weakPtr.expired() << endl;
    
    if (auto temp = weakPtr.lock()) { // Get shared_ptr from weak_ptr
        cout << "Got value via weak pointer: " << *temp << endl;
    } else {
        cout << "Weak pointer expired" << endl;
    }
    
    // Reset the shared_ptr
    sharedPtr1.reset();
    cout << "After resetting sharedPtr1, weakPtr expired? " << weakPtr.expired() << endl;
}

void demonstrateVoidPointers() {
    cout << "\n==== VOID POINTERS ====\n";
    
    int num = 42;
    float decimal = 3.14f;
    char letter = 'A';
    
    // Void pointer can point to any data type
    void* voidPtr;
    
    voidPtr = &num;
    cout << "voidPtr pointing to int: " << voidPtr << endl;
    // Need to cast void pointer before dereferencing
    cout << "Value: " << *(static_cast<int*>(voidPtr)) << endl;
    
    voidPtr = &decimal;
    cout << "voidPtr pointing to float: " << voidPtr << endl;
    cout << "Value: " << *(static_cast<float*>(voidPtr)) << endl;
    
    voidPtr = &letter;
    cout << "voidPtr pointing to char: " << voidPtr << endl;
    cout << "Value: " << *(static_cast<char*>(voidPtr)) << endl;
}

void demonstrateDangerousPointers() {
    cout << "\n==== DANGEROUS POINTER PRACTICES ====\n";
    
    // 1. Using uninitialized pointer
    int* uninitPtr; // Uninitialized, contains garbage address
    cout << "Uninitialized pointer (address): " << uninitPtr << endl;
    // cout << *uninitPtr << endl; // DANGER: Dereferencing can crash program
    
    // 2. Memory leak
    int* leakPtr = new int(42);
    cout << "Allocated memory with value: " << *leakPtr << endl;
    // Forgetting to delete leads to memory leak
    // Proper way:
    delete leakPtr;
    cout << "Memory freed" << endl;
    leakPtr = nullptr; // Good practice to nullify after delete
    
    // 3. Dangling pointer
    int* ptr1 = new int(100);
    int* ptr2 = ptr1; // Both point to same memory
    
    delete ptr1; // Memory freed
    ptr1 = nullptr; // This pointer is nullified but...
    
    cout << "ptr2 still points to freed memory: " << ptr2 << endl;
    // cout << *ptr2 << endl; // DANGER: Accessing freed memory
}

int main() {
    cout << "C++ POINTERS DEMONSTRATION\n";
    cout << "==========================\n";
    
    demonstrateBasicPointers();
    demonstratePointerArithmetic();
    demonstrateNullPointers();
    demonstratePointerToPointer();
    demonstrateFunctionPointers();
    demonstrateConstPointers();
    demonstrateSmartPointers();
    demonstrateVoidPointers();
    demonstrateDangerousPointers();
    
    return 0;
}