#ifndef RATIONAL_H
#define RATIONAL_H
#include <iostream>
#include <numeric>

class Rational
{
private:
    int numerator{0}, denominator{1};

public:
    class DivideByZeroException
    {
    };

    Rational(void);
    Rational(int number);
    Rational(int numerator, int denominator);
    Rational &operator=(const Rational &a);
    // Rational operator+(const Rational& a) const;
    // Rational operator+(int a) const;

    int getNumerator(void) const;
    int getDenominator(void) const;
    double toDouble() const;
};

std::ostream &operator<<(std::ostream &out, const Rational &a);
Rational operator+(const Rational &a, const Rational &b);
Rational operator+(const Rational &a, int b);
Rational operator+(int a, const Rational &b);
Rational operator-(const Rational &a, const Rational &b);
Rational operator*(const Rational &a, const Rational &b);
Rational operator/(const Rational &a, const Rational &b);
bool operator==(const Rational &a, const Rational &b);
bool operator>(const Rational &a, const Rational &b);
bool operator<(const Rational &a, const Rational &b);

#endif