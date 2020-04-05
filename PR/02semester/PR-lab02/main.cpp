#include <iostream>
#include <vector>
#include <sstream>
using namespace std;

typedef struct {
    string name;
    string surname;
    string facultyTitle;
} Author;

typedef struct {
    string debtDate;
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
        stringstream resultStringStream;
        StudentLending newDebtor = {date, name};
        
        studentsDebtsData.push_back(newDebtor);

        resultStringStream << "----------------------------Method book--" << endl;
        resultStringStream << "\tgiven to " << name << endl;
        resultStringStream << "\tdate: " << date << endl;
        resultStringStream << "-----------------------------------------" << endl;

        return resultStringStream.str();
    }

    string removeBookFrom(string name, string date) {
        stringstream resultStringStream;

        for (int index = 0; index < studentsDebtsData.size(); index++) {
            string lowercasedName = studentsDebtsData[index].studentNaming;
            string lowercasedSearchedName = name;
            transform(lowercasedName.begin(), lowercasedName.end(), lowercasedName.begin(), ::tolower);
            transform(lowercasedSearchedName.begin(), lowercasedSearchedName.end(), lowercasedSearchedName.begin(), ::tolower);

            if (lowercasedName.find(lowercasedSearchedName) != string::npos) {
                if (studentsDebtsData[index].debtDate == date) {
                    resultStringStream << "----------------------------Method book--" << endl;
                    resultStringStream << "\tgiven back from " << studentsDebtsData[index].studentNaming << endl;
                    resultStringStream << "\tfrom date: " << studentsDebtsData[index].debtDate << endl;
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
            for (int index = currentIndex + 1, flag = 0; index < studentsDebtsData.size(); index++) {
                if (studentsDebtsData[currentIndex].studentNaming == studentsDebtsData[index].studentNaming) {
                    for (int tempIndex = 0; tempIndex < extraDebtors.size(); tempIndex++) {
                        if (studentsDebtsData[currentIndex].studentNaming == extraDebtors[tempIndex].studentNaming) {
                            flag = 1;
                        }
                    }
                    if (flag) {
                        break;
                    } else {
                        extraDebtors.push_back(studentsDebtsData[currentIndex]);
                    }
                }
            }
        }

        resultStringStream << "----------------------------Method book--" << endl;
        for (int index = 0; index < extraDebtors.size(); index++) {
            resultStringStream << "\textra Debtor: " << extraDebtors[index].studentNaming << endl;
            resultStringStream << "\tdate: " << extraDebtors[index].debtDate << endl;
            if (index + 1 < extraDebtors.size()) {
                resultStringStream << "+++++++++++++++++++++++++++++++++++++++++" << endl;
            }
        }
        resultStringStream << "-----------------------------------------" << endl;

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
    cout << someBook.giveBookTo("Brews Delivan", "06-03-20") << endl;
    cout << someBook.getTotalNumberOfDebts() << endl;
    cout << endl << endl << endl;
    cout << someBook.removeBookFrom("sam", "06-01-20") << endl;
    cout << someBook.getTotalNumberOfDebts() << endl;

    cout << endl << endl << endl;
    cout << someBook.giveBookTo("Sam Oustin", "06-03-20") << endl;
    cout << someBook.giveBookTo("Sam Oustin", "06-03-20") << endl;
    cout << someBook.giveBookTo("Sam Oustin", "06-03-20") << endl;
    cout << someBook.giveBookTo("Andrew Johnson", "06-03-20") << endl;
    cout << someBook.giveBookTo("Andrew Johnson", "06-03-20") << endl;
    cout << someBook.getTotalNumberOfDebts() << endl;
    cout << someBook.findExtraDebtors() << endl;
    
    return 0;
}