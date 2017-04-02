#ifndef PLANSZA_H_INCLUDED
#define PLANSZA_H_INCLUDED

#include <string>
#include <iostream>

//#include <iostream>

class plansza
{
    public:
         plansza();

        //////////////////////////////////////////////////////Metody :
        int IleKart(std::string str);                                                   //zwraca ile kart w talii jako int
        int ShortIntToFullInt(std::string Str,int poczatek);                            //zmienia int(jeden znak) na pelna liczbe int
            int CharToShortInt(std::string str,int i);                                  //zmienia jeden wyraz stringa(char) na int, a wlasciwie short


        char ShortIntToChar(int x);                                                     //zmienia Int a wlasciwie short na jeden wyraz stringa(char)

        std::string CharToFullString(char x,char y,char z);


        std::string DodanieKarty(std::string talia,int NrKarty, int IdDodawanejKarty);  //zamienia karte NrKarty na IdDodawanieKarty w formie stringow
        std::string WywalKarte0(std::string talia,int ktora);                           //zwraca talie z usunieta karta o numerze podanym w int
        std::string PowieOKarte(std::string talia,int NrKarty, int IdDodawanejKarty);   //zwraca karte jako string
        std::string Wyzerowanie(std::string Talia,int ktora);                           //zmiana karty na 000;
        std::string IdToNazwaString(int ID);
        std::string PodliczonaFunkcjaKarty(std::string,int ktora);

        std::string SortTalia(std::string talia, int left, int right);



        void WypisanieKartString(std::string str);                                      //wypisuje wszystkie karty z ciagu string
        void WypiszIdToNazwa(std::string karty,int min,int max);                        //wypisuje w liscie "x) nazwa karty x"
        void kts();
        void narysuj(std::string talie[],int tryb,int ileGraczy,int ktory,int a,int o, int m,std::string gr);      //Rysuje plansze na pdst trybu, il. graczy, ataku morali i obrony, dla konkretnego gracza
        void Sortowanie( int tab[], int left, int right );

        ///////////////////////////////////////////////////////Zmienne :
        int zwyciestwo;

        ///////////////////////////////////////////////////////Tablice :
        std::string Segment[12];

        ~plansza();
};

#endif // PLANSZA_H_INCLUDED
