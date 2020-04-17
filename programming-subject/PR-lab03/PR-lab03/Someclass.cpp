//
//  Someclass.cpp
//  PR-lab03
//
//  Created by Eric Golovin on 17.04.2020.
//  Copyright © 2020 com.ericgolovin-university. All rights reserved.
//

#include "Basement.cpp"

class Someclass {
public:
    
    void printWithInt(string str, int num) {
        for (int i = 0; i < str.size(); i++) {
            if (str[i] == '~') {
                stringstream destinationStrStream;
                destinationStrStream << num;
                cout << destinationStrStream.str();
            } else {
                cout << str[i];
            }
        }
        cout << endl;
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
    
    string getStringWith_strs(string str, string arr[], int num) {
        string result = "";
        for (int i = 0, arrIndex = 0; i < str.size(); i++) {
            if (str[i] == '~') {
                stringstream destinationStrStream;
                destinationStrStream << arr[arrIndex];
                result += destinationStrStream.str();
                arrIndex += 1;
            } else {
                result += str[i];
            }
        }
        return result + "\n";
    }
    
    string getStringWith_ints(string str, int arr[], int num) {
        string result = "";
        for (int i = 0, arrIndex = 0; i < str.size(); i++) {
            if (str[i] == '~') {
                stringstream destinationStrStream;
                destinationStrStream << arr[arrIndex];
                result += destinationStrStream.str();
                arrIndex += 1;
            } else {
                result += str[i];
            }
        }
        return result + "\n";
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
        cout << sen;
    }
    
};
