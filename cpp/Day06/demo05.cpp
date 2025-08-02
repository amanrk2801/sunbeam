#include <iostream>
using namespace std;

class A
{
public:
    int n1;

    A()
    {
        n1 = 10;
        cout << "A()" << endl;
    }
    void displayA()
    {
        cout << n1 << endl;
    }
};

class B : virtual public A
{
public:
    int n2;
    B()
    {
        n1 = 100;
        n2 = 20;
        cout << "B()" << endl;
    }
    void displayB()
    {
        cout << n1 << n2 << endl;
    }
};

class C : virtual public A
{
public:
    int n3;
    C()
    {
        n3 = 30;
        cout << "C()" << endl;
    }

    void displayC()
    {
        cout << n1 << n3 << endl;
    }
};

class D : public B, public C
{
public:
    int n4;
    D()
    {
        n4 = 40;
        cout << "D()" << endl;
    }
    void displayD()
    {
        // cout << n1 << n2 << n3 << n4 << endl;
    }
};

int main()
{
    // A a;
    // B b;
    // C c;
    // D d;
    return 0;
}