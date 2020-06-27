#include <iostream>
#include <string>
#include <iomanip>

using namespace std;

ostream& str_manip(ostream& out) {
	out << setw(10) << setfill('.')
		<< resetiosflags(ios::right)
		<< setiosflags(ios::left);
	return out;
}
ostream& int_manip(ostream& out) {
	out << setw(4) << setfill('-')
		<< resetiosflags(ios::left)
		<< setiosflags(ios::right);
	return out;
}

int main() {
	string str;
	cout << "Input name: ";
	getline(cin, str);
	int x;
	cout << "Input bal: ";
	cin >> x;

	cout << str_manip << str << int_manip << x << endl;

	return 0;
}
