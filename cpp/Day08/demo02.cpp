#include <iostream>
using namespace std;

class Test
{
    mutable int n1;
    const int n2;
    int n3;

public:
    Test() : n2(20)
    {
        n1 = 10;
        n3 = 30;
    }

    void f1() const // const Test *const this
    {
        n1 = 100; // OK
        // n2 = 200; // NOT OK
        const_cast<Test *const>(this)->n3 = 300; // OK
    }
    void f2() // Test *const this
    {
        n1 = 30; // OK
        // n2 = 200; /// NOT OK
        n3 = 300; // OK
    }
    void f3() const
    {
        n1 = 40;  // OK
        n3 = 300; // NOT OK
    }
};

int main()
{

    return 0;
}