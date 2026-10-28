#include <iostream>
#include "../include/Rational.h"
#include "../include/Math.h"

// -- Costruttori --
Rational::Rational(void) : numerator{0}, denominator{1} {}
Rational::Rational(int number) : numerator{number}, denominator{1} {}
Rational::Rational(int numerator, int denominator) : numerator{numerator}, denominator{denominator}
{
    int mcd;

    // Controllo denominatore non nullo
    if (denominator == 0)
    {
        throw DivideByZeroException();
    }

    // Riduco ai minimi termini
    mcd = math::mcd(numerator, denominator);
    this->numerator /= mcd;
    this->denominator /= mcd;

    // Porto il segno solo al numeratore
    if (this->denominator < 0)
    {
        this->numerator *= -1;
        this->denominator *= -1;
    }
}

// -- Getters --
int Rational::getNumerator() const
{
    return numerator;
}
int Rational::getDenominator() const
{
    return denominator;
}
double Rational::toDouble() const
{
    return static_cast<double>(numerator) / denominator;
}

// -- Operatori Member
Rational &Rational::operator=(const Rational &a)
{
    numerator = a.getNumerator();
    denominator = a.getDenominator();
    return *this;
}
// Rational Rational::operator+(const Rational& a) const{
//     int denominator = math::mcm(this->denominator, a.getDenominator());
//     int numerator = denominator / this->denominator * this->numerator + denominator / a.getDenominator() * a.getNumerator();

//     return Rational(numerator, denominator);
// }
// Rational Rational::operator+(int a) const {
//     int denominator = this->denominator;
//     int numerator = this->numerator + denominator * a;

//     return Rational(numerator, denominator);
// }

// Operatori Helper
Rational operator+(const Rational &a, const Rational &b)
{
    int denominator = math::mcm(a.getDenominator(), b.getDenominator());
    int numerator = denominator / a.getDenominator() * a.getNumerator() + denominator / b.getDenominator() * b.getNumerator();

    return Rational(numerator, denominator);
}
Rational operator+(const Rational &a, int b)
{
    int denominator = a.getDenominator();
    int numerator = a.getNumerator() + denominator * b;

    return Rational(numerator, denominator);
}
Rational operator+(int a, const Rational &b)
{
    return b + a;
}
Rational operator-(const Rational &a, const Rational &b)
{
    return a + Rational{-b.getNumerator(), b.getDenominator()};
}
Rational operator*(const Rational &a, const Rational &b)
{
    int numerator = a.getNumerator() * b.getNumerator();
    int denominator = a.getDenominator() * b.getDenominator();

    return Rational(numerator, denominator);
}
Rational operator/(const Rational &a, const Rational &b)
{
    return a * Rational(b.getDenominator(), b.getNumerator());
}

bool operator==(const Rational &a, const Rational &b)
{
    return a.getNumerator() == b.getNumerator() && a.getDenominator() == b.getDenominator();
}
bool operator>(const Rational &a, const Rational &b)
{
    return (a - b).getNumerator() > 0;
}
bool operator<(const Rational &a, const Rational &b)
{
    return (a - b).getNumerator() < 0;
}
std::ostream &operator<<(std::ostream &out, const Rational &a)
{
    return out << a.getNumerator() << "/" << a.getDenominator() << " (" << a.toDouble() << ")";
}