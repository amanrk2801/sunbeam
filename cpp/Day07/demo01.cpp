#include <iostream>
using namespace std;

class Base
{
public:
    void f1()
    {
        cout << "Base::f1()" << endl;
    }
    void f2()
    {
        cout << "Base::f2()" << endl;
    }
};

class Derived : public Base
{
public:
    // function overriding
    void f2()
    {
        cout << "Derived::f2()" << endl;
    }

    void f3()
    {
        cout << "Derived::f3()" << endl;
    }
};

int main()
{

    Base *bptr = new Derived();
    bptr->f2();                      // Early Binding - Base::f2
    Derived *dptr = (Derived *)bptr; // Downcasting
    dptr->f2();
    return 0;
}

int main1()
{
    Base *bptr = new Derived(); // Upcasting
    bptr->f1();
    bptr->f2();
    // bptr->f3(); // OBJECT SLICING
    Derived *dptr = (Derived *)bptr; // Downcasting
    dptr->f3();
    return 0;
}