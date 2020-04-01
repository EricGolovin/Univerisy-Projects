#include <iostream>
#include <sstream>
#include <math.h>
using namespace std;

double getX_argument() {
    string buffer;
    int result;
    stringstream strInputStream;

    cout << "Enter argument X: ";
    cin >> buffer;
    strInputStream << buffer;
    strInputStream >> result;

    return result;
}

double getCalculationMistake_argument() {
    string buffer;

    cout << "Enter calculation mistake: ";
    cin >> buffer;
    int lastInputDigit = buffer[3] - '0';
    double result = 1 * pow(10, -lastInputDigit);

    return result;
}

int main(int argc, char *argv[]) {
    int xArgument = getX_argument();
    double calcMistakeArgument = getCalculationMistake_argument();

    
    return 0;
}