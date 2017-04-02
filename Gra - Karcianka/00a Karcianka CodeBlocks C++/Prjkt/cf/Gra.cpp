#include <Gra.h>
#include <MenuGlowne.h>
#include <Plansza.h>
#include <Gracz.h>
#include <Karta.h>


void gra::krok()
{
    int opka=0,x=0;
    for(int i=1;i>0;i++)
    {
        switch(i)
        {
        case 0:
            {
                std::cout<<"Koniec programu"<<std::endl;
                i=-1;
                break;
            }
        case 1:
            {
                std::cout<<"Intro i reszta"<<std::endl;
                break;
            }
        case 2:
            {
                std::cout<<"Menu glowne"<<std::endl;
                megl MenuGl;
                i=MenuGl.OpcjeMenu();
                break;
            }
        case 3:
            {
                std::cout<<"Wybrano PVP 1v1"<<std::endl;
                srand(time(NULL));
                Grcz pierwszy;
                Grcz drugi;
                plansza PVP_1v1;
                PVP_1v1.zwyciestwo=0;
                karta karty;

                {//wstep
/*zerowanie atakow */
                    {
                        pierwszy.atak=0;
                        drugi.atak=0;
                    }
/*zerowanie kart*/
                    for(int j=0;j<12;j++)
                    {
                        PVP_1v1.Segment[j]="";
                    }

/*nadanie wartosci*/
                    for(int j=0;j<12;j++)
                        {
                            switch(j)
                            {
                            case 0:
                                {
                                    PVP_1v1.Segment[j]=pierwszy.talia;                  //talia gracza1
                                    break;
                                }
                            case 1:
                                {
                                    if(PVP_1v1.Segment[j]=="")                          //reka gracza1
                                        {
                                            for(int k=0;k<MaxReka;k++)
                                                {
                                                    PVP_1v1.Segment[j]+="000;";
                                                }
                                            break;
                                        }
                                    else
                                        break;
                                }
                            case 2:
                                {
                                    PVP_1v1.Segment[j]="";                              //zuzyte gracza1
                                    break;
                                }
                            case 3:
                                {
                                    std::cout<<"Gracz1, wybierz bohatera :"<<std::endl;
                                    PVP_1v1.WypiszIdToNazwa(PVP_1v1.Segment[j-3],1,6);     //bohater gracza1       do przerobienia(wybor bohatera)
                                    std::cin>>opka;
                                    while(opka!=5&&opka!=1&&opka!=2&&opka!=3&&opka!=4)
                                        {
                                            std::cout<<"zle jeszcze raz"<<std::endl;
                                            std::cin>>opka;
                                        }
                                    PVP_1v1.Segment[j]+="000;";
                                    PVP_1v1.Segment[j]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[j],1,opka);

                                    //PVP_1v1.Segment[j-3]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[j-3],opka+1,0);
                                    //PVP_1v1.Segment[j-3]=PVP_1v1.WywalKarte0(PVP_1v1.Segment[j-3],opka);
                                    break;
                                }
                            case 4:
                                {
                                    for(int k=0;k<MaxDoZagrania;k++)
                                        {
                                            PVP_1v1.Segment[j]+="000;";                     //zagrane gracza1       do przerobienia (4-na ograniczenie kart do zagrania)
                                        }
                                    break;
                                }
                            case 5:
                                {
                                    for(int k=0;k<MaxBuf;k++)
                                        {
                                            PVP_1v1.Segment[j]+="000;";                     //bufy gracza1          do przerobienia (2-na ograniczenie bofow)
                                        }
                                    break;
                                }
                            case 6:
                                {
                                    PVP_1v1.Segment[j]=drugi.talia;                     //talia gracza2
                                    break;
                                }
                            case 7:
                                {
                                    if(PVP_1v1.Segment[j]=="")
                                        {
                                            for(int k=0;k<MaxReka;k++)
                                                {
                                                    PVP_1v1.Segment[j]+="000;";         //reka gracza2
                                                }
                                            break;
                                        }
                                    else
                                        break;
                                }
                            case 8:
                                {
                                    PVP_1v1.Segment[j]="";                              //zuzyte gracza2
                                    break;
                                }
                            case 9:
                                {
                                    std::cout<<"Gracz2, wybierz bohatera :"<<std::endl;
                                    PVP_1v1.WypiszIdToNazwa(PVP_1v1.Segment[j-3],1,6);     //bohater gracza2       do przerobienia(wybor bohatera)
                                    std::cin>>opka;
                                    while(opka!=1&&opka!=2&&opka!=3&&opka!=4&&opka!=5)
                                        {
                                            std::cout<<"zle jeszcze raz"<<std::endl;
                                            std::cin>>opka;
                                        }
                                    PVP_1v1.Segment[j]+="000;";
                                    PVP_1v1.Segment[j]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[j],1,opka);

                                    PVP_1v1.Segment[j-3]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[j-3],opka+1,0);
                                    PVP_1v1.Segment[j-3]=PVP_1v1.WywalKarte0(PVP_1v1.Segment[j-3],opka);
                                    break;
                                }
                            case 10:
                                {
                                    for(int k=0;k<MaxDoZagrania;k++)
                                        {
                                        PVP_1v1.Segment[j]+="000;";                     //zagrane gracza2       do przerobienia (4-na ograniczenie kart do zagrania)
                                        }
                                    break;
                                }
                            case 11:
                                {
                                    for(int k=0;k<MaxBuf;k++)
                                        {
                                            PVP_1v1.Segment[j]+="000;";                     //bufy gracza2          do przerobienia (2-na ograniczenie bofow)
                                        }
                                    break;
                                }
                            }
                        }

/*losowanie reki dla gracza1*/
                    for(int k=0,g=0;k<MaxReka;)
                        {
                            g=(std::rand()%25)+6;
                            for(int kk=0;kk<MaxReka;kk++)
                                {
                                    if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[1],kk)==g)
                                        {
                                            kk=MaxReka;
                                        }
                                    else
                                        {
                                            if(kk==MaxReka-1)
                                                {
                                                    PVP_1v1.Segment[1]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[1],k+1,g);

                                                    PVP_1v1.Segment[0]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[0],g-k,0);
                                                    //PVP_1v1.Segment[0]=PVP_1v1.WywalKarte0(PVP_1v1.Segment[0],g-(k));

                                                    k++;
                                                }
                                        }

                                }
                        }
                    PVP_1v1.WypiszIdToNazwa(PVP_1v1.Segment[1],0,PVP_1v1.IleKart(PVP_1v1.Segment[1]));
                    //std::cout<<PVP_1v1.Segment[0]<<std::endl;

/*losowanie reki dla gracza2*/
                    for(int k=0,g=0;k<MaxReka;)
                        {
                            g=(std::rand()%25)+6;
                            for(int kk=0;kk<MaxReka;kk++)
                                {
                                    if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[7],kk)==g)
                                        {
                                            kk=MaxReka;
                                        }
                                    else
                                        {
                                            if(kk==MaxReka-1)
                                                {
                                                    PVP_1v1.Segment[7]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[7],k+1,g);
                                                    k++;
                                                }
                                        }
                                }
                        }

