#include <iostream>
#include "include/Rational.h"

int main(int argc, char **argv)
{
    Rational a = 0;
    Rational b{10};
    Rational c{10, 3};
    Rational d = c;

    std::cout << "---- Valori Iniziali ----" << std::endl;
    std::cout << "A: " << a << std::endl;
    std::cout << "B: " << b << std::endl;
    std::cout << "C: " << c << std::endl;
    std::cout << "D: " << d << std::endl;

    std::cout << std::endl
              << "---- Artitmetica ----" << std::endl;
    std::cout << "B + C: " << b + c << std::endl;
    std::cout << "B - C: " << b - c << std::endl;
    std::cout << "B * C: " << b * c << std::endl;
    std::cout << "B / C: " << b / c << std::endl;

    std::cout << std::endl
              << "---- Confronti ----" << std::endl;
    std::cout << "C == D: " << (c == d ? "true" : "false") << std::endl;
    std::cout << "B < C: " << (b < c ? "true" : "false") << std::endl;
    std::cout << "B > C: " << (b > c ? "true" : "false") << std::endl;
    std::cout << "C + int(10): " << c + 10 << std::endl;
    std::cout << "int(10) + C: " << 10 + c << std::endl;
    return 0;
}

/*
Se implemento operation+ come funzione membro non posso fare l'overload di 
int + Rational, quindi int + Rational non ha senso e genera un errore di compilazione
*/