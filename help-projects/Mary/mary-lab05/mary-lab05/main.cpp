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
#include <numeric>
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
    
    void printStudentInfo() {
        cout << "Name: " << studentName << " Age: " << age << " Lives in: " << campusName << endl;
    }
    
    void printProffessors() {
        cout << "Professors: ";
        copy(listOfProffessors.begin(), listOfProffessors.end(), ostream_iterator<string>(cout, ", "));
        cout << endl;
    }
    
    void printMarks() {
        cout << "Marks: ";
        copy(marks.begin(), marks.end(), ostream_iterator<int>(cout, ", "));
        cout << endl;
    }
    
    string getStudentInfo() {
        stringstream resultStringStream;
        resultStringStream << "Name: " << studentName << " Age: " << age << " Lives in: " << campusName << endl;
        return resultStringStream.str();
    }
    
    string getProffessors() {
        stringstream resultStringStream;
        resultStringStream << "Professors: ";
        copy(listOfProffessors.begin(), listOfProffessors.end(), ostream_iterator<string>(resultStringStream, ", "));
        resultStringStream << endl;
        return resultStringStream.str();
    }
    
    string getMarks() {
        stringstream resultStringStream;
        resultStringStream << "Marks: ";
        copy(marks.begin(), marks.end(), ostream_iterator<int>(resultStringStream, ", "));
        resultStringStream << endl;
        return resultStringStream.str();
    }
    
};

class Group {
public:
    string groupName;
    vector<Student> students;
    int averageMark = 0;
    
    void printGroupDetails() {
        cout << "Group Name: " << groupName << endl;
        for (int i = 0; i < students.size(); i++) {
            students[i].printStudentInfo();
            students[i].printMarks();
            students[i].printProffessors();
            cout << endl;
        }
    }
    
    string getGroupDetails() {
        stringstream resultStringStream;
        resultStringStream << "Group Name: " << groupName << endl;
        for (int i = 0; i < students.size(); i++) {
            resultStringStream << students[i].getStudentInfo();
            resultStringStream << students[i].getMarks();
            resultStringStream << students[i].getProffessors();
            resultStringStream <<  endl;
        }
        return resultStringStream.str();
    }
    
    void printAverageMark() {
        cout << "Group with name '" << groupName << "' has " << averageMark << " average Mark" << endl;
    }
    
    string getAverageMark() {
        stringstream resultStringStream;
        resultStringStream << "Group with name '" << groupName << "' has " << averageMark << " average Mark" << endl;
        return resultStringStream.str();
    }
};

string removerCharFrom(char element, string source) {
    string result = source;
    result.erase(remove(result.begin(), result.end(), element), result.end());
    return result;
}

bool sortByGroupName(Group lhs, Group rhs) {
    return lhs.groupName < rhs.groupName;
}

bool sortByStudentsAverageMark(Group &lhs, Group &rhs) {
    int averageLhs = 0, averageRhs = 0;
    int lhsStudentsCounter = 0, rhsStudentCounter = 0;
    for (int i = 0; i < lhs.students.size(); i++) {
        int buffer = 0;
        for (int q = 0; q < lhs.students[i].marks.size(); q++) {
            buffer += lhs.students[i].marks[q];
        }
        averageLhs += buffer / lhs.students[i].marks.size();
        lhsStudentsCounter += 1;
    }
    for (int i = 0; i < rhs.students.size(); i++) {
        int buffer = 0;
        for (int q = 0; q < rhs.students[i].marks.size(); q++) {
            buffer += rhs.students[i].marks[q];
        }
        averageRhs += buffer / rhs.students[i].marks.size();
        rhsStudentCounter += 1;
    }
    
    int rhsResult = averageLhs / lhsStudentsCounter;
    int lhsResult = averageRhs / rhsStudentCounter;
    
    return rhsResult < lhsResult;
}

vector<Group> filterStudentsCountGroups(vector<Group> groups) {
    vector<Group> resultVector;
    for (int i = 0; i < groups.size(); i++) {
        if (groups[i].students.size() > 4) {
            resultVector.push_back(groups[i]);
        }
    }
    return resultVector;
}

vector<string> filterStudentNamingGroups(vector<Group> groups) {
    vector<string> resultVector;
    for (int i = 0; i < groups.size(); i++) {
        for (int q = 0; q < groups[i].students.size(); q++) {
            resultVector.push_back(groups[i].students[q].studentName);
        }
    }
    return resultVector;
}