/*Ukladanie rak graczy*/
                    {
                        opka=0,x=PVP_1v1.IleKart(PVP_1v1.Segment[1]);
                        PVP_1v1.Segment[1]=PVP_1v1.SortTalia(PVP_1v1.Segment[1],opka,x);
                        PVP_1v1.WypiszIdToNazwa(PVP_1v1.Segment[1],0,PVP_1v1.IleKart(PVP_1v1.Segment[1]));

                        //opka=0,x=PVP_1v1.IleKart(PVP_1v1.Segment[7]);
                        //PVP_1v1.Segment[7]=PVP_1v1.SortTalia(PVP_1v1.Segment[7],opka,x);
                    }


/*stworzenie podsumowania string*/
                    {
                        pierwszy.podsumowanie="000000000000000000000000000000";
                        pierwszy.podsumowanie=pierwszy.TaliaToPodsum(pierwszy.podsumowanie,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[3],0),1);
                        drugi.podsumowanie="000000000000000000000000000000";
                        drugi.podsumowanie=drugi.TaliaToPodsum(drugi.podsumowanie,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[9],0),1);
                    }
                }
/*RUNDA*/       for(int runda=(rand()&3)+1,r=1;r<IleRundMax+1;runda++,r++)
                    {
                        if(runda==4)runda=1;
                        switch(runda)
                        {
                            case 1:
                                {
                                    std::cout<<"Runda "<<r<<", pora dnia"<<std::endl;
                                    break;
                                }
                            case 2:
                                {
                                    std::cout<<"Runda "<<r<<", pora zachodu"<<std::endl;
                                    break;
                                }
                            case 3:
                                {
                                    std::cout<<"Runda "<<r<<", pora nocy"<<std::endl;
                                    break;
                                }
                        }
                        //std::cout<<"Runda "<<runda+1<<std::endl;
/*MIEDZY RUNDAMI*/      if(runda>1)
                            {
/*zerowanie z i b dla 1 i 2*/
                                {
/*Zagrane>odrzucone*/               {
/*Zagrane>odrzucone 1*/                 for(int j=0;j<MaxDoZagrania;j++)
                                            {
                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],j)!=0)
                                                {
                                                    PVP_1v1.Segment[2]+="000;";
                                                    PVP_1v1.Segment[2]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[2],PVP_1v1.IleKart(PVP_1v1.Segment[2]),PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],j));
                                                }
                                            }
/*Zagrane>odrzucone 2*/                 for(int j=0;j<MaxDoZagrania;j++)
                                            {
                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],j)!=0)
                                                {
                                                    PVP_1v1.Segment[8]+="000;";
                                                    PVP_1v1.Segment[8]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[8],PVP_1v1.IleKart(PVP_1v1.Segment[8]),PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],j));
                                                }
                                            }
                                    }
/*Bufy>odrzucone*/                  {
/*Bufy>odrzucone 1*/                    for(int j=0;j<MaxBuf;j++)
                                            {
                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[5],j)!=0)
                                                {
                                                    PVP_1v1.Segment[2]+="000;";
                                                    PVP_1v1.Segment[2]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[2],PVP_1v1.IleKart(PVP_1v1.Segment[2]),PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[5],j));
                                                }
                                            }
/*Bufy>odrzucone 2*/                    for(int j=0;j<MaxBuf;j++)
                                            {
                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[11],j)!=0)
                                                {
                                                    PVP_1v1.Segment[8]+="000;";
                                                    PVP_1v1.Segment[8]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[8],PVP_1v1.IleKart(PVP_1v1.Segment[8]),PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[11],j));
                                                }
                                            }
                                    }
/*Zagrane=0000*/                    for(int j=1;j<MaxDoZagrania+1;j++)
                                        {
                                            PVP_1v1.Segment[4]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[4],j,0);
                                            PVP_1v1.Segment[10]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[10],j,0);
                                        }
/*Bufy=0000*/                       for(int j=1;j<MaxBuf+1;j++)
                                        {
                                            PVP_1v1.Segment[5]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[5],j,0);
                                            PVP_1v1.Segment[11]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[11],j,0);
                                        }
                                }
/*zerowanie atakow*/            {
                                    pierwszy.atak=0;drugi.atak=0;
                                }
/*zerowanie podsumowan*/        {
                                    pierwszy.podsumowanie="000000000000000000000000000000";
                                    pierwszy.podsumowanie=pierwszy.TaliaToPodsum(pierwszy.podsumowanie,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[3],0),1);
                                    drugi.podsumowanie="000000000000000000000000000000";
                                    drugi.podsumowanie=drugi.TaliaToPodsum(drugi.podsumowanie,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[9],0),1);
                                }
/*Przystosowanie zmiennych*/    {
                                    opka=0,x=0;
                                }
                            }
/*PRZEBIEG*/                for(int pas1=0,pas2=0,ao=0,ZiB1=0,ZiB2=0;pas1!=1||pas2!=1;)
                                {
/*ogranicznik gracza1*/
                                    {
                                        for(int ii=0,jj=0;ii<MaxDoZagrania;ii++)
                                            {
                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],ii)!=0)
                                                    {
                                                        jj++;
                                                    }
                                                if(jj==MaxDoZagrania)
                                                    {
                                                        if(ZiB1==12){;}
                                                        if(ZiB1==2) {ZiB1=12;}
                                                        if(ZiB1==1) {;}
                                                        if(ZiB1==0) {ZiB1=1;}
                                                    }
                                            }
                                        for(int ii=0,jj=0;ii<MaxBuf;ii++)
                                            {
                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[5],ii)!=0)
                                                    {
                                                        jj++;
                                                    }
                                                if(jj==MaxBuf)
                                                    {
                                                        if(ZiB1==12){;}
                                                        if(ZiB1==2){;}
                                                        if(ZiB1==1) {ZiB1=12;}
                                                        if(ZiB1==0) {ZiB1=2;}
                                                    }
                                            }
                                    }
/*ogranicznik gracza2*/
                                    {
                                        for(int ii=0,jj=0;ii<MaxDoZagrania;ii++)
                                            {
                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],ii)!=0)
                                                    {
                                                        jj++;
                                                    }
                                                if(jj==MaxDoZagrania)
                                                    {
                                                        if(ZiB2==12){;}
                                                        if(ZiB2==2) {ZiB2=12;}
                                                        if(ZiB2==1) {;}
                                                        if(ZiB2==0) {ZiB2=1;}
                                                    }
                                            }
                                        for(int ii=0,jj=0;ii<MaxBuf;ii++)
                                            {
                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[11],ii)!=0)
                                                    {
                                                        jj++;
                                                    }
                                                if(jj==MaxBuf)
                                                    {
                                                        if(ZiB2==12){;}
                                                        if(ZiB2==2){;}
                                                        if(ZiB2==1) {ZiB2=12;}
                                                        if(ZiB2==0) {ZiB2=2;}
                                                    }
                                            }
                                    }

