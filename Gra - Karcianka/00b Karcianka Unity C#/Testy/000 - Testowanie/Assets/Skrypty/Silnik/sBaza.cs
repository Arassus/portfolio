using UnityEngine;
using System.Collections;

public class sBaza : MonoBehaviour 
{
	public string sKarty,sTalia;				/*
													sKarty:	1		2		3		4		5		6		7
															ID;		Nazwa;	rodzaj;	tryb;	atak;	obrona;	morale;
													sTalia
															talia	|
																1		2		...		n
																Karta1;	Karta2;	...		Kartan;
															ostatnio wywalone na ekran

	                                 			*/

	void ZaladujBazeKart(int iTryb)
	{
		if(iTryb==1)
		{
			sKarty = "";
			sKarty += "1;BOHATER1;1;1;1000;200;50;|";      //Bohater1
			sKarty += "2;BOHATER2;1;2;800;400;50;|";       //Bohater2
			sKarty += "3;BOHATER3;1;3;600;600;50;|";       //Bohater3
			sKarty += "4;BOHATER4;1;1;400;800;50;|";       //Bohater4
			sKarty += "5;BOHATER5;1;2;200;1000;50;|";      //Bohater5
			
			sKarty += "6;SZERMIERZ1;2;3;100;500;2;|";         //Szermierz1   
			sKarty += "7;SZERMIERZ2;2;1;100;500;2;|";         //Szermierz2
			sKarty += "8;SZERMIERZ3;2;2;200;400;2;|";         //Szermierz3
			sKarty += "9;SZERMIERZ4;2;3;200;400;2;|";         //Szermierz4
			sKarty += "10;SZERMIERZ5;2;1;300;300;2;|";        //Szermierz5
			sKarty += "11;SZERMIERZ6;2;2;300;300;2;|";        //Szermierz6
			sKarty += "12;SZERMIERZ7;2;3;400;200;2;|";        //Szermierz7
			sKarty += "13;SZERMIERZ8;2;1;400;200;2;|";        //Szermierz8
			sKarty += "14;SZERMIERZ9;2;2;500;100;2;|";        //Szermierz9
			sKarty += "15;SZERMIERZ10;2;3;500;100;2;|";       //Szermierz10 
			
			sKarty += "16;LUCZNIK1;2;1;100;500;2;|";          //Lucznik1   
			sKarty += "17;LUCZNIK1;2;2;100;500;2;|";          //Lucznik2
			sKarty += "18;LUCZNIK1;2;3;200;400;2;|";          //Lucznik3
			sKarty += "19;LUCZNIK1;2;1;200;400;2;|";          //Lucznik4
			sKarty += "20;LUCZNIK1;2;2;300;300;2;|";          //Lucznik5
			sKarty += "21;LUCZNIK1;2;3;300;300;2;|";          //Lucznik6
			sKarty += "22;LUCZNIK1;2;1;400;200;2;|";          //Lucznik7
			sKarty += "23;LUCZNIK1;2;2;400;200;2;|";          //Lucznik8
			sKarty += "24;LUCZNIK1;2;3;500;100;2;|";          //Lucznik9
			sKarty += "25;LUCZNIK1;2;1;500;100;2;|";          //Lucznik10
			
			sKarty += "26;BUF1;3;Podwaja morale;|";         //Buf1    
			sKarty += "27;BUF2;3;nie tracisz morali;|";     //Buf1
			sKarty += "28;BUF3;3;on traci morale;|";        //Buf1
			sKarty += "29;BUF4;3;wywala mu jednostke;|";    //Buf1
			sKarty += "30;BUF5;3;Wywala bufy;|";            //Buf1     
			
			sKarty += "31;POTWOR1;1;1;1000;100;50;|";       //Potwor1
			sKarty += "32;POTWOR2;1;2;800;200;50;|";        //Potwor2
			sKarty += "33;POTWOR3;1;3;600;300;50;|";        //Potwor3
			
			sKarty += "34;MINION1;2;3;100;500;2;|";           //Minion1   
			sKarty += "35;MINION2;2;1;100;500;2;|";           //Minion2
			sKarty += "36;MINION3;2;2;200;400;2;|";           //Minion3
			sKarty += "37;MINION4;2;3;200;400;2;|";           //Minion4
			sKarty += "38;MINION5;2;1;300;300;2;|";           //Minion5
			sKarty += "39;MINION6;2;2;300;300;2;|";           //Minion6
			sKarty += "40;MINION7;2;3;400;200;2;|";           //Minion7
			sKarty += "41;MINION8;2;1;400;200;2;|";           //Minion8
			sKarty += "42;MINION9;2;2;500;100;2;|";           //Minion9;


			sTalia = "";
			sTalia += "1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23;24;25;26;27;28;29;30;|";

		}
	}
	// Use this for initialization
	void Start ()
	{
		ZaladujBazeKart(1);
	}
	// Update is called once per frame
	void Update () 
	{
	
	}
}
