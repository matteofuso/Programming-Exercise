#include <iostream>
#include <vector>
#include <string>

using std::cout;
using std::vector;
using std::string;

int print(const vector<int> &vettore, const string &header);

int main(int argc, char **argv){
    vector<int> vettore = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    string header = "Vettore ordinato:";
    print(vettore, header);
    return 0;
}

int print(const vector<int> &vettore, const string &header){
    cout << header << "\n";
    for(int i = 0; i < vettore.size(); i++)
    {
        cout << vettore.at(i) << "\n";
    }
    cout << "\n";
    return 0;
}