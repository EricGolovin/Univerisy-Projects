#include <stdio.h>

int main(void) {
    int m, n;
    
    printf("Enter M: ");
    scanf("%d", &m);
    printf("Enter N: ");
    scanf("%d", &n);
    printf("\n");
    
    int array[m][n];
    
    for (int x = 0; x < m; x++) {
        for (int y = 0; y < n; y++) {
            printf("Enter value for [%d][%d]: ", x, y);
            scanf("%d", &array[x][y]);
        }
    }
    
    int isNegative, changeCounter = 0;
    
    if (array[0][0] < 0) {
        isNegative = 1;
    } else if (array[0][0] > 0) {
        isNegative = 0;
    }
    
    for (int x = 0; x < m; x++) {
        for (int y = 0; y < n; y++) {
            if (array[x][y] > 0 && isNegative != 0) {
                isNegative = 0;
                changeCounter++;
            } else if (array[x][y] < 0 && isNegative != 1) {
                isNegative = 1;
                changeCounter++;
            }
        }
    }
    
    for (int x = 0; x < m; x++) {
        for (int y = 0; y < n; y++) {
            printf("%d", array[x][y]);
        }
        printf("\n");
    }
    
    printf("Total changes: %d\n", changeCounter);
    return 0;
}
