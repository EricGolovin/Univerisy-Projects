#include <iostream>
#include <vector>
#include <math.h>
using namespace std;

double con(vector <vector<double> > &xy, int k)
{
	double y[10][10];
	for (int i = 0; i < 10; i++)
	{
		y[i][0]=xy[i][1];
	}
	for (int i = 1; i < 10; i++) 
	{
		for (int j = 0; j < 10 - i; j++) 
			y[j][i] = y[j + 1][i - 1] - y[j][i - 1];
	}

	return y[0][k];
}
double fact(int n) {
 double f = 1.0;
 for (int i = 2; i <= n; i++) f *= i;
 return f;
}
double f(double x)
{
    // MARK: - Need to enter our initial formula
	double y = pow(x - 1, 2) - exp(-x);
	return y;
}
double L(vector <vector<double> > &xy, double x)
{
	double y=0;
	for (int i = 0; i < 10; i++)
	{
		double d = 1;
		for (int j = 0; j < 10; j++)
		{
			if(i!=j)
			d = d * (x - xy[j][0]) / (xy[i][0]- xy[j][0]);
		}
		y = y + d * xy[i][1];
	}
	return y;
}
double P(vector <vector<double> > &xy, double x)
{
	double q = (x - xy[0][0]) / (xy[1][0] - xy[0][0]);
	double Y = xy[0][1],H = q;
		for (int j = 1; j < 10; j++)
		{
			for (int k = 1; k < j; k++)
			{
				H = q;
				H = H * (q-k);
			}
			H = H * con(xy,j)/ fact(j);
			Y = Y + H;
		}
		return Y;
}
int main()
{
	vector <vector<double> > xy;
	
    // MARK: - Need to change a and b to our values
    double a = 0.4;
	double b = 0.9;
	vector<double> h;
	double j;
	
	for (int i = 0; i < 10; i++)
	{
		h.push_back(a + i * (b - a) / 10);
		h.push_back(f(a+i*(b-a)/10));
		xy.push_back(h);
		h.resize(0);
	}
	
	cout << "FUNCTION "<<f(xy[4][0]+0.021) << " LANGRANG " << L(xy, xy[4][0]+0.021) <<" NEWTON "<< P(xy, xy[4][0]+0.021) << endl;
	cout << "FUNCTION " << f(xy[7][0] + 0.0146) << " LANGRANG " << L(xy, xy[7][0] + 0.0146) << " NEWTON " << P(xy, xy[7][0] + 0.0146);
	return 0;
}

