using UnityEngine;
using System.Collections;

public class kGra : MonoBehaviour {
	public string sOpcje;
	public int iKrok;

	bool CzyZapauzowac;

	// Use this for initialization
	void Start () 
	{
		sOpcje= "1;2;4;10;3;30;0;|1;2;4;10;3;30;4;2;|";               //Nadanie poczatkowych wartosci w opcjach dla   :      
		
		/*
                1-PVP:      1)MaxBoh; 2)MaxBuf; 3)MaxJed; 4)MaxRek; 5)MaxRund; 6)MaxTal; | 
                2-Camp:     1)MaxBoh; 2)MaxBuf; 3)MaxJed; 4)MaxRek; 5)MaxRund; 6)MaxTal; 7)+akcjaRunda; 8)+akcjaJednostka;       
                                                            (   
                                                                1-ile punktow akcji standardowo przyznaje sie na runde;    
                                                                2-ile punktow akcji jest warta karta jednostki;  
                                                            )
		*/
		iKrok=0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameObject.Find ("Silnik").GetComponent<kProcedura>().bWyb==false)
		{
			//Debug.Log ("Krok w kGra : "+iKrok);
			iKrok++;
		}
		//Debug.Log("     TERAZ MAMY KROR : " + iKrok);
	}
}
