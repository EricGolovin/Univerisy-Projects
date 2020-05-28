#include <iostream>
using namespace std;

int main() {
    long long n, ans;
    cin >> n;
    ans = n;
    
    for (long long i = 2; i*i <= n; i++) {
        if (n % i == 0) {
            while (n % i == 0) {
                n/= i;
            }
        }
        ans-=ans/i;
    }
    
    if (n > 1) {
        ans-=ans/n;
    }
    
    cout << ans;
    return 0;
}


