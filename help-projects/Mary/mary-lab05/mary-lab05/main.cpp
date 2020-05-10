//
//  main.cpp
//  mary-lab05
//
//  Created by Eric Golovin on 10.05.2020.
//  Copyright © 2020 com.ericgolovin-university. All rights reserved.
//

#include <iostream>
#include <fstream>
#include <vector>
#include <sstream>
#include <algorithm>
using namespace std;

void printPair(string first, string second) {
    cout << first << " : " << second << endl;
}

class Student {
public:
    string studentName;
    string age;
    string campusName;
    vector<int> marks;
    vector<string> listOfProffessors;
    
    void getStudentInfo() {
        cout << "Name: " << studentName << " Age: " << age << " Lives in: " << campusName << endl;
    }
    
    void getProffessors() {
        cout << "Professors: ";
        copy(listOfProffessors.begin(), listOfProffessors.end(), ostream_iterator<string>(cout, ", "));
        cout << endl;
    }
    
    void getMarks() {
        cout << "Marks: ";
        copy(marks.begin(), marks.end(), ostream_iterator<int>(cout, ", "));
        cout << endl;
    }
};

class Group {
public:
    string groupName;
    vector<Student> students;
    
    void printGroupDetails() {
        cout << "Group Name: " << groupName << endl;
        for (int i = 0; i < students.size(); i++) {
            students[i].getStudentInfo();
            students[i].getMarks();
            students[i].getProffessors();
        }
    }
};

bool sortByName(Student lhs, Student rhs) {
    return lhs.studentName < rhs.studentName;
}

bool sortByAverageMark(Student lhs, Student rhs) {
    int averageLhs = 0, averageRhs = 0;
    for (int i = 0; i < lhs.marks.size(); i++) {
        averageLhs += lhs.marks[i];
    }
    for (int i = 0; i < rhs.marks.size(); i++) {
        averageRhs += rhs.marks[i];
    }
    
    return (averageLhs / lhs.marks.size()) < (averageRhs / rhs.marks.size());
}

int main(int argc, const char * argv[]) {
    ifstream is("/Users/ericgolovin/Developer/c_c++/Univerisy-Projects/help-projects/Mary/mary-lab05/mary-lab05/inputFile.txt");
    istream_iterator<string> start(is), end;
    
    vector<string> elements(start, end);
    cout << "Read " << elements.size() << " symbols" << endl;
    
    vector<Group> groups;
    
    int closeBrackets = 0, index = 0;
    string buffer = "";
    while (1) {
        Group bufferGroup;
        if (elements[index] == "[") {
            index += 2;
        } else if (elements[index] == "]") {
            break;
        }
        if (elements[index] == "groupName:") {
            index++;
            buffer = elements[index];
            buffer.erase(remove(buffer.begin(), buffer.end(), '"'), buffer.end());
            bufferGroup.groupName = buffer;
            
            index++;
            
            while (1) {
                Student bufferStudent;
                if (elements[index] == "{") {
                    closeBrackets++;
                }
                
                do {
                    if (elements[index] == "{") {
                        closeBrackets++;
                    } else if (elements[index] == "}") {
                        closeBrackets--;
                        break;
                    }
                    if (elements[index] == "name:") {
                        index++;
                        buffer = elements[index];
                        buffer.erase(remove(buffer.begin(), buffer.end(), '"'), buffer.end());
                        bufferStudent.studentName = buffer;
                        //                printPair("name", buffer);
                    } else if (elements[index] == "age:") {
                        index++;
                        buffer = elements[index];
                        buffer.erase(remove(buffer.begin(), buffer.end(), '"'), buffer.end());
                        bufferStudent.age = buffer;
                        //                printPair("age", buffer);
                    } else if (elements[index] == "campusName:") {
                        index++;
                        buffer = elements[index];
                        buffer.erase(remove(buffer.begin(), buffer.end(), '"'), buffer.end());
                        bufferStudent.campusName = buffer;
                        //                printPair("campusName", buffer);
                    } else if (elements[index] == "marks:") {
                        index += 2; // because index++ ({) index += 2 "FirstMark"
                        closeBrackets++;
                        while (closeBrackets > 1) {
                            if (elements[index] == "}") {
                                closeBrackets--;
                                break;
                            } else {
                                buffer = elements[index];
                                buffer.erase(remove(buffer.begin(), buffer.end(), '"'), buffer.end());
                                stringstream convertStringStream;
                                convertStringStream << buffer;
                                int mark;
                                convertStringStream >> mark;
                                bufferStudent.marks.push_back(mark);
                                index++;
                            }
                        }
                    } else if (elements[index] == "professorsList:") {
                        index += 2; // because index++ ({) index += 2 "FirstName"
                        closeBrackets++;
                        //                cout << "Proffessors:" << endl;
                        while (closeBrackets > 1) {
                            if (elements[index] == "}") {
                                closeBrackets--;
                                break;
                            } else {
                                buffer = elements[index];
                                buffer.erase(remove(buffer.begin(), buffer.end(), '"'), buffer.end());
                                bufferStudent.listOfProffessors.push_back(buffer);
                                //                        printPair("proffessor", buffer);
                                index++;
                            }
                        }
                    }
                    index++;
                } while (closeBrackets != 1);
                
                index++;
                bufferGroup.students.push_back(bufferStudent);
                
                if (elements[index] == "}") {
                    break;
                }
            }
        }
        groups.push_back(bufferGroup);
        index++;
    }
    
    for (int i = 0; i < groups.size(); i++) {
        groups[i].printGroupDetails();
        cout << "------- " << i << " -------" << endl;
    }
    
    //    copy(elements.begin(), elements.end(), ostream_iterator<string>(cout, " "));
    
    
    return 0;
}
