#include <stdio.h>

double calculationForX1(double x1, double x2, double x3) {
    return 0.4 * x1 - 0.39 * x2 - 0.39 * x3 + 0.4;
}

double calculationForX2(double x1, double x2, double x3) {
    return -0.29 * x1 + 0.69 * x2 - 0.14 * x3 + 1.05;
}

double calculationForX3(double x1, double x2, double x3) {
    return -0.76 * x1 - 0.71 * x2 + 0.21 * x3 + 1.38;
}

int main(void) {
    double x1 = 0.4;
    double x2 = 1.05;
    double x3 = 1.38;

    for (int i = 0; i < 8; i++) {
        double tempX1 = x1;
        double tempX2 = x2;
        double tempX3 = x3;

        x1 = calculationForX1(tempX1, tempX2, tempX3);
        x2 = calculationForX2(tempX1, tempX2, tempX3);
        x3 = calculationForX3(tempX1, tempX2, tempX3);

        printf("Iteration#%d:\n\tx1 = %.4f\n\tx2=%.4f\n\tx3=%.4f\n\n", i + 1, x1, x2, x3);
    }

    return 0;
}
