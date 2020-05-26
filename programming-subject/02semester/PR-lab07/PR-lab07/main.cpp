//
//  main.cpp
//  PR-lab07
//
//  Created by Eric Golovin on 26.05.2020.
//  Copyright © 2020 com.ericgolovin. All rights reserved.
//

#include <iostream>
#include <vector>
using namespace std;

template <class T>
class Array2D {
public:
    class Array1D {
    private:
        int dim2;
        T * Array1; public:
        friend class Array2D;
        Array1D():Array1(NULL),dim2(0) {} T& operator[](int index);
        const T& operator[] (int index) const;
    };
    int dim1;
    Array1D* Array2; public:
    Array2D():dim1(0), Array2(NULL){};
    Array2D(int d1, int d2);
    virtual ~Array2D();
    Array1D& operator[] (int index) {
        return Array2[index];
    }
    const Array1D& operator[] (int index) const {
        return Array2[index];
    }
};


int main(int argc, const char * argv[]) {
    vector<int> results;
    int result = 0;
    int rows = 6, columns = rows;
    Array2D<int> array2D(rows, columns);
    
    cout << "Initial Array: " << endl;
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < columns; j++) {
            array2D[i][j] = rand() % 10;
            cout << array2D[i][j] << " ";
        }
        cout << endl;
    }
    
    // Operation Performing
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < columns; j++) {
            if (j > i) {
                if (array2D[i][j] % 2 == 0) {
                    results.push_back(array2D[i][j]);
                }
            }
        }
    }
        
    cout << endl << endl;
    
    for (int i = 0; i < results.size(); i++) {
        cout << "Element: " << results[i] << endl;
        result *= results[i];
    }
    
    cout << "Multiplication of elements above the main diagonal: " << result << endl;
    
    
    return 0;
}

template <class T>
T& Array2D<T>::Array1D::operator[](int index) {
    return Array1[index];
}

template <class T>
const T& Array2D<T>::Array1D::operator[](int index)const {
    return Array1[index];
}

template <class T> Array2D<T>::Array2D(int d1, int d2) {
    dim1 = d1;
    Array2 = new Array1D[dim1];
    for (int i = 0; i < d1; ++i) {
        Array2[i].dim2 = d2;
        Array2[i].Array1 = new T [d2];
    }
}
template <class T> Array2D<T>::~Array2D() {
    for (int i(0);i<dim1;++i) {
        delete[]Array2[i].Array1;
    }
    delete[] Array2;
}

