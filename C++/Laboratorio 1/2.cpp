#include <iostream>

using std::cout;
                                                  // text    data     bss
int globale = 100;                                // 292      16       8
int globale_non_inizializzata;                    // 292      16      12

int main(int argc, char **argv){
    int locale_automatica = 0;                    // 292       8       1
    static int locale_statica = 100;              // 292      12       1
    static int locale_statica_non_inizializzata;  // 292      12       8
    return 0;
}

/*

a. in quale delle sezioni riportate da size compare la variabile locale automatica? Perché?
Sta solo nello stack

b. perché la variabile locale automatica è “automatica”?
Viene inserita nello stack durante l'esecuzione

c. cosa succede togliendo l’inizializzazione alle variabili statiche? Perché?
La variabile si sposta nel bss

d. qual è lo scope di ciascuna delle variabili create?
globale, globale_non_inizializzata hanno scope globale
locale_automatica, locale_statica, locale_statica_non_inizializzata locale rispetto alla funzione main
*/