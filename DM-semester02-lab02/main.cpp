#include <stdio.h>
#include <stdlib.h>
#define SIZE 8

int main() {
    int relationMatrix[SIZE][SIZE];
    int minDistance[SIZE];
    int visitedPeaks[SIZE];
    int temp, minindex, min;
    int begin_index = 0;
    
    
    for (int i = 0; i < SIZE; i++) {
        for (int j = 0; j < SIZE; j++) {
            relationMatrix[i][j] = 0;
            
            printf("Enter a Distance %d - %d: ", i + 1, j + 1);
            scanf("%d", &temp);
            relationMatrix[i][j] = temp;
        }
    }
    
    for (int i = 0; i < SIZE; i++) {
        minDistance[i] = 10000;
        visitedPeaks[i] = 1;
    }
    minDistance[begin_index] = 0;
    do {
        minindex = 10000;
        min = 10000;
        for (int i = 0; i < SIZE; i++) {
            if ((visitedPeaks[i] == 1) && (minDistance[i]<min)) {
                min = minDistance[i];
                minindex = i;
            }
        }
        
        if (minindex != 10000) {
            for (int i = 0; i<SIZE; i++) {
                if (relationMatrix[minindex][i] > 0) {
                    temp = min + relationMatrix[minindex][i];
                    if (temp < minDistance[i]) {
                        minDistance[i] = temp;
                    }
                }
            }
            visitedPeaks[minindex] = 0;
        }
    } while (minindex < 10000);
    
    printf("\nShortest Distance to the tops: \n");
    for (int i = 0; i<SIZE; i++){
        printf("%5d ", minDistance[i]);
    }
    
    int ver[SIZE];
    int end = 7;
    ver[0] = end + 1;
    int k = 1;
    int weight = minDistance[end];
    
    while (end != begin_index) {
        for (int i = 0; i<SIZE; i++) {
            if (relationMatrix[i][end] != 0) {
                int temp = weight - relationMatrix[i][end];
                if (temp == minDistance[i]) {
                    weight = temp;
                    end = i;
                    ver[k] = i + 1;
                    k++;
                }
            }
        }
    }
    
    printf("\nShortest way:\n");
    for (int i = k - 1; i >= 0; i--) {
        printf("%3d ", ver[i]);
    }
    getchar(); getchar();
    return 0;
}

