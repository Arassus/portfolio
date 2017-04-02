#include <Plansza.h>
#include <algorithm>
#include <functional>
//
//#include <string>


//plansza


int plansza::IleKart(std::string str)
{
    int x=0;
    for(unsigned int i=0;i<str.length();i++)
    {
        if(str[i]==';')x++;
    }
    return x;
}

char plansza::ShortIntToChar(int x)
{
    switch(x)
    {
    case 0:
        {
            return '0';
            break;
        }
    case 1:
        {
            return '1';
            break;
        }
    case 2:
        {
            return '2';
            break;
        }
    case 3:
        {
            return '3';
            break;
        }
    case 4:
        {
            return '4';
            break;
        }
    case 5:
        {
            return '5';
            break;
        }
    case 6:
        {
            return '6';
            break;
        }
    case 7:
        {
            return '7';
            break;
        }
    case 8:
        {
            return '8';
            break;
        }
    case 9:
        {
            return '9';
            break;
        }
    default:
        {
            std::cout<<"blad w gra::ShortInrtToChar"<<std::endl;
            break;
        }
    }
    return 0;
}

std::string plansza::CharToFullString(char x,char y,char z)
{
    std::string str="";
    str+=x+y+z+";";
    return str;
}

int plansza::CharToShortInt(std::string str,int i)
{
    switch(str[i])
    {
    case '0':
        {
            return 0;
            break;
        }
    case '1':
        {
            return 1;
            break;
        }
    case '2':
        {
            return 2;
            break;
        }
    case '3':
        {
            return 3;
            break;
        }
    case '4':
        {
            return 4;
            break;
        }
    case '5':
        {
            return 5;
            break;
        }
    case '6':
        {
            return 6;
            break;
        }
    case '7':
        {
            return 7;
            break;
        }
    case '8':
        {
            return 8;
            break;
        }
    case '9':
        {
            return 9;
            break;
        }
    default:
        {
            std::cout<<"blad w gra::CharToShortInt; case : |"<<str[i]<<"|"<<std::endl;
            break;
        }
    }
    return 0;
}

int plansza::ShortIntToFullInt(std::string Str,int poczatek)
{
    int x=0;
    for(int i=poczatek*4,k=0;k<3;k++,i++)
    {
        if(k==0)
            {
                x+=100*plansza::CharToShortInt(Str,i);
                //std::cout<<"wyraz 100 to : "<<x<<std::endl;
            }
            else
                {
                    if(k==1)
                    {
                        x+=10*plansza::CharToShortInt(Str,i);
                        //std::cout<<"wyraz 10 to : "<<x<<std::endl;
                    }
                    else
                    {
                        x+=plansza::CharToShortInt(Str,i);
                        //std::cout<<"wyraz 1 to : "<<x<<std::endl;
                    }
                }
    }

    return x;
}



void plansza::WypisanieKartString(std::string str)
{
    std::string tempor="";

    for(unsigned int i=0;i<str.length();i++)
    {
        if(str[i]==char(59))
            {
                tempor+=str[i-3];tempor+=str[i-2];tempor+=str[i-1];
                std::cout<<tempor<<std::endl;


                tempor="";
            }
    }
}

std::string plansza::DodanieKarty(std::string talia,int NrKarty, int IdDodawanejKarty)
{
    int i=(NrKarty-1)*4,x=IdDodawanejKarty/100,y=(IdDodawanejKarty-x*100)/10,z=IdDodawanejKarty-x*100-y*10;
    talia[i]=plansza::ShortIntToChar(x);
    talia[i+1]=plansza::ShortIntToChar(y);
    talia[i+2]=plansza::ShortIntToChar(z);
    talia[i+3]=';';

    return talia;
}

std::string plansza::PowieOKarte(std::string talia,int NrKarty, int IdDodawanejKarty)
{
    std::string asd="000;";
    asd=plansza::DodanieKarty(talia,NrKarty,IdDodawanejKarty);
    return asd;
}

std::string plansza::Wyzerowanie(std::string talia,int ktora)
{
    int x=(ktora-1)*4;
    talia[x]='0';
    talia[x+1]='0';
    talia[x+2]='0';
    talia[x+3]=';';

    return talia;
}

