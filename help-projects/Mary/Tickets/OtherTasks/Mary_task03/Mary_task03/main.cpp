//
//  main.cpp
//  Mary_task03
//
//  Created by Eric Golovin on 6/27/20.
//

#include <iostream>
#include <fstream>
#include <string>

using namespace std;

struct Student
{
    char fio[40];
    int bal;
};
template<typename T>
void my_bi_output(ostream& out, T& st)
{
    out << st.fio << setw(10) << setfill('.');
    out << st.bal;
}
template<typename T>
void my_bi_input(istream& in, T& st) {
    in >>st.fio >> st.bal ;
}
template<typename T>
void my_txt_output(ostream& out,T& st)
{
    out << st.fio << endl;
}

int main()
{
    
    Student petrov = {"Petrov", 75};
    
    ofstream fout("res.dat", ios::binary);
    
    my_bi_output<Student>(fout,petrov);
    
    fout.close();
    
    ifstream fin("res.dat", ios::binary);
    
    Student st;
    
    my_bi_input<Student>(fin,st);
    
    fout.close();
    
    my_txt_output(cout, st);
    
    return 0;
    
}



