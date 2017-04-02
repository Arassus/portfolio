#ifndef GRACZ_H_INCLUDED
#define GRACZ_H_INCLUDED

#include <string>
#include <iostream>

class Grcz
{
    public :
    Grcz();

////////////////////////Zmienne VVVVVVVVVVVVVV
    std::string talia;
    std::string podsumowanie;
    int atak;
    int obrona;
    int morale;
////////////////////////Zmienne ^^^^^^^^^^^^^^
////////////////////////Metody VVVVVVVVVVVVVVV

    int PodsumToAtak(std::string pods,int PoraDnia);                  //zwraca ile ataku ma gracz po podsumowaniu(string)
    int PodsumToObro(std::string podsum);                            //zwraca ile obrony ma gracz po podsumowaniu(string)
    int PodsumToMora(std::string pds,char BufOd26);                 //zwraca ile morali ma gracz po podsumowaniu(string); char istnieje bo bufy
    std::string TaliaToPodsum(std::string pods,int id,int t);         //zwraca podsumowanie(string) na podstawie jednej karty

    char ShortIntToChar(int x);
    std::string CharToFullString(char x,char y,char z);

//--------------------------------------------

    int Ruch(std::string Pozycja,int xx,int x);                      //ustala pozycje gracza na planszy na podstawie xx(wytycznych - gora,dol,lewo,prawo)
    int CharToAkcja(std::string teren,int x,int kierunek);          //na podstawie wyrazu string[x] zwraca ile pkt trzeba by wykonac akcje, kierunek-bo zabezpieczenie przed ";"
    int DlugWiersz(std::string teren);                              //Zwraca dlugosc wiersza
    int IdToAkcja(int ID);
////////////////////////Metody ^^^^^^^^^^^^^^

    ~Grcz();
};

#endif // GRACZ_H_INCLUDED
