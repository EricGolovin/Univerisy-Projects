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
void my_bi_output(T& st, ostream& out)
{
    out << st.bal << endl;
    out << st.fio << endl;
}
template<typename T>
void my_bi_intput(T& st, istream& in)
{
    in >> st.bal >> st.fio;
}
template<typename T>
void my_txt_output(T& st, ostream& out)
{
    out << st.bal << endl;
    out << st.fio << endl;
}
int main()
{
    Student Student = { "Petrov",100 }, Stud;
    ofstream fout;
    fout.open("res.dat", ios::binary);
    my_bi_output<Student>(Student, fout);
    fout.close();
    ifstream fin;
    fin.open("res.dat", ios::binary);
    my_bi_intput<Student>(Stud, fin);
    my_txt_output<Student>(Stud, cout);
    fin.close();
    system("pause");
    return 0;
}

