using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Build_00a_VS15.Klasy
{
    class Dijijijjikstyyra
    {
        int MAX = 999;

        public Vert[] V;
        public int[] G;//, K, W;
        public int k;

        //public Edge[] E;
        public EI[] Ei;

        public int IDStart, IDEnd;

        private string[] Wierzcholki;
        private int[] Dlugosci;

        public Dijijijjikstyyra()
        {
            V = new Vert[] { new Vert(200, 20, "A"), new Vert(20, 200, "B"), new Vert(300, 200, "C"), new Vert(500, 200, "D"), new Vert(200, 400, "E") };
            //V = new Vert[] { new Vert(100, 500, "A"), new Vert(500, 500, "B"), new Vert(200, 400, "C"), new Vert(400, 300, "D"), new Vert(600, 300, "E"), new Vert(200, 200, "F"), new Vert(600, 150, "G"), new Vert(200, 100, "H"), new Vert(600, 50, "I"), new Vert(700, 300, "J"), new Vert(300, 200, "K") };

            Ei = new EI[] { new EI(0, 1, false, 2), new EI(1, 4, false, 2), new EI(4, 2, false, 1), new EI(0, 2, false, 1), new EI(2, 3, false, 1) };
            //Ei = new EI[] { new EI(0, 1, false, 4), new EI(0, 2, false, 1), new EI(2, 3, false, 2), new EI(1, 4, false, 1), new EI(1, 3, false, 1), new EI(3, 4, false, 1), new EI(0, 5, false, 2), new EI(0, 7, false, 3), new EI(2, 5, false, 1), new EI(5, 10, false, 1), new EI(10, 3, false, 1), new EI(1, 9, false, 3), new EI(4, 9, false, 2), new EI(6, 9, false, 2), new EI(8, 9, false, 3), new EI(4, 6, false, 1), new EI(6, 8, false, 1), new EI(7, 8, false, 4), new EI(10, 6, false, 2) };

            IDStart = 0; IDEnd = 4;

            DomyslneWartosci();
        }

        public void NadajWartosci(string[] Param)
        {
            //V = null;
            string sTemp = "";
            char cTemp = 'x';
            int X = 0, Y = 0, Dl=0;
            bool bCzyJedkokier = false;
            string Nazwa = "";
            for (int i = 0; i < Param[0].Length; i++)
            {
                cTemp = Param[0][i];

                if (cTemp == '!')
                {
                    X = int.Parse(sTemp);
                    sTemp = "";
                }
                else
                {
                    if (cTemp == '@')
                    {
                        Y = int.Parse(sTemp);
                        sTemp = "";
                    }
                    else
                    {
                        if (cTemp == '#')
                        {
                            Nazwa = sTemp;
                            sTemp = "";
                        }
                        else
                        {
                            if (cTemp == ';')
                            {
                                DodajWert_ref(ref V, new Vert(X, Y, Nazwa));
                                //V = DodajWert(V, new Vert(X, Y, Nazwa));
                                sTemp = "";

                            }
                            else
                            {
                                sTemp += cTemp;
                            }
                        }
                    }
                }
            }
            if(Param[1]!="")
            for (int i = 0; i < Param[1].Length; i++)
            {
                cTemp = Param[1][i];

                if (cTemp == '!')
                {
                    X = int.Parse(sTemp);
                    sTemp = "";
                }
                else
                {
                    if (cTemp == '@')
                    {
                        Y = int.Parse(sTemp);
                        sTemp = "";
                    }
                    else
                    {
                        if (cTemp == '#')
                        {
                            bCzyJedkokier = bool.Parse(sTemp);
                            sTemp = "";
                        }
                        else
                        {
                            if (cTemp == '$')
                            {
                                Dl = int.Parse(sTemp);
                                sTemp = "";
                            }
                            else
                            {
                                if (cTemp == ';')
                                {
                                    DodajEdge_ref(ref Ei, new EI(X, Y, bCzyJedkokier, Dl));
                                    for (int j = 0; j < Ei.Length; j++)
                                    {
                                        Console.WriteLine(V[Ei[j].V1_ID].Nazwa+" "+ V[Ei[j].V2_ID].Nazwa+" "+ Ei[j].Dlugosc);
                                    }
                                    sTemp = "";

                                }
                                else
                                {
                                    sTemp += cTemp;
                                }
                            }
                        }
                    }
                }
            }
            NadajDlugosciIWierzcholki();
        }
        public int[] Output_OptymalnaSciezka()
        {
            int iKrok = IDEnd;
            //string Linia = V[IDEnd].Nazwa;
            int[] Temp = null;
            Temp = DodajInt(Temp, IDEnd);
            while (iKrok != IDStart)
            {
                for (int i = 0; i < V.Length; i++)
                {
                    if (V[i].Nazwa == Wierzcholki[iKrok])
                    {
                        Console.WriteLine(i.ToString());
                        iKrok = i;
                        //Linia = V[i].Nazwa + " -> " + Linia;
                        Temp = DodajInt(Temp, iKrok);
                        i = V.Length;
                    }
                }
            }
            //MessageBox.Show(Linia);
            //return Linia;
            //Console.WriteLine(Linia);
            return Temp;
        }
        private void NadajDlugosciIWierzcholki()
        {
            G = null;//= K = W = null;
            Dlugosci = null;
            for (int i = 0; i < V.Length; i++)
            {
                if (IDStart == i)
                {
                    Dlugosci = DodajInt(Dlugosci, 0);
                }
                else
                {
                    Dlugosci = DodajInt(Dlugosci, MAX);
                }
            }
            OdwrocTablice(ref Dlugosci);
            Wierzcholki = null;
            for (int i = 0; i < V.Length; i++)
            {
                if (IDStart == i)
                {
                    Wierzcholki = DodajString(Wierzcholki, "-");
                }
                else
                {
                    Wierzcholki = DodajString(Wierzcholki, "&");
                }
            }
            OdwrocTablice(ref Wierzcholki);
        }
        private void DomyslneWartosci()
        {
            G = null;//= K = W = null;        
            for (int i = 0; i < V.Length; i++)
            {
                if (IDStart == i)
                {
                    Dlugosci = DodajInt(Dlugosci, 0);
                }
                else
                {
                    Dlugosci = DodajInt(Dlugosci, MAX);
                }
            }
            OdwrocTablice(ref Dlugosci);
            Console.WriteLine(Dlugosci[0] + "  " + Dlugosci[1] + "  " + Dlugosci[2] + "  " + Dlugosci[3] + "  " + Dlugosci[4]);
            for (int i = 0; i < V.Length; i++)
            {
                if (IDStart == i)
                {
                    Wierzcholki = DodajString(Wierzcholki, "-");
                }
                else
                {
                    Wierzcholki = DodajString(Wierzcholki, "&");
                }
            }
            OdwrocTablice(ref Wierzcholki);
            Console.WriteLine(Wierzcholki[0] + "  " + Wierzcholki[1] + "  " + Wierzcholki[2] + "  " + Wierzcholki[3] + "  " + Wierzcholki[4]);       
        }

        public int[] Algorytm()
        {

            for (int i = 0; i < V.Length; i++)
            {                              
                k = IDNajmniejszego(Dlugosci, G);
                G = DodajInt(G, k);

                /////////////////////////////////////////K
                for (int ii = 0; ii < Ei.Length; ii++)
                {
                    if (Ei[ii].V1_ID == k)
                    {
                        Console.WriteLine("k:" + V[k].Nazwa + " E:" + Ei[ii].Dlugosc + " " + V[Ei[ii].V1_ID].Nazwa + ">" + V[Ei[ii].V2_ID].Nazwa);

                        if (Dlugosci[Ei[ii].V2_ID] > Dlugosci[k] + Ei[ii].Dlugosc)
                        {
                            Dlugosci[Ei[ii].V2_ID] = Dlugosci[k] + Ei[ii].Dlugosc;
                            Wierzcholki[Ei[ii].V2_ID] = V[k].Nazwa;
                        }
                        else
                        {
                            if (Dlugosci[Ei[ii].V2_ID] == Dlugosci[k] + Ei[ii].Dlugosc)
                            {                                                           
                                Wierzcholki[Ei[ii].V2_ID] += V[k].Nazwa;
                            }
                        }
                    }
                    if (Ei[ii].V2_ID == k)
                    {
                        Console.WriteLine("k:" + V[k].Nazwa + " E:" + Ei[ii].Dlugosc + " " + V[Ei[ii].V1_ID].Nazwa + ">" + V[Ei[ii].V2_ID].Nazwa);
                        //Dlugosci[Ei[ii].V1_ID] = Dlugosci[k] + Ei[ii].Dlugosc;   
                        if (Dlugosci[Ei[ii].V1_ID] > Dlugosci[k] + Ei[ii].Dlugosc)
                        {
                            Dlugosci[Ei[ii].V1_ID] = Dlugosci[k] + Ei[ii].Dlugosc;
                            Wierzcholki[Ei[ii].V1_ID] = V[k].Nazwa;
                        }
                        else
                        {
                            if (Dlugosci[Ei[ii].V1_ID] == Dlugosci[k] + Ei[ii].Dlugosc)
                            {                                                          
                                Wierzcholki[Ei[ii].V1_ID] += V[k].Nazwa;
                            }
                        }
                    }
                }                              
            }
            for(int i=0;i<Dlugosci.Length;i++)
            Console.Write(Dlugosci[i] + " ");
            Console.WriteLine("");

            for (int i = 0; i < Wierzcholki.Length; i++)
                Console.Write(Wierzcholki[i] + " ");
            Console.WriteLine("\n");
            return Output_OptymalnaSciezka();
        }

        private Vert[] WywalWert( Vert[] v, int ID)
        {
            Vert[] Temp = new Vert[V.Length-1];

            for (int i = 0, j = 0; i < V.Length; i++)
            {
                if (i != ID)
                {
                    Temp[j] = v[i];
                    j++;
                }
            }

            return Temp;
        }
        private Vert[] DodajWert(Vert[] v, Vert v0)
        {
            Vert[] Temp = null;//= new Vert[v.Length + 1];

            if (v == null)
            {
                Temp = new Vert[1] { v0 };         
            }
            else
            {
                Temp = new Vert[v.Length + 1];

                for (int i = 0; i < v.Length; i++)
                {
                    Temp[i] = v[i];
                }
                Temp[v.Length] = v0;
            }
            return Temp;
        }
        private void DodajWert_ref(ref Vert[] v, Vert v0)
        {
            Vert[] Temp = null;//= new Vert[v.Length + 1];

            if (v == null)
            {
                Temp = new Vert[1] { v0 };
            }
            else
            {
                Temp = new Vert[v.Length + 1];

                for (int i = 0; i < v.Length; i++)
                {
                    Temp[i] = v[i];
                }
                Temp[v.Length] = v0;
            }
            v = Temp;
        }
        private void DodajEdge_ref(ref EI[] v, EI v0)
        {
            EI[] Temp = null;//= new Vert[v.Length + 1];

            if (Ei == null)
            {
                Temp = new EI[1] { v0 };
            }
            else
            {
                Temp = new EI[Ei.Length + 1];

                Temp[0] = v0;
                for (int i = 0; i < Ei.Length; i++)
                {
                    Temp[i + 1] = Ei[i];
                }
            }
            Ei = Temp;
        }
        private string[] DodajString(string[] v, string v0)
        {
            string[] Temp = null;//= new Vert[v.Length + 1];

            if (v == null)
            {
                Temp = new string[1];

                Temp[0] = v0;
            }
            else
            {
                Temp = new string[v.Length + 1];

                Temp[0] = v0;
                for (int i = 0; i < v.Length; i++)
                {
                    Temp[i + 1] = v[i];
                }
            }
            return Temp;
        }
        private int[] DodajInt(int[] I, int i0)
        {
            int[] Temp = null;//= new Vert[v.Length + 1];

            if (I == null)
            {
                Temp = new int[1];

                Temp[0] = i0;
            }
            else
            {
                Temp = new int[I.Length + 1];

                Temp[0] = i0;
                for (int i = 0; i < I.Length; i++)
                {
                    Temp[i + 1] = I[i];
                }
            }
            return Temp;
        }
        private void OdwrocTablice(ref int[] X)
        {
            int temp;
            for (int i = 0; i < X.Length / 2; i++)
            {
                temp = X[i];
                X[i] = X[X.Length - 1 - i];
                X[X.Length - 1 - i] = temp;
            }
        }
        private void OdwrocTablice(ref string[] X)
        {
            string temp;
            for (int i = 0; i < X.Length / 2; i++)
            {
                temp = X[i];
                X[i] = X[X.Length - 1 - i];
                X[X.Length - 1 - i] = temp;
            }
        }
        private int IDNajmniejszego(ref int[] tab)
        {
            int ID = 0;
            for (int i = 1; i < tab.Length; i++)
            {
                if (tab[ID] > tab[i])
                {
                    ID = i;
                }
            }
            return ID;
        }   
        private int IDNajmniejszego(int[] tab, int[] Wyjatki)
        {                             
            bool Czymozna = true;
            int ID = MAX;
            for (int i = 0; i < tab.Length; i++)
            {                             
                if (Wyjatki != null)
                for (int j = 0; j < Wyjatki.Length; j++)
                    {                           
                        if (i == Wyjatki[j])
                        {
                            Czymozna = false;
                        }                       
                    }
                if (Czymozna)
                {
                    if (ID == MAX)
                    {
                        ID = i;
                    }
                    else
                    {
                        if (tab[ID] > tab[i])
                        {
                            ID = i;
                        }
                    }
                }
                Czymozna = true;            
            }                          
            return ID;
        } 
    }
}
