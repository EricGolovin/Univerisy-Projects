//
//  main.cpp
//  Mary-Ticket_Task02
//

#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

struct Student {
    string name;
    int averageMark;
};

Student enterNames(string name, int mark) {
    Student someStudent;
    someStudent.name = name;
    someStudent.averageMark = mark;
    return someStudent;
}

bool sortByNames(Student first, Student second) {
    return first.name < second.name;
}

int main(int argc, const char * argv[]) {
    vector<string> names{"Random Names", "Rumaisa Lovell", "Shoaib Hogan", "Kiefer Villalobos", "Libbie Hamer", "Anika Hardin", "Cody Kramer", "Ptolemy Burks", "Bill Peck", "Timur Thorne"};
    vector<int> marks(10, 10);
    
    vector<Student> students(10);
    
    transform(names.begin(), names.end(), marks.begin(), students.begin(), enterNames);
    
    cout << "Unsorted:" << endl;
    for (int i = 0; i < 10; i++) {
        cout << students[i].name << endl;
    }
    
    sort(students.begin(), students.end(), sortByNames);
    
    cout << "Sorted:" << endl;
    for (int i = 0; i < 10; i++) {
        cout << students[i].name << endl;
    }
    return 0;
}
