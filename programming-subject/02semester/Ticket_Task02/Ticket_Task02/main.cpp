//
//  main.cpp
//  Ticket_Task02
//
//  Created by Eric Golovin on 6/27/20.
//

#include <iostream>
#include <queue>
#include <string>
#include <vector>
using namespace std;

struct Date {
    int day;
    int month;
    int year;
};

struct Zodiac {
    string title;
    Date startDate;
    Date endDate;
    
    bool operator<(const Zodiac &o) const
    {
        return startDate.month < o.startDate.month;
    }
};

priority_queue<Zodiac> addZodiacs(int count) {
    priority_queue<Zodiac> zodiacsQueue;
    for (int i = 0; i < count; i++) {
        Zodiac someZodiac;
        Date someStartDate;
        Date someEndDate;
        
        someStartDate.day = 0;
        someStartDate.month = i * 3;
        someStartDate.year = 2000 + i * 2;
        
        someEndDate = someStartDate;
        someEndDate.day = someStartDate.day + 30;
        
        someZodiac.title = to_string(i);
        someZodiac.startDate = someStartDate;
        someZodiac.endDate = someEndDate;
        zodiacsQueue.push(someZodiac);
    }
    
    return zodiacsQueue;
}

vector<Zodiac> createVectorFromQueue(priority_queue <Zodiac> queue)
{
    vector<Zodiac> someVector;
    priority_queue<Zodiac> zodiacs = queue;
    while (!zodiacs.empty())
    {
        someVector.push_back(zodiacs.top());
        zodiacs.pop();
    }
    return someVector;
}

int main(int argc, const char * argv[]) {
    priority_queue<Zodiac> zodiacsQueue;
    vector<Zodiac> zodiacsVector;
    
    zodiacsQueue = addZodiacs(10);
    cout << zodiacsQueue.size() << endl;
    
    zodiacsVector = createVectorFromQueue(zodiacsQueue);
    
    for (int i = 0; i < zodiacsVector.size(); i++) {
        cout << zodiacsVector[i].title << endl;
    }
    return 0;
}
