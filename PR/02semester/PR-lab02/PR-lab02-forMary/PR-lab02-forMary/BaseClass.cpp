#include "header.h"

template <typename T>
class Base {
    private:
        vector<T> elements;
    public:
        void addElement(T element) {
            elements.push_back(element);
        }
        void deleteElementByIndex(int index) {
            elements.erase(elements.begin() + index);
        }
}