/*ruch gracza 1*/                   if(pas1==0)
                                        {
                                            for(int gr1=0;gr1<1;)
                                                {
/*Rysowanie planszy*/                               {
/*atak1*/                                               pierwszy.atak=pierwszy.PodsumToAtak(pierwszy.podsumowanie,runda);
/*obrona1*/                                             pierwszy.obrona=pierwszy.PodsumToObro(pierwszy.podsumowanie);
/*morale1*/                                             {
                                                            if(pierwszy.podsumowanie[25]=='1')
                                                                {
                                                                    if(drugi.podsumowanie[27]=='1')
                                                                        {
/*Buf1.p + Buf3.d*/                                                         pierwszy.morale=pierwszy.PodsumToMora(pierwszy.podsumowanie,'4');
                                                                        }
                                                                    else
                                                                        {
/*Buf1.p*/                                                                  pierwszy.morale=pierwszy.PodsumToMora(pierwszy.podsumowanie,'1');
                                                                        }
                                                                }
                                                            else
                                                                {
                                                                    if(drugi.podsumowanie[27]=='1')
                                                                        {
/*Buf3.d*/                                                                  pierwszy.morale=pierwszy.PodsumToMora(pierwszy.podsumowanie,'3');
                                                                        }
                                                                    else
                                                                        {
/*nic nie zagrane*/                                                         pierwszy.morale=pierwszy.PodsumToMora(pierwszy.podsumowanie,'2');
                                                                        }
                                                                }
                                                        }
                                                        PVP_1v1.narysuj(PVP_1v1.Segment,1,2,0,pierwszy.atak,pierwszy.obrona,pierwszy.morale,"GRACZ1");
                                                    }
                                                    opka=0;
                                                    x=0;
/*Zabezpieczenie przed zagraniem*/                  {
                                                        std::cout<<"\tCo robisz ?\n1)pas\n2)zagraj karte\n3)zmien funcje zagranej karty"<<std::endl;
                                                        for(;x<1;)
                                                            {
                                                                std::cin>>opka;
                                                                {
/*pas*/                                                             {
                                                                        if(opka==1)
                                                                            {
                                                                                x=1;
                                                                            }
                                                                    }
/*zagraj*/                                                          {

                                                                        if(PVP_1v1.IleKart(PVP_1v1.Segment[1])==0)
                                                                            {
                                                                                if(opka==2)
                                                                                    {
                                                                                        x=0;std::cout<<"nie masz kart"<<std::endl;
                                                                                    }
                                                                                else
                                                                                    {
                                                                                        x=1;
                                                                                    }
                                                                            }
                                                                        else
                                                                        {
                                                                            if(ZiB1==12&&opka==2)
                                                                                {
                                                                                    x=0;std::cout<<"Zagrales maksymalna ilosc kart"<<std::endl;
                                                                                }
                                                                            if(ZiB1==2&&opka==2)
                                                                                {
                                                                                    if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[1],0)>25)
                                                                                        {
                                                                                            x=0;std::cout<<"nie ma kart ktore mozesz zagrac"<<std::endl;
                                                                                        }
                                                                                    else
                                                                                        {
                                                                                            x=1;
                                                                                        }
                                                                                }
                                                                            if(ZiB1==1&&opka==2)
                                                                                {
                                                                                    if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[1],PVP_1v1.IleKart(PVP_1v1.Segment[1])-1)<26)
                                                                                        {
                                                                                            x=0;std::cout<<"nie ma kart ktore mozesz zagrac"<<std::endl;
                                                                                        }
                                                                                    else
                                                                                        {
                                                                                            x=1;
                                                                                        }
                                                                                }
                                                                            if(ZiB1==0)
                                                                                {
                                                                                    x=1;
                                                                                }
                                                                        }
                                                                    }
/*zmiana*/                                                          {
                                                                        if(opka==3)
                                                                            {
                                                                                for(int ii=0,jj=0;ii<MaxDoZagrania;ii++)
                                                                                    {
                                                                                        if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],ii)!=0)
                                                                                            {
                                                                                                jj++;
                                                                                                if(pierwszy.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],ii)-1]=='3'||pierwszy.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],ii)-1]=='4')
                                                                                                    {
                                                                                                        jj--;
                                                                                                    }
                                                                                            }
                                                                                        if(ii==MaxDoZagrania-1)
                                                                                            {
                                                                                                if(jj==0)
                                                                                                    {
                                                                                                        x=0;std::cout<<"nie ma mozliwosci zmiany funkcji kart"<<std::endl;
                                                                                                    }
                                                                                                else
                                                                                                    {
                                                                                                        x=1;
                                                                                                    }
                                                                                            }
                                                                                    }
                                                                            }
                                                                    }
                                                                }
                                                            }
                                                    }
                                                    switch(opka)
                                                    {
                                                        case 1:
                                                            {
                                                                gr1=1;
                                                                pas1=1;
                                                                break;
                                                            }
                                                        case 2:
                                                            {
/*wypisanie reki*/                                              {
                                                                    std::cout<<"ktora?"<<std::endl;
                                                                    std::cout<<"twoja reka, to : "<<std::endl;
                                                                    PVP_1v1.WypiszIdToNazwa(PVP_1v1.Segment[1],0,PVP_1v1.IleKart(PVP_1v1.Segment[1]));
                                                                }
                                                                x=0;
/*wybranie reki*/                                               {
/*zabezpieczenie*/                                                  for(int h=0;h==0;)
                                                                        {
                                                                            std::cin>>x;
                                                                            if(ZiB1==1&&PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[1],x)<26)
                                                                                {
                                                                                    std::cout<<"tej karty nie mozna juz zagrac"<<std::endl;
                                                                                    h=0;
                                                                                }
                                                                            else
                                                                                {
                                                                                    if(ZiB1==2&&PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[1],x)>=26)
                                                                                        {
                                                                                            std::cout<<"tej karty nie mozna juz zagrac"<<std::endl;
                                                                                            h=0;
                                                                                        }
                                                                                    else
                                                                                        {
                                                                                            h=1;
                                                                                        }
                                                                                }
                                                                        }
                                                                    std::cout<<"wybrales "<<PVP_1v1.IdToNazwaString(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[1],x))<<std::endl;
                                                                }
                                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[1],x)>25)
