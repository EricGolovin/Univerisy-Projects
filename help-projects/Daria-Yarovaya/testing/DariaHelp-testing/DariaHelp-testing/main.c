//
//  main.c
//  DariaHelp-testing
//
//  Created by Eric Golovin on 6/25/20.
//

#include <stdio.h>

int main(int argc, const char * argv[]) {
    int N = 10;
    int array[10] = {5, 8, 3, 6, 8, 8, 10, 8, 7, 5};
    
    for (int i = 0; i < N; i++) {
        if (array[i] < array[N - i]) {
            printf("Int: %d\n", array[i]);
        } else {
            printf("No such Ints\n");
        }
    }
    
    return 0;
}