int accumulationOperation(int accumulator, Group &first) {
    int averageLhs = 0, lhsStudentsCounter = 0;
    for (int i = 0; i < first.students.size(); i++) {
        int buffer = 0;
        for (int q = 0; q < first.students[i].marks.size(); q++) {
            buffer += first.students[i].marks[q];
        }
        averageLhs += buffer / first.students[i].marks.size();
        lhsStudentsCounter += 1;
    }
    
    first.averageMark = averageLhs / lhsStudentsCounter;
    
    return accumulator + first.averageMark;
}

int main(int argc, const char * argv[]) {
    ifstream is("/Users/ericgolovin/Developer/c_c++/Univerisy-Projects/help-projects/Mary/mary-lab05/mary-lab05/inputFile.txt");
    istream_iterator<string> start(is), end;
    
    vector<string> elements(start, end);
//    cout << "Read " << elements.size() << " symbols" << endl;
    
    vector<Group> groups;
    
    int closeBracketsCounter = 0, index = 0;
    string buffer = "";
    
    do {
//        cout << "1: " << elements[index] << endl;
        if (elements[index] == "start|" || elements[index] == "g{") {
            closeBracketsCounter += 1;
        } else if (elements[index] == "}g") {
            closeBracketsCounter -= 1;
        } else if (elements[index] == "groupName:") {
            Group bufferGroup;
            index += 1;
            
//            buffer = elements[index];
//            buffer.erase(remove(buffer.begin(), buffer.end(), '"'), buffer.end());
            
            bufferGroup.groupName = removerCharFrom('"', elements[index]);
            index += 1;
            while (elements[index] != "}g") {
//                cout << "2: " << elements[index] << endl;
                Student bufferStudent;
                do {
//                    cout << "3: " << elements[index] << endl;
                    if (elements[index] == "s{") {
                        closeBracketsCounter += 1;
                    } else if (elements[index] == "}s") {
                        closeBracketsCounter -= 1;
                    } else if (elements[index] == "name:") {
                        index += 1;
                        bufferStudent.studentName = removerCharFrom('"', elements[index]);
                    } else if (elements[index] == "age:") {
                        index += 1;
                        bufferStudent.age = removerCharFrom('"', elements[index]);
                    } else if (elements[index] == "campusName:") {
                        index += 1;
                        bufferStudent.campusName = removerCharFrom('"', elements[index]);
                    } else if (elements[index] == "marks:") {
                        index += 1;
                        do {
                            if (elements[index] == "[") {
                                closeBracketsCounter += 1;
                                index += 1;
                            } else if (elements[index] == "]") {
                                closeBracketsCounter -= 1;
                            } else {
                                stringstream convertionStream;
                                int convertionResult = 0;
                                convertionStream << removerCharFrom('"', elements[index]);
                                convertionStream >> convertionResult;
                                bufferStudent.marks.push_back(convertionResult);
                                index += 1;
                            }
                        } while (closeBracketsCounter > 3);
                    } else if (elements[index] == "professorsList:") {
                        index += 1;
                        do {
                            if (elements[index] == "[") {
                                closeBracketsCounter += 1;
                                index += 1;
                            } else if (elements[index] == "]") {
                                closeBracketsCounter -= 1;
                            } else {
                                bufferStudent.listOfProffessors.push_back(removerCharFrom('"', elements[index]));
                                index += 1;
                            }
                        } while (closeBracketsCounter > 3);
                    }
                    index += 1;
                } while (closeBracketsCounter > 2);
                
                bufferGroup.students.push_back(bufferStudent);
            }
            groups.push_back(bufferGroup);
        }
        index += 1;
        if (elements[index] == "|end") {
            break;
        }
    } while (closeBracketsCounter > 0);
    
    // sorting (task 2)
    sort(groups.begin(), groups.end(), sortByGroupName);
    sort(groups.begin(), groups.end(), sortByStudentsAverageMark);
    
    // filtering vector (task 3 - 4)
    vector<Group> groupsWithFivePlus = filterStudentsCountGroups(groups);
    vector<string> studentNames = filterStudentNamingGroups(groups);
    
    // average mark calculating
    accumulate(groups.begin(), groups.end(), 0, accumulationOperation);
    
    
    ofstream output("/Users/ericgolovin/Developer/c_c++/Univerisy-Projects/help-projects/Mary/mary-lab05/mary-lab05/outputFile.txt");
    
    for (int i = 0; i < groups.size(); i++) {
        output << groups[i].getGroupDetails();
        output << groups[i].getAverageMark();
        output << "------- " << i << " -------" << endl << endl;
    }
    
    output.close();
    
    for (int i = 0; i < groups.size(); i++) {
        groups[i].printGroupDetails();
        groups[i].printAverageMark();
        cout << "------- " << i << " -------" << endl << endl;
    }
    
    return 0;
}
