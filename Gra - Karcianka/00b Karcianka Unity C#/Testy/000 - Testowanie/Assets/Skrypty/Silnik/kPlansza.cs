using UnityEngine;
using System.Collections;

public class kPlansza : MonoBehaviour 
{
	public int iTryb;
	public string sMapa;		/*
                                        0;|1;|2;|3;|4;|5;|6;|7;|8;|9;|10;|11;|12;|13;|

                                        0-Bohater1 | 1-Bufy1 | 2-Jednostki1 | 3-Reka1 | 4-Talia1 | 5-Zuzyte1 | 6-Zagrane1 |
                                        7-Bohater2 | 8-Bufy2 | 9-Jednostki2 | 10-Reka2 | 11-Talia2 | 12-Zuzyte2 | 13-Zagrane2 |
								*/

	public string sPrzygotowaniePlanszy(string sOpcje, int iTryb)//, kOblicz OB)
	{
		kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
		print ("Przygotowanie planszy");
		string sZwracany = "";
		switch(iTryb)
		{
		case 1:
			{
				for(int i=0,j=0;i<=13;i++)
				{
					if(i==0||i==7)
						{
							j=OB.iSt_In(OB.s1Seg(sOpcje,0),0);		//Boh
							Debug.Log("Boh "+i+" "+j);
						}
					if(i==1||i==8)
						{
							j=OB.iSt_In(OB.s1Seg(sOpcje,0),1);		//Buf
							Debug.Log("Buf "+i+" "+j);
						}
					if(i==2||i==9)
						{
							j=OB.iSt_In(OB.s1Seg(sOpcje,0),2);		//Jed
							Debug.Log("Jed "+i+" "+j);
						}
					if(i==3||i==10)
						{
							j=OB.iSt_In(OB.s1Seg(sOpcje,0),3);		//Rek
							Debug.Log("Rek "+i+" "+j);
						}
					if(i==4||i==11)
						{
							j=OB.iSt_In(OB.s1Seg(sOpcje,0),5);		//Tal
							Debug.Log("Rek "+i+" "+j);
						}										
					if(i==5||i==12)
						{
							j=OB.iSt_In(OB.s1Seg(sOpcje,0),6);		//Zuz
							Debug.Log("Rek "+i+" "+j);
						}										
					if(i==6||i==13)
						{
							j=OB.iSt_In(OB.s1Seg(sOpcje,0),5);		//Zag
							Debug.Log("Rek "+i+" "+j);
						}		
				sZwracany=OB.sDodajSegment(sZwracany,i,j);
				}
				break;
			}
		default:
			{
				Debug.Log("wyjatek.case.sPRzgPlan");
				break;
			}
		}
		return sZwracany;
	}
	// Use this for initialization
	void Start () 
	{
		iTryb =1;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}