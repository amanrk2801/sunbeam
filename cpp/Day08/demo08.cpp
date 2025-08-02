#include <iostream>
using namespace std;

template <class T>
class myvector
{
    T *ptr;
    int size;
    int index;

public:
    myvector(int size = 5)
    {
        this->size = size;
        this->index = 0;
        ptr = new T[size];
    }

    // to add the given element in to the array
    void addElement(T element)
    {
        if (index < size)
        {
            ptr[index] = element;
            index++;
        }
        else
        {
            cout << "myvector is full " << endl;
        }
    }

    T get(int index)
    {
        if (index >= 0 && index < this->index)
            return ptr[index];
        return NULL;
    }

    int length()
    {
        return index;
    }

    ~myvector()
    {
        delete[] ptr;
        ptr = NULL;
    }
};

int main()
{
    myvector<int *> v1;
    v1.addElement(new int(10));
    v1.addElement(new int(20));
    v1.addElement(new int(30));
    v1.addElement(new int(40));
    v1.addElement(new int(50));

    for (int i = 0; i < v1.length(); i++)
    {
        cout << "Element = " << *v1.get(i) << endl;
    }
    return 0;
}

int main1()
{
    myvector<int> v1;
    v1.addElement(10);
    v1.addElement(20);
    v1.addElement(30);
    v1.addElement(40);
    v1.addElement(50);
    v1.addElement(60);

    for (int i = 0; i < v1.length(); i++)
    {
        cout << "Element = " << v1.get(i) << endl;
    }
    return 0;
}