//
//  main.cpp
//  PR_lab05
//
//  Created by Eric Golovin on 22.05.2020.
//  Copyright © 2020 com.ericgolovin. All rights reserved.
//

#include <iostream>
#include <vector>
#include <sstream>
#include <fstream>
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
    vector<int> numOfLends;
    vector<string> listOfProffessors;
    
    void printStudentInfo() {
        cout << "Name: " << studentName << " Age: " << age << " Lives in: " << campusName << endl;
    }
    
    void printProffessors() {
        cout << "Professors: ";
        copy(listOfProffessors.begin(), listOfProffessors.end(), ostream_iterator<string>(cout, ", "));
        cout << endl;
    }
    
    void printLends() {
        cout << "Lends: ";
        copy(numOfLends.begin(), numOfLends.end(), ostream_iterator<int>(cout, ", "));
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
    
    string getLends() {
        stringstream resultStringStream;
        resultStringStream << "Lends: ";
        copy(numOfLends.begin(), numOfLends.end(), ostream_iterator<int>(resultStringStream, ", "));
        resultStringStream << endl;
        return resultStringStream.str();
    }
    
};

class GroupRegister {
public:
    string authorsName;
    vector<Student> students;
    int averageMark = 0;
    
    void printGroupDetails() {
        cout << "Group Name: " << authorsName << endl;
        for (int i = 0; i < students.size(); i++) {
            students[i].printStudentInfo();
            students[i].printLends();
            students[i].printProffessors();
            cout << endl;
        }
    }
    
    string getGroupDetails() {
        stringstream resultStringStream;
        resultStringStream << "Group Name: " << authorsName << endl;
        for (int i = 0; i < students.size(); i++) {
            resultStringStream << students[i].getStudentInfo();
            resultStringStream << students[i].getLends();
            resultStringStream << students[i].getProffessors();
            resultStringStream <<  endl;
        }
        return resultStringStream.str();
    }
    
    void printAverageLend() {
        cout << "Group with name '" << authorsName << "' has " << averageMark << " average Lends count" << endl;
    }
    
    string getAverageLend() {
        stringstream resultStringStream;
        resultStringStream << "Group with name '" << authorsName << "' has " << averageMark << " average Lends count" << endl;
        return resultStringStream.str();
    }
};

string removerCharFrom(char element, string source) {
    string result = source;
    result.erase(remove(result.begin(), result.end(), element), result.end());
    return result;
}

bool sortByAuthorsName(GroupRegister lhs, GroupRegister rhs) {
    return lhs.authorsName < rhs.authorsName;
}

bool sortByStudentsAverageLendsCount(GroupRegister &lhs, GroupRegister &rhs) {
    int averageLhs = 0, averageRhs = 0;
    int lhsStudentsCounter = 0, rhsStudentCounter = 0;
    for (int i = 0; i < lhs.students.size(); i++) {
        int buffer = 0;
        for (int q = 0; q < lhs.students[i].numOfLends.size(); q++) {
            buffer += lhs.students[i].numOfLends[q];
        }
        averageLhs += buffer / lhs.students[i].numOfLends.size();
        lhsStudentsCounter += 1;
    }
    for (int i = 0; i < rhs.students.size(); i++) {
        int buffer = 0;
        for (int q = 0; q < rhs.students[i].numOfLends.size(); q++) {
            buffer += rhs.students[i].numOfLends[q];
        }
        averageRhs += buffer / rhs.students[i].numOfLends.size();
        rhsStudentCounter += 1;
    }
    
    int rhsResult = averageLhs / lhsStudentsCounter;
    int lhsResult = averageRhs / rhsStudentCounter;
    
    return rhsResult < lhsResult;
}

vector<GroupRegister> filterStudentsCountGroupRegister(vector<GroupRegister> groups) {
    vector<GroupRegister> resultVector;
    for (int i = 0; i < groups.size(); i++) {
        if (groups[i].students.size() > 4) {
            resultVector.push_back(groups[i]);
        }
    }
    return resultVector;
}

vector<string> filterStudentByGroupRegisterName(vector<GroupRegister> groups) {
    vector<string> resultVector;
    for (int i = 0; i < groups.size(); i++) {
        for (int q = 0; q < groups[i].students.size(); q++) {
            resultVector.push_back(groups[i].students[q].studentName);
        }
    }
    return resultVector;
}

int accumulationOperation(int accumulator, GroupRegister &first) {
    int numberOfTotalLends = 0;
    for (int i = 0; i < first.students.size(); i++) {
        for (int q = 0; q < first.students[i].numOfLends.size(); q++) {
            numberOfTotalLends += 1;
        }
    }
    
    first.averageMark = numberOfTotalLends / first.students.size();
    
    return accumulator + first.averageMark;
}

int main(int argc, const char * argv[]) {
    ifstream is("/Users/ericgolovin/Developer/c_c++/Univerisy-Projects/programming-subject/02semester/PR-lab05/PR_lab05/PR_lab05/inputFile.txt");
    istream_iterator<string> start(is), end;
    
    vector<string> elements(start, end);
    
    vector<GroupRegister> groups;
    
    int closeBracketsCounter = 0, index = 0;
    string buffer = "";
    
    do {
        if (elements[index] == "start|" || elements[index] == "g{") {
            closeBracketsCounter += 1;
        } else if (elements[index] == "}g") {
            closeBracketsCounter -= 1;
        } else if (elements[index] == "groupName:") {
            GroupRegister bufferGroup;
            index += 1;
            
            bufferGroup.authorsName = removerCharFrom('"', elements[index]);
            index += 1;
            while (elements[index] != "}g") {
                Student bufferStudent;
                do {
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
                                bufferStudent.numOfLends.push_back(convertionResult);
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
    sort(groups.begin(), groups.end(), sortByAuthorsName);
    sort(groups.begin(), groups.end(), sortByStudentsAverageLendsCount);
    
    // filtering vector (task 3 - 4)
    vector<GroupRegister> groupsWithFivePlus = filterStudentsCountGroupRegister(groups);
    vector<string> studentNames = filterStudentByGroupRegisterName(groups);
    
    // average mark calculating
    accumulate(groups.begin(), groups.end(), 0, accumulationOperation);
    
    
    ofstream output("/Users/ericgolovin/Developer/c_c++/Univerisy-Projects/programming-subject/02semester/PR-lab05/PR_lab05/PR_lab05/outputFile.txt");
    for (int i = 0; i < groups.size(); i++) {
        output << groups[i].getGroupDetails();
        output << groups[i].getAverageLend();
        output << "------- " << i << " -------" << endl << endl;
    }


    output.close();
    
    for (int i = 0; i < groups.size(); i++) {
        groups[i].printGroupDetails();
        groups[i].printAverageLend();
        cout << "------- " << i << " -------" << endl << endl;
    }
    
    return 0;
}

