#include <iostream>
using namespace std;

class Base
{
public:
    Base()
    {
        cout << "Base()" << endl;
    }
    virtual void f1()
    {
        cout << "Base::f1()" << endl;
    }
    void f2()
    {
        cout << "Base::f2()" << endl;
    }
    virtual ~Base()
    {
        cout << "~Base()" << endl;
    }
};

class Derived : public Base
{
public:
    Derived()
    {
        cout << "Derived()" << endl;
    }
    void f3()
    {
        cout << "Derived::f3()" << endl;
    }
    ~Derived()
    {
        cout << "~Derived()" << endl;
    }
};

int main()
{

    // Base *bptr = new Base();
    // delete bptr;
    // bptr = NULL;

    // Derived *dptr = new Derived();
    // delete dptr;
    // dptr = NULL;

    Base *bptr = new Derived();
    delete bptr;
    bptr = NULL;
    return 0;
}
