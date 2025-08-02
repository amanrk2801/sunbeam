#include <iostream>
using namespace std;

class Test
{
private:
    int n1;

protected:
    int n2;

public:
    int n3;

    void display()
    {
        cout << n1 << n2 << n3 << endl;
    }

    friend void f1();
};

// friend functions do not get this pointer
void f1()
{
    Test t;
    cout << t.n1 << t.n2 << t.n3 << endl;
}

int main()
{
    Test t;
    cout << t.n1 << t.n2 << t.n3 << endl;
    return 0;
}