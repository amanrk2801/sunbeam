#include <iostream>
using namespace std;

class Base
{
private:
    int n1;

protected:
    int n2;

public:
    int n3;

    void displayBase()
    {
        cout << n1 << n2 << n3 << endl;
    }
    friend class Derived;
};

class Derived : public Base
{
public:
    void displayDerived()
    {
        cout << n1 << n2 << n3 << endl;
    }
};

int main()
{

    return 0;
}