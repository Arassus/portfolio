#include <Gracz.h>
//////////


std::string Grcz::CharToFullString(char x,char y,char z)
{
    std::string str="";
    str+=x+y+z+";";
    return str;
}

int Grcz::DlugWiersz(std::string teren)
{
    int i=0;
    while(teren[i]!=';') {i++;}

    return i+1;
}

int Grcz::CharToAkcja(std::string teren,int x,int kierunek)
{
    int ile;
    switch(teren[x])
    {
    case '0':
        {
            ile=1;
            break;
        }
    case '1':
        {
            ile=1;
            break;
        }
    case '2':
        {
            ile=1;
            break;
        }
    case '3':
        {
            ile=1;
            break;
        }
    case '4':
        {
            ile=1;
            break;
        }
    case '5':
        {
            ile=1;
            break;
        }
    case '6':
        {
            ile=1;
            break;
        }
    case '7':
        {
            ile=1;
            break;
        }
    case '8':
        {
            ile=1;
            break;
        }
    case '9':
        {
            ile=1;
            break;
        }
    case 'a':
        {
            ile=1;
            break;
        }
    case 'b':
        {
            ile=2;
            break;
        }
    case 'c':
        {
            ile=4;
            break;
        }
    case 'd':
        {
            ile=5;
            break;
        }
    case ';':
        {
            if(kierunek==1)
            {
                ile=CharToAkcja(teren,x+DlugWiersz(teren)-1,1);
            }
            if(kierunek==3)
            {
                ile=CharToAkcja(teren,x-DlugWiersz(teren)+1,3);
            }
            break;
        }
    default:
        {
            ile=0;
            std::cout<<"blad"<<std::endl;
            break;
        }

    }

    return ile;
}

char Grcz::ShortIntToChar(int x)
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

