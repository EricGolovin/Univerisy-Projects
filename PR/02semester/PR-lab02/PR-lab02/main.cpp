//
//  main.cpp
//  PR-lab02
//
//  Created by Eric Golovin on 06.04.2020.
//  Copyright © 2020 Eric Golovin. All rights reserved.
//

#include <iostream>
#include <vector>
#include <sstream>
using namespace std;

typedef struct {
    int day;
    int month;
    int year;
    string date(void) {
        stringstream resultDate;
        resultDate << day << "/" << month << "/" << year;
        return resultDate.str();
    }
} Date;

typedef struct {
    string name;
    string surname;
    string facultyTitle;
} Author;

typedef struct {
    vector <Date> debtDate;
    string studentNaming;
} StudentLending;

class MethodBook {
private:
    Author bookAuthor;
    string bookName;
    string bookSubject;
    vector <StudentLending> studentsDebtsData;
    
public:
    
    void setBookAuthor(string name, string surname, string faculty) {
        if (bookAuthor.name == "") {
            bookAuthor.name = name;
            bookAuthor.surname = surname;
            bookAuthor.facultyTitle = faculty;
        } else {
            cout << "Cannot set author, book's author already is " << bookAuthor.name << endl;
        }
    }
    
    void setBookName(string name) {
        if (bookName == "") {
            bookName = name;
        } else {
            cout << "Cannot set name, book's name already is " << bookName << endl;
        }
    }
    
    void setBookSubject(string subject) {
        if (bookSubject == "") {
            bookSubject = subject;
        } else {
            cout << "Cannot set subject, book's subject already is " << bookSubject << endl;
        }
    }
    
    string getAuthor(void) {
        stringstream resultStringStream;
        resultStringStream << "----------------------------Method book--" << endl;
        resultStringStream << "\tAuthor's name: " << bookAuthor.name << endl;
        resultStringStream << "\tAuthor's surname: " << bookAuthor.surname << endl;
        resultStringStream << "-----------------------------------------" << endl;
        
        return resultStringStream.str();
    }
    
    string getNameSubjectFaculty(void) {
        stringstream resultStringStream;
        resultStringStream << "----------------------------Method book--" << endl;
        resultStringStream << "\tname: " << bookName << endl;
        resultStringStream << "\tsubject: " << bookSubject << endl;
        resultStringStream << "\tfaculty: " << bookAuthor.facultyTitle << endl;
        resultStringStream << "-----------------------------------------" << endl;
        
        return resultStringStream.str();
    }
    
    string getTotalNumberOfDebts(void) {
        stringstream resultStringStream;
        resultStringStream << "----------------------------Method book--" << endl;
        resultStringStream << "\tissued " << studentsDebtsData.size() << " times" << endl;
        resultStringStream << "-----------------------------------------" << endl;
        
        return resultStringStream.str();
    }
    
    string giveBookTo(string name, string date) {
        int day, month, year;
        stringstream resultStringStream;
        stringstream dateStringStream(date);
        
        dateStringStream >> day;
        dateStringStream >> month;
        dateStringStream >> year;
        
        Date newDate = {day, month, year};
        StudentLending newDebtor;
        newDebtor.studentNaming = name;
        newDebtor.debtDate.push_back(newDate);
        
        studentsDebtsData.push_back(newDebtor);
        
        resultStringStream << "----------------------------Method book--" << endl;
        resultStringStream << "\tgiven to " << newDebtor.studentNaming << endl;
        resultStringStream << "\tdate: " << newDebtor.debtDate[0].date() << endl;
        resultStringStream << "-----------------------------------------" << endl;
        
        return resultStringStream.str();
    }
    
    string removeBookFrom(string name, string date) {
        int day, month, year;
        stringstream resultStringStream;
        stringstream dateStringStream(date);
        
        dateStringStream >> day;
        dateStringStream >> month;
        dateStringStream >> year;
        
        for (int index = 0; index < studentsDebtsData.size(); index++) {
            string lowercasedName = studentsDebtsData[index].studentNaming;
            string lowercasedSearchedName = name;
            transform(lowercasedName.begin(), lowercasedName.end(), lowercasedName.begin(), ::tolower);
            transform(lowercasedSearchedName.begin(), lowercasedSearchedName.end(), lowercasedSearchedName.begin(), ::tolower);
            
            if (lowercasedName.find(lowercasedSearchedName) != string::npos) {
                Date studentDate = studentsDebtsData[index].debtDate[0];
                if (studentDate.day == day && studentDate.month == month && studentDate.year == year) {
                    resultStringStream << "----------------------------Method book--" << endl;
                    resultStringStream << "\tgiven back from " << studentsDebtsData[index].studentNaming << endl;
                    resultStringStream << "\tfrom date: " << studentsDebtsData[index].debtDate[0].date() << endl;
                    resultStringStream << "-----------------------------------------" << endl;
                    
                    studentsDebtsData.erase(studentsDebtsData.begin() + index);
                    
                    return resultStringStream.str();
                }
            }
        }
        
        resultStringStream << "----------------------------Method book--" << endl;
        resultStringStream << "\tno student with name " << name << endl;
        resultStringStream << "\tdate: " << date << endl;
        resultStringStream << "-----------------------------------------" << endl;
        
        return resultStringStream.str();
    }
    
