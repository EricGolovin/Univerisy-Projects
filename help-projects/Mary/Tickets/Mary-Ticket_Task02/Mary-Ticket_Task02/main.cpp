//
//  main.cpp
//  Mary-Ticket_Task02
//
//  Created by Eric Golovin on 6/27/20.
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

Student enterMarks(Student &student, int mark) {
    student.averageMark = mark;
    return student;
}

int main(int argc, const char * argv[]) {
    vector<string> names{"Random Names", "Rumaisa Lovell", "Shoaib Hogan", "Kiefer Villalobos", "Libbie Hamer", "Anika Hardin", "Cody Kramer", "Ptolemy Burks", "Bill Peck", "Timur Thorne"};
    vector<int> marks(10, 10);
    
    vector<Student> students(10);
    
    transform(names.begin(), names.end(), marks.begin(), students.begin(), enterNames);
    
    for (int i = 0; i < 10; i++) {
        cout << students[i].averageMark << endl;
    }
    
    
    
    return 0;
}
