//
//  main.cpp
//  Mary-Ticket_Tasks01
//

#include <iostream>
using namespace std;

class Rectangle {
public:
    int leftCorner;
    int width;
    int height;
    
    Rectangle(int corner, int nWidth, int nHeight) {
        leftCorner = corner;
        width = nWidth;
        height = nHeight;
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
    Rectangle someRectangle(90, 10, 5);
    someRectangle.show();
    
    someRectangle.plus(20);
    someRectangle.show();
    
    someRectangle.minus(5);
    someRectangle.show();
    
    return 0;
}