    string findExtraDebtors() {
        stringstream resultStringStream;
        vector <StudentLending> extraDebtors;
        
        for (int currentIndex = 0; currentIndex < studentsDebtsData.size(); currentIndex++) {
            for (int index = currentIndex , flag = 0; index < studentsDebtsData.size(); index++) {
                if (studentsDebtsData[currentIndex].studentNaming == studentsDebtsData[index].studentNaming) {
                    for (int tempIndex = 0; tempIndex < extraDebtors.size(); tempIndex++) {
                        if (studentsDebtsData[currentIndex].studentNaming == extraDebtors[tempIndex].studentNaming) {
                            if (studentsDebtsData[currentIndex].debtDate[0].date() != extraDebtors[tempIndex].debtDate[extraDebtors[tempIndex].debtDate.size() - 1].date()) {
                                extraDebtors[tempIndex].debtDate.push_back(studentsDebtsData[currentIndex].debtDate[0]);
                            }
                            flag = 1;
                        }
                    }
                    if (flag) {
                        flag = 0;
                        break;
                    } else {
                        extraDebtors.push_back(studentsDebtsData[currentIndex]);
                    }
                }
            }
        }
        
        for (int i = 0; i < extraDebtors.size(); i++) {
            if (extraDebtors[i].debtDate.size() == 1) {
                extraDebtors[i].studentNaming = "NoN";
            }
        }
        
        resultStringStream << "----------------------------Method book--" << endl;
        for (int index = 0; index < extraDebtors.size(); index++) {
            if (extraDebtors[index].studentNaming == "NoN") {
                continue;
            }
            resultStringStream << "\textra Debtor: " << extraDebtors[index].studentNaming << endl;
            resultStringStream << "\tdate: | ";
            for (int i = 0; i < extraDebtors[index].debtDate.size(); i++) {
                resultStringStream << extraDebtors[index].debtDate[i].date() << " | ";
            }
            if (index + 1 < extraDebtors.size()) {
                resultStringStream << endl << "+++++++++++++++++++++++++++++++++++++++++" << endl;
            }
        }
        resultStringStream << endl << "-----------------------------------------" << endl;
        
        return resultStringStream.str();
    }
    
    string getDateCount(string date) {
        int day, month, year, resultCount = 0;
        string printableDate;
        stringstream resultStringStream;
        stringstream dateStringStream(date);
        
        dateStringStream >> day;
        dateStringStream >> month;
        dateStringStream >> year;
        
        for (int index = 0; index < studentsDebtsData.size(); index++) {
            Date studentDate = studentsDebtsData[index].debtDate[0];
            if (studentDate.day == day && studentDate.month == month && studentDate.year == year) {
                resultCount += 1;
                printableDate = studentDate.date();
            }
        }
        
        resultStringStream << "----------------------------Method book--" << endl;
        resultStringStream << "\t book was given to " << resultCount << " people on this " << printableDate << " date" << endl;
        resultStringStream << endl << "-----------------------------------------" << endl;
        
        return resultStringStream.str();
    }
    
};

