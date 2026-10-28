#include <iostream>
#include <vector>
#include <string>

using std::cout;
using std::vector;
using std::string;

int print(const vector<int> &vettore, const string &header);
int fibonacci(int x, int y, vector<int> &v, int n);

int main(int argc, char **argv){
    vector<int> vettore;
    fibonacci(1, 1, vettore, 45);
    print(vettore, "Vettore di fibonacci:");
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

int fibonacci(int x, int y, vector<int> &v, int n){
    v.clear();
    v.push_back(x);
    v.push_back(y);
    for (int i = 0; i < n; i++)
    {
        v.push_back(v.at(i) + v.at(i + 1));
    }
    return 0;
}

/*
Esercizio 5:
1
1
2
3
5
8
13
21
34
55
89
144
233
377
610
987
1597
2584
4181
6765
10946
17711
28657
46368
75025
121393
196418
317811
514229
832040
1346269
2178309
3524578
5702887
9227465
14930352
24157817
39088169
63245986
102334155
165580141
267914296
433494437
701408733
1134903170
1836311903
-1323752223

Questo mostra che 1836311903 e' il numero massimo stimato, poi va in overflow
*/