std::string plansza::IdToNazwaString(int ID)
{
    switch(ID)
    {
    case 0:
        return "miejsce puste";
        break;
    case 1:
        return "bohater1";
        break;
    case 2:
        return "bohater2";
        break;
    case 3:
        return "bohater3";
        break;
    case 4:
        return "bohater4";
        break;
    case 5:
        return "bohater5";
        break;
    case 6:
        return "szermierz1";
        break;
    case 7:
        return "szermierz2";
        break;
    case 8:
        return "szermierz3";
        break;
    case 9:
        return "szermierz4";
        break;
    case 10:
        return "szermierz5";
        break;
    case 11:
        return "szermierz6";
        break;
    case 12:
        return "szermierz7";
        break;
    case 13:
        return "szermierz8";
        break;
    case 14:
        return "szermierz9";
        break;
    case 15:
        return "szermierz10";
        break;
    case 16:
        return "lucznik1";
        break;
    case 17:
        return "lucznik2";
        break;
    case 18:
        return "lucznik3";
        break;
    case 19:
        return "lucznik4";
        break;
    case 20:
        return "lucznik5";
        break;
    case 21:
        return "lucznik6";
        break;
    case 22:
        return "lucznik7";
        break;
    case 23:
        return "lucznik8";
        break;
    case 24:
        return "lucznik9";
        break;
    case 25:
        return "lucznik10";
        break;
    case 26:
        return "buf1";
        break;
    case 27:
        return "buf2";
        break;
    case 28:
        return "buf3";
        break;
    case 29:
        return "buf4";
        break;
    case 30:
        return "buf5";
        break;
    default:
        return "problem z plansza::IdToNazwaString";
        break;
    }
}

void plansza::WypiszIdToNazwa(std::string karty,int min,int max)
{
    for(int i=min;i<max;i++)
    {
        std::cout<<i<<") "<<IdToNazwaString(ShortIntToFullInt(karty,i))<<std::endl;
    }
}

void kts()
{
    ;
}

std::string plansza::WywalKarte0(std::string talia,int ktora)
{
    std::string dasd="";
    int ile=IleKart(talia);
    for(;ktora<ile;ktora++)
    {
        talia[ktora*4]=talia[(ktora+1)*4];
        talia[ktora*4+1]=talia[(ktora+1)*4+1];
        talia[ktora*4+2]=talia[(ktora+1)*4+2];
        talia[ktora*4+3]=talia[(ktora+1)*4+3];
    }
    for(int m=0;m<ile-1;m++)
    {
        dasd+=talia[m*4];
        dasd+=talia[m*4+1];
        dasd+=talia[m*4+2];
        dasd+=talia[m*4+3];
    }

    return dasd;
}

void plansza::Sortowanie( int tab[], int left, int right )
{
    int i = left;
    int j = right;
    int x = tab[( left + right ) / 2 ];

    do
    {
        while( tab[ i ] < x )
             i++;
        while( tab[ j ] > x )
             j--;
        if( i <= j )
        {
            std::swap( tab[ i ], tab[ j ] );
            i++;
            j--;
        }
    }
    while( i <= j );

    if( left < j ) Sortowanie( tab, left, j );
    if( right > i ) Sortowanie( tab, i, right );
}

std::string plansza::SortTalia(std::string talia, int left, int right)
{
    int tab[right+1];
    for(int i=0;i<right;i++)
    {
        tab[i]=plansza::ShortIntToFullInt(talia,i);
    }
    plansza::Sortowanie(tab,left,right);
    for(int i=1;i<right+1;i++)
    {
        talia=plansza::DodanieKarty(talia,i,tab[i]);
    }
    return talia;
}