/*wykladanie karty na bufy*/                                        {
                                                                        for(int c=0;c<MaxBuf;c++)
                                                                            {
                                                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[5],c)==0)
                                                                                    {
                                                                                        PVP_1v1.Segment[5]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[5],c+1,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[1],x));
                                                                                        PVP_1v1.Segment[1]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[1],x+1,0);
                                                                                        pierwszy.podsumowanie=pierwszy.TaliaToPodsum(pierwszy.podsumowanie,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[5],c),1);
                                                                                        gr1=1;
                                                                                        c=MaxBuf;
                                                                                        PVP_1v1.Segment[1]=PVP_1v1.WywalKarte0(PVP_1v1.Segment[1],x);
                                                                                    }
                                                                                if(pierwszy.podsumowanie[28]=='1')
                                                                                    {
                                                                                        opka=0;
                                                                                        for(int v=0,vv=PVP_1v1.IleKart(PVP_1v1.Segment[10]);v<vv;v++)
                                                                                            {
                                                                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],v)!=0){opka++;}
                                                                                            }
                                                                                        if(opka!=0)
                                                                                            {
                                                                                                PVP_1v1.Segment[8]+="000;";
                                                                                                while(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],opka)==0)opka=(std::rand()%PVP_1v1.IleKart(PVP_1v1.Segment[10]))+0;
                                                                                                PVP_1v1.Segment[8]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[8],PVP_1v1.IleKart(PVP_1v1.Segment[8]),PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],opka));
                                                                                                PVP_1v1.Segment[10]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[10],opka+1,0);
                                                                                                opka=0;
                                                                                                pierwszy.podsumowanie[28]=='3';
                                                                                            }
                                                                                        else
                                                                                            {
                                                                                                pierwszy.podsumowanie[28]=='3';
                                                                                            }
                                                                                        opka=2;
                                                                                    }
                                                                                if(pierwszy.podsumowanie[29]=='1')
                                                                                    {
                                                                                        for(int v=0,vv=PVP_1v1.IleKart(PVP_1v1.Segment[5]);v<vv;v++)
                                                                                            {
                                                                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[11],v)!=0)
                                                                                                    {
                                                                                                        PVP_1v1.Segment[8]+="000;";
                                                                                                        PVP_1v1.Segment[8]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[8],PVP_1v1.IleKart(PVP_1v1.Segment[8]),PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[11],v));
                                                                                                        PVP_1v1.Segment[11]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[11],v+1,0);
                                                                                                        {
                                                                                                            drugi.podsumowanie[25]='0';drugi.podsumowanie[26]='0';drugi.podsumowanie[27]='0';drugi.podsumowanie[28]='0';drugi.podsumowanie[29]='0';
                                                                                                        }
                                                                                                    }
                                                                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[5],v)!=0)
                                                                                                    {
                                                                                                        PVP_1v1.Segment[2]+="000;";
                                                                                                        PVP_1v1.Segment[2]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[2],PVP_1v1.IleKart(PVP_1v1.Segment[2]),PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[5],v));
                                                                                                        PVP_1v1.Segment[5]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[5],v+1,0);
                                                                                                        {
                                                                                                            pierwszy.podsumowanie[25]='0';pierwszy.podsumowanie[26]='0';pierwszy.podsumowanie[27]='0';pierwszy.podsumowanie[28]='0';pierwszy.podsumowanie[29]='0';
                                                                                                        }
                                                                                                    }
                                                                                            }
                                                                                        pierwszy.podsumowanie[29]=='3';
                                                                                    }

                                                                            }
                                                                        break;
                                                                    }
                                                                else
/*jak zagrac*/                                                      {
                                                                        std::cout<<"jak chcesz ja zagrac?\n\t1)atak\n\t2)obrona"<<std::endl;
                                                                        ao=0;
                                                                        while(ao!=1&&ao!=2)
                                                                            {
                                                                                std::cin>>ao;
                                                                            }
                                                                        switch(ao)
                                                                        {
/*wykladanie karty na atak*/                                                case 1:
                                                                                {
                                                                                    for(int c=0;c<MaxDoZagrania;c++)
                                                                                        {
                                                                                            if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],c)==0)
                                                                                                {
                                                                                                    PVP_1v1.Segment[4]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[4],c+1,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[1],x));
                                                                                                    PVP_1v1.Segment[1]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[1],x+1,0);
                                                                                                    pierwszy.podsumowanie=pierwszy.TaliaToPodsum(pierwszy.podsumowanie,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],c),1);
                                                                                                }
                                                                                        }
                                                                                    PVP_1v1.Segment[1]=PVP_1v1.WywalKarte0(PVP_1v1.Segment[1],x);
                                                                                    break;
                                                                                }
/*wykladanie karty na obrone*/                                              case 2:
                                                                                {
                                                                                    for(int c=0;c<MaxDoZagrania;c++)
                                                                                        {
                                                                                            if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],c)==0)
                                                                                                {
                                                                                                    PVP_1v1.Segment[4]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[4],c+1,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[1],x));
                                                                                                    PVP_1v1.Segment[1]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[1],x+1,0);
                                                                                                    pierwszy.podsumowanie=pierwszy.TaliaToPodsum(pierwszy.podsumowanie,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],c),2);
                                                                                                }
                                                                                        }
                                                                                    PVP_1v1.Segment[1]=PVP_1v1.WywalKarte0(PVP_1v1.Segment[1],x);
                                                                                    break;
                                                                                }
                                                                        }
                                                                    }
                                                                gr1=1;
                                                                break;
                                                            }
/*zmiana finkcji karty*/                                case 3:
                                                            {
                                                                std::cout<<"ktora karte chcesz edytowac ?"<<std::endl;
                                                                PVP_1v1.WypiszIdToNazwa(PVP_1v1.Segment[4],0,PVP_1v1.IleKart(PVP_1v1.Segment[4]));
                                                                std::cin>>x;
                                                                while(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],x)==0||pierwszy.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],x)]=='3'||pierwszy.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],x)]=='4')
                                                                    {
                                                                        std::cout<<"nie mozna edytowac tej karty"<<std::endl;
                                                                        std::cin>>x;
                                                                    }
                                                                if(pierwszy.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],x)-1]=='1')
                                                                    {
                                                                        if(pierwszy.podsumowanie[26]=='1')
                                                                            {
                                                                                pierwszy.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],x)-1]='2';
                                                                            }
                                                                        else
                                                                            {
                                                                                pierwszy.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],x)-1]='3';
                                                                            }
                                                                        gr1=1;
                                                                    }
                                                                else
                                                                    {
                                                                        if(pierwszy.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],x)-1]=='3')
                                                                            {
                                                                                std::cout<<"juz edytowales ta karte"<<std::endl;
                                                                            }
                                                                        else
                                                                            {
                                                                                if(pierwszy.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],x)-1]=='2')
                                                                                    {
                                                                                        if(pierwszy.podsumowanie[26]=='1')
                                                                                            {
                                                                                                pierwszy.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],x)-1]='1';
                                                                                            }
                                                                                        else
                                                                                            {
                                                                                                pierwszy.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],x)-1]='4';
                                                                                            }
                                                                                        gr1=1;
                                                                                    }
                                                                                else
                                                                                    {
                                                                                        if(pierwszy.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],x)-1]=='4')
                                                                                            {
                                                                                                std::cout<<"juz edytowales ta karte"<<std::endl;
                                                                                            }
                                                                                    }
                                                                            }
                                                                    }
                                                                break;
                                                            }
                                                        default :
                                                            {
                                                                std::cout<<"nieladnie, jeszcze raz "<<std::endl;
                                                                break;
                                                            }
                                                    }
                                                }
                                            if(runda==4)runda=1;
                                        }