int Grcz::PodsumToAtak(std::string pods,int PoraDnia)
{
    int x=0;
    for(int i=0;i<30;i++)
    {
        switch(pods[i])
        {
        case '1':
            {
                if(i==0)/*Bohater1*/
                    {
                        if(PoraDnia==1)
                            {
                                x+=300;
                            }
                        else
                            {
                                x+=150;
                            }
                    }
                if(i==1)/*Bohater2*/
                    {
                        if(PoraDnia==1||PoraDnia==2)
                            {
                                x+=400;
                            }
                        else
                            {
                                x+=200;
                            }
                    }
                if(i==2) /*Bohater3*/
                    {
                        if(PoraDnia==1||PoraDnia==2||PoraDnia==3)
                            {
                                x+=500;
                            }
                        else
                            {

                            }
                    }
                if(i==3) /*Bohater4*/
                    {
                        if(PoraDnia==2||PoraDnia==3)
                            {
                                x+=600;
                            }
                        else
                            {
                                x+=300;
                            }
                    }
                if(i==4)  /*Bohater5*/
                    {
                        if(PoraDnia==3)
                            {
                                x+=700;
                            }
                        else
                            {
                                x+=350;
                            }
                    }
                if(i==5)/*Szermierz1*/
                    {
                        if(PoraDnia==3)
                            {
                                x+=100;
                            }
                        else
                            {
                                x+=50;
                            }
                    }
                if(i==6)  /*Szermierz2*/
                    {
                        if(PoraDnia==3)
                            {
                                x+=100;
                            }
                        else
                            {
                                x+=50;
                            }
                    }
                if(i==7)  /*Szermierz3*/
                    {
                        if(PoraDnia==2||PoraDnia==3)
                            {
                                x+=200;
                            }
                        else
                            {
                                x+=100;
                            }
                    }
                if(i==8)  /*Szermierz4*/
                    {
                        if(PoraDnia==2||PoraDnia==3)
                            {
                                x+=200;
                            }
                        else
                            {
                                x+=100;
                            }
                    }
                if(i==9)  /*Szermierz5*/
                    {
                        if(PoraDnia==2)
                            {
                                x+=300;
                            }
                        else
                            {
                                x+=150;
                            }
                    }
                if(i==10) /*Szermierz6*/
                    {
                         if(PoraDnia==2)
                            {
                                x+=300;
                            }
                        else
                            {
                                x+=150;
                            }
                    }
                if(i==11) /*Szermierz7*/
                    {
                         if(PoraDnia==1||PoraDnia==2)
                            {
                                x+=400;
                            }
                        else
                            {
                                x+=200;
                            }
                    }
                if(i==12) /*Szermierz8*/
                    {
                         if(PoraDnia==1||PoraDnia==2)
                            {
                                x+=400;
                            }
                        else
                            {
                                x+=200;
                            }
                    }
                if(i==13) /*Szermierz9*/
                    {
                         if(PoraDnia==1)
                            {
                                x+=500;
                            }
                        else
                            {
                                x+=250;
                            }
                    }
                if(i==14) /*Szermierz10*/
                    {
                         if(PoraDnia==1)
                            {
                                x+=500;
                            }
                        else
                            {
                                x+=250;
                            }
                    }
                if(i==15) /*Lucznik1*/
                    {
                        if(PoraDnia==3)
                            {
                                x+=100;
                            }
                        else
                            {
                                x+=50;
                            }
                    }
                if(i==16) /*Lucznik2*/
                    {
                         if(PoraDnia==3)
                            {
                                x+=100;
                            }
                        else
                            {
                                x+=50;
                            }
                    }
                if(i==17) /*Lucznik3*/
                    {
                        if(PoraDnia==2||PoraDnia==3)
                            {
                                x+=100;
                            }
                        else
                            {
                                x+=50;
                            }
                    }
                if(i==18) /*Lucznik4*/
                    {
                         if(PoraDnia==2||PoraDnia==3)
                            {
                                x+=200;
                            }
                        else
                            {
                                x+=100;
                            }
                    }
                if(i==19) /*Lucznik5*/
                    {
                        if(PoraDnia==2)
                            {
                                x+=200;
                            }
                        else
                            {
                                x+=100;
                            }
                    }
                if(i==20) /*Lucznik6*/
                    {
                        if(PoraDnia==2)
                            {
                                x+=200;
                            }
                        else
                            {
                                x+=100;
                            }
                    }
                if(i==21) /*Lucznik7*/
                    {
                        if(PoraDnia==1||PoraDnia==2)
                            {
                                x+=300;
                            }
                        else
                            {
                                x+=150;
                            }
                    }
                if(i==22) /*Lucznik8*/
                    {
                        if(PoraDnia==1||PoraDnia==2)
                            {
                                x+=300;
                            }
                        else
                            {
                                x+=150;
                            }
                    }
                if(i==23) /*Lucznik9*/
                    {
                        if(PoraDnia==1)
                            {
                                x+=300;
                            }
                        else
                            {
                                x+=150;
                            }
                    }
                if(i==24) /*Lucznik10*/
                    {
                         if(PoraDnia==1)
                            {
                                x+=400;
                            }
                        else
                            {
                                x+=200;
                            }
                    }
                break;
            }
        case '2':
            {
                if(i==0)/*Bohater1*/
                    {
                        if(PoraDnia==1)
                            {
                                x+=300;
                            }
                        else
                            {
                                x+=150;
                            }
                    }
                if(i==1)/*Bohater2*/
                    {
                        if(PoraDnia==1||PoraDnia==2)
                            {
                                x+=400;
                            }
                        else
                            {
                                x+=200;
                            }
                    }
                if(i==2) /*Bohater3*/
                    {
                        if(PoraDnia==1||PoraDnia==2||PoraDnia==3)
                            {
                                x+=500;
                            }
                        else
                            {

                            }
                    }
                if(i==3) /*Bohater4*/
                    {
                        if(PoraDnia==2||PoraDnia==3)
                            {
                                x+=600;
                            }
                        else
                            {
                                x+=300;
                            }
                    }
                if(i==4)  /*Bohater5*/
                    {
                        if(PoraDnia==3)
                            {
                                x+=700;
                            }
                        else
                            {
                                x+=350;
                            }
                    }
                break;
            }
        case '3':
            {
                if(i==5)/*Szermierz1*/
                    {
                        if(PoraDnia==3)
                            {
                                x+=70;
                            }
                        else
                            {
                                x+=35;
                            }
                    }
                if(i==6)  /*Szermierz2*/
                    {
                        if(PoraDnia==3)
                            {
                                x+=70;
                            }
                        else
                            {
                                x+=35;
                            }
                    }
                if(i==7)  /*Szermierz3*/
                    {
                        if(PoraDnia==2||PoraDnia==3)
                            {
                                x+=140;
                            }
                        else
                            {
                                x+=70;
                            }
                    }
                if(i==8)  /*Szermierz4*/
                    {
                        if(PoraDnia==2||PoraDnia==3)
                            {
                                x+=140;
                            }
                        else
                            {
                                x+=70;
                            }
                    }
                if(i==9)  /*Szermierz5*/
                    {
                        if(PoraDnia==2)
                            {
                                x+=210;
                            }
                        else
                            {
                                x+=105;
                            }
                    }
                if(i==10) /*Szermierz6*/
                    {
                         if(PoraDnia==2)
                            {
                                x+=210;
                            }
                        else
                            {
                                x+=105;
                            }
                    }
                if(i==11) /*Szermierz7*/
                    {
                         if(PoraDnia==1||PoraDnia==2)
                            {
                                x+=280;
                            }
                        else
                            {
                                x+=140;
                            }
                    }
                if(i==12) /*Szermierz8*/
                    {
                         if(PoraDnia==1||PoraDnia==2)
                            {
                                x+=280;
                            }
                        else
                            {
                                x+=140;
                            }
                    }
                if(i==13) /*Szermierz9*/
                    {
                         if(PoraDnia==1)
                            {
                                x+=350;
                            }
                        else
                            {
                                x+=175;
                            }
                    }
                if(i==14) /*Szermierz10*/
                    {
                         if(PoraDnia==1)
                            {
                                x+=350;
                            }
                        else
                            {
                                x+=175;
                            }
                    }
                if(i==15) /*Lucznik1*/
                    {
                        if(PoraDnia==3)
                            {
                                x+=70;
                            }
                        else
                            {
                                x+=35;
                            }
                    }
                if(i==16) /*Lucznik2*/
                    {
                         if(PoraDnia==3)
                            {
                                x+=70;
                            }
                        else
                            {
                                x+=35;
                            }
                    }
                if(i==17) /*Lucznik3*/
                    {
                        if(PoraDnia==2||PoraDnia==3)
                            {
                                x+=70;
                            }
                        else
                            {
                                x+=35;
                            }
                    }
                if(i==18) /*Lucznik4*/
                    {
                         if(PoraDnia==2||PoraDnia==3)
                            {
                                x+=140;
                            }
                        else
                            {
                                x+=70;
                            }
                    }
                if(i==19) /*Lucznik5*/
                    {
                        if(PoraDnia==2)
                            {
                                x+=140;
                            }
                        else
                            {
                                x+=70;
                            }
                    }
                if(i==20) /*Lucznik6*/
                    {
                        if(PoraDnia==2)
                            {
                                x+=140;
                            }
                        else
                            {
                                x+=70;
                            }
                    }
                if(i==21) /*Lucznik7*/
                    {
                        if(PoraDnia==1||PoraDnia==2)
                            {
                                x+=210;
                            }
                        else
                            {
                                x+=105;
                            }
                    }
                if(i==22) /*Lucznik8*/
                    {
                        if(PoraDnia==1||PoraDnia==2)
                            {
                                x+=210;
                            }
                        else
                            {
                                x+=105;
                            }
                    }
                if(i==23) /*Lucznik9*/
                    {
                        if(PoraDnia==1)
                            {
                                x+=210;
                            }
                        else
                            {
                                x+=105;
                            }
                    }
                if(i==24) /*Lucznik10*/
                    {
                         if(PoraDnia==1)
                            {
                                x+=280;
                            }
                        else
                            {
                                x+=140;
                            }
                    }
                break;
            }
        case '0':
            {
                break;
            }
        }
    }
    return x;
}

