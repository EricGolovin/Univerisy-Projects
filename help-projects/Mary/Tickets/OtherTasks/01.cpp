#include <iostream>
#include <iomanip>
#include <string>

using namespace std;

void printStrInStream(ostream& out, string str, int n) {
	out << resetiosflags(ios::right) 
		<< setiosflags(ios::left) 
		<< setfill('-') 
		<< setw(n) 
		<< str 
		<< endl;
}

int main() {
	string str;
	cout << "Input line: ";
	getline(cin, str);

	int x;
	cout << "Symbol '-' length: ";
	cin >> x;

	printStrInStream(cout, str, x);

	return 0;
}