/*ruch gracza 2*/                   if(pas2==0)
                                        {
                                            for(int gr2=0;gr2<1;)
                                                {
/*Rysowanie planszy*/                               {
/*atak2*/                                               drugi.atak=drugi.PodsumToAtak(drugi.podsumowanie,runda);
/*obrona2*/                                             drugi.obrona=drugi.PodsumToObro(drugi.podsumowanie);
/*morale2*/                                             {
                                                            if(drugi.podsumowanie[25]=='1')
                                                                {
                                                                    if(pierwszy.podsumowanie[27]=='1')
                                                                        {
                                                                            drugi.morale=drugi.PodsumToMora(drugi.podsumowanie,'4');
                                                                        }
                                                                    else
                                                                        {
                                                                            drugi.morale=drugi.PodsumToMora(drugi.podsumowanie,'1');
                                                                        }
                                                                }
                                                            else
                                                                {
                                                                    if(pierwszy.podsumowanie[27]=='1')
                                                                        {
                                                                            drugi.morale=drugi.PodsumToMora(drugi.podsumowanie,'3');
                                                                        }
                                                                    else
                                                                        {
                                                                            drugi.morale=drugi.PodsumToMora(drugi.podsumowanie,'2');
                                                                        }
                                                                }
                                                        }
                                                        PVP_1v1.narysuj(PVP_1v1.Segment,1,2,1,drugi.atak,drugi.obrona,drugi.morale,"GRACZ2");
                                                    }
                                                    opka=0;
                                                    x=0;
/*Zabezpieczenie przed zagraniem*/                  {
                                                        std::cout<<"\tCo robisz ?\n1)pas\n2)zagraj karte\n3)zmien funcje zagranej karty"<<std::endl;
                                                        for(int u=0;x<1;)
                                                            {
                                                                std::cin>>opka;
                                                                {
/*pas*/                                                             {
                                                                        if(opka==1)
                                                                            {
                                                                                x=1;
                                                                            }
                                                                    }
/*zagraj*/                                                          {

                                                                        if(PVP_1v1.IleKart(PVP_1v1.Segment[7])==0)
                                                                            {
                                                                                if(opka==2)
                                                                                    {
                                                                                        x=0;std::cout<<"nie masz kart"<<std::endl;
                                                                                    }
                                                                                else
                                                                                    {
                                                                                        x=1;
                                                                                    }
                                                                            }
                                                                        else
                                                                        {
                                                                            if(ZiB2==12&&opka==2)
                                                                                {
                                                                                    x=0;std::cout<<"Zagrales maksymalna ilosc kart"<<std::endl;
                                                                                }
                                                                            if(ZiB2==2&&opka==2)
                                                                                {
                                                                                    if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[7],0)>25)
                                                                                        {
                                                                                            x=0;std::cout<<"nie ma kart ktore mozesz zagrac"<<std::endl;
                                                                                        }
                                                                                    else
                                                                                        {
                                                                                            x=1;
                                                                                        }
                                                                                }
                                                                            if(ZiB2==1&&opka==2)
                                                                                {
                                                                                    if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[7],PVP_1v1.IleKart(PVP_1v1.Segment[7])-1)<26)
                                                                                        {
                                                                                            x=0;std::cout<<"nie ma kart ktore mozesz zagrac"<<std::endl;
                                                                                        }
                                                                                    else
                                                                                        {
                                                                                            x=1;
                                                                                        }
                                                                                }
                                                                            if(ZiB2==0)
                                                                                {
                                                                                    x=1;
                                                                                }
                                                                        }
                                                                    }
/*zmiana*/                                                          {
                                                                        if(opka==3)
                                                                            {
                                                                                for(int ii=0,jj=0;ii<MaxDoZagrania;ii++)
                                                                                    {
                                                                                        if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],ii)!=0)
                                                                                            {
                                                                                                jj++;
                                                                                                if(drugi.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],ii)-1]=='3'||drugi.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],ii)-1]=='4')
                                                                                                    {
                                                                                                        jj--;
                                                                                                    }
                                                                                            }
                                                                                        if(ii==MaxDoZagrania-1)
                                                                                            {
                                                                                                if(jj==0)
                                                                                                    {
                                                                                                        x=0;std::cout<<"nie ma mozliwosci zmiany funkcji kart"<<std::endl;
                                                                                                    }
                                                                                                else
                                                                                                    {
                                                                                                        x=1;
                                                                                                    }
                                                                                            }
                                                                                    }
                                                                            }
                                                                    }
                                                                }
                                                            }
                                                    }
                                                    switch(opka)
                                                    {
                                                        case 1:
                                                            {
                                                                gr2=1;
                                                                pas2=1;
                                                                break;
                                                            }
                                                        case 2:
                                                            {
/*wypisanie reki*/                                              {
                                                                    std::cout<<"ktora?"<<std::endl;
                                                                    std::cout<<"twoja reka, to : "<<std::endl;
                                                                    PVP_1v1.WypiszIdToNazwa(PVP_1v1.Segment[7],0,PVP_1v1.IleKart(PVP_1v1.Segment[7]));
                                                                }
                                                                x=0;
/*wybranie reki*/                                               {
/*zabezpieczenie*/                                                  for(int h=0;h==0;)
                                                                        {
                                                                            std::cin>>x;
                                                                            if(ZiB2==1&&PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[7],x)<26)
                                                                                {
                                                                                    std::cout<<"tej karty nie mozna juz zagrac"<<std::endl;
                                                                                    h=0;
                                                                                }
                                                                            else
                                                                                {
                                                                                    if(ZiB2==2&&PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[7],x)>=26)
                                                                                        {
                                                                                            std::cout<<"tej karty nie mozna juz zagrac"<<std::endl;
                                                                                            h=0;
                                                                                        }
                                                                                    else
                                                                                        {
                                                                                            h=1;
                                                                                        }
                                                                                }
                                                                        }
                                                                    std::cout<<"wybrales "<<PVP_1v1.IdToNazwaString(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[7],x))<<std::endl;
                                                                }
                                                                if((PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[7],x))>25)
