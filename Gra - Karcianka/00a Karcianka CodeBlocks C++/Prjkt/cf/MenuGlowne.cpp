#include <MenuGlowne.h>// wyjscie 0 ; PVP1v1 1 ; PVP2v2 2 ; Coop2 3; Coop3 4; Coop4 5;
#include <iostream>

int megl::OpcjeMenu()
{
    int i;
    std::cout<<"\tMENU GLOWNE :\n\t0)Koniec\n\t1)PVP 1v1\n\t2)PVP 2v2\n\t3)Coop 2\n\t4)Coop 3\n\t5)Coop 4\n\t6)Opcje"<<std::endl;
    while(i<0||i>6)
    {
        std::cin>>i;
    }

    if(i==0)return i-1;
    else return i+1;
    //return i;
}

megl::megl()
{
    //std::cout<<"\tstworzono obiekt megl"<<std::endl;
}

megl::~megl()
{
    //std::cout<<"\tzniszczono obiekt megl"<<std::endl;

}