int main(int argc, char *argv[]) {
    
    string names[10] = {"Gradhen", "Tim", "Steve", "Bill", "Andrew", "Elizabeth", "Michael", "Harvy", "Larry", "Gwen"};
    string surnames[10] = {"Spectre", "Litt", "Marqes", "Dellywon", "Peitterman", "Literr", "Neuburg", "Nadella", "Gates", "Jobs"};
    
    int numberOfBooks, demoFlag = 0;
    
    cout << "Please, enter the number of method books you want to create (enter 0 for demo mode): ";
    cin >> numberOfBooks;
    cout << "Starting initialisation of your request..." << endl << endl;
    
    if (numberOfBooks == 0) {
        numberOfBooks = 1;
        demoFlag = 1;
    }
    
    MethodBook methodBooksArray[numberOfBooks];
    
    if (!demoFlag) {
        for (int i = 0; i < numberOfBooks; i++) {
            string authorName, authorSurname, authorFaculty;
            string bookName, bookSubject;
            
            MethodBook someBook;
            
            cout << "----------------------------Configuring book #" << i + 1 << endl;
            cout << "Enter Athor's Name: ";
            cin >> authorName;
            cout << "Enter Athor's Surname: ";
            cin >> authorSurname;
            cout << "Enter Athor's Faculty: ";
            cin >> authorFaculty;
            cout << "Enter Books's Name: ";
            cin >> bookName;
            cout << "Enter Books's Subject: ";
            cin >> bookSubject;
            cout << endl;
            
            someBook.setBookAuthor(authorSurname, authorName, authorFaculty);
            someBook.setBookName(bookName);
            someBook.setBookSubject(bookSubject);
            
            methodBooksArray[i] = someBook;
        }
    } else {
        MethodBook someBook;
        someBook.setBookAuthor("David J. ", "Malan", "Computer Science");
        someBook.setBookName("Harvard CS50");
        someBook.setBookSubject("Computer Science Fundamentals");
        methodBooksArray[0] = someBook;
        
        for (int index = 0; index < 100; index++) {
            stringstream someStrStream;
            string studentName, date;
            
            studentName += names[rand() % 10];
            studentName += "-";
            studentName += surnames[rand() % 10];
            
            someStrStream << rand() % 30 + 1;
            someStrStream << " ";
            someStrStream << rand() % 12 + 1;
            someStrStream << " ";
            someStrStream << 2020 - (rand() % 5 + 1);
            
            date = someStrStream.str();
            
            methodBooksArray[0].giveBookTo(studentName, date);
        }
    }
    
    while (1) {
        int currentBookIndex;
        string nameOfOperation;
        
        if (!demoFlag) {
            cout << "On which book you want to work on? (Enter Number)" << endl;
            cin >> currentBookIndex;
        } else {
            currentBookIndex = 1;
        }
        
        if (currentBookIndex > numberOfBooks) {
            cout << "There is no book with this index, check your request" << endl << endl;
            continue;
        } else {
            currentBookIndex -= 1;
        }
        
        while (1) {
            cout << "Which operation do you want to perform? (Enter <help> to see operations)" << endl;
            cin >> nameOfOperation;
            
            if (nameOfOperation == "help" || nameOfOperation == "<help>") {
                cout << endl << "get-author --> to get Author info" << endl;
                cout << "get-info --> to get Book info" << endl;
                cout << "get-debtors --> to get number of Debtors" << endl;
                cout << "give-book --> to register new Debtor to the list" << endl;
                cout << "remove-book --> to remove Debtor from the list" << endl;
                cout << "get-extraDeb --> to get extra Debtors" << endl;
                cout << "find-date --> to find debtors by Date" << endl;
                cout << "change-book --> to change working book index (not working in demo)" << endl;
                cout << "stop --> to exit program" << endl << endl;
                continue;
            } else if (nameOfOperation == "get-author") {
                cout << endl;
                cout << methodBooksArray[currentBookIndex].getAuthor() << endl;
                cout << endl;
            } else if (nameOfOperation == "get-info") {
                cout << endl;
                cout << methodBooksArray[currentBookIndex].getNameSubjectFaculty() << endl;
                cout << endl;
            } else if (nameOfOperation == "get-debtors") {
                cout << endl;
                cout << methodBooksArray[currentBookIndex].getTotalNumberOfDebts() << endl;
                cout << endl;
            } else if (nameOfOperation == "give-book") {
                cout << endl;
                string name, date, buffer;
                cout << "Enter name of the Student: ";
                cin >> name;
                cout << "Enter date: " << endl;
                cout << "\tday: ";
                cin >> buffer;
                date += buffer;
                date += " ";
                cout << "\tmonth: ";
                cin >> buffer;
                date += buffer;
                date += " ";
                cout << "\tyear: ";
                cin >> buffer;
                date += buffer;
                cout << methodBooksArray[currentBookIndex].giveBookTo(name, date) << endl;
                cout << endl;
            } else if (nameOfOperation == "remove-book") {
                cout << endl;
                string name, date, buffer;
                cout << "Enter name of the Student: ";
                cin >> name;
                cout << "Enter date: " << endl;;
                cout << "\tday: ";
                cin >> buffer;
                date += buffer;
                date += " ";
                cout << "\tmonth: ";
                cin >> buffer;
                date += buffer;
                date += " ";
                cout << "\tyear: ";
                cin >> buffer;
                date += buffer;
                cout << methodBooksArray[currentBookIndex].removeBookFrom(name, date) << endl;
                cout << endl;
            } else if (nameOfOperation == "get-extraDeb") {
                cout << endl;
                cout << methodBooksArray[currentBookIndex].findExtraDebtors() << endl;
                cout << endl;
            } else if (nameOfOperation == "find-date") {
                cout << endl;
                string date, buffer;
                cout << "Enter date to find: " << endl;
                cout << "\tday: ";
                cin >> buffer;
                date += buffer;
                date += " ";
                cout << "\tmonth: ";
                cin >> buffer;
                date += buffer;
                date += " ";
                cout << "\tyear: ";
                cin >> buffer;
                date += buffer;
                cout << methodBooksArray[currentBookIndex].getDateCount(date) << endl;
                cout << endl;
            } else if (nameOfOperation == "change-book" || nameOfOperation == "stop") {
                break;
            }
        }
        if (nameOfOperation == "stop") {
            cout << "Thank you for using our Service ;)" << endl;
            break;
        }
    }
    
    return 0;
}

