#include <iostream>
using namespace std;

class Base
{public:
    int bnum=20;

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
    int dnum=10;
public:
Derived(){}
    void f3()
    {
        cout << "Derived::f3()" << endl;
    }
};

int main()
{
    Base *bptr = new Derived(); // upcasting
    bptr->f1();
    bptr->f2();

    // bptr->f3(); // NOT OK -> Object Slicing

    Derived *dptr = (Derived *)bptr; // Downcasting
    dptr->f3();
    
    return 0;
}

int main1()
{
    Base *bptr = new Base();
    bptr->f1();
    bptr->f2();
    
    Derived *dptr = new Derived();
    dptr->f1();
    dptr->f2();
    dptr->f3();

    // int *ptr1 = (int *)malloc(1 * sizeof(int));
    return 0;
}
