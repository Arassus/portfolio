using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSciezek : MonoBehaviour {
    int MAX = 10;
    GameObject[] Obiekty;
	// Use this for initialization
	void Start ()
    {
        Obiekty = new GameObject[MAX*MAX];
        for (int i = 0; i < Obiekty.Length; i++)
        {
            Obiekty[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (i > 9)
            {
                Obiekty[i].transform.position = new Vector3((i - 5) % MAX , -15, i / MAX );
            }
            else
            {
                Obiekty[i].transform.position = new Vector3(i , -15, i / MAX);
            }
            Obiekty[i].transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            Obiekty[i].name = i.ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
