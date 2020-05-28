#include <iostream>
using namespace std;

int main() {
    int m;
    int i, j;
    int INF = 1000;
    int Graph[20][20];
    int islongs[40];
    int Long[40];
    int PreTops[40];
    int Tops;
    cout << "Enter number of tops: " << endl;
    cin >> Tops;
    cout << "Enter graph edges: " << endl;;
    for (i = 0; i < Tops; i++) {
        for (j = 0; j < Tops; j++) {
            if (i == j) {
                Graph[i][j] = 0;
                continue;
            }
            cout << char('A' + i);
            cout << " - " << char('A' + j) << ": ";
            cin >> Graph[i][j];
        }
    }
    cout << endl;
    int s = 0;
    int end;
    for (i = 0; i < Tops; i++) {
        cout << i + 1 << ". " << char('A' + i) << endl;
    }
    cout << "Enter number of the START top: ";
    cin >> s;
    while (s > Tops || s <= 0) {
        cout << "Error, enter one more time..." << endl;
        cout << "Enter number of the START top: ";
        cin >> s;
    }
    s--;
    for (int i = 0; i < Tops; i++) {
        end = i;
        if (end == s) {
            continue;
        } else {
            int n;
            for (n = 0; n < Tops; n++) {
                Long[n] = INF;
                islongs[n] = 0;
            }
            PreTops[s] = 0;
            Long[s] = 0;
            islongs[s] = 1;
            m = s;
            while (1) {
                for (n = 0; n < Tops; n++) {
                    if (Graph[m][n] == 0) {
                        continue;
                    }
                    if (islongs[n] == 0 && Long[n] > Long[m] + Graph[m][n]) {
                        Long[n] = Long[m] + Graph[m][n];
                        PreTops[n] = m;
                    }
                }
                int w = INF;
                m = -1;
                for (n = 0; n < Tops; n++) {
                    if (islongs[n] == 0 && Long[n] < w) {
                        m = n;
                        w = Long[n];
                    }
                }
                
                if (m == -1) {
                    cout << "No way from the top " << char('A'+ s);
                    cout << " to top " << char('A' + end) << "." << endl;
                    break;
                }
                if (m == end) {
                    cout << "The shortest way from  " << char('A' + s); cout << " to top " << char('A' + end) << ":";
                    n = end;
                    while (n != s) {
                        cout << " " << char('A' + n);
                        n = PreTops[n];
                    }
                    cout << " " << char('A' + s) << ". Length of the way - " << Long[end]; cout << endl;
                    break;
                }
                islongs[m] = 1;
            }
        }
    }
    cout << "Weight matrix:\n";
    for (size_t i = 0; i < Tops; i++) {
        for (size_t j = 0; j < Tops; j++) {
            cout << Graph[i][j] << " ";
        }
        cout << endl;
    }
    return 0;
}