int Grcz::PodsumToObro(std::string asd)
{
    int x=0;
    for(int i=0;i<30;i++)
    {
        switch(asd[i])
        {
        case '1':
            {
                if(i==0) x+=700;
                if(i==1) x+=600;
                if(i==2) x+=500;
                if(i==3) x+=400;
                if(i==4) x+=300;
                break;
            }
        case '2':
            {
                if(i==5) x+=500;
                if(i==6) x+=500;
                if(i==7) x+=400;
                if(i==8) x+=400;
                if(i==9) x+=300;
                if(i==10) x+=300;
                if(i==11) x+=200;
                if(i==12) x+=200;
                if(i==13) x+=100;
                if(i==14) x+=100;
                if(i==15) x+=500;
                if(i==16) x+=500;
                if(i==17) x+=500;
                if(i==18) x+=400;
                if(i==19) x+=400;
                if(i==20) x+=400;
                if(i==21) x+=300;
                if(i==22) x+=300;
                if(i==23) x+=300;
                if(i==24) x+=200;
                break;
            }
        case '4':
            {
                if(i==5) x+=350;
                if(i==6) x+=350;
                if(i==7) x+=280;
                if(i==8) x+=280;
                if(i==9) x+=210;
                if(i==10) x+=210;
                if(i==11) x+=140;
                if(i==12) x+=140;
                if(i==13) x+=70;
                if(i==14) x+=70;
                if(i==15) x+=350;
                if(i==16) x+=350;
                if(i==17) x+=350;
                if(i==18) x+=280;
                if(i==19) x+=280;
                if(i==20) x+=280;
                if(i==21) x+=210;
                if(i==22) x+=210;
                if(i==23) x+=210;
                if(i==24) x+=140;
                break;
            }
        case '0':
            {
                break;
            }
        }
    }
    return x;
}

