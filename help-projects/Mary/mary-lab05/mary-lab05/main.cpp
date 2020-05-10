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
    vector<string> professorsList;
    
    void getProffessors() {
        cout << "Professors: ";
        copy(professorsList.begin(), professorsList.end(), ostream_iterator<string>(cout, ", "));
        cout << endl;
    }
};

int main(int argc, const char * argv[]) {
    ifstream is("/Users/ericgolovin/Developer/c_c++/Univerisy-Projects/help-projects/Mary/mary-lab05/mary-lab05/inputFile.txt");
    istream_iterator<string> start(is), end;
    
    vector<string> elements(start, end);
    cout << "Read " << elements.size() << " symbols" << endl;
    
    vector<Student> students;
    
    int closeBrackets = 0, index = 0;
    string buffer = "";
    
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
                        bufferStudent.professorsList.push_back(buffer);
//                        printPair("proffessor", buffer);
                        index++;
                    }
                }
            }
            index++;
        } while (closeBrackets != 1);
        
        index++;
        students.push_back(bufferStudent);
        
        if (elements[index] == "}") {
            break;
        }
    }
    
    for (int i = 0; i < students.size(); i++) {
        cout << students[i].studentName << endl;
        cout << students[i].campusName << endl;
        cout << students[i].age << endl;
        students[i].getProffessors();
        cout << "------- " << i << " -------" << endl;
    }
    
//    copy(elements.begin(), elements.end(), ostream_iterator<string>(cout, " "));
    
    
    return 0;
}
