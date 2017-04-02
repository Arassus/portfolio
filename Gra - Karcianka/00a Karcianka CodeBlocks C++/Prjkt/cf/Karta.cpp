#include <Karta.h>

std::string karta::CharToFullString(char x,char y,char z)
{
    std::string str="";
    str+=x+y+z+";";
    return str;
}

char karta::ShortIntToChar(int x)
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

karta::karta()
{
    int x,y,z;
    talia="";
    for(int i=0;i<25;i++)
    {
        x=i/100;
        y=i/10-x;
        z=i-x*100-y*10;
        talia+=ShortIntToChar(x);
        talia+=ShortIntToChar(y);
        talia+=ShortIntToChar(z);
        talia+=";";
    }
}

karta::~karta()
{

}