/*wykladanie karty na bufy*/                                        {
                                                                        for(int c=0;c<MaxBuf;c++)
                                                                            {
                                                                                if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[11],c)==0)
                                                                                    {
                                                                                        PVP_1v1.Segment[11]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[11],c+1,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[7],x));
                                                                                        PVP_1v1.Segment[7]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[7],x+1,0);
                                                                                        drugi.podsumowanie=drugi.TaliaToPodsum(drugi.podsumowanie,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[11],c),1);
                                                                                        gr2=1;
                                                                                        c=MaxBuf;
                                                                                        PVP_1v1.Segment[7]=PVP_1v1.WywalKarte0(PVP_1v1.Segment[7],x);
                                                                                    }
                                                                            }
                                                                        if(drugi.podsumowanie[28]=='1')
                                                                           {
                                                                               opka=0;
                                                                               for(int v=0,vv=PVP_1v1.IleKart(PVP_1v1.Segment[4]);v<vv;v++)
                                                                                    {
                                                                                        if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],v)!=0){opka++;}
                                                                                    }
                                                                                if(opka!=0)
                                                                                    {
                                                                                        PVP_1v1.Segment[2]+="000;";
                                                                                        while(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],opka)==0)opka=(std::rand()%PVP_1v1.IleKart(PVP_1v1.Segment[4]))+0;
                                                                                        PVP_1v1.Segment[2]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[2],PVP_1v1.IleKart(PVP_1v1.Segment[2]),PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[4],opka));
                                                                                        PVP_1v1.Segment[4]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[4],opka+1,0);
                                                                                        opka=0;
                                                                                        drugi.podsumowanie[28]='3';
                                                                                    }
                                                                                else
                                                                                    {
                                                                                        drugi.podsumowanie[28]='3';
                                                                                    }
                                                                                opka=2;
                                                                           }
                                                                        if(drugi.podsumowanie[29]=='1')
                                                                            {
                                                                                for(int v=0,cc=PVP_1v1.IleKart(PVP_1v1.Segment[11]);v<cc;v++)
                                                                                {
                                                                                    if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[11],v)!=0)
                                                                                        {
                                                                                            PVP_1v1.Segment[8]+="000;";
                                                                                            PVP_1v1.Segment[8]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[8],PVP_1v1.IleKart(PVP_1v1.Segment[8]),PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[11],v));
                                                                                            PVP_1v1.Segment[11]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[11],v+1,0);
                                                                                            {
                                                                                                drugi.podsumowanie[25]='0';drugi.podsumowanie[26]='0';drugi.podsumowanie[27]='0';drugi.podsumowanie[28]='0';drugi.podsumowanie[29]='0';
                                                                                            }
                                                                                        }

                                                                                        if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[5],v)!=0)
                                                                                        {
                                                                                            PVP_1v1.Segment[2]+="000;";
                                                                                            PVP_1v1.Segment[2]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[2],PVP_1v1.IleKart(PVP_1v1.Segment[2]),PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[5],v));
                                                                                            PVP_1v1.Segment[5]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[5],v+1,0);
                                                                                            {
                                                                                                pierwszy.podsumowanie[25]='0';pierwszy.podsumowanie[26]='0';pierwszy.podsumowanie[27]='0';pierwszy.podsumowanie[28]='0';pierwszy.podsumowanie[29]='0';
                                                                                            }
                                                                                        }
                                                                                }
                                                                                drugi.podsumowanie[29]=='3';
                                                                            }
                                                                        break;
                                                                    }
                                                                else
/*jak zagrac*/                                                      {
                                                                        std::cout<<"jak chcesz ja zagrac?\n\t1)atak\n\t2)obrona"<<std::endl;
                                                                        ao=0;
                                                                        while(ao!=1&&ao!=2)
                                                                            {
                                                                                std::cin>>ao;
                                                                            }
                                                                        switch(ao)
                                                                        {
/*wykladanie karty na atak*/                                                case 1:
                                                                                {
                                                                                    for(int c=0;c<MaxDoZagrania;c++)
                                                                                    {
                                                                                        if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],c)==0)
                                                                                            {
                                                                                                PVP_1v1.Segment[10]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[10],c+1,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[7],x));
                                                                                                PVP_1v1.Segment[7]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[7],x+1,0);
                                                                                                drugi.podsumowanie=drugi.TaliaToPodsum(drugi.podsumowanie,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],c),1);
                                                                                            }
                                                                                    }
                                                                                    PVP_1v1.Segment[7]=PVP_1v1.WywalKarte0(PVP_1v1.Segment[7],x);
                                                                                    break;
                                                                                }
/*wykladanie karty na obrone*/                                              case 2:
                                                                                {
                                                                                    for(int c=0;c<MaxDoZagrania;c++)
                                                                                    {
                                                                                        if(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],c)==0)
                                                                                                {
                                                                                                    PVP_1v1.Segment[10]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[10],c+1,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[7],x));
                                                                                                    PVP_1v1.Segment[7]=PVP_1v1.DodanieKarty(PVP_1v1.Segment[7],x+1,0);
                                                                                                    drugi.podsumowanie=drugi.TaliaToPodsum(drugi.podsumowanie,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],c),2);
                                                                                                }
                                                                                    }
                                                                                    PVP_1v1.Segment[7]=PVP_1v1.WywalKarte0(PVP_1v1.Segment[7],x);
                                                                                    break;
                                                                                }


                                                                        }
                                                                    }
                                                                gr2=1;
                                                                break;
                                                            }
/*zmiana finkcji karty*/                                case 3:
                                                            {
                                                                std::cout<<"ktora karte chcesz edytowac ?"<<std::endl;
                                                                PVP_1v1.WypiszIdToNazwa(PVP_1v1.Segment[10],0,PVP_1v1.IleKart(PVP_1v1.Segment[10]));
                                                                std::cin>>x;
                                                                while(PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],x)==0||drugi.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],x)]=='3'||drugi.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],x)]=='4')
                                                                    {
                                                                        std::cout<<"nie mozna edytowac tej karty"<<std::endl;
                                                                        std::cin>>x;
                                                                    }
                                                                if(drugi.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],x)-1]=='1')
                                                                    {
                                                                        if(drugi.podsumowanie[26]=='1')
                                                                            {
                                                                                drugi.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],x)-1]='2';
                                                                            }
                                                                        else
                                                                            {
                                                                                drugi.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],x)-1]='3';
                                                                            }
                                                                        gr2=1;
                                                                    }
                                                                else
                                                                    {
                                                                        if(drugi.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],x)-1]=='3')
                                                                            {
                                                                                std::cout<<"nie moszna jusz bo jusz to sropiues"<<std::endl;
                                                                            }
                                                                        else
                                                                            {
                                                                                if(drugi.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],x)-1]=='2')
                                                                                    {
                                                                                        if(drugi.podsumowanie[26]=='1')
                                                                                           {
                                                                                               drugi.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],x)-1]='1';
                                                                                           }
                                                                                        else
                                                                                            {
                                                                                                drugi.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],x)-1]='4';
                                                                                            }
                                                                                        gr2=1;
                                                                                    }
                                                                                else
                                                                                {
                                                                                    if(drugi.podsumowanie[PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[10],x)-1]=='4')
                                                                                        {
                                                                                            std::cout<<"nie moszna jusz bo jusz to sropiues"<<std::endl;
                                                                                        }
                                                                                }
                                                                            }
                                                                    }
                                                                break;
                                                            }
                                                        default :
                                                            {
                                                                std::cout<<"nieladnie, jeszcze raz "<<std::endl;
                                                                break;
                                                            }
                                                    }
                                                }
                                        }
                                }
                                std::cout<<"koniec rundy"<<std::endl;
/*ZAKONCZENIE RUNDY*/           {
/*okreslenie podsumowania na podstawie planszy*/
                                    {
                                        pierwszy.podsumowanie=pierwszy.TaliaToPodsum(pierwszy.podsumowanie,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[3],0),1);
                                        drugi.podsumowanie=drugi.TaliaToPodsum(drugi.podsumowanie,PVP_1v1.ShortIntToFullInt(PVP_1v1.Segment[9],0),1);
                                    }