void plansza::narysuj(std::string talie[],int tryb,int ileGraczy,int ktory, int a, int o, int m,std::string gr)
{
    int ile1wiersz, ile2wiersz;
    if(tryb==1)
    {
        if(ileGraczy=2)
        {
                if(plansza::IleKart(talie[1+ktory*6])<plansza::IleKart(talie[2+ktory*6])) ile1wiersz=plansza::IleKart(talie[2+ktory*6]);
                else ile1wiersz=plansza::IleKart(talie[1+ktory*6]);
                if(plansza::IleKart(talie[3+ktory*6])<plansza::IleKart(talie[4+ktory*6]))
                {
                    if(plansza::IleKart(talie[4+ktory*6])<plansza::IleKart(talie[5+ktory*6]))
                    ile2wiersz=plansza::IleKart(talie[5+ktory*6]);
                    else
                    ile2wiersz=plansza::IleKart(talie[4+ktory*6]);
                }
                else
                {
                    if(plansza::IleKart(talie[3+ktory*6])<plansza::IleKart(talie[5+ktory*6]))
                    ile2wiersz=plansza::IleKart(talie[5+ktory*6]);
                    else
                    ile2wiersz=plansza::IleKart(talie[3+ktory*6]);
                }
/*1 linijka*/   {
                std::cout<<(char)201;
                for(int v=0;v<6;v++){std::cout<<(char)205;}
                std::cout<<(char)203;
                for(int v=0;v<6;v++){std::cout<<(char)205;}
                std::cout<<(char)203;
                for(int v=0;v<5;v++){std::cout<<(char)205;}
                std::cout<<(char)203;
                for(int v=0;v<6;v++){std::cout<<(char)205;}
                std::cout<<(char)187<<std::endl;
                }
/*2 linijka*/   {
                std::cout<<(char)186<<"      "<<(char)179<<"MORALE"<<(char)179<<"ATAK "<<(char)179<<"OBRONA"<<(char)186<<std::endl;
                }
/*3 linijka*/   {
                std::cout<<(char)186<<gr<<(char)179;
/*MORA*/                    {
                                if(m>999)
                                {
                                    std::cout<<m;
                                    std::cout<<"% ";
                                }
                                else
                                {
                                    if(m>99)
                                    {
                                        std::cout<<m;
                                        std::cout<<"%  ";
                                    }
                                    else
                                    {
                                        if(m>9)
                                        {
                                            std::cout<<m;
                                            std::cout<<"%   ";
                                        }
                                        else
                                        {
                                            std::cout<<m;
                                            std::cout<<"%    ";
                                        }
                                    }
                                }
                                std::cout<<(char)179;
                            }
/*ATAK*/                    {
                if(a>9999)
                    {
                        std::cout<<a;
                    }
                else
                {
                    if(a>999)
                    {
                        std::cout<<a;
                        std::cout<<" ";
                    }
                    else
                    {
                        if(a>99)
                        {
                            std::cout<<a;
                            std::cout<<"  ";
                        }
                        else
                        {
                            if(a>9)
                            {
                                std::cout<<a;
                                std::cout<<"   ";
                            }
                            else
                            {
                                std::cout<<a;
                                std::cout<<"    ";
                            }
                        }
                    }
                }
                std::cout<<(char)179;
                            }
/*OBRO*/                    {
                if(o>9999)
                    {
                        std::cout<<o;
                        std::cout<<" ";
                    }
                else
                {
                    if(o>999)
                    {
                        std::cout<<o;
                        std::cout<<"  ";
                    }
                    else
                    {
                        if(o>99)
                        {
                            std::cout<<o;
                            std::cout<<"   ";
                        }
                        else
                        {
                            if(o>9)
                            {
                                std::cout<<o;
                                std::cout<<"    ";
                            }
                            else
                            {
                                std::cout<<o;
                                std::cout<<"     ";
                            }
                        }
                    }
                }
                            }
                std::cout<<(char)186<<std::endl;
                }
/*4 linijka*/   {
                std::cout<<(char)204;
                for(int v=0;v<6;v++){std::cout<<(char)205;}
                std::cout<<(char)202<<(char)203;
                for(int v=0;v<5;v++){std::cout<<(char)205;}
                std::cout<<(char)202<<(char)205<<(char)203;
                for(int v=0;v<3;v++){std::cout<<(char)205;}
                std::cout<<(char)202;
                for(int v=0;v<2;v++){std::cout<<(char)205;}
                std::cout<<(char)203;
                for(int v=0;v<3;v++){std::cout<<(char)205;}
                std::cout<<(char)188<<std::endl;
                }
/*5 linijka*/   {
                std::cout<<(char)186<<"TALIA  "<<(char)179<<"REKA   "<<(char)179<<"ZUZYTE"<<(char)186<<std::endl;
                }
/*1 wiersz*/    for(int v=0;v<ile1wiersz;v++)
                {
                    std::cout<<(char)186<<"XXXXXXX"<<(char)179;
                    if(v<plansza::IleKart(talie[1+ktory*6]))    std::cout<<talie[1+ktory*6][v*4]<<talie[1+ktory*6][v*4+1]<<talie[1+ktory*6][v*4+2]<<";";     else std::cout<<"    ";
                    std::cout<<"   "<<(char)179;
                    if(v<plansza::IleKart(talie[2+ktory*6]))    std::cout<<talie[2+ktory*6][v*4]<<talie[2+ktory*6][v*4+1]<<talie[2+ktory*6][v*4+2]<<";";     else std::cout<<"    ";
                    std::cout<<"  "<<(char)186<<std::endl;
                }
/*miedzyWiersz*/{
                std::cout<<(char)204;for(int v=0;v<20;v++){std::cout<<(char)196;if(v==6||v==13)std::cout<<(char)197;}std::cout<<(char)206<<std::endl;
                std::cout<<(char)186<<"BOHATER"<<(char)179<<"ZAGRANE"<<(char)179<<"BUFY  "<<(char)186<<std::endl;
                }
/*2 wiersz*/    for(int v=0;v<ile2wiersz;v++)
                {
                    std::cout<<(char)186;
                    if(v<plansza::IleKart(talie[3+ktory*6]))  std::cout<<talie[3+ktory*6][v*4]<<talie[3+ktory*6][v*4+1]<<talie[3+ktory*6][v*4+2]<<";";    else std::cout<<"    ";
                    std::cout<<"   "<<(char)179;
                    if(v<plansza::IleKart(talie[4+ktory*6]))  std::cout<<talie[4+ktory*6][v*4]<<talie[4+ktory*6][v*4+1]<<talie[4+ktory*6][v*4+2]<<";";    else std::cout<<"    ";
                    std::cout<<"   "<<(char)179;
                    if(v<plansza::IleKart(talie[5+ktory*6]))  std::cout<<talie[5+ktory*6][v*4]<<talie[5+ktory*6][v*4+1]<<talie[5+ktory*6][v*4+2]<<";";    else std::cout<<"    ";
                    std::cout<<"  "<<(char)186<<std::endl;
                }
/*ostatnia lin*/{
                std::cout<<(char)200;
                for(int v=0;v<7;v++){std::cout<<(char)205;}
                std::cout<<(char)202;
                for(int v=0;v<7;v++){std::cout<<(char)205;}
                std::cout<<(char)202;
                for(int v=0;v<6;v++){std::cout<<(char)205;}
                std::cout<<(char)188<<std::endl;
                }
            //}
        }
        else
        {
            std::cout<<"PVP_2v2"<<std::endl;
        }
    }
    if(tryb==3)
    {
        if(a==o)
            {
                std::cout<<(char)2;
            }
        else
            {
                if(talie[0][a]=='0')std::cout<<(char)205;       //droga poziomo                         //[co][jak][kierunki]
                if(talie[0][a]=='1')std::cout<<(char)186;       //droga pionowo
                if(talie[0][a]=='2')std::cout<<(char)206;       //droga skrzyzowanie    NSEW
                if(talie[0][a]=='3')std::cout<<(char)201;       //droga skret           SE
                if(talie[0][a]=='4')std::cout<<(char)187;       //droga skret           SW
                if(talie[0][a]=='5')std::cout<<(char)188;       //droga skret           NW
                if(talie[0][a]=='6')std::cout<<(char)200;       //droga skret           NE
                if(talie[0][a]=='7')std::cout<<(char)202;       //droga skrzyzowanie    NEW
                if(talie[0][a]=='8')std::cout<<(char)204;       //droga skrzyzowanie    NSE
                if(talie[0][a]=='9')std::cout<<(char)203;       //droga skrzyzowanie    SEW
                if(talie[0][a]=='a')std::cout<<(char)180;       //droga skrzyzowanie    NSW
                if(talie[0][a]=='b')std::cout<<(char)0;         //trawa
                if(talie[0][a]=='c')std::cout<<(char)177;       //bagno
                if(talie[0][a]=='d')std::cout<<(char)237;       //las
                if(talie[0][a]==';')std::cout<<"\n";            //enter
            }
    }
}

plansza::plansza()
{
    //std::cout<<"narysowano plansze"<<std::endl;
    zwyciestwo=0;
}

plansza::~plansza()
{
    //std::cout<<"usunieto plansze"<<std::endl;
}
