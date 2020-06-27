#include <cstdlib>
#include <iostream>
#include <math.h>
using namespace std;
double myfunc(const double& x, const double& y) {
    return 1/(2*x - pow(y, 2));
}

int main(int argc, char *argv[]) {
    int i, n;
    double x, y, h, fy, py;
    cout<< " h = ";
    cin>>h;
    cout<< " n = ";
    cin>>n;
    cout<< " x0 = ";
    cin>>x;
    cout<< " y0 = ";
    cin>>y;
    for (i = 0; i <= n; i++) {
        fy = myfunc(x, y);
        py = y + h * fy / 2;
        y += h * myfunc(x + h/2, py);
        cout << "y = " << y;
        cout << " x = " << x << "\n";
        x += h;
        
    }
    return 0;
    
}


