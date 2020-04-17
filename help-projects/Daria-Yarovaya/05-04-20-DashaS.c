#include <stdio.h>

int main()
{
    int n;
    int k;
    
    printf("Vvedite N: ");
    scanf("%d",&n);
    
    int a[n];
    int b[n];
    
    for (k = 0; k < n; k++) {
        printf("a[%d]: ", k);
        scanf("%d", &a[k]);
    }
    
    for(k = 0; k < n; k++) {
        b[k] = 0;
        for (int i = k; i < n; i++){
            b[k] += a[i];
        }
    }
    
    printf("B: \n");
    
    for(k = 0; k < n; k++){
        printf("%d: %d\n",k + 1, b[k]);
    }
    
    return 0;
}
