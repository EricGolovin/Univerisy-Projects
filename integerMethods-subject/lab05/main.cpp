#include <iostream>
#include <math.h>
using namespace std;

double f(double x) {
    // MARK: - Equation
    return  pow(x, 4) + 5 * pow(x, 3) + 3 * pow(x, 2) - 4 * x - 1;
}

int main() {
    double t = 0, y = 2.0;
    double mas[11];
    int n;
    cin >> n;
    double h = (y - t) / n;
    double x = 0;
    for (int i = 0; i < n; i++) {
        x = x + ((f(t+h*i) + f(t + h * (i+1)))*(t+h*(i+1) - (t+h*i))) / 2;
    }
    double xx=0;
    for (int i = 0; i < n; i++) {
        xx = xx + ((t + h * (i + 1) - t - h * i) / 6.0)*(f(t + h * i) + 4.0 * f((t + h * (i + 1) + t + h * i) / 2.0) + f(t + h * (i + 1)));
    }
    cout << xx <<endl;
    cout << x;
    return 0;
}
