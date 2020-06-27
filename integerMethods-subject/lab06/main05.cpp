#include <iostream>
#include <cmath>
using namespace std;

long double F(long double x, long double y){
    return (1+y)/tan(x);
}

int main() {
    long double a=10; 
    long double b=a; long double h=0.001;
    long double n=(b-a)/h;
    long double X[(int)n];
    long double Y1[(int)n];
    long double Y2[(int)n];
    long double Y3[(int)n];
    long double Y4[(int)n];
    long double Y[(int)n];
    //calculate
    X[0]=a; Y[0]=b;
    for(int i=1; i<=n; i++){
        X[i]=a+i*h;
        Y1[i]=h*F(X[i-1],Y[i-1]);
        Y2[i]=h*F(X[i-1]+h/2.0,Y[i-1]+Y1[i]/2.0);
        Y3[i]=h*F(X[i-1]+h/2,Y[i-1]+Y2[i]/2);
        Y4[i]=h*F(X[i-1]+h,Y[i-1]+Y3[i]);
        Y[i]=Y[i-1]+(Y1[i]+2*Y2[i]+2*Y3[i]+Y4[i])/6;
    }
    
    //print results
    for(int i=0; i<=n; i++){
        cout << "X["<<i<<"]="<<X[i] <<" ";
    }
    cout << endl;
    for(int i=0; i<=n; i++){
        cout << "Y["<<i<<"]="<<Y[i] << " ";
    }
    return 0;
}
