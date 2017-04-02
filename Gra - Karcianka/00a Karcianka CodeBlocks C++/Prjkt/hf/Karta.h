#ifndef KARTA_H_INCLUDED
#define KARTA_H_INCLUDED

#include <string>
#include <iostream>

class karta
{
public:
    karta();
    std::string talia;

    char ShortIntToChar(int x);
    std::string CharToFullString(char x,char y,char z);
    ~karta();
};

#endif // KARTA_H_INCLUDED
