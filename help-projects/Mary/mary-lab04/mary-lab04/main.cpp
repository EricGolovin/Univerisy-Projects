//
//  main.cpp
//  mary-lab04
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
    
    // demo mode
//    if (flag) {
//        for (int firstIndex = 0; firstIndex < 4; firstIndex++) {
//            vector <int> testVector1;
//            mainVector.push_back(testVector1);
//            for (int secondIndex = 0; secondIndex < 4; secondIndex++) {
//                mainVector[firstIndex].push_back(firstIndex - 1 - secondIndex);
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
    
    // do calculations
    for (int firstIndex = 0; firstIndex < mainVector.size(); firstIndex++) {
        int numOfPositiveIntegers = 0;
        vector<int> lineNegativeIntegers;
        for (int secondIndex = 0; secondIndex < mainVector[firstIndex].size(); secondIndex++) {
            if (mainVector[firstIndex][secondIndex] >= 0) {
                numOfPositiveIntegers += 1;
            } else {
                lineNegativeIntegers.push_back(mainVector[firstIndex][secondIndex]);
            }
        }
        if (numOfPositiveIntegers > 0) {
            mainVector[firstIndex][firstIndex] = numOfPositiveIntegers;
        } else {
            sort(lineNegativeIntegers.begin(), lineNegativeIntegers.end());
            mainVector[firstIndex][firstIndex] = lineNegativeIntegers.back();
        }
    }
    
    // print mainVector
    for (int firstIndex = 0; firstIndex < mainVector.size(); firstIndex++) {
        for (int secondIndex = 0; secondIndex < mainVector[firstIndex].size(); secondIndex++) {
            cout << mainVector[firstIndex][secondIndex] << " ";
        }
        cout << endl;
    }
    
    
    return 0;
}
