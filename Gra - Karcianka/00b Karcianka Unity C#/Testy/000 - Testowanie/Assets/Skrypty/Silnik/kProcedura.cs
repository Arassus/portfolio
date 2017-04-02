using UnityEngine;
using System.Collections;

public class kProcedura : MonoBehaviour 
{
	public bool bWyb,bCzyKlik;

	public int iOp;
	public string sOP;
	//int iOp2;
	int iKtoryGracz,iDlugoscKlikniecia,iZwyciestwo,iRunda,Atak1,Atak2,Obrona1,Obrona2,Morale1,Morale2;
	bool CzyGracz1Spasowal,CzyGracz2Spasowal;

	Ray RY;
	RaycastHit HI;

	void StworzKarte(int iID, string sSegment, Vector3 pozycja, char cPlus, int iEwentualnie)
	{
		if(sSegment=="Tlo")
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.parent = GameObject.Find ("Tlo"+cPlus).transform;
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/"+iID+".png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.1f,0.5f,0.3f);
		}
		if(sSegment[0]=='s'&&cPlus=='p')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/"+iID+".png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.072f,0.5f,0.108f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
		if(sSegment[0]=='s'&&cPlus=='b')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.Rotate(0,90,0);
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/"+iID+".png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.072f,0.5f,0.108f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
		if(sSegment[0]=='s'&&cPlus=='j')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/"+iID+".png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.072f,0.5f,0.108f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
		if(sSegment[0]=='s'&&cPlus=='r')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/"+iID+".png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.072f,0.5f,0.108f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
		if(sSegment[0]=='s'&&cPlus=='t')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/"+iID+".png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.072f,0.5f,0.108f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
		if(sSegment[0]=='s'&&cPlus=='z')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/"+iID+".png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.072f,0.5f,0.108f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
		if(sSegment[0]=='s'&&cPlus=='P')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/0.png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.072f,0.5f,0.108f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
		if(sSegment[0]=='s'&&cPlus=='B')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.Rotate(0,90,0);
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/0.png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.072f,0.5f,0.108f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
		if(sSegment[0]=='s'&&cPlus=='J')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/0.png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.1f,0.5f,0.15f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
		if(sSegment[0]=='s'&&cPlus=='J')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/0.png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.072f,0.5f,0.108f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
		if(sSegment[0]=='s'&&cPlus=='R')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/0.png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.072f,0.5f,0.108f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
		if(sSegment[0]=='s'&&cPlus=='T')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/0.png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.072f,0.5f,0.108f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
		if(sSegment[0]=='s'&&cPlus=='Z')
		{
			kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
			GameObject Karta = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Karta.transform.position = pozycja;
			Karta.transform.parent = GameObject.Find (sSegment).transform;
			Karta.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/KartyID/0.png",typeof (Texture2D));
			Karta.transform.localScale = new Vector3(0.072f,0.5f,0.108f);
			Karta.name = OB.s1Lin(OB.sIn_St(iID,3),0)+iEwentualnie;
		}
	}
	void StworzNapis(int iTryb,char cPlus, string sNapis, Vector3 vNapis, Vector3 vSkala)
	{
		if(iTryb==0)
		{
			GameObject Napis = new GameObject();
			Napis.transform.parent = GameObject.Find("Tlo"+cPlus).transform;
			Napis.name = "Napis"+cPlus ;
			Napis.AddComponent<TextMesh>();
			Napis.GetComponent<TextMesh>().text = sNapis;
			Napis.transform.position = vNapis;
			Napis.transform.Rotate(90,180,0);
			Napis.GetComponent<TextMesh>().font = (Font)Resources.GetBuiltinResource(typeof(Font),"Arial.ttf");
			Napis.GetComponent<TextMesh>().renderer.material = ((Font)Resources.GetBuiltinResource(typeof(Font),"Arial.ttf")).material;
			Napis.transform.localScale = vSkala;
		}
		if(iTryb==1)
		{
			GameObject Napis = new GameObject();
			Napis.transform.parent = GameObject.Find("Napisy").transform;
			Napis.name = cPlus + "Napis";
			Napis.AddComponent<TextMesh>();
			Napis.GetComponent<TextMesh>().text = sNapis;
			Napis.transform.position = vNapis;
			Napis.transform.Rotate(90,180,0);
			Napis.GetComponent<TextMesh>().font = (Font)Resources.GetBuiltinResource(typeof(Font),"Arial.ttf");
			Napis.GetComponent<TextMesh>().renderer.material = ((Font)Resources.GetBuiltinResource(typeof(Font),"Arial.ttf")).material;
			Napis.transform.localScale = vSkala;
		}
		if(iTryb==2)
		{
			GameObject Napis = new GameObject();
			Napis.transform.parent = GameObject.Find("Tlo"+cPlus).transform;
			Napis.name = "Napis"+cPlus ;
			Napis.AddComponent<TextMesh>();
			Napis.GetComponent<TextMesh>().text = sNapis;
			Napis.transform.position = vNapis;
			Napis.transform.Rotate(90,180,0);
			Napis.GetComponent<TextMesh>().font = (Font)Resources.GetBuiltinResource(typeof(Font),"Arial.ttf");
			Napis.GetComponent<TextMesh>().renderer.material = ((Font)Resources.GetBuiltinResource(typeof(Font),"Arial.ttf")).material;
			Napis.transform.localScale = vSkala;
		}
	}
	void StworzGuzik(string sJaki, string sGdzie, Vector3 vPozycja, char cPlus)
	{
		GameObject Guzik = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Guzik.name = 'g'+sJaki;
		Guzik.transform.Translate(vPozycja.x,vPozycja.y,vPozycja.z);//(-6.6f,1,3);
		Guzik.transform.localScale = new Vector3(0.2f,0.5f,0.1f);
		Guzik.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/Guziki/"+sJaki+".png",typeof (Texture2D));

		if(sGdzie == "Mapa")
		{
			Guzik.transform.parent = GameObject.Find ("Guziki").transform;
		}
		if(sGdzie[0] == 'T')
		{
			Guzik.transform.parent = GameObject.Find("Tlo"+cPlus).transform;
		}
		//if(sGdz)
	}
	void Podsumowanie(int iTryb)
	{
		switch(iTryb)
		{
		case 0:
		{
			break;
		}
		case 1:
		{
			break;
		}
		}
	}
	void NarysujWedlug(int iTryb, int iGracz)
	{
		switch(iTryb)
		{
		case 0:
		{
			switch(iGracz)
			{
			case 0:
			{
				{
					GameObject Guziki = new GameObject();
					Guziki.name = "Guziki";
					Guziki.transform.parent = GameObject.Find ("Mapa").transform;

					StworzGuzik("Pas","Mapa",new Vector3(-6.6f,1,3),'0');
				}		//Guziki
				{
					GameObject Napisy = new GameObject();
					Napisy.transform.parent = GameObject.Find ("Mapa").transform;
					Napisy.name = "Napisy";

					StworzNapis(1,'R',"Runda "+(iRunda+1),new Vector3(8,5,-4.2f),new Vector3(0.5f,0.5f,0.5f));
					StworzNapis(1,'G',"Gracz "+(iKtoryGracz+1),new Vector3(8,5,3),new Vector3(0.5f,0.5f,0.5f));

					StworzNapis(1,'A',"A "+(Atak1),new Vector3(-3.6f,5,1),new Vector3(0.2f,0.2f,0.2f));
					StworzNapis(1,'O',"O "+(Obrona1),new Vector3(-3.6f,5,1.3f),new Vector3(0.2f,0.2f,0.2f));
					StworzNapis(1,'M',"M "+(Morale1),new Vector3(-3.6f,5,1.6f),new Vector3(0.2f,0.2f,0.2f));
					StworzNapis(1,'S',"S "+((Atak1-Obrona2)*Morale1/100),new Vector3(-3.6f,5,2.6f),new Vector3(0.2f,0.2f,0.2f));

					StworzNapis(1,'A',"A "+(Atak2),new Vector3(-3.6f,5,-4),new Vector3(0.2f,0.2f,0.2f));
					StworzNapis(1,'O',"O "+(Obrona2),new Vector3(-3.6f,5,-3.7f),new Vector3(0.2f,0.2f,0.2f));
					StworzNapis(1,'M',"M "+(Morale2),new Vector3(-3.6f,5,-3.4f),new Vector3(0.2f,0.2f,0.2f));
					StworzNapis(1,'S',"S "+((Atak2-Obrona1)*Morale2/100),new Vector3(-3.6f,5,-2.4f),new Vector3(0.2f,0.2f,0.2f));
				}		//Napisy

				GameObject Segmenty = new GameObject();
				Segmenty.name = "Segmenty" + iGracz;
				Segmenty.transform.parent = GameObject.Find("Mapa").transform;

				kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();

				for(int i=0,k;i<=14;i++)
				{
					k=OB.iIleLin(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i));
					switch(i)
					{
					case 0:		//boh1
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						//Segment.transform.Translate(2.8f,1,-1.69f);
						Segment.transform.Translate(2.8f,1,1.24f);

						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0.5f,1,0)),'p',j);
						}
						break;
					}
					case 1:		//Buf1
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						//Segment.transform.Translate(-2.37f,1,-2.13f);
						Segment.transform.Translate(-2.37f,1,1.24f);
						
						for(int j=0;j<k;j++)
						{
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0,1,1.65f)),'b',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x,VC.y+0.1f+(float)j*0.1f,VC.z+0.4f-j*1),'b',j);
						}
						break;
					}
					case 2:		//Jed1
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						//Segment.transform.Translate(-0.2f,1,-1.69f);
						Segment.transform.Translate(-0.2f,1,1.63f);

						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(3.7f,1,0)),'j',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);
						}
						break;
					}
					case 3:		//Rek1
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(0.52f,1,3.68f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(2.35f,1,0)),'r',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);//new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);
						}
						break;
					}
					case 4:		//Tal1
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(-2.53f,1,3.68f);

						for(int j=0;j<k;j++)
						{
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0.1f,1,0.1f)),'T',j);
						}
						break;
					}
					case 5:		//Zuz1
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(-1.64f,1,3.68f);
						
						for(int j=0;j<k;j++)
						{
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0.1f,1,0.1f)),'z',j);
						}
						break;
					}

					case 7:		//Boh2
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(2.8f,1,-1.69f);
						//Segment.transform.Translate(2.8f,1,1.24f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0.5f,1,0)),'p',j);
						}
						break;
					}
					case 8:		//Buf2
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						//Segment.transform.Translate(-2.37f,1,1.24f);
						Segment.transform.Translate(-2.37f,1,-2.13f);

						for(int j=0;j<k;j++)
						{
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0,1,1.65f)),'b',j);
						}
						break;
					}
					case 9:		//Jed2
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						//Segment.transform.Translate(-0.2f,1,1.63f);
						Segment.transform.Translate(-0.2f,1,-1.69f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(3.7f,1,0)),'j',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);
						}
						break;
					}
					case 10:	//Rek2
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(0.52f,1,-3.74f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(2.35f,1,0)),'R',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);//new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);
						}
						break;
					}
					case 11:	//Tal2
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(-2.54f,1,-3.74f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0.1f,1,0.1f)),'T',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);//new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);
						}
						break;
					}
					case 12:	//Zuz2
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(-1.64f,1,-3.74f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0.1f,1,0.1f)),'z',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);//new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);
						}
						break;
					}
					default:
					{
						break;
					}
					}

					/*for(int j=0;j<k;j++)
					{
						Vector3 VC = GameObject.Find("s"+i).transform.position;
						StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-i*1,VC.y+0.1f+(float)i*0.1f,VC.z),'a');
					}*/
				}

				break;
			}
			case 1:
			{
				{
					GameObject Guziki = new GameObject();
					Guziki.name = "Guziki";
					Guziki.transform.parent = GameObject.Find ("Mapa").transform;
					
					StworzGuzik("Pas","Mapa",new Vector3(-6.6f,1,3),'0');
				}		//Guziki
				{
					GameObject Napisy = new GameObject();
					Napisy.transform.parent = GameObject.Find ("Mapa").transform;
					Napisy.name = "Napisy";
					
					StworzNapis(1,'R',"Runda "+(iRunda+1),new Vector3(8,5,-4.2f),new Vector3(0.5f,0.5f,0.5f));
					StworzNapis(1,'G',"Gracz "+(iKtoryGracz+1),new Vector3(8,5,3),new Vector3(0.5f,0.5f,0.5f));

					StworzNapis(1,'A',"A "+(Atak2),new Vector3(-3.6f,5,1),new Vector3(0.2f,0.2f,0.2f));
					StworzNapis(1,'O',"O "+(Obrona2),new Vector3(-3.6f,5,1.3f),new Vector3(0.2f,0.2f,0.2f));
					StworzNapis(1,'M',"M "+(Morale2),new Vector3(-3.6f,5,1.6f),new Vector3(0.2f,0.2f,0.2f));
					StworzNapis(1,'S',"S "+((Atak2-Obrona1)*Morale2/100),new Vector3(-3.6f,5,2.6f),new Vector3(0.2f,0.2f,0.2f));

					StworzNapis(1,'A',"A "+(Atak1),new Vector3(-3.6f,5,-4),new Vector3(0.2f,0.2f,0.2f));
					StworzNapis(1,'O',"O "+(Obrona1),new Vector3(-3.6f,5,-3.7f),new Vector3(0.2f,0.2f,0.2f));
					StworzNapis(1,'M',"M "+(Morale1),new Vector3(-3.6f,5,-3.4f),new Vector3(0.2f,0.2f,0.2f));
					StworzNapis(1,'S',"S "+((Atak1-Obrona2)*Morale1/100),new Vector3(-3.6f,5,-2.4f),new Vector3(0.2f,0.2f,0.2f));
				}
				GameObject Segmenty = new GameObject();
				Segmenty.name = "Segmenty" + iGracz;
				Segmenty.transform.parent = GameObject.Find("Mapa").transform;
				
				kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
				
				for(int i=0,k;i<=14;i++)
				{
					k=OB.iIleLin(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i));
					switch(i)
					{
					case 0:		//boh1
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						//Segment.transform.Translate(2.8f,1,1.24f);
						Segment.transform.Translate(2.8f,1,-1.69f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0.5f,1,0)),'p',j);
						}
						break;
					}
					case 1:		//Buf1
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						//Segment.transform.Translate(-2.37f,1,1.24f);
						Segment.transform.Translate(-2.37f,1,-2.13f);
						
						for(int j=0;j<k;j++)
						{
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0,1,1.65f)),'b',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x,VC.y+0.1f+(float)j*0.1f,VC.z+0.4f-j*1),'b',j);
						}
						break;
					}
					case 2:		//Jed1
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(-0.2f,1,-1.69f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(3.7f,1,0)),'j',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);
						}
						break;
					}
					case 3:		//Rek1
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(0.52f,1,-3.74f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(2.35f,1,0)),'R',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);//new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);
						}
						break;
					}
					case 4:		//Tal1
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(-2.54f,1,-3.74f);
						
						for(int j=0;j<k;j++)
						{
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0.1f,1,0.1f)),'T',j);
						}
						break;
					}
					case 5:		//Zuz1
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(-1.71f,1,-3.74f);
						
						for(int j=0;j<k;j++)
						{
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0.1f,1,0.1f)),'z',j);
						}
						break;
					}
						
					case 7:		//Boh2
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						//Segment.transform.Translate(2.8f,1,-1.69f);
						Segment.transform.Translate(2.8f,1,1.24f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0.5f,1,0)),'p',j);
						}
						break;
					}
					case 8:		//Buf2
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(-2.37f,1,1.25f);
						
						for(int j=0;j<k;j++)
						{
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0,1,1.65f)),'b',j);
						}
						break;
					}
					case 9:		//Jed2
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(-0.2f,1,1.63f);
						//Segment.transform.Translate(-0.2f,1,-1.69f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(3.7f,1,0)),'j',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);
						}
						break;
					}
					case 10:	//Rek2
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;

						Segment.transform.Translate(0.52f,1,3.68f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(2.35f,1,0)),'r',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);//new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);
						}
						break;
					}
					case 11:	//Tal2
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;

						Segment.transform.Translate(-2.53f,1,3.68f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0.1f,1,0.1f)),'t',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);//new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);
						}
						break;
					}
					case 12:	//Zuz2
					{
						GameObject Segment = new GameObject();
						Segment.name = "s" + i;
						Segment.transform.parent = GameObject.Find ("Segmenty"+iGracz).transform;
						Segment.transform.Translate(-1.64f,1,3.68f);
						
						for(int j=0;j<k;j++)
						{
							//Vector3 VC = GameObject.Find("s"+i).transform.position;
							StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,PozycjaKartyNaStosie(Segment.transform.position,k,j,new Vector3(0.1f,1,0.1f)),'z',j);
							//StworzKarte(OB.iSt_In(OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,i),j),"s"+i,new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);//new Vector3(VC.x-j*1,VC.y+0.1f+(float)j*0.1f,VC.z),'B',j);
						}
						break;
					}
					default:
					{
						break;
					}
					}
				}
				break;
			}
			}
			break;
		}
		}
	}
	void OdswiezMape()
	{
		kOblicz O = GameObject.Find ("Silnik").GetComponent<kOblicz>();
		string Calosc = GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa;

		for(int i=0;i<2;i++)
		{
			string SegJed=O.s1Seg(Calosc,2+i*7), SegBuf=O.s1Seg(Calosc,1+i*7), SegZuz=O.s1Seg(Calosc,5+i*7), SegFun1=O.s1Seg(Calosc,6+i*7), SegFun="";

			Debug.Log (SegBuf+"     "+SegJed+"     "+SegZuz);
			for(int j=0,k=O.iIleLin(SegBuf),l;j<k;j++)
			{
				Debug.Log ("j i k  = "+j+k);
				l=O.iSt_In(SegBuf,j);
				if(l!=0)
				{
					SegZuz = O.sDodaj0(SegZuz,3,l);
				}
			}		//Dodawanie bufow do zuzytych

			for(int j=0,k=O.iIleLin(SegJed),l;j<k;j++)
			{
				Debug.Log ("j i k  = "+j+k);
				l=O.iSt_In(SegJed,j);
				if(l!=0)
				{
					SegZuz = O.sDodaj0(SegZuz,3,l);
				}
			}		//dodawanie jednostek do zuzytych


			
			for(int j=0,k=O.iIleLin(SegFun1);j<k;j++)
			{
				if(j<5)
				{
					SegFun+=SegFun1[j*2];//+';';
					SegFun+=";";
				}
				else
				{
					SegFun+="0;";
				}
			}SegFun+="|";		//Odswiez funkcje
			SegBuf = "0;0;|";		//odswiez bufy
			SegJed = "0;0;0;0;|";		//odswiez jednostki

			Debug.Log ("B");
			Calosc = O.sZamienSeg(Calosc,SegBuf,1+i*7);		//dodanie odswiezonych bufow do do calosci
			Debug.Log ("J");
			Calosc = O.sZamienSeg(Calosc,SegJed,2+i*7);		//dodanie odswiezonych jednostek do do calosci
			Debug.Log ("Z");
			Calosc = O.sZamienSeg(Calosc,SegZuz,5+i*7);		//dodanie odswiezonych zuzytych do do calosci
			Debug.Log ("F");
			Calosc = O.sZamienSeg(Calosc,SegFun,6+i*7);		//dodanie odswiezonych funkcji do do calosci

			GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa = Calosc;
		}
	}		//Dodanie zuzytych, usuniecie bofow i jednostek z planszy
	void PodliczStatystyki(string FunkcjeGracza1,string FunkcjeGracza2)
	{
		string sObliczony1 = "", sObliczony2 = "";

		Atak1 = 0;		Atak2 = 0;
		Obrona1 = 0;	Obrona2 = 0;
		Morale1 = 0;	Morale2 = 0;

		kOblicz O = GameObject.Find ("Silnik").GetComponent<kOblicz>();

		//int mnoznik

		for(int i=0;i<25;i++)
		{
			sObliczony1 = O.s1Lin(FunkcjeGracza1,i);
			sObliczony2 = O.s1Lin(FunkcjeGracza2,i);

			string Baza = O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,i);
			
			if(sObliczony1=="1")	//Podliczanie Ataku1
			{
				Debug.Log("FUNKCJE_1 1, dla i = "+i);

				Atak1 += O.iSt_In(Baza,4);		//Podliczanie Ataku Gracza1

				if(O.s1Lin(FunkcjeGracza1,25)=="1") 		//Gdy Gracz1 zagral buf1
				{
					if(O.s1Lin(FunkcjeGracza2,27)=="1"&&i>5) 		//Gdy Gracz2 zagral buf3
					{
						Morale1 -= 2*O.iSt_In(Baza,6);		//podliczanie morali gracza1
					}
					else
					{
						Morale1 += 2*O.iSt_In(Baza,6);		//podliczanie morali gracza1
					}
				}
				else
				{
					if(O.s1Lin(FunkcjeGracza2,27)=="1"&&i>5) 		//Gdy Gracz2 zagral buf3
					{
						Morale1 -= O.iSt_In(Baza,6);		//podliczanie morali gracza1
					}
					else
					{
						Morale1 += O.iSt_In(Baza,6);		//podliczanie morali gracza1
					}
				}

				if(i<5)		//stale podliczanie kart bohaterow gracza1
				{
					Obrona1+= O.iSt_In(Baza,5);		//podliczanie obrony gracza1
				}
			}
			if(sObliczony1=="2")	//Podliczanie Obrony1
			{
				Debug.Log("FUNKCJE_1 2, dla i = "+i);

				Obrona1 += O.iSt_In(Baza,5);		//podliczanie obrony gracza1

				if(O.s1Lin(FunkcjeGracza1,25)=="1") 		//Gdy Gracz1 zagral buf1
				{
					if(O.s1Lin(FunkcjeGracza1,26)=="1") 		//Gdy Gracz1 zagral buf2
					{
						if(O.s1Lin(FunkcjeGracza2,27)=="1"&&i>5) 		//Gdy Gracz2 zagral buf3
						{
							Morale1 -= 2*O.iSt_In(Baza,6);		//podliczanie morali gracza1
						}
						else
						{
							Morale1 += 2*O.iSt_In(Baza,6);		//podliczanie morali gracza1
						}
					}
					else
					{
						Morale1 -= 2*O.iSt_In(Baza,6);		//podliczanie morali gracza1
					}
				}
				else
				{
					if(O.s1Lin(FunkcjeGracza1,26)=="1") 		//Gdy Gracz1 zagral buf2
					{
						if(O.s1Lin(FunkcjeGracza2,27)=="1"&&i>5) 		//Gdy Gracz2 zagral buf3
						{
							Morale1 -= O.iSt_In(Baza,6);		//podliczanie morali gracza1
						}
						else
						{
							Morale1 += O.iSt_In(Baza,6);		//podliczanie morali gracza1
						}
					}
					else
					{
						Morale1 -= O.iSt_In(Baza,6);		//podliczanie morali gracza1
					}
				}
			}
					if(sObliczony2=="1")	//Podliczanie Ataku2
					{
						Debug.Log("FUNKCJE_2 1, dla i = "+i);

						Atak2 += O.iSt_In(Baza,4);
						if(O.s1Lin(FunkcjeGracza2,25)=="1")
						{
							//Morale2 += 2*O.iSt_In(Baza,6);
							if(O.s1Lin(FunkcjeGracza1,27)=="1"&&i>5) 		//Gdy Gracz1 zagral buf3
							{
								Morale2 -= 2*O.iSt_In(Baza,6);		//podliczanie morali gracza2
							}
							else
							{
								Morale2 += 2*O.iSt_In(Baza,6);		//podliczanie morali gracza2
							}
						}
						else
						{
							//Morale2 += O.iSt_In(Baza,6);
							if(O.s1Lin(FunkcjeGracza1,27)=="1"&&i>5) 		//Gdy Gracz1 zagral buf3
							{
								Morale2 -= O.iSt_In(Baza,6);		//podliczanie morali gracza2
							}
							else
							{
								Morale2 += O.iSt_In(Baza,6);		//podliczanie morali gracza2
							}
						}

						if(i<5)
						{
							Obrona2+= O.iSt_In(Baza,5);
						}
					}
					if(sObliczony2=="2")	//Podliczanie Obrony2
					{
						Debug.Log("FUNKCJE_2 2, dla i = "+i);

						Obrona2 += O.iSt_In(Baza,5);

						if(O.s1Lin(FunkcjeGracza2,25)=="1")
						{
							if(O.s1Lin(FunkcjeGracza2,26)=="1")
							{
								if(O.s1Lin(FunkcjeGracza1,27)=="1"&&i>5) 		//Gdy Gracz1 zagral buf3
								{
									Morale2 -= 2*O.iSt_In(Baza,6);
								}
								else
								{
									Morale2 += 2*O.iSt_In(Baza,6);
								}
							}
							else
							{
								Morale2 -= 2*O.iSt_In(Baza,6);
							}
						}
						else
						{
							if(O.s1Lin(FunkcjeGracza2,26)=="1")
							{
								if(O.s1Lin(FunkcjeGracza1,27)=="1"&&i>5) 		//Gdy Gracz1 zagral buf3
								{
									Morale2 -= O.iSt_In(Baza,6);
								}
								else
								{
									Morale2 += O.iSt_In(Baza,6);
								}
							}
							else
							{
								Morale2 -= O.iSt_In(Baza,6);
							}
						}
					}
		}
	}
	void WypiszDoWyboru(int iTryb, char cPlus, string sNapis, Vector3 vNapis,string sTalia, int iMin, int iMax)
	{
		GameObject Tlo = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Tlo.name="Tlo"+cPlus;
		//Tlo.transform.position = new Vector3(0,10,0);
		Tlo.transform.position = new Vector3(vNapis.x,vNapis.y-1,vNapis.z);
		Tlo.transform.localScale = new Vector3(1.777f,1,1);
		Tlo.renderer.material.mainTexture = (Texture2D)Resources.LoadAssetAtPath("Assets/Obrazy/Okna puste.png",typeof (Texture2D));

		switch(iTryb)
		{
		case 0:				//Gole tlo
			{
				if(sNapis!="")
				StworzNapis(0,cPlus,sNapis,new Vector3(vNapis.x+8,vNapis.y,vNapis.z),new Vector3(0.2f,0.2f,0.2f));
				break;
			}
		case 1:				//Wybierz karte
			{
				if(sNapis!="")
					StworzNapis(0,cPlus,sNapis,new Vector3(vNapis.x+8,vNapis.y,vNapis.z+3),new Vector3(0.4f,0.4f,0.4f));
				kOblicz B = GameObject.Find ("Silnik").GetComponent<kOblicz>();
				if(iMax-iMin>2)
				{
					for(int i = iMin,j=iMax;i<=j;i++)
					{
						//StworzKarte(GameObject.Find ("Silnik").GetComponent<kOblicz>().iSt_In(sTalia,iMin+i),"Tlo",new Vector3(-6+(12/(float)(iMax-iMin))*i,18+(float)i/4,0),cPlus,0);
						StworzKarte(B.iSt_In(sTalia,iMin+i),"Tlo",PozycjaKartyNaStosie(new Vector3(0,18,0),j,i,new Vector3(12,1,0)),cPlus,0);
					}
				}
				else
				{
					if(iMax-iMin==2)
					{
						StworzKarte(B.iSt_In(sTalia,iMin),"Tlo",new Vector3(-4,18,0),cPlus,0);
						StworzKarte(B.iSt_In(sTalia,iMin+1),"Tlo",new Vector3(4,18,0),cPlus,0);
					}
					else
					{
						StworzKarte(B.iSt_In(sTalia,iMin),"Tlo",new Vector3(0,18,0),cPlus,0);
					}
				}



				break;
			}
		case 2:		//Zagrac czy nie zagrac?
		{
			kOblicz O = GameObject.Find("Silnik").GetComponent<kOblicz>();

			if(sNapis!="")
				StworzNapis(0,cPlus,sNapis,new Vector3(vNapis.x+8,vNapis.y,vNapis.z+3),new Vector3(0.2f,0.2f,0.2f));
			//kOblicz B = GameObject.Find ("Silnik").GetComponent<kOblicz>();
			//string BZ = B.s1Seg(GameObject.Find("Silnik").GetComponent<sBaza>().sKarty,iOp);

			StworzKarte(iOp,"Tlo",new Vector3(5,18,0),cPlus,0);
			StworzGuzik("ZagA","Tlo",new Vector3(3,18,0),cPlus);
			StworzGuzik("ZagO","Tlo",new Vector3(3,18,-2),cPlus);
			
			StworzNapis(2,cPlus,O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),1),new Vector3(1,18,1),new Vector3(0.2f,0.2f,0.2f));
			StworzNapis(2,cPlus,"Atak="+O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),4),new Vector3(1,18,0),new Vector3(0.2f,0.2f,0.2f));
			StworzNapis(2,cPlus,"Obrona="+O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),5),new Vector3(1,18,-1),new Vector3(0.2f,0.2f,0.2f));
			StworzNapis(2,cPlus,"Morale="+O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),6),new Vector3(1,18,-2),new Vector3(0.2f,0.2f,0.2f));
			//int iT = B.iSt_In(B.s1Seg(GameObject.Find("Silnik").GetComponent<sBaza>().sKarty,iOp),2);		//wyciaga tryb karty



			break;
		}
		case 3:				//Wybierz karte (nazwa+nr)
		{
			if(sNapis!="")
				StworzNapis(0,cPlus,sNapis,new Vector3(vNapis.x+8,vNapis.y,vNapis.z+3),new Vector3(0.2f,0.2f,0.2f));
			kOblicz B = GameObject.Find ("Silnik").GetComponent<kOblicz>();
			if(iMax-iMin>2)
			{
				for(int i = 0;iMin+i<=iMax;i++)
				{
					//StworzKarte(GameObject.Find ("Silnik").GetComponent<kOblicz>().iSt_In(sTalia,iMin+i),"Tlo",new Vector3(-6+(12/(float)(iMax-iMin))*i,18+(float)i/4,0),cPlus,0);
					StworzKarte(B.iSt_In(sTalia,iMin+i),"Tlo",PozycjaKartyNaStosie(new Vector3(0,18,0),iMax-iMin,i,new Vector3(12,1,0)),cPlus,i);
				}
			}
			else
			{
				if(iMax-iMin==2)
				{
					StworzKarte(B.iSt_In(sTalia,iMin),"Tlo",new Vector3(-4,18,0),cPlus,0);
					StworzKarte(B.iSt_In(sTalia,iMin+1),"Tlo",new Vector3(4,18,0),cPlus,0);
				}
				else
				{
					StworzKarte(B.iSt_In(sTalia,iMin),"Tlo",new Vector3(0,18,0),cPlus,0);
				}
			}
			break;
		}
		case 4:			//tylko staty karty
		{
			kOblicz O = GameObject.Find("Silnik").GetComponent<kOblicz>();
			
			if(sNapis!="")
				StworzNapis(0,cPlus,sNapis,new Vector3(vNapis.x+8,vNapis.y,vNapis.z+3),new Vector3(0.2f,0.2f,0.2f));
			//kOblicz B = GameObject.Find ("Silnik").GetComponent<kOblicz>();
			//string BZ = B.s1Seg(GameObject.Find("Silnik").GetComponent<sBaza>().sKarty,iOp);
			
			StworzKarte(iOp,"Tlo",new Vector3(5,18,0),cPlus,0);
			//StworzGuzik("ZagA","Tlo",new Vector3(3,18,0),cPlus);
			//StworzGuzik("ZagO","Tlo",new Vector3(3,18,-2),cPlus);
			
			StworzNapis(2,cPlus,O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),1),new Vector3(1,18,1),new Vector3(0.2f,0.2f,0.2f));
			StworzNapis(2,cPlus,"Atak="+O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),4),new Vector3(1,18,0),new Vector3(0.2f,0.2f,0.2f));
			StworzNapis(2,cPlus,"Obrona="+O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),5),new Vector3(1,18,-1),new Vector3(0.2f,0.2f,0.2f));
			StworzNapis(2,cPlus,"Morale="+O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),6),new Vector3(1,18,-2),new Vector3(0.2f,0.2f,0.2f));
			//int iT = B.iSt_In(B.s1Seg(GameObject.Find("Silnik").GetComponent<sBaza>().sKarty,iOp),2);		//wyciaga tryb karty
			
			
			
			break;
		}
		case 5:				//////Czy zmienic funkcje + staty
		{
			kOblicz O = GameObject.Find("Silnik").GetComponent<kOblicz>();
			
			if(sNapis!="")
				StworzNapis(0,cPlus,sNapis,new Vector3(vNapis.x+8,vNapis.y,vNapis.z+3),new Vector3(0.2f,0.2f,0.2f));
			
			StworzKarte(iOp,"Tlo",new Vector3(5,18,0),cPlus,0);
			//StworzGuzik("ZagA","Tlo",new Vector3(3,18,0),cPlus);
			//StworzGuzik("ZagO","Tlo",new Vector3(3,18,-2),cPlus);
			StworzGuzik("Zmien","Tlo",new Vector3(3,18,-2),cPlus);
			
			StworzNapis(2,cPlus,O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),1),new Vector3(1,18,1),new Vector3(0.2f,0.2f,0.2f));
			StworzNapis(2,cPlus,"Atak="+O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),4),new Vector3(1,18,0),new Vector3(0.2f,0.2f,0.2f));
			StworzNapis(2,cPlus,"Obrona="+O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),5),new Vector3(1,18,-1),new Vector3(0.2f,0.2f,0.2f));
			StworzNapis(2,cPlus,"Morale="+O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),6),new Vector3(1,18,-2),new Vector3(0.2f,0.2f,0.2f));
			//int iT = B.iSt_In(B.s1Seg(GameObject.Find("Silnik").GetComponent<sBaza>().sKarty,iOp),2);		//wyciaga tryb karty
			
			
			
			break;
		}
		case 6:			//Czy zagrac buf
		{
			kOblicz O = GameObject.Find("Silnik").GetComponent<kOblicz>();
			
			if(sNapis!="")
				StworzNapis(0,cPlus,sNapis,new Vector3(vNapis.x+8,vNapis.y,vNapis.z+3),new Vector3(0.2f,0.2f,0.2f));
			
			StworzGuzik("Buf","Tlo",new Vector3(3,18,-2),cPlus);
			StworzKarte(iOp,"Tlo",new Vector3(5,18,0),cPlus,0);

			
			StworzNapis(2,cPlus,O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),1),new Vector3(1,18,0.5f),new Vector3(0.2f,0.2f,0.2f));
			StworzNapis(2,cPlus,"Funkcja : "+O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),3),new Vector3(1,18,0),new Vector3(0.2f,0.2f,0.2f));
			break;
		}
		case 7:			//Tylko staty bufa
		{
			kOblicz O = GameObject.Find("Silnik").GetComponent<kOblicz>();
			
			if(sNapis!="")
				StworzNapis(0,cPlus,sNapis,new Vector3(vNapis.x+8,vNapis.y,vNapis.z+3),new Vector3(0.2f,0.2f,0.2f));
			
			//StworzGuzik("Buf","Tlo",new Vector3(3,18,-2),cPlus);
			StworzKarte(iOp,"Tlo",new Vector3(5,18,0),cPlus,0);
			
			
			StworzNapis(2,cPlus,O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),1),new Vector3(1,18,0.5f),new Vector3(0.2f,0.2f,0.2f));
			StworzNapis(2,cPlus,"Funkcja : "+O.s1Lin(O.s1Seg(GameObject.Find ("Silnik").GetComponent<sBaza>().sKarty,iOp-1),3),new Vector3(1,18,0),new Vector3(0.2f,0.2f,0.2f));
			break;
		}
		}
	}
	void LosowanieReki(int iTryb, int iGracz, string sTalia, int iMin, int iMax, int iIle)
	{
		switch(iTryb)
		{
		case 0:													//Bez losowania i Sortowania
		{
			switch(iGracz)
			{
			case 0:													//dla Gracza1
			{
				kOblicz OB=GameObject.Find("Silnik").GetComponent<kOblicz>();
				GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa = OB.sZamienSeg(GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa,"6;9;16;17;25;26;27;28;29;30;|",3);
				break;
			}
			case 1:													//dla Gracza2
			{
				kOblicz OB=GameObject.Find("Silnik").GetComponent<kOblicz>();
				//string Reka = OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,3);			//Tutaj Gracz

				GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa = OB.sZamienSeg(GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa,"6;9;16;17;25;26;27;28;29;30;|",10);
				break;
			}
			}
			break;
		}
		}

	}

	public int WyborMiedzy(int iTryb,char cPlus,int iID)
	{
		int iZwraca = 0;
		switch(iTryb)
		{
		case 0:															//Samo tlo, klik i koniec
		{
			RY = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(RY, out HI))
			{
				if(Input.GetMouseButton(0)==true)
				{
					bWyb=false;
					Destroy (GameObject.Find("Tlo"+cPlus));
					//iOp 
					iZwraca = 1;
				}
				else
				{
					//iOp
					iZwraca = 0;
				}
			}
			break;
		}
		case 1:														//Klik na karte i koniec
		{
			RY = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(RY, out HI))
			{
				if(HI.collider.name!="Tlo"+cPlus && Input.GetMouseButton(0)==true)
				{
					bWyb=false;
					Destroy (GameObject.Find("Tlo"+cPlus));
					//iOp
					iZwraca = int.Parse (""+HI.collider.name[0]+HI.collider.name[1]+HI.collider.name[2]);
				}
				else
				{
					//iOp
					iZwraca = 0;
				}
			}
			break;
		}
		case 2:														//Wybierz stos i kontynuuj wybieranie kart
		{
			iZwraca = -1;
			RY = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(RY, out HI))
			{
				if(HI.collider.transform.parent!=null)
				{
					sOP=HI.collider.transform.parent.name;
				}
				else
				{	
					sOP="";
				}
				Debug.Log (HI.collider.name);
				if(Input.GetMouseButton(0))
				{
					if(HI.collider.name[0]=='g')
					{
						if(HI.collider.name=="gPas")
						{
							if(iKtoryGracz==0)
							{
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=24;
								CzyGracz1Spasowal=true;
							}
							if(iKtoryGracz==1)
							{
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=24;
								CzyGracz2Spasowal=true;
							}
						}
						if(HI.collider.name=="gZagA")
						{
							GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=22;
							Destroy(GameObject.Find("Tlo"+cPlus));
							iZwraca=1;

							bWyb=true;
						}
						if(HI.collider.name=="gZagO")
						{
							GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=22;
							Destroy(GameObject.Find("Tlo"+cPlus));
							iZwraca=2;
							
							bWyb=true;
						}
						if(HI.collider.name=="gBuf")
						{
							kOblicz O = GameObject.Find ("Silnik").GetComponent<kOblicz>();
							int iX;

							string sFrag="";
							if(iKtoryGracz==0)
							{
								sFrag = O.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,1);
							}
							if(iKtoryGracz==1)
							{
								sFrag = O.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,8);
							}
							if(O.s1Lin(sFrag,0)!="0")
							{
								if(O.s1Lin(sFrag,1)!="0")
								{
									GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=17;
									iX=-2;
								}
								else
								{
									GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=24;
									iX=1;
								}
							}
							else
							{
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=24;
								iX=0;
							}

							string Calosc = GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa;

							if(iX!=-2)
							{
								if(iOp==29)				//Zagrano buf4
								{
									string JedPrze;

									if(iKtoryGracz==0)
									{JedPrze = O.s1Seg(Calosc,9);}
									else
									{JedPrze = O.s1Seg(Calosc,2);}

									if(O.s1Lin(JedPrze,0)!="0"||O.s1Lin(JedPrze,1)!="0"||O.s1Lin(JedPrze,2)!="0"||O.s1Lin(JedPrze,3)!="0")
									{
										int x=Random.Range(0,3);

										while (O.s1Lin(JedPrze,x)=="0"){x=Random.Range(0,3);}
										int iKarta = O.iSt_In(JedPrze,x);

										
										if(iKtoryGracz==0)
										{
											Calosc = O.sZamienSeg(Calosc,O.sZmienWyr(Calosc,iKarta-1,0,9),13);			//wywalic mu funkcje karty
											Calosc = O.sZamienSeg(Calosc,O.sDodaj0(O.s1Seg(Calosc,12),3,iKarta),12);	//dodac ja do zuzytych
											JedPrze = O.sZmienWyr(JedPrze,x,0,0);										//Wywawilc przeciwnikowi jednostke
											Calosc = O.sZamienSeg(Calosc,JedPrze,9);
										}
										else
										{
											Calosc = O.sZamienSeg(Calosc,O.sZmienWyr(Calosc,iKarta-1,0,2),6);			//wywalic mu funkcje karty
											Calosc = O.sZamienSeg(Calosc,O.sDodaj0(O.s1Seg(Calosc,5),3,iKarta),5);	//dodac ja do zuzytych
											JedPrze = O.sZmienWyr(JedPrze,x,0,0);										//Wywawilc przeciwnikowi jednostke
											Calosc = O.sZamienSeg(Calosc,JedPrze,2);
										}
									}
									
									if(iKtoryGracz==0)
									{
									}
									else
									{
										Calosc = O.sZamienSeg(Calosc,JedPrze,2);
									}
								}

								//Zagraj Karte
								
								string SegRek="", SegBuf="", SegFun="";
								
								//jesli Gracz1
								if(iKtoryGracz==0)
								{
									SegRek = O.s1Seg(Calosc,3); SegBuf = O.s1Seg(Calosc,1); SegFun = O.s1Seg(Calosc,6);
								}
								//jesli Gracz2
								if(iKtoryGracz==1)
								{
									SegRek = O.s1Seg(Calosc,10); SegBuf = O.s1Seg(Calosc,8); SegFun = O.s1Seg(Calosc,13);
								}
								
								
								Debug.Log(Calosc+"     "+SegFun+"     "+SegBuf+"     "+SegRek);
								Debug.Log (iOp);
								
								
								//dodaj Buf
								//jesli Gracz1
								if(iKtoryGracz==0)
								{
									SegBuf = O.sZmienWyr(SegBuf,iX,iOp,0);
									Calosc = O.sZamienSeg(Calosc,SegBuf,1);
								}
								//jesli Gracz2
								if(iKtoryGracz==1)
								{
									SegBuf = O.sZmienWyr(SegBuf,iX,iOp,0);
									Calosc = O.sZamienSeg(Calosc,SegBuf,8);
								}
								
								
								//usun z reki
								for(int i=0,j=O.iIleLin(SegRek);i<j;i++)
								{
									if(iOp==O.iSt_In(SegRek,i))
									{
										SegRek = O.sZmienWyr(SegRek,i,0,0);
										SegRek = O.sUsun0(SegRek);
										
										if(iKtoryGracz==0)
										{
											Calosc = O.sZamienSeg(Calosc,SegRek,3);
										}
										if(iKtoryGracz==1)
										{
											Calosc = O.sZamienSeg(Calosc,SegRek,10);
										}
										
										i=j;
									}
								}
								
								
								//dodaj funkcje
								//jesli Gracz1
								if(iKtoryGracz==0)
								{
									SegFun = O.sZmienWyr(SegFun,iOp-1,1,0);
									Calosc = O.sZamienSeg(Calosc,SegFun,6);
								}
								//jesli Gracz2
								if(iKtoryGracz==1)
								{
									SegFun = O.sZmienWyr(SegFun,iOp-1,1,0);
									Calosc = O.sZamienSeg(Calosc,SegFun,13);
								}
								Debug.Log(Calosc+"     "+SegFun+"     "+SegBuf+"     "+SegRek+"     Gracz"+(iKtoryGracz+1));
							}
							
							GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa = Calosc;

							Destroy(GameObject.Find("Tlo"+cPlus));
							iZwraca=3;
							
							bWyb=true;
						}
					}
					else
					{
						if(HI.collider.name[0]=='T')
						{
							Destroy(GameObject.Find("Tlo"+cPlus));
							iZwraca=0;
						}
						else
						{
							if(HI.collider.transform.parent.name[0]=='s')
							{
								if(HI.collider.transform.parent.name!="s4"&&HI.collider.transform.parent.name!="s11")
								{
									if((iKtoryGracz==0&&HI.collider.transform.parent.name!="s10")||(iKtoryGracz==1&&HI.collider.transform.parent.name!="s3"))
									{
										string sDoZwrotu = "";//, sPrzerabiane = HI.collider.transform.parent.name ;
										for(int i=1,j=HI.collider.transform.parent.name.Length;i<j;i++)
										{
											sDoZwrotu+=HI.collider.transform.parent.name[i];
										}
										iZwraca = int.Parse(sDoZwrotu);
										bWyb=false;
									}
								}
							}
						}
					}
				}
			}
			break;
		}
		case 3:														//Klik na karte i koniec
		{
			iZwraca = -1;
			RY = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(RY, out HI))
			{
				if(Input.GetMouseButton(0)==true)
				{
					bWyb=false;
					if(HI.collider.name!="Tlo"+cPlus)
					{
					iZwraca = int.Parse (""+HI.collider.name[0]+HI.collider.name[1]+HI.collider.name[2]);
					}
					else
					{
						iZwraca = 0;
					}
					Destroy (GameObject.Find("Tlo"+cPlus));
				}
			}
			break;
		}
		case 4:														//klik i nie usuwa jesli nie pusta albo nie tlo
		{
			Debug.Log ("Wybor case 4 ; "+cPlus+" ; " + iID);
			iZwraca = -2;
			RY = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(RY, out HI))
			{
				if(Input.GetMouseButton(0)==true)
				{
					bWyb=false;
					if(HI.collider.name!="Tlo"+cPlus)
					{
						Debug.Log("Teraz Zwraca : "+HI.collider.name);
						iZwraca = int.Parse (""+HI.collider.name[0]+HI.collider.name[1]+HI.collider.name[2]);
					}
					else
					{
						Destroy (GameObject.Find("Tlo"+cPlus));
						iZwraca = -1;
					}

					if(iZwraca==0)
					{
						Destroy (GameObject.Find("Tlo"+cPlus));
						//if(iZwraca!=-1)
						//{
							iZwraca = int.Parse(""+HI.collider.name[HI.collider.name.Length-1]);
						//}
					}
					else
					{
						//iZwraca = -2;
					}
				}
			}
			Debug.Log(iZwraca);
			break;
		}
		default :
		{
			break;
		}
		}
		bCzyKlik=true;
		return iZwraca;
	}

	public Vector3 PozycjaKartyNaStosie(Vector3 PozycjaStosu, int iIleKart,int iKtoraKarta, Vector3 vWychylenie)//Vector3 PozycjaPoczatek, Vector3 PozycjaKoniec)
	{
		float x,y,z;//,PK;


		x = PozycjaStosu.x+vWychylenie.x/2-vWychylenie.x/iIleKart*iKtoraKarta;
		y = PozycjaStosu.y+vWychylenie.y/2-vWychylenie.y/iIleKart*iKtoraKarta;
		z = PozycjaStosu.z+vWychylenie.z/2-vWychylenie.z/iIleKart*iKtoraKarta;

		return new Vector3(x,y,z);
	}

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Stworzodo procedure");
		bWyb = false;
		bCzyKlik = false;
		iOp = 0;
		//iOp2 = 0;
		iDlugoscKlikniecia = 0;
		iRunda = 0;
		iZwyciestwo=0;
		sOP="";

		Atak1=Atak2=Obrona1=Obrona2=Morale1=Morale2=0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==1)
		{
			GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa=GameObject.Find ("Mapa").GetComponent<kPlansza>().sPrzygotowaniePlanszy(GameObject.Find ("Main Camera").GetComponent<kGra>().sOpcje,1);
			WypiszDoWyboru(0,'a',"Nacisnij, by kontynuowac",new Vector3(0,15,0),"",0,0);
			bWyb=true;
			GameObject.Find("Main Camera").GetComponent<kGra>().iKrok = 2;

			//kOblicz O = GameObject.Find("Silnik").GetComponent<kOblicz>();
			//PodliczStatystyki(O.s1Seg(GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa,6),O.s1Seg(GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa,13));
		}
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==2)
		{
			WyborMiedzy(0,'a',0);
			iOp = 0;
		}



		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==11)
		{
			WypiszDoWyboru(1,'a',"Gracz1, Wybierz Bohatera",new Vector3(0,15,0),"1;2;3;4;5;6;",0,4);
			bWyb=true;
			GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=12;
			iOp=0;
		}		//Wypisz Bohaterow Gracza1
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==12)
		{
			iOp = WyborMiedzy(1,'a',0);
			if(iOp!=0)
			{
				kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
				string MA = GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,SegFun = OB.s1Seg(MA,6);
				
				SegFun = OB.sZmienWyr(SegFun,iOp-1,1,0);
				MA = OB.sZamienSeg(MA,OB.sZmienWyr(OB.s1Seg(MA,0),0,iOp,0),0);
				MA = OB.sZamienSeg(MA,SegFun,6);

				GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa = MA;

				bWyb=false;
				iOp=0;
			}
		}		//Wybor Bohatera1
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==13)
		{
			WypiszDoWyboru(1,'b',"Gracz2, Wybierz Bohatera",new Vector3(0,15,0),"1;2;3;4;5;6;",0,4);
			bWyb=true;
			GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=14;
			iOp=0;
		}		//Wypisz Bohaterow Gracza2
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==14&&bCzyKlik==false)
		{
			iOp = WyborMiedzy(1,'b',0);
			if(iOp!=0)
			{
				kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
				string MA = GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,SegFun = OB.s1Seg(MA,13);
				
				SegFun = OB.sZmienWyr(SegFun,iOp-1,1,0);
				MA = OB.sZamienSeg(MA,OB.sZmienWyr(MA,0,iOp,7),7);
				MA = OB.sZamienSeg(MA,SegFun,13);

				GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa = MA;

				bWyb=false;
				iOp=0;
			}
		}		//Wybor Bohatera2
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==15)
		{
			//kOblicz O = GameObject.Find("Silnik").GetComponent<kOblicz>();
			//PodliczStatystyki(O.s1Seg(GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa,6),O.s1Seg(GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa,13));
			LosowanieReki(0,0,GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,5,25,10);
			LosowanieReki(0,1,GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,5,25,10);
		}		//Lososwanie Rak Graczy
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==16)
		{
			kOblicz O = GameObject.Find("Silnik").GetComponent<kOblicz>();
			PodliczStatystyki(O.s1Seg(GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa,6),O.s1Seg(GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa,13));
			NarysujWedlug(0,iKtoryGracz);
			bWyb = true;
			iOp=0;
			GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=17;
		}		//RYSOWANIE PLANSZY
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==17&&bCzyKlik==false)
		{
			iOp=-1;
			iOp = WyborMiedzy(2,'1',0);

			if(iOp!=-1)
			{
				kOblicz OB = GameObject.Find ("Silnik").GetComponent<kOblicz>();
				if(OB.iIleLin(OB.s1Seg(GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa,iOp))==0)
				{
					Debug.Log("XXXXXXXX "+OB.iIleLin(OB.s1Seg(GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa,iOp)));
					GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=18;
				}
				else
				{
					string Segm = OB.s1Seg(GameObject.Find("Mapa").GetComponent<kPlansza>().sMapa,iOp);
					Debug.Log(Segm);
					int x = OB.iIleLin(Segm);
					if(x==1)			//Gdy w stosie jest 1 karta
					{
						Debug.Log("asd kart jest : "+x);
						WypiszDoWyboru(1,'g',"",new Vector3(0,15,0),Segm,0,1);
					}
					else
					{
						if(x==2)		//Gdy w stosie sa 2 karty
						{
							Debug.Log("asd kart jest : "+x);
							WypiszDoWyboru(1,'g',"",new Vector3(0,15,0),Segm,0,2);
						}
						else			//Gdy w stosie jest wiecej niz 2 karty karty
						{
							Debug.Log("asd kart jest : "+x);
							WypiszDoWyboru(1,'g',"",new Vector3(0,15,0),Segm,0,x-1);
						}
					}
					bWyb=true;bCzyKlik=true;
					GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=20;
					iOp=-1;
				}
			}
		}		//ROZGRYWKA: Decyzja
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==18)
		{
			WypiszDoWyboru(0,'f',"W tym stosie nie ma kart",new Vector3(0,15,0),"",0,0);
			bWyb=true;
			GameObject.Find("Main Camera").GetComponent<kGra>().iKrok = 19;
		}		//Wybrano Stos bez Kart
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==19&&bCzyKlik==false)
		{
			iOp = WyborMiedzy(0,'f',0);
			if(iOp==1)
			{
				bWyb=true;
				GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=17;
			}
			iOp = -1;
		}		//Kliknij w puste pole i cofnij do kroku 17
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==20&&bCzyKlik==false)
		{
			Debug.Log("krok 20\t\tstos chyba");
			bWyb=true;
			//iOp = -1;
			iOp = WyborMiedzy(3,'g',0);
			if(iOp!=-1)
			{
				//string Parent = HI.collider.transform.parent.name;
				RY = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(RY, out HI) && Input.GetMouseButton(0))
				{
					if(iOp==0)
					{
						GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=17;
						//bWyb=false;
					}
					else
					{
						Debug.Log("Wybrano karte do rzucenia albo czegos innego");
						switch(iKtoryGracz)
						{
						case 0:
						{
							if(sOP=="s0")		//bohater1
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							if(sOP=="s1")		//bufy1
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,1);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							if(sOP=="s2")		//jednostki1
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,3);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							if(sOP=="s3")		//reka1
							{
								bWyb=true;
								if(iOp<26)		//gdy wybrano jednostke
								{
								WypiszDoWyboru(2,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								}
								else			//gdy wybrano buf
								{
									WypiszDoWyboru(6,'h',"",new Vector3(0,15,0),"",0,0);
									GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								}
								bCzyKlik=true;
							}
							/*if(sOP=="s4")		//Talia1
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}*/
							if(sOP=="s5")		//Zuzyte1
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}


							if(sOP=="s7")		//Bohater2
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							if(sOP=="s8")		//bufy2
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							if(sOP=="s9")		//jednostki2
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							if(sOP=="s12")		//Zuzyte2
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							break;
						}
						case 1:
						{
							if(sOP=="s0")		//Bohater1
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							if(sOP=="s1")		//Bufy1
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							if(sOP=="s2")		//Jednostki1
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}

							if(sOP=="s5")		//Zuzyte1
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}


							if(sOP=="s7")		//Bohater2
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							if(sOP=="s8")		//Bufy2
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							if(sOP=="s9")		//Jednostki2
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							if(sOP=="s10")		//Reka2
							{
								bWyb=true;
								//WypiszDoWyboru(2,'h',"",new Vector3(0,15,0),"",0,0);
								//GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								if(iOp<26)
								{
									WypiszDoWyboru(2,'h',"",new Vector3(0,15,0),"",0,0);
									GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								}
								else
								{
									WypiszDoWyboru(6,'h',"",new Vector3(0,15,0),"",0,0);
									GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								}
								bCzyKlik=true;
							}
							if(sOP=="s12")		//Zuzyte2
							{
								bWyb=true;
								WypiszDoWyboru(4,'h',"",new Vector3(0,15,0),"",0,0);
								GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=21;
								bCzyKlik=true;
							}
							break;
						}
						}
					}
				}
				bWyb=true;
			}
		}		//Wybieramy karte ze stosu wybranego w kroku 17
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==21&&bCzyKlik==false)
		{
			Debug.Log("Krok 21");
			int Wyb = WyborMiedzy(2,'h',iOp);
			Debug.Log ("Wyb = "+Wyb);
			if(Wyb==1)		//wyrzucono jako atak
			{
				kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();

				if(iKtoryGracz==0)
				{
					WypiszDoWyboru(3,'k',"Wybierz Pole",new Vector3(0,15,0),OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,2),0,3);
				}
				if(iKtoryGracz==1)
				{
					WypiszDoWyboru(3,'k',"Wybierz Pole",new Vector3(0,15,0),OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,9),0,3);
				}

				GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=22;
				bWyb=true;
				//bCzyKlik=true;
			}
			if(Wyb==2)		//wyrzucono jako obrone
			{
				kOblicz OB = GameObject.Find("Silnik").GetComponent<kOblicz>();
				
				if(iKtoryGracz==0)
				{
					WypiszDoWyboru(3,'k',"Wybierz Pole",new Vector3(0,15,0),OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,2),0,3);
				}
				if(iKtoryGracz==1)
				{
					WypiszDoWyboru(3,'k',"Wybierz Pole",new Vector3(0,15,0),OB.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,9),0,3);
				}

				GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=22;
				bWyb=true;
			}
			if(Wyb==3)		//wyrzucono jako buf
			{
				bWyb=true;
			}
			if(Wyb==0)		//kliknieto pole
			{
				GameObject.Find("Main Camera").GetComponent<kGra>().iKrok=17;
				bWyb=true;
				bCzyKlik=true;
			}
			sOP = Wyb.ToString();
		}		//Atak, obrona, czy zmiana funkcji
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==22&&bCzyKlik==false)
		{
			int iX = WyborMiedzy(4,'k',iOp);		//Wybierz pole do wyrzucenia
			if(iX != -2)
			{
				if(iX == -1)
				{
					bCzyKlik=true;
					bWyb=true;
					GameObject.Find("Main Camera").GetComponent<kGra>().iKrok = 17;
					Destroy(GameObject.Find("Tlok"));
				}
				else
				{
				//Zagraj Karte
					
					kOblicz O = GameObject.Find ("Silnik").GetComponent<kOblicz>();
					string Calosc = GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa;

					if((O.s1Lin(O.s1Seg(Calosc,2),iX)=="0"&&iKtoryGracz==0)||(O.s1Lin(O.s1Seg(Calosc,9),iX)=="0"&&iKtoryGracz==1))

					{
						string SegRek="", SegJed="", SegFun="";

						//jesli Gracz1
						if(iKtoryGracz==0)
						{
							SegRek = O.s1Seg(Calosc,3); SegJed = O.s1Seg(Calosc,2); SegFun = O.s1Seg(Calosc,6);
						}
						//jesli Gracz2
						if(iKtoryGracz==1)
						{
							SegRek = O.s1Seg(Calosc,10); SegJed = O.s1Seg(Calosc,9); SegFun = O.s1Seg(Calosc,13);
						}


						Debug.Log(Calosc+"     "+SegFun+"     "+SegJed+"     "+SegRek);
						Debug.Log (iOp);


						//dodaj jednostke
							//jesli Gracz1
						if(iKtoryGracz==0)
						{
						SegJed = O.sZmienWyr(SegJed,iX,iOp,0);
						Calosc = O.sZamienSeg(Calosc,SegJed,2);
						}
							//jesli Gracz2
						if(iKtoryGracz==1)
						{
							SegJed = O.sZmienWyr(SegJed,iX,iOp,0);
							Calosc = O.sZamienSeg(Calosc,SegJed,9);
						}


						//usun z reki
						for(int i=0,j=O.iIleLin(SegRek);i<j;i++)
						{
							if(iOp==O.iSt_In(SegRek,i))
							{
								SegRek = O.sZmienWyr(SegRek,i,0,0);
								SegRek = O.sUsun0(SegRek);
								
								if(iKtoryGracz==0)
								{
									Calosc = O.sZamienSeg(Calosc,SegRek,3);
								}
								if(iKtoryGracz==1)
								{
									Calosc = O.sZamienSeg(Calosc,SegRek,10);
								}
								
								i=j;
							}
						}


						//dodaj funkcje
							//jesli Gracz1
						if(iKtoryGracz==0)
						{
							if(int.Parse (sOP)==1)
								SegFun = O.sZmienWyr(SegFun,iOp-1,1,0);
							if(int.Parse (sOP)==2)
								SegFun = O.sZmienWyr(SegFun,iOp-1,2,0);
							Calosc = O.sZamienSeg(Calosc,SegFun,6);
						}
							//jesli Gracz2
						if(iKtoryGracz==1)
						{
							if(int.Parse (sOP)==1)
								SegFun = O.sZmienWyr(SegFun,iOp-1,1,0);
							if(int.Parse (sOP)==2)
								SegFun = O.sZmienWyr(SegFun,iOp-1,2,0);
							Calosc = O.sZamienSeg(Calosc,SegFun,13);
						}
						Debug.Log(Calosc+"     "+SegFun+"     "+SegJed+"     "+SegRek+"     Gracz"+(iKtoryGracz+1));
						GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa = Calosc;
						
						
						
						
						
						
						GameObject.Find("Main Camera").GetComponent<kGra>().iKrok = 24;
					}
					else
					{
						GameObject.Find("Main Camera").GetComponent<kGra>().iKrok = 17;
					}

					
					bCzyKlik=true;
					bWyb=true;

					
					Destroy(GameObject.Find("Tlok"));
				}
			}
			
			//bCzyKlik=true;
		}		//Wybierz Pole do Wyrzucenia
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==23&&bCzyKlik==false)
		{
			iOp = WyborMiedzy(0,'l',0);
			if(iOp!=0)
			{
				GameObject.Find ("Main Camera").GetComponent<kGra>().iKrok=16;
				bWyb=true;
			}
		}
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==24)
		{
			{
				Destroy (GameObject.Find ("Guziki"));
				Destroy (GameObject.Find ("Segmenty"+iKtoryGracz));
				Destroy (GameObject.Find ("Napisy"));
			}

			iKtoryGracz++;
			if(iKtoryGracz>1)
				iKtoryGracz=0;

			kOblicz O = GameObject.Find("Silnik").GetComponent<kOblicz>();
			PodliczStatystyki(O.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,6),O.s1Seg(GameObject.Find ("Mapa").GetComponent<kPlansza>().sMapa,13));
			bWyb=true;
			GameObject.Find ("Main Camera").GetComponent<kGra>().iKrok=16;

			if(CzyGracz1Spasowal&&CzyGracz2Spasowal)
			{
				iRunda++;
				if(iRunda<3)
				{
					{
						int x=(Atak1-Obrona2)*Morale1/100,y=(Atak2-Obrona1)*Morale2/100;
						if(x<y)
						{
							iZwyciestwo--;
							WypiszDoWyboru(0,'l',"Runde wygral Gracz2",new Vector3(0,15,0),"",0,0);
						}
						else
						{
							if(x>y)
							{
								iZwyciestwo++;
								WypiszDoWyboru(0,'l',"Runde wygral Gracz1",new Vector3(0,15,0),"",0,0);
							}
							else
							{
								WypiszDoWyboru(0,'l',"Runda zakonczyla sie remisem",new Vector3(0,15,0),"",0,0);
							}
						}
					}
					GameObject.Find ("Main Camera").GetComponent<kGra>().iKrok=23;
					OdswiezMape();
					CzyGracz1Spasowal=false;
					CzyGracz2Spasowal=false;
					bWyb=true;
					//czyja runda : jakis obiekt endgame (klik i destroy)
				}
				else
				{
					if(iZwyciestwo<0)
					{
						WypiszDoWyboru(0,'m',"WYGRAL GRACZ2",new Vector3(0,15,0),"",0,0);
					}
					else
					{
						if(iZwyciestwo>0)
						{
							WypiszDoWyboru(0,'m',"WYGRAL GRACZ1",new Vector3(0,15,0),"",0,0);
						}
						else
						{
							WypiszDoWyboru(0,'m',"REMIS",new Vector3(0,15,0),"",0,0);
						}
					}
					GameObject.Find ("Main Camera").GetComponent<kGra>().iKrok=25;
					bWyb=true;
					Destroy (GameObject.Find("Mapa"));
					bCzyKlik=true;
				}
			}
			else
			{
				if(CzyGracz1Spasowal)
				{
					iKtoryGracz=1;
				}
				if(CzyGracz2Spasowal)
				{
					iKtoryGracz=0;
				}
			}

		}		//Miedzy rundami
		if(GameObject.Find("Main Camera").GetComponent<kGra>().iKrok==25&&bCzyKlik==false)
		{
			iOp = WyborMiedzy(0,'m',0);
			if(iOp!=0)
			{
				//GameObject.Find ("Main Camera").GetComponent<kGra>().iKrok=16;
				//bWyb=true;
				Debug.Log ("KONIEC GRYYY");
			}
		}		//ENDGAME

		if(Input.GetMouseButton(0))
		{
			iDlugoscKlikniecia=5;
		}
		else
		{
			if(iDlugoscKlikniecia>-1)
			iDlugoscKlikniecia-=1;
		}
		if(iDlugoscKlikniecia<=1)
		{
			bCzyKlik=false;
		}
		else
		{
			bCzyKlik=true;
		}
	}
}