/*obliczenie wartosci ataku, obronui i morali na podstawie uzytych kart*/
                                    {
/*atak1*/                               pierwszy.atak=pierwszy.PodsumToAtak(pierwszy.podsumowanie,runda);
/*obrona1*/                             pierwszy.obrona=pierwszy.PodsumToObro(pierwszy.podsumowanie);
/*morale1*/                             {
                                            if(pierwszy.podsumowanie[25]=='1')
                                                {
                                                    if(drugi.podsumowanie[27]=='1')
                                                        {
                                                            pierwszy.morale=pierwszy.PodsumToMora(pierwszy.podsumowanie,'4');
                                                        }
                                                    else
                                                        {
                                                            pierwszy.morale=pierwszy.PodsumToMora(pierwszy.podsumowanie,'1');
                                                        }
                                                }
                                            else
                                                {
                                                    if(drugi.podsumowanie[27]=='1')
                                                        {
                                                            pierwszy.morale=pierwszy.PodsumToMora(pierwszy.podsumowanie,'3');
                                                        }
                                                    else
                                                        {
                                                            pierwszy.morale=pierwszy.PodsumToMora(pierwszy.podsumowanie,'2');
                                                        }
                                                }
                                        }
/*atak2*/                               drugi.atak=drugi.PodsumToAtak(drugi.podsumowanie,runda);
/*obrona2*/                             drugi.obrona=drugi.PodsumToObro(drugi.podsumowanie);
/*morale2*/                             {
                                            if(drugi.podsumowanie[25]=='1')
                                                {
                                                    if(pierwszy.podsumowanie[27]=='1')
                                                        {
                                                            drugi.morale=drugi.PodsumToMora(drugi.podsumowanie,'4');
                                                        }
                                                    else
                                                        {
                                                            drugi.morale=drugi.PodsumToMora(drugi.podsumowanie,'1');
                                                        }
                                                }
                                            else
                                                {
                                                    if(pierwszy.podsumowanie[27]=='1')
                                                        {
                                                            drugi.morale=drugi.PodsumToMora(drugi.podsumowanie,'3');
                                                        }
                                                    else
                                                        {
                                                            drugi.morale=drugi.PodsumToMora(drugi.podsumowanie,'2');
                                                        }
                                                }
                                        }
                                    }

/*wypisanie wynikow na ekran*/      {
                                        std::cout<<"gracz1 ma "<<pierwszy.atak<<" pkt ataku"<<std::endl;
                                        std::cout<<"gracz1 ma "<<pierwszy.obrona<<" pkt obrony"<<std::endl;
                                        std::cout<<"gracz1 ma "<<pierwszy.morale<<"% morali"<<std::endl;
                                        std::cout<<"gracz2 ma "<<drugi.atak<<" pkt ataku"<<std::endl;
                                        std::cout<<"gracz2 ma "<<drugi.obrona<<" pkt obrony"<<std::endl;
                                        std::cout<<"gracz2 ma "<<drugi.morale<<"% morali"<<std::endl;
                                        x=(pierwszy.atak-drugi.obrona)*pierwszy.morale/100;
                                        opka=(drugi.atak-pierwszy.obrona)*drugi.morale/100;
                                        if(x>opka)
                                            {
                                                std::cout<<"runde wygral gracz1"<<std::endl;
                                                PVP_1v1.zwyciestwo++;
                                            }
                                        if(x<opka)
                                            {
                                                std::cout<<"runde wygral gracz2"<<std::endl;
                                                PVP_1v1.zwyciestwo--;
                                            }
                                        if(x==opka)
                                            {
                                                std::cout<<"remis"<<std::endl;
                                            }
                                    }
                                }

                    }
