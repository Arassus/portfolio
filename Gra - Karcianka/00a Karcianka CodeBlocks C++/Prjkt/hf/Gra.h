#ifndef GRA_H_INCLUDED
#define GRA_H_INCLUDED

//
#include <iostream>
#include <cstdlib>
#include <ctime>

class gra
{
public :
    gra();


    void krok();


    int IleRundMax;
    int MaxWTalii;
    int MaxBoh;
    int MaxDoZagrania;
    int MaxBuf;
    int MaxReka;

    ~gra();
};
#endif // GRA_H_INCLUDED
