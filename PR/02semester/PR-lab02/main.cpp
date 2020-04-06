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
                extraDebtors.erase(extraDebtors.begin() + i);
            }
        }

        resultStringStream << "----------------------------Method book--" << endl;
        for (int index = 0; index < extraDebtors.size(); index++) {
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

    MethodBook someBook;
    someBook.setBookAuthor("David J. ", "Malan", "Computer Science");
    someBook.setBookName("Harvard CS50");
    someBook.setBookSubject("Computer Science Fundamentals");

    cout << someBook.getAuthor() << endl;
    cout << someBook.getNameSubjectFaculty() << endl;
    cout << someBook.getTotalNumberOfDebts() << endl;

    cout << endl << endl << endl;
    cout << someBook.giveBookTo("Brews Delivan", "06 03 20") << endl;
    cout << someBook.getTotalNumberOfDebts() << endl;

    cout << endl << endl << endl;
    cout << someBook.removeBookFrom("sam", "06 01 20") << endl;
    cout << someBook.getTotalNumberOfDebts() << endl;

    cout << endl << endl << endl;
    cout << someBook.giveBookTo("Sam Oustin", "06 02 20") << endl;
    cout << someBook.giveBookTo("Sam Oustin", "06 03 20") << endl;
    cout << someBook.giveBookTo("Sam Oustin", "06 04 20") << endl;
    cout << someBook.giveBookTo("Andrew Johnson", "06 03 20") << endl;
    cout << someBook.giveBookTo("Andrew Johnson", "06 04 20") << endl;
    cout << someBook.giveBookTo("Andrew Johnson", "06 09 20") << endl;
    cout << someBook.giveBookTo("Andrew Johnson", "06 07 20") << endl;
    cout << someBook.getTotalNumberOfDebts() << endl;
    cout << someBook.findExtraDebtors() << endl;

    cout << endl << endl << endl;
    cout << someBook.giveBookTo("User1", "06 01 20") << endl;
    cout << someBook.giveBookTo("User2", "06 01 20") << endl;
    cout << someBook.giveBookTo("User3", "06 01 20") << endl;
    cout << someBook.giveBookTo("User4", "06 01 20") << endl;
    cout << someBook.giveBookTo("User5", "06 01 20") << endl;
    cout << someBook.getDateCount("06 01 20") << endl;
    
    
    return 0;
}