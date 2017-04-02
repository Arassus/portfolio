using UnityEngine;
using System.Collections;

public class kOblicz : MonoBehaviour 
{
	public void QuickSort(int[] tab, int left, int right)       //zwyczajny quicksort
	{
		int i = left;
		int j = right;
		int x = tab[(left + right) / 2];
		
		do
		{
			while (tab[i] < x)
				i++;
			while (tab[j] > x)
				j--;
			if (i <= j)
			{
				int asd;
				asd = tab[i];
				tab[i] = tab[j];
				tab[j] = asd;
				asd = 0;
				i++;
				j--;
			}
		} while (i <= j);
		
		if (left < j) QuickSort(tab, left, j);
		if (right > i) QuickSort(tab, i, right);
	}
	public char cSh_Ch(int iSh)
	{
		char x;
		switch (iSh)
		{
		case 0:
		{
			x = '0';
			break;
		}
		case 1:
		{
			x = '1';
			break;
		}
		case 2:
		{
			x = '2';
			break;
		}
		case 3:
		{
			x = '3';
			break;
		}
		case 4:
		{
			x = '4';
			break;
		}
		case 5:
		{
			x = '5';
			break;
		}
		case 6:
		{
			x = '6';
			break;
		}
		case 7:
		{
			x = '7';
			break;
		}
		case 8:
		{
			x = '8';
			break;
		}
		case 9:
		{
			x = '9';
			break;
		}
		default:
		{
			Debug.Log("cos poszlo nie tak w oGra::sI_C : " + iSh);
			x = (char)iSh;
			break;
		}
		}
		return x;
	}       //zwraca znak(char) - tlumaczy z inta
	public int iDlLin(string sWyraz, int iKtora)        //Zwraca dlugosc konkretnej linii w wyrazie
	{
		int x = 0;      //zwracana liczba
		for (int i1 = 0, i2 = 0; i1 <= iKtora; i2++)        //skakanie po po znakach(indeks i2) poki nie dotrzemy do konkretnego wyrazu(oddzielane ';')
		{
			if (sWyraz[i2] == ';')      //trafilismy na koniec linii
			{
				i1++;
			}
			if (i1 == iKtora)       //dotarlismy do konkretnej linii
			{
				for (x = i2; sWyraz[x + 1] != ';'||x+1==sWyraz.Length; x++)     //skaczemy po wyrazach poki nie dotrzemy do konca linii; nadanie wartosci i2 dla zwracanej x
				{
					;
				}
				i1 = iKtora + 1;        //ucieczka z petli
				x -= i2;        //po usunieciu i2 z x'a zostaje tylko dlugosc znaku
			}
		}
		if (iKtora == 0)
		{
			return x + 1;               //indeks tablic i wyrazow stringow jest liczony od 0, powowduje to zmniejszenie wyniku x o 1, naprawiono zwracajac x+1
		}
		else
		{
			return x;                   //gdy wyraz liczony od wiecej niz 0
		}
	}        
	public int iId_Seg(string sWyraz, int iID, string sID)      //zwraca indeks segmentu gdzie znajduje sie karta o konkretnym indeksie(jesli podasz id w int to string musi byc rowny "")
	{
		
		int x = iIleSeg(sWyraz), iZwracane = 0;
		string sOper;
		if (sID == "")
		{
			for (int i = 0; i < x; i++)
			{
				sOper = s1Seg(sWyraz, i);
				if (int.Parse(s1Lin(sOper, 0)) == iID)
				{
					iZwracane = i;
					i = x;
				}
			}
		}
		else
		{
			for (int i = 0; i < x; i++)
			{
				sOper = s1Seg(sWyraz, i);
				if (s1Lin(sOper, 0) == sID)
				{
					iZwracane = i;
					i = x;
				}
			}
		}
		return iZwracane;
	}
	public int iId_Wart(string sWyraz, int iID,string sID, int x)       //zwraca wartosc X karty o indeksie ID na podstawie bazy kart(jesli podasz id w int to string musi byc rowny "")
	{
		int iZwracane = 0;
		switch(x)
		{
		case 2:     //Rodzaj
		{
			iZwracane = iSt_In(s1Seg(sWyraz, iId_Seg(sWyraz, iID, sID)), 2);
			break;
		}
		case 3:     //tryb
		{
			iZwracane = iSt_In(s1Seg(sWyraz, iId_Seg(sWyraz, iID, sID)), 3);
			break;
		}
		case 4:     //atak
		{
			iZwracane = iSt_In(s1Seg(sWyraz, iId_Seg(sWyraz, iID, sID)), 4);
			break;
		}
		case 5:     //obrona
		{
			iZwracane = iSt_In(s1Seg(sWyraz, iId_Seg(sWyraz, iID, sID)), 5);
			break;
		}
		case 6:     //morale
		{
			iZwracane = iSt_In(s1Seg(sWyraz, iId_Seg(sWyraz, iID, sID)), 6);
			break;
		}
			
		}     
		return iZwracane;
	}
	public int iIleLin(string sWyraz)       //zwraca ile linii ma wyraz
	{
		int x = 0, y = sWyraz.Length;
		for (int i = 0; i < y; i++)
		{
			if (sWyraz[i] == ';') x++;
		}
		return x;
	}
	public int iIleSeg(string sWyraz)       //zwraca ile segmentow ma wyraz
	{
		int x = 0, y = sWyraz.Length;
		for (int i = 0; i < y; i++)
		{
			if (sWyraz[i] == '|') x++;
		}
		return x;
	}
	public int iKaNoPa(int iCzyTen, int iZtym)      //Zwraca kto wygral w kamien nozyce papier - (iCzyTen gra z iZtym)      1)Przegral; 2)Remis; 3)Wygral;
	{
		int iWynik = iCzyTen - iZtym;
		switch (iWynik)
		{
		case -2:
		{
			iWynik = 3;
			break;
		}
		case -1:
		{
			iWynik = 1;
			break;
		}
		case 0:
		{
			iWynik = 2;
			break;
		}
		case 1:
		{
			iWynik = 3;
			break;
		}
		case 2:
		{
			iWynik = 1;
			break;
		}
		}
		return iWynik;
	}
	public int iOstZnak(string sWyraz, int iKtora)      //zwraca indeks ostatniego znaku konkretnej linii w wyrazie
	{
		int znak = 0;       //zaczynamy od poczatku      
		for (int i = 0; i <= iKtora; i++)       //skaczemy po liniach 
		{
			znak += iDlLin(sWyraz, i);      //dodawanie do zwracanej liczby dlugosci linii
		}
		znak += iKtora - 1;     //wziecie pod uwage ze linie sa oddzielone znakiem ';'
		return znak;
	}
	public int iSt_In(string sWyraz, int iKtora)        //zwraca linie(int) - przerobienie konkretnej linii ze stringa na int
	{
		//Debug.Log(s1Lin(sWyraz,iKtora));
		int wynik = int.Parse(s1Lin(sWyraz,iKtora));
		
		return wynik;
	}
	public string sDodaj0(string sWyraz, int iDlugosc, int iCo)         //zwraca segment z dodatkowa linia wynoszaca 0
	{
		string sDodawany = "";
		for (int i = 0, x = sWyraz.Length - 1; i < x; i++)
		{
			sDodawany += sWyraz[i];
		}
		sDodawany += sIn_St(iCo, iDlugosc);
		sDodawany += "|";
		return sDodawany;
	}
	public string sDodajSegment(string sWyraz, int iKtory, int iIle)
	{
		int max = iIleSeg(sWyraz);
		string sZwracany = "";
		
		for (int i = 0; i <= max; i++)
		{
			if(i==iKtory)
			{
				sZwracany += '|';
				string supa="|";
				for(int ii=0;ii< iIle;ii++)
				{
					supa = sZamienSeg(supa, sDodaj0(supa, 1, 0), 0);
				}
				sZwracany = sZamienSeg(sZwracany, supa, i);
			}
			if(i< max)
			{
				sZwracany += s1Seg(sWyraz, i);
			}
		}
		
		return sZwracany;
	}
	public string s1Lin(string sWyraz, int iKtora)      //zwraca linie w postaci stringu
	{
		string sZwracany = "";
		
		for (int i = 0, j = 0, k = iIleLin(sWyraz); j < k || i<sWyraz.Length; i++)      //skaczemy po znakach poki nie przelecimy po wszystkich liniach
		{
			if (j == iKtora && sWyraz[i] != ';')        //dotarlismy do naszej konkretnej linii oraz nie jest to koniec tego wyrazu
			{
				sZwracany += sWyraz[i];         //dodajemy znak linii do zwracanego stringa
			}
			if (sWyraz[i] == ';')       //dotarlismy do konca linii
			{
				j++;        //lecimy do nastepnej linii
			}
		}
		
		return sZwracany;
	}
	public string s1Seg(string sWyraz, int iKtory)      //zwraca segment w postaci stringu
	{
		string sSegment = "";
		for (int i = 0, x = iIleSeg(sWyraz), ii = 0; i < x; i++, ii++)
		{
			for (; sWyraz[ii] != '|'; ii++)
			{
				if (i == iKtory)
				{
					sSegment += sWyraz[ii];
				}
			}
		}
		sSegment += '|';
		return sSegment;
	}/*
                                        0;|1;|2;|3;|4;|5;|6;|7;|8;|9;|10;|11;|12;|13;|

                                        0-Bohater1 | 1-Bufy1 | 2-Jednostki1 | 3-Reka1 | 4-Talia1 | 5-Zuzyte1 | 6-Zagrane1 |
                                        7-Bohater2 | 8-Bufy2 | 9-Jednostki2 | 10-Reka2 | 11-Talia2 | 12-Zuzyte2 | 13-Zagrane2 |
								*/
	public string sIn_St(int iLiczba, int iIleCyfr)      //zwraca wyraz(string) - przerabia inta na stringa o dlugosci ilecyfr
	{
		int iMianownik = 1;
		string sLiczba = "";
		for (int i = iIleCyfr - 1; i >= 0; i--)     //skaczemy po cyfrach zwracanego stringa
		{
			for (int ii = 1; ii <= i; ii++)         //szukamy odpowiedniego mianownika
			{
				iMianownik = iMianownik * 10;
			}
			if (iLiczba / iMianownik != 0)          //liczba nie jest krotsza niz podana liczba cyfr
			{
				sLiczba += cSh_Ch(iLiczba / iMianownik);        //do zwracanego stringa dodajemy znak na podstawie cyfry z liczby
				iLiczba -= (iLiczba / iMianownik) * iMianownik;         //usuniecie tej cyfry z liczby(by nie dodac za duzo do stringa zwracanego)
			}
			else            //liczba jest krotsza niz podana liczba cyfr
			{
				sLiczba += cSh_Ch(0);       //do stringa dodajemy znak '0';
			}
			iMianownik = 1;     //by przerobic mianownik od nowa
		}
		sLiczba += ';';     //dodajemy koniec wyrazu
		return sLiczba;
	}
	public string sPosortuj(string sWyraz)      //zwraca posortowany rosnaco segment
	{
		string sZwracane = "";
		int iIle = iIleLin(sWyraz);
		switch (iIle)
		{
		case 10:
		{
			int[] tab = new int[15];
			for (int i = 0; i < iIle; i++)
			{
				tab[i] = iSt_In(sWyraz, i);
			}
			QuickSort(tab, 0, iIle - 1);
			for (int i = 0; i < iIle; i++)
			{
				sWyraz = sZmienWyr(sWyraz, i, tab[i], 0);
			}
			sZwracane += sWyraz;   
			break;
		}
		case 30:
		{
			//int[] tab = new int[30];   
			break;
		}
		}
		return sZwracane;
		
	}
	public string sUsun0(string sWyraz)         //zwraca segment bez linii wynoszacych 0;
	{
		string wyzerowana = "";
		for (int i = 0; i < iIleLin(sWyraz); i++)
		{
			if (iSt_In(sWyraz, i) != 0)
				wyzerowana += sIn_St(iSt_In(sWyraz, i), iDlLin(sWyraz, i));
		}
		wyzerowana += '|';
		return wyzerowana;
	}
	public string sUsunSeg(string sWyraz, int iKtory)       //zwraca wyraz z usunietym segmentem
	{
		string sZwracane = "";
		for (int i = 0, ii = 0, x = iIleSeg(sWyraz); i < x; i++, ii++)
		{
			for (; sWyraz[ii] != '|'; ii++)
			{
				if (i != iKtory)
				{
					sZwracane += sWyraz[ii];
				}
			}
			if (i != iKtory)
			{
				sZwracane += '|';
			}
		}
		return sZwracane;
	}
	public string sZamienSeg(string sCalosc, string sFragment, int iKtory)      //zwraca wyraz z zamienionym segmentem
	{
		string sZmienna = "";
		for (int i = 0, x = iIleSeg(sCalosc); i < x; i++)
		{
			if (i != iKtory)
			{
				sZmienna += s1Seg(sCalosc, i);
			}
			else
			{
				sZmienna += s1Seg(sFragment, 0);
			}
		}
		return sZmienna;
	}
	public string sZmienWyr(string sTalia, int iKtora, int iNaCo, int iKtory)        //Zwraca segment ze zmienionym wyrazem
	{
		/*string sFragment = s1Seg(sTalia, iKtory), sDodawane = sIn_St(iNaCo, iDlLin(sFragment, iKtora)), sZwracany = "";
		int x = sFragment.Length;
		for (int i = 0, j = 0, k = 0; i < x; i++)
		{
			if (j == iKtora)
			{
				sZwracany += sDodawane[k];
				k++;
			}
			else
			{
				sZwracany += sFragment[i];
			}
			
			if (sFragment[i] == ';')
			{
				j++;
			}
		}
		
		return sZwracany;*/

		
		string sFragment = s1Seg(sTalia, iKtory), sZwracany = "";
		int x = sFragment.Length;
		for (int i = 0, j = 0; i < x; i++)
		{
			if (j == iKtora)
			{
				sZwracany += iNaCo.ToString()+";";   
				while (sFragment[i] != ';'&&i<x) { i++; }
				j++;  
			}
			else
			{                   
				sZwracany += sFragment[i];
			}
			
			if (sFragment[i] == ';')
			{
				j++;
			}
		}
		
		return sZwracany;
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
