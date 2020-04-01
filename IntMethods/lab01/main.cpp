#include <iostream>
#include <sstream>
#include <cmath>
using namespace std;

double getX_argument() {
    string buffer;
    double result;
    stringstream strInputStream;

    cout << "Enter START value for X: ";
    cin >> buffer;
    strInputStream << buffer;
    strInputStream >> result;

    return result;
}

double getX_LastArgument() {
    string buffer;
    double result;
    stringstream strInputStream;

    cout << "Enter END value for X: ";
    cin >> buffer;
    strInputStream << buffer;
    strInputStream >> result;

    return result;
}

double getCalculationMistake_argument() {
    string buffer;
    
    cout << "Enter calculation mistake: ";
    cin >> buffer;
    int lastInputDigit = buffer.back() - '0';
    double result = 1 * pow(10, -lastInputDigit);
    
    return result;
}

int main(int argc, char *argv[]) {
    double xArgument = getX_argument();
    double xArgumentLastValue = getX_LastArgument();
    double calcMistakeArgument = getCalculationMistake_argument();
    
    long double initialResult = 0;
    double runtimeCalculation = 0;
    double sumCalculation = 0;
    int index = 1;
    
    while (xArgument <= xArgumentLastValue) {

        cout << endl << "--------------------------------------------> " << "X = " << xArgument << endl;
        while (calcMistakeArgument < sumCalculation) {
            sumCalculation = pow(-1, index)  / (pow(xArgument, 2) - pow(index * M_PI, 2));
            index += 1;
            runtimeCalculation += sumCalculation;
        }
        
        initialResult = 1 / xArgument + 2 * xArgument * runtimeCalculation;
        long double systemAcosResult = acos(xArgument);
        
        // printing results
        cout << "Our calculation result: " << initialResult << endl;
        cout << "System function result: " << systemAcosResult << endl;
        cout << "Fifference in calculation = ";
        if (initialResult < systemAcosResult) {
            cout << systemAcosResult - initialResult;
        } else {
            cout << initialResult - systemAcosResult;
        }
        xArgument += 0.1;

        cout << endl;
    }
    
    
    return 0;
}
