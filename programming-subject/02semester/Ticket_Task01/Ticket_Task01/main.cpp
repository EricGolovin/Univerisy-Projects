//
//  main.cpp
//  Ticket_Task01
//
//  Created by Eric Golovin on 6/27/20.
//

#include <iostream>
using namespace std;

class Rectangle {
private:
    int width = 10;
    int height = 5;
public:
    int leftCorner;
    int rightCorner;
    
    Rectangle(int lCorner, int rCorner) {
        leftCorner = lCorner;
        rightCorner = rCorner;
    }
    
    void plus(int value) {
        width += value;
        height += value;
    }
    
    void minus(int value) {
        width -= value;
        height -= value;
    }
    
    void show() {
        for (int i = 0; i < width; i++) {
            printf("-");
        }
        cout << endl;
        for (int i = 0; i < height; i++) {
            printf("|");
            for (int q = 2; q < width; q++) {
                printf(" ");
            }
            printf("|\n");
        }
        for (int i = 0; i < width; i++) {
            printf("-");
        }
        cout << endl;
    }
    
};

int main(int argc, const char * argv[]) {
    Rectangle someRectangle(90, 90);
    someRectangle.show();
    
    someRectangle.plus(3);
    someRectangle.show();
    
    someRectangle.minus(1);
    someRectangle.show();
    
    return 0;
}