int Grcz::PodsumToMora(std::string pds,char BufOd26)
{
    int x=0;

        if(BufOd26=='1')
        {
            for(int i=0;i<30;i++)
            {
                switch(pds[i])
                {
                case '1':
                    {
                    if(i==0) x+=60;
                    if(i==1) x+=55;
                    if(i==2) x+=50;
                    if(i==3) x+=45;
                    if(i==4) x+=40;
                    if(i==5) x+=2;
                    if(i==6) x+=2;
                    if(i==7) x+=4;
                    if(i==8) x+=4;
                    if(i==9) x+=6;
                    if(i==10) x+=6;
                    if(i==11) x+=8;
                    if(i==12) x+=8;
                    if(i==13) x+=10;
                    if(i==14) x+=10;
                    if(i==15) x+=4;
                    if(i==16) x+=4;
                    if(i==17) x+=4;
                    if(i==18) x+=6;
                    if(i==19) x+=6;
                    if(i==20) x+=6;
                    if(i==21) x+=8;
                    if(i==22) x+=8;
                    if(i==23) x+=8;
                    if(i==24) x+=10;
                    break;
                    }
                case '2':
                    {
                    if(i==5) x-=2;
                    if(i==6) x-=2;
                    if(i==7) x-=4;
                    if(i==8) x-=4;
                    if(i==9) x-=6;
                    if(i==10) x-=6;
                    if(i==11) x-=8;
                    if(i==12) x-=8;
                    if(i==13) x-=10;
                    if(i==14) x-=10;
                    if(i==15) x-=4;
                    if(i==16) x-=4;
                    if(i==17) x-=4;
                    if(i==18) x-=6;
                    if(i==19) x-=6;
                    if(i==20) x-=6;
                    if(i==21) x-=8;
                    if(i==22) x-=8;
                    if(i==23) x-=8;
                    if(i==24) x-=10;
                    break;
                    }
                case '3':
                    {
                    if(i==5) x-=4;
                    if(i==6) x-=4;
                    if(i==7) x-=8;
                    if(i==8) x-=8;
                    if(i==9) x-=12;
                    if(i==10) x-=12;
                    if(i==11) x-=16;
                    if(i==12) x-=16;
                    if(i==13) x-=20;
                    if(i==14) x-=20;
                    if(i==15) x-=8;
                    if(i==16) x-=8;
                    if(i==17) x-=8;
                    if(i==18) x-=12;
                    if(i==19) x-=12;
                    if(i==20) x-=12;
                    if(i==21) x-=16;
                    if(i==22) x-=16;
                    if(i==23) x-=16;
                    if(i==24) x-=20;
                    break;
                    }
                case '4':
                    {
                    if(i==5) x-=4;
                    if(i==6) x-=4;
                    if(i==7) x-=8;
                    if(i==8) x-=8;
                    if(i==9) x-=12;
                    if(i==10) x-=12;
                    if(i==11) x-=16;
                    if(i==12) x-=16;
                    if(i==13) x-=20;
                    if(i==14) x-=20;
                    if(i==15) x-=8;
                    if(i==16) x-=8;
                    if(i==17) x-=8;
                    if(i==18) x-=12;
                    if(i==19) x-=12;
                    if(i==20) x-=12;
                    if(i==21) x-=16;
                    if(i==22) x-=16;
                    if(i==23) x-=16;
                    if(i==24) x-=20;
                    break;
                    }
                case '0':
                    {
                break;
                    }
                }
            }
        }
        if(BufOd26=='2')
        {
            for(int i=0;i<30;i++)
            {
                switch(pds[i])
                {
                case '1':
                    {
                if(i==0) x+=60;
                if(i==1) x+=55;
                if(i==2) x+=50;
                if(i==3) x+=45;
                if(i==4) x+=40;
                if(i==5) x+=1;
                if(i==6) x+=1;
                if(i==7) x+=2;
                if(i==8) x+=2;
                if(i==9) x+=3;
                if(i==10) x+=3;
                if(i==11) x+=4;
                if(i==12) x+=4;
                if(i==13) x+=5;
                if(i==14) x+=5;
                if(i==15) x+=2;
                if(i==16) x+=2;
                if(i==17) x+=2;
                if(i==18) x+=3;
                if(i==19) x+=3;
                if(i==20) x+=3;
                if(i==21) x+=4;
                if(i==22) x+=4;
                if(i==23) x+=4;
                if(i==24) x+=5;
                break;
                    }
                case '2':
                    {
                if(i==5) x-=1;
                if(i==6) x-=1;
                if(i==7) x-=2;
                if(i==8) x-=2;
                if(i==9) x-=3;
                if(i==10) x-=3;
                if(i==11) x-=4;
                if(i==12) x-=4;
                if(i==13) x-=5;
                if(i==14) x-=5;
                if(i==15) x-=2;
                if(i==16) x-=2;
                if(i==17) x-=2;
                if(i==18) x-=3;
                if(i==19) x-=3;
                if(i==20) x-=3;
                if(i==21) x-=4;
                if(i==22) x-=4;
                if(i==23) x-=4;
                if(i==24) x-=5;
                break;
                    }
                case '3':
                    {
                if(i==5) x-=2;
                if(i==6) x-=2;
                if(i==7) x-=4;
                if(i==8) x-=4;
                if(i==9) x-=6;
                if(i==10) x-=6;
                if(i==11) x-=8;
                if(i==12) x-=8;
                if(i==13) x-=10;
                if(i==14) x-=10;
                if(i==15) x-=4;
                if(i==16) x-=4;
                if(i==17) x-=4;
                if(i==18) x-=6;
                if(i==19) x-=6;
                if(i==20) x-=6;
                if(i==21) x-=8;
                if(i==22) x-=8;
                if(i==23) x-=8;
                if(i==24) x-=10;
                break;
                    }
                case '4':
                    {
                if(i==5) x-=2;
                if(i==6) x-=2;
                if(i==7) x-=4;
                if(i==8) x-=4;
                if(i==9) x-=6;
                if(i==10) x-=6;
                if(i==11) x-=8;
                if(i==12) x-=8;
                if(i==13) x-=10;
                if(i==14) x-=10;
                if(i==15) x-=4;
                if(i==16) x-=4;
                if(i==17) x-=4;
                if(i==18) x-=6;
                if(i==19) x-=6;
                if(i==20) x-=6;
                if(i==21) x-=8;
                if(i==22) x-=8;
                if(i==23) x-=8;
                if(i==24) x-=10;
                break;
                    }
                case '0':
                    {
                break;
                    }
                }
            }
        }
        if(BufOd26=='3')
        {
            for(int i=0;i<30;i++)
            {
                switch(pds[i])
                {
                case '1':
                    {
                if(i==0) x+=60;
                if(i==1) x+=55;
                if(i==2) x+=50;
                if(i==3) x+=45;
                if(i==4) x+=40;
                if(i==5) x-=1;
                if(i==6) x-=1;
                if(i==7) x-=2;
                if(i==8) x-=2;
                if(i==9) x-=3;
                if(i==10) x-=3;
                if(i==11) x-=4;
                if(i==12) x-=4;
                if(i==13) x-=5;
                if(i==14) x-=5;
                if(i==15) x-=2;
                if(i==16) x-=2;
                if(i==17) x-=2;
                if(i==18) x-=3;
                if(i==19) x-=3;
                if(i==20) x-=3;
                if(i==21) x-=4;
                if(i==22) x-=4;
                if(i==23) x-=4;
                if(i==24) x-=5;
                break;
                    }
                case '2':
                    {
                if(i==5) x-=1;
                if(i==6) x-=1;
                if(i==7) x-=2;
                if(i==8) x-=2;
                if(i==9) x-=3;
                if(i==10) x-=3;
                if(i==11) x-=4;
                if(i==12) x-=4;
                if(i==13) x-=5;
                if(i==14) x-=5;
                if(i==15) x-=2;
                if(i==16) x-=2;
                if(i==17) x-=2;
                if(i==18) x-=3;
                if(i==19) x-=3;
                if(i==20) x-=3;
                if(i==21) x-=4;
                if(i==22) x-=4;
                if(i==23) x-=4;
                if(i==24) x-=5;
                break;
                    }
                case '3':
                    {
                if(i==5) x-=4;
                if(i==6) x-=4;
                if(i==7) x-=8;
                if(i==8) x-=8;
                if(i==9) x-=12;
                if(i==10) x-=12;
                if(i==11) x-=16;
                if(i==12) x-=16;
                if(i==13) x-=20;
                if(i==14) x-=20;
                if(i==15) x-=8;
                if(i==16) x-=8;
                if(i==17) x-=8;
                if(i==18) x-=12;
                if(i==19) x-=12;
                if(i==20) x-=12;
                if(i==21) x-=16;
                if(i==22) x-=16;
                if(i==23) x-=16;
                if(i==24) x-=20;
                break;
                    }
                case '4':
                    {
                if(i==5) x-=4;
                if(i==6) x-=4;
                if(i==7) x-=8;
                if(i==8) x-=8;
                if(i==9) x-=12;
                if(i==10) x-=12;
                if(i==11) x-=16;
                if(i==12) x-=16;
                if(i==13) x-=20;
                if(i==14) x-=20;
                if(i==15) x-=8;
                if(i==16) x-=8;
                if(i==17) x-=8;
                if(i==18) x-=12;
                if(i==19) x-=12;
                if(i==20) x-=12;
                if(i==21) x-=16;
                if(i==22) x-=16;
                if(i==23) x-=16;
                if(i==24) x-=20;
                break;
                    }
                case '0':
                    {
                break;
                    }
                }
            }
        }
        if(BufOd26=='4')
        {
            for(int i=0;i<30;i++)
            {
                switch(pds[i])
                {
                case '1':
                    {
                if(i==0) x+=60;
                if(i==1) x+=55;
                if(i==2) x+=50;
                if(i==3) x+=45;
                if(i==4) x+=40;
                if(i==5) x-=2;
                if(i==6) x-=2;
                if(i==7) x-=4;
                if(i==8) x-=4;
                if(i==9) x-=6;
                if(i==10) x-=6;
                if(i==11) x-=8;
                if(i==12) x-=8;
                if(i==13) x-=10;
                if(i==14) x-=10;
                if(i==15) x-=4;
                if(i==16) x-=4;
                if(i==17) x-=4;
                if(i==18) x-=6;
                if(i==19) x-=6;
                if(i==20) x-=6;
                if(i==21) x-=8;
                if(i==22) x-=8;
                if(i==23) x-=8;
                if(i==24) x-=10;
                break;
                    }
                case '2':
                    {
                if(i==5) x-=2;
                if(i==6) x-=2;
                if(i==7) x-=4;
                if(i==8) x-=4;
                if(i==9) x-=6;
                if(i==10) x-=6;
                if(i==11) x-=8;
                if(i==12) x-=8;
                if(i==13) x-=10;
                if(i==14) x-=10;
                if(i==15) x-=4;
                if(i==16) x-=4;
                if(i==17) x-=4;
                if(i==18) x-=6;
                if(i==19) x-=6;
                if(i==20) x-=6;
                if(i==21) x-=8;
                if(i==22) x-=8;
                if(i==23) x-=8;
                if(i==24) x-=10;
                break;
                    }
                case '3':
                    {
                if(i==5) x-=4;
                if(i==6) x-=4;
                if(i==7) x-=8;
                if(i==8) x-=8;
                if(i==9) x-=12;
                if(i==10) x-=12;
                if(i==11) x-=16;
                if(i==12) x-=16;
                if(i==13) x-=20;
                if(i==14) x-=20;
                if(i==15) x-=8;
                if(i==16) x-=8;
                if(i==17) x-=8;
                if(i==18) x-=12;
                if(i==19) x-=12;
                if(i==20) x-=12;
                if(i==21) x-=16;
                if(i==22) x-=16;
                if(i==23) x-=16;
                if(i==24) x-=20;
                break;
                    }
                case '4':
                    {
                if(i==5) x-=4;
                if(i==6) x-=4;
                if(i==7) x-=8;
                if(i==8) x-=8;
                if(i==9) x-=12;
                if(i==10) x-=12;
                if(i==11) x-=16;
                if(i==12) x-=16;
                if(i==13) x-=20;
                if(i==14) x-=20;
                if(i==15) x-=8;
                if(i==16) x-=8;
                if(i==17) x-=8;
                if(i==18) x-=12;
                if(i==19) x-=12;
                if(i==20) x-=12;
                if(i==21) x-=16;
                if(i==22) x-=16;
                if(i==23) x-=16;
                if(i==24) x-=20;
                break;
                    }
                case '0':
                    {
                break;
                    }
                }
            }
        }
    return x;
}