/*Zakonczenie PVP_1v1*/
                    {
                        if(PVP_1v1.zwyciestwo>0)std::cout<<"\n\n\tZYCIEZA GRACZ1\n\n"<<std::endl;
                        if(PVP_1v1.zwyciestwo<0)std::cout<<"\n\n\tZYCIEZA GRACZ2\n\n"<<std::endl;
                        if(PVP_1v1.zwyciestwo==0)std::cout<<"\n\n\tREMIS\n\n"<<std::endl;
                    }
                    i=1;
                break;
            }
        case 4:
            {
                std::cout<<"Wybrano PVP 2v2"<<std::endl;
                std::cout<<"Rozgrywka PVP 2v2"<<std::endl;
                i=1;
                break;
            }
        case 5:
            {
                std::cout<<"Wybrano Coop 2"<<std::endl;
/*przygotowanie*/
                plansza Coop2;

                Grcz pierwszy;
                //Grcz drugi;
                    Coop2.Segment[0]="b1bbbbbbbb;07004bbcbb;bbbb1bccbb;bbbc1cccbb;b300700000;b1bdddddbb;b1bbdbbbbb;|";

                    int iPozycja1=13;
                    int iAkcja1=10;
                    int iPozycja2=29;
                    int iAkcja2=10;

                    for(int z=1;z<4;z++)
                    {
                        switch(z)
                        {
                        case 1:
                            {
                                Coop2.Segment[z]="";//reka1
                                break;
                            }
                        case 2:
                            {
                                Coop2.Segment[z]=pierwszy.talia;//talia
                                break;
                            }
                        case 3:
                            {
                                Coop2.Segment[z]="";//bohater1
                                break;
                            }
                        case 4:
                            {
                                Coop2.Segment[z]="";
                                break;
                            }
                        }
                    }

                //x=13;
/*rozgrywka*/   {
                    for(int pas1=0,xx=0;pas1!=1;)
                        {
                            for(opka=0;Coop2.Segment[0][opka]!='|';opka++)
                                {
                                    Coop2.narysuj(Coop2.Segment,3,2,0,opka,iPozycja1,0,"");
                                }
                             std::cout<<"zostalo "<<iAkcja1<<" pkt akcji"<<std::endl;

                            //std::cout<<pierwszy.CharToAkcja(Coop2.Segment[0],iPozycja1-1,1)<<std::endl;
/*Co gdzie idzie gracz*/    {
                                std::cout<<"0)Pas\n1)Lewo\n2)Gora\n3)Prawo\n4)Duyuuuul"<<std::endl;
                                std::cin>>xx;
/*zabezpieczenie*/              while   (
/*drzewo*/                                  (
                                                xx!=0&&
                                                (xx!=1||Coop2.Segment[0][iPozycja1-1]=='d')&&
                                                (xx!=2||Coop2.Segment[0][iPozycja1-11]=='d')&&
                                                (xx!=3||Coop2.Segment[0][iPozycja1+1]=='d')&&
                                                (xx!=4||Coop2.Segment[0][iPozycja1+11]=='d')
                                             )||
/*koszt*/                                   (
                                                (xx==1&&iAkcja1<pierwszy.CharToAkcja(Coop2.Segment[0],iPozycja1-1,1))||
                                                (xx==2&&iPozycja1>pierwszy.DlugWiersz(Coop2.Segment[0])&&iAkcja1<pierwszy.CharToAkcja(Coop2.Segment[0],iPozycja1-pierwszy.DlugWiersz(Coop2.Segment[0]),2))||
                                                (xx==2&&iPozycja1<pierwszy.DlugWiersz(Coop2.Segment[0])&&iAkcja1<pierwszy.CharToAkcja(Coop2.Segment[0],Coop2.Segment[0].length()-pierwszy.DlugWiersz(Coop2.Segment[0])+iPozycja1,2))||
                                                (xx==3&&iAkcja1<pierwszy.CharToAkcja(Coop2.Segment[0],iPozycja1+1,3))||
                                                (xx==4&&iPozycja1<(Coop2.Segment[0].length()-pierwszy.DlugWiersz(Coop2.Segment[0]))&&iAkcja1<(pierwszy.CharToAkcja(Coop2.Segment[0],Coop2.Segment[0].length()-pierwszy.DlugWiersz(Coop2.Segment[0])+iPozycja1,4)))||
                                                (xx==4&&iPozycja1>(Coop2.Segment[0].length()-pierwszy.DlugWiersz(Coop2.Segment[0]))&&iAkcja1<(pierwszy.CharToAkcja(Coop2.Segment[0],iPozycja1-pierwszy.DlugWiersz(Coop2.Segment[0]),2)))
                                             )
                                         )
                                            {
                                                if
                                                    (
                                                        Coop2.Segment[0][iPozycja1-1]=='d'||    //drzewo
                                                        Coop2.Segment[0][iPozycja1-11]=='d'||   //drzewo
                                                        Coop2.Segment[0][iPozycja1+1]=='d'||    //drzewo
                                                        Coop2.Segment[0][iPozycja1+11]=='d'     //drzewo
                                                    )
                                                        {
                                                            std::cout<<"nie, bo drzewo"<<std::endl;
                                                        }
                                                if  (
                                                        (xx==1&&iAkcja1<pierwszy.CharToAkcja(Coop2.Segment[0],iPozycja1-1,1))||
                                                        (xx==2&&iPozycja1>11&&iAkcja1<pierwszy.CharToAkcja(Coop2.Segment[0],iPozycja1-pierwszy.DlugWiersz(Coop2.Segment[0]),2))||
                                                        (xx==2&&iPozycja1<11&&iAkcja1<pierwszy.CharToAkcja(Coop2.Segment[0],Coop2.Segment[0].length()-pierwszy.DlugWiersz(Coop2.Segment[0])+iPozycja1,2))||
                                                        (xx==3&&iAkcja1<pierwszy.CharToAkcja(Coop2.Segment[0],iPozycja1+1,3))||
                                                        (xx==4&&iPozycja1<(Coop2.Segment[0].length()-pierwszy.DlugWiersz(Coop2.Segment[0]))&&iAkcja1<(pierwszy.CharToAkcja(Coop2.Segment[0],Coop2.Segment[0].length()-pierwszy.DlugWiersz(Coop2.Segment[0])+iPozycja1,4)))||
                                                        (xx==4&&iPozycja1>(Coop2.Segment[0].length()-pierwszy.DlugWiersz(Coop2.Segment[0]))&&iAkcja1<(pierwszy.CharToAkcja(Coop2.Segment[0],iPozycja1-pierwszy.DlugWiersz(Coop2.Segment[0]),2)))
                                                     )
                                                        {
                                                            std::cout<<"nie masz punktow"<<std::endl;
                                                        }
                                                std::cin>>xx;
                                            }
                            }
                            if(xx==0)
                                {
                                    pas1=1;std::cout<<"pas"<<std::endl;
                                }
                            else
                                {

                                    iPozycja1=pierwszy.Ruch(Coop2.Segment[0],xx,iPozycja1);
                                    iAkcja1-=pierwszy.CharToAkcja(Coop2.Segment[0],iPozycja1,xx);
                                }
                        }
                }
                i=1;
                break;
            }
        case 6:
            {
                std::cout<<"Wybrano Coop 3"<<std::endl;
                std::cout<<"Rozgrywka Coop 3"<<std::endl;
                i=1;
                break;
            }
        case 7:
            {
                std::cout<<"Wybrano Coop 4"<<std::endl;
                std::cout<<"Rozgrywka Coop 4"<<std::endl;
                i=1;
                break;
            }
        case 8:
            {
                std::cout<<"Wybrano Opcje"<<std::endl;
/*Glowna petla opcji*/
                opka=-1;
                for(;opka!=0;)
                    {
                        std::cout<<"OPCJE:\n\t1)Gra\n\t0)Wyjscie"<<std::endl;
                        std::cin>>x;
                        while(x!=0&&x!=1)
                            {
                                std::cout<<"zle, jeszcze raz"<<std::endl;
                                std::cin>>x;
                            }
/*petla mozliwosci*/    for(int iOpcje=1;iOpcje!=0;)
                            {
                                switch(x)
                                {
                                    case 0:
                                        {
                                            iOpcje=0;
                                            opka=0;
                                            break;
                                        }
                                    case 1:
                                        {
                                            for(int iGra=1,iGraX=0;iGra!=0;)
                                            {
                                                std::cout<<"Co zmienic?\n\t0)Wroc\n\t1)Maksymalna ilosci bohaterow\n\t2)maksymalna ilosc kart na reku\n\t3)max zagr\n\t4)max buf"<<std::endl;
                                                std::cin>>iGraX;
                                                while(iGraX!=0&&iGraX!=1&&iGraX!=2&&iGraX!=3&&iGraX!=4)
                                                    {
                                                        std::cout<<"zle, jeszcze raz"<<std::endl;
                                                        std::cin>>iGraX;
                                                    }
                                                switch(iGraX)
                                                    {
                                                        case 0:
                                                            {
                                                                iGra=0;
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                std::cout<<"Ile ma byc bohaterow?"<<std::endl;
                                                                std::cin>>MaxBoh;
                                                                while(MaxBoh<0)
                                                                    {
                                                                        std::cin>>MaxBoh;
                                                                    }
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                std::cout<<"Ile ma byc kart na reku?"<<std::endl;
                                                                std::cin>>MaxReka;
                                                                while(MaxReka<0)
                                                                    {
                                                                        std::cin>>MaxReka;
                                                                    }
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                std::cout<<"Ile moze byc kart zagranych?"<<std::endl;
                                                                std::cin>>MaxDoZagrania;
                                                                while(MaxDoZagrania<0)
                                                                    {
                                                                        std::cin>>MaxDoZagrania;
                                                                    }
                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                std::cout<<"Ile ma byc bufow?"<<std::endl;
                                                                std::cin>>MaxBuf;
                                                                while(MaxBuf<0)
                                                                    {
                                                                        std::cin>>MaxBuf;
                                                                    }
                                                                break;
                                                            }
                                                    }
                                            }
                                            iOpcje=0;
                                            break;
                                        }
                                }
                            }
                    }
                i=1;
                break;
            }
        default:
            {
                i=1;
                break;
            }
        }
    }
    std::cout<<"\t\tKoniec programu"<<std::endl;
}

gra::gra()
{
    //std::cout<<"stworzono obiekt gra"<<std::endl;

    IleRundMax=3;
    MaxWTalii=30;
    MaxDoZagrania=4;
    MaxBoh=1;
    MaxBuf=2;
    MaxReka=10;
}

gra::~gra()
{
    //std::cout<<"zniszczono obiekt gra"<<std::endl;
}
