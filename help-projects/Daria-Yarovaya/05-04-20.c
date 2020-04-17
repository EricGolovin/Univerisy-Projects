#include <stdio.h>

void printArr(int arrayOfElements[], int count) {
    printf("\n");
    for (int i = 0; i < count; i++) {
        printf("[%i] ", arrayOfElements[i]);
    }
    printf("\n");
}

int main(int argc, char *argv[]) {
    
    // asking user for number of elements (N) in A-array
    int numOfElements = 0;
    printf("Please, enter number of elements: ");
    scanf("%i", &numOfElements);
    printf("\n");
    
    int A_array[numOfElements];
    int B_array[numOfElements];
    
    // asking user for elements in A-array
    for (int i = 0; i < numOfElements; i++) {
        printf("Enter the %i element of your array: ", i);
        scanf("%i", &A_array[i]);
        printf("\n");
    }
    
    
    // adding elemetns to B-array
    for (int bIndex = 0; bIndex < numOfElements; bIndex++) {
        B_array[bIndex] = 0; // to initialize each element in B-array before adding to it
        for (int aIndex = bIndex; aIndex < numOfElements; aIndex++) {
            B_array[bIndex] += A_array[aIndex];
        }
    }
    
    // printing final array
    printArr(A_array, numOfElements);
    printArr(B_array, numOfElements);
    
    return 0;
}