int Grcz::Ruch(std::string Pozycja,int xx, int x)
{
    switch(xx)
    {
        case 1:
            {
                if(Pozycja[x-1]==';'||x==0)
                    {
                        x+=9;
                    }
                else
                    {
                        x-=1;
                    }
                std::cout<<"lewo"<<std::endl;
                break;
            }
        case 2:
            {
                if(x<10)
                    {
                        //x+=66;
                        x+=(Pozycja.length()-12);
                    }
                else
                    {
                        x-=11;
                    }
                std::cout<<"gora"<<std::endl;
                break;
            }
        case 3:
            {
                if(Pozycja[x+1]==';')
                    {
                        x-=9;
                    }
                else
                    {
                        x+=1;
                    }
                std::cout<<"prawo"<<std::endl;
                break;
            }
        case 4:
            {
                if(x>66)
                    {
                        //x+=66;
                        x-=(Pozycja.length()-12);
                    }
                else
                    {
                        x+=11;
                    }
                std::cout<<"dol"<<std::endl;
                break;
            }
        default :
            {
                std::cout<<"blad"<<std::endl;
                break;
            }
    }
    return x;
}

int Grcz::IdToAkcja(int ID)
{
    ;
}

std::string Grcz::TaliaToPodsum(std::string pods,int id,int t)
{
    if(t==0)pods[id-1]='0';
    if(t==1)pods[id-1]='1';
    if(t==2)pods[id-1]='2';
    if(t==3)pods[id-1]='3';
    if(t==4)pods[id-1]='4';

    return pods;
}

Grcz::Grcz()
{
    int x,y,z;
    talia="";
    for(int i=0;i<31;i++)
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

Grcz::~Grcz()
{
    //std::cout<<"usunieto gracza"<<std::endl;
}
