#include <iostream>
#include <vector>
#include <string>

using std::cout;

void call_counter(void);

int main(int argc, char **argv){
    for (int i = 0; i < 20; i++){
        call_counter();
    }
    return 0;
}

void call_counter(void){
    static int times = 0;
    times++;
    cout << "Funzione chiamata " << times << " volte" << "\n";
}

/*
Che tipo di variabile è necessario utilizzare per risolvere questo problema?
una variabile statica

Qual è la sua durata di memorizzazione?
fino alla fine del programma

Qual è il suo scope?
locale alla funzione call_counter
*/