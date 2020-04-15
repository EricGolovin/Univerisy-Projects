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
        int numOfElements() {
            return elements.size();
        }
        T getCardByIndex(int index) {
            return elements[index];
        }
        void printWithArguments(string str, int arr[], int num) {  
            for (int i = 0, arrIndex = 0; i < str.size(); i++) {
                if (str[i] == '~') {
                    stringstream destinationStrStream;
                    destinationStrStream << arr[arrIndex];
                    cout << destinationStrStream.str();
                    arrIndex += 1;
                } else {
                    cout << str[i];
                }
            }
            cout << endl;
        }
       void printWithStrArguments(string str, string arr[], int num) {
            for (int i = 0, arrIndex = 0; i < str.size(); i++) {
                if (str[i] == '~') {
                    stringstream destinationStrStream;
                    destinationStrStream << arr[arrIndex];
                    cout << destinationStrStream.str();
                    arrIndex += 1;
                } else {
                    cout << str[i];
                }
            }
            cout << endl;
        }
        void print(string sen) {
            cout << sen << endl;
        }

};

