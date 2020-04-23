//
//  main.cpp
//  PR-lab04
//
//  Created by Eric Golovin on 23.04.2020.
//  Copyright © 2020 com.ericgolovin-university. All rights reserved.
//

#include <iostream>
#include <vector>
#include <sstream>
using namespace std;

int main(int argc, const char * argv[]) {
    vector<vector<int> > mainVector;
    int flag = 0;
    int lineCounter = 1;
    
    cout << "(print <next> to move to the next Line; <stop> to end)" << endl;
    
    // fill up mainVector
    while (!flag) {
        vector<int> tempVector;
        int indexOfElement = 0;
        cout << "Line #" << lineCounter << endl;
        while (1) {
            stringstream inputStrStream;
            string buffer;
            int inputInteger;

            cout << "\tEnter element #" << indexOfElement << ": ";
            indexOfElement += 1;

            cin >> buffer;
            if (buffer == "next" || buffer == "<next>") {
                lineCounter += 1;
                break;
            } else if (buffer == "stop" || buffer == "<stop> ") {
                flag = 1;
                break;
            }

            inputStrStream << buffer;
            inputStrStream >> inputInteger;
            tempVector.push_back(inputInteger);
        }
        mainVector.push_back(tempVector);
    }
    
//    // demo mode
//    if (flag) {
//        for (int firstIndex = 0; firstIndex < 43; firstIndex++) {
//            vector <int> testVector1;
//            mainVector.push_back(testVector1);
//            for (int secondIndex = 0; secondIndex < 6; secondIndex++) {
//                mainVector[firstIndex].push_back(firstIndex + secondIndex);
//            }
//        }
//        for (int firstIndex = 0; firstIndex < mainVector.size(); firstIndex++) {
//            for (int secondIndex = 0; secondIndex < mainVector[firstIndex].size(); secondIndex++) {
//                cout << mainVector[firstIndex][secondIndex] << " ";
//            }
//            cout << endl;
//        }
//        cout << endl;
//    }
    
    // caculations
    
    vector<int> resultVector;
    
    for (int firstIndex = 0; firstIndex < mainVector.size(); firstIndex++) {
        int positiveIntegers = 0;
        for (int secondIndex = 0; secondIndex < mainVector[firstIndex].size(); secondIndex++) {
            if (mainVector[firstIndex][secondIndex] >= 0) {
                positiveIntegers += 1;
            }
        }
        resultVector.push_back(positiveIntegers);
    }
    
    // printing result array
    cout << "Result Vector: ";
    int index;
    for (index = 0; index < resultVector.size(); index++) {
        if (resultVector[index] > 0) {
            cout << resultVector[index] << " ";
        } else {
            break;
        }
    }
    
    cout << endl << "Number of elements after zero: " << resultVector.size() - index << endl;
    
    return 0;
}
