#include "../include/Math.h"

int math::mcm(int a, int b)
{
    if (a == 0 || b == 0)
        return 0;
    return abs(a / mcd(a, b) * b);
}

int math::mcd(int a, int b)
{
    int r;
    a = abs(a);
    b = abs(b);
    while (b > 0)
    {
        r = a % b;
        a = b;
        b = r;
    }
    return a;
}

int math::abs(int a)
{
    if (a < 0)
    {
        return -a;
    }
    return a;
}