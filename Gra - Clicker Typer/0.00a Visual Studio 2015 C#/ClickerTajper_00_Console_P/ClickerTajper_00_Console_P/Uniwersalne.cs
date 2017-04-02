using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerTajper_00_Console_P
{
    class Uniwersalne
    {
        public static int IleSegmentow(string Tekst, char ZnakMiedzyWyrazami, char ZnakMiedzySegmentami)
        {
            int Zwracany = 0;
            for (int i = 0; i < Tekst.Length; i++)
            {
                if (Tekst[i] == ZnakMiedzySegmentami)
                {
                    Zwracany++;
                }
            }
            return Zwracany;
        }

        public static int IleWyrazow(string Segment, char ZnakMiedzyWyrazami)
        {
            int Zwracany = 0;
            for (int i = 0; i < Segment.Length; i++)
            {
                if (Segment[i] == ZnakMiedzyWyrazami)
                {
                    Zwracany++;
                }
            }
            return Zwracany;
        }

        public static int DlugoscWyrazu(string Text, char ZnakMiedzyWyrazami, int NrWyrazu, char ZnakMiedzySegmentami, int NrSegmentu)
        {
            int Zwracany = 0;
            for (int i = 0, j = 0, k = 0; i < Text.Length; i++)
            {
                if (Text[i] == ZnakMiedzySegmentami)
                {
                    k++;
                }
                else
                {
                    if (k == NrSegmentu)
                    {
                        if (Text[i] == ZnakMiedzyWyrazami)
                        {
                            j++;
                        }
                        else
                        {
                            if (j == NrWyrazu)
                            {
                                Zwracany++;
                            }
                        }
                    }
                }
            }
            return Zwracany;
        }
        public static int DlugoscWyrazu(string Segment, char ZnakMiedzyWyrazami, int NrWyrazu)
        {
            int Zwracany = 0;
            for (int i = 0, j = 0; i < Segment.Length; i++)
            {
                if (Segment[i] == ZnakMiedzyWyrazami)
                {
                    j++;
                }
                else
                {
                    if (j == NrWyrazu)
                    {
                        Zwracany++;
                    }
                }
            }
            return Zwracany;
        }

        public static string WyciagnijWyraz(string Text, char ZnakMiedzyWyrazami, int NrWyrazu, char ZnakMiedzySegmentami, int NrSegmentu)
        {
            string Zwracany = null;
            for (int i = 0, j = 0, k = 0; i < Text.Length; i++)
            {
                if (Text[i] == ZnakMiedzySegmentami)
                {
                    k++;
                }
                else
                {
                    if (k == NrSegmentu)
                    {
                        if (Text[i] == ZnakMiedzyWyrazami)
                        {
                            j++;
                        }
                        else
                        {
                            if (j == NrWyrazu)
                            {
                                Zwracany += Text[i];
                            }
                        }
                    }
                }
            }
            return Zwracany;
        }
        public static string WyciagnijWyraz(string Segment, char ZnakMiedzyWyrazami, int NrWyrazu)
        {
            string Zwracany = null;
            for (int i = 0, j = 0; i < Segment.Length; i++)
            {
                if (Segment[i] == ZnakMiedzyWyrazami)
                {
                    j++;
                }
                else
                {
                    if (j == NrWyrazu)
                    {
                        Zwracany += Segment[i];
                    }
                }
            }
            return Zwracany;
        }

        public static string WyciagnijSegment(string Tekst, char ZnakMiedzySegmentami, int NrSegmentu)
        {
            string Zwracany = null;
            for (int i = 0, j = 0; i < Tekst.Length; i++)
            {
                if (Tekst[i] == ZnakMiedzySegmentami)
                {
                    j++;
                }
                else
                {
                    if (j == NrSegmentu)
                    {
                        Zwracany += Tekst[i];
                    }
                }
            }
            return Zwracany;
        }


        public static void SegregacjaWyrazu_Rosnaco(ref string Wyraz)
        {
            int[] Znaki = new int[Wyraz.Length];

            PobierzZnaki_StrToInt(Wyraz, ref Znaki);

            Sortowanie(ref Znaki, 0, Znaki.Length - 1);

            PobierzZnaki_IntToStr(Znaki, ref Wyraz);
        }
        public static void SegregacjaWyrazu_Rosnaco(ref string Text, char ZnakMiedzyWyrazami, int NrWyrazu, char ZnakMiedzySegmentami, int NrSegmentu)
        {

        }
        
        private static void PobierzZnaki_StrToInt(string Wyraz, ref int[] Wyrazy)
        {
            for (int i = 0; i < Wyraz.Length; i++)
            {
                Wyrazy[i] = (int)Wyraz[i];
            }
        }
        private static void PobierzZnaki_IntToStr(int[] Wyrazy, ref string Wyraz)
        {
            Wyraz = null;
            for (int i = 0; i < Wyrazy.Length; i++)
            {
                Wyraz+=(char)Wyrazy[i];
            }
        }

        public static void Sortowanie(ref int[] tab, int poczatek, int koniec)
        {
            int i = poczatek;
            int j = koniec;
            int x = tab[(poczatek + koniec) / 2];
            do
            {
                while (tab[i] < x)
                    i++;

                while (tab[j] > x)
                    j--;

                if (i <= j)
                {
                    int Zamienna = tab[i];
                    tab[i] = tab[j];
                    tab[j] = Zamienna;

                    i++;
                    j--;
                }
            } while (i <= j);

            if (poczatek < j) Sortowanie(ref tab, poczatek, j);

            if (koniec > i) Sortowanie(ref tab, i, koniec);

        }
        public static void Sortowanie(ref double[] tab, int poczatek, int koniec)
        {
            int i = poczatek;
            int j = koniec;
            double x = tab[(poczatek + koniec) / 2];
            do
            {
                while (tab[i] < x)
                    i++;

                while (tab[j] > x)
                    j--;

                if (i <= j)
                {
                    double Zamienna = tab[i];
                    tab[i] = tab[j];
                    tab[j] = Zamienna;

                    i++;
                    j--;
                }
            } while (i <= j);

            if (poczatek < j) Sortowanie(ref tab, poczatek, j);

            if (koniec > i) Sortowanie(ref tab, i, koniec);

        }
        public static void Sortowanie(ref float[] tab, int poczatek, int koniec)
        {
            int i = poczatek;
            int j = koniec;
            float x = tab[(poczatek + koniec) / 2];
            do
            {
                while (tab[i] < x)
                    i++;

                while (tab[j] > x)
                    j--;

                if (i <= j)
                {
                    float Zamienna = tab[i];
                    tab[i] = tab[j];
                    tab[j] = Zamienna;

                    i++;
                    j--;
                }
            } while (i <= j);

            if (poczatek < j) Sortowanie(ref tab, poczatek, j);

            if (koniec > i) Sortowanie(ref tab, i, koniec);

        }


        public static void DodajWyraz(ref string Segment, string Wyraz)
        {
            string Operacyjny = null;
            for (int i = 0; i < Segment.Length - 1; i++)
            {
                Operacyjny += Segment[i];
            }
            Operacyjny += Wyraz + ";|";
            Segment = Operacyjny;
        }

        public static void WstawWyraz(ref string Segment, char ZnakMiedzyWyrazami, int GdzieWstawic_ID, string Wyraz)
        {
            string Operacyjny = null;
            bool CzyDodano = false;
            for (int i = 0, j = 0; i < Segment.Length; i++)
            {
                if (Segment[i] == ZnakMiedzyWyrazami) 
                {
                    j++; 
                }
                else 
                {
                    if (j == GdzieWstawic_ID && !CzyDodano)
                    {
                        Operacyjny += Wyraz+";";
                        CzyDodano = true;
                    }
                }
                Operacyjny += Segment[i]; 
            }
            Segment = Operacyjny;
        }
        
        public static void PodmienWyraz(ref string Segment, char ZnakMiedzyWyrazami, int KtoryPodmienic, string Wyraz)
        {
            string Operacyjny = null;
            bool CzyDodano = false;
            for (int i = 0, j = 0; i < Segment.Length; i++)
            {
                if (Segment[i] == ZnakMiedzyWyrazami)
                {
                    Operacyjny += Segment[i]; 
                    j++; 
                }
                else 
                {
                    if (j == KtoryPodmienic)
                    {
                        if (!CzyDodano)
                        {
                            Operacyjny += Wyraz;
                            CzyDodano = true;
                        }
                    }
                    else
                    {
                        Operacyjny += Segment[i];
                    }
                }
                //Operacyjny += Segment[i]; 
            }
            Segment = Operacyjny;
        }   

        public static void DodajSegment(ref string Text, string Segment)
        {
            Text+=Segment;
        }

        public static void WstawSegment(ref string Text, char ZnakMiedzySegmentami, int GdzieWstawic_ID, string Segment)
        {
            string Operacyjny=null;
            bool CzyDodano = false;
            for (int i = 0, j = 0; i < Text.Length; i++)
            {
                if (Text[i] == ZnakMiedzySegmentami)
                {
                    j++;
                }
                Operacyjny += Text[i];
                if (j == GdzieWstawic_ID && !CzyDodano)
                {
                    CzyDodano = true;
                    Operacyjny += Segment + "|";
                }
            }
            Text = Operacyjny;
        }
    }
}
