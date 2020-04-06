#include <iostream>
#include <vector>
#include <sstream>
using namespace std;

int main() {
    stringstream strStream("33 01 2020");
    
    int i01, i02, i03;
    
    strStream >> i01;
    cout << strStream.str() << endl << endl;
    strStream >> i02;
    cout << strStream.str() << endl << endl;
    strStream >> i03;
    cout << strStream.str() << endl << endl;
    
    cout << i01 << endl;
    cout << i02 << endl;
    cout << i03 << endl;
    return 0;
}
