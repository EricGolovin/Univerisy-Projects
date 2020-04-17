//
//  Header.h
//  PR-lab03
//
//  Created by Eric Golovin on 17.04.2020.
//  Copyright © 2020 com.ericgolovin-university. All rights reserved.
//

#ifndef Header_h
#define Header_h

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

#endif /* Header_h */
