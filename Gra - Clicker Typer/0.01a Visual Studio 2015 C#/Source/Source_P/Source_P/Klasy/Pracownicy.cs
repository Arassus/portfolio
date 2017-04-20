using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace Source_P.Klasy
{
    class Pracownicy : ListView
    {
        public bool bDopasujSzerokoscPrzyZmianie = true;
        private int DzienNowegoPracownika = 0;

        public delegate string WylosujWyraz(string Co);
        public WylosujWyraz dWylosujWyraz;

        private Color[] Motyw;     ///0. tlo; 1. czcionka1; 2. czcionka2;  
        public Pracownicy(int[] Param, Color[] motyw, string[] Kolumny)
        {
            Motyw = motyw;
            Inicjalizacja(Param, Kolumny);

        }
        private void Inicjalizacja(int[] Param, string[] Kolumny)
        {
            ZmienPozycjeOkna(Param[0], Param[1]);
            ZmienRozmiarOkna(Param[2], Param[3]);


            //Projekt oP = new Projekt(new string[] { "asd", "1000", "20" }, Motyw);
            //this.Items.Add(oP);


            DodajKolumny(Kolumny);
            DopasujSzerokoscKolumnDoOkna();

            ZmienKolor();
        }
        private void ZmienRozmiarOkna(int Szer, int Wyso)
        {
            this.Width = Szer;
            this.Height = Wyso;
        }
        private void ZmienPozycjeOkna(int X, int Y)
        {
            this.Left = X;
            this.Top = Y;
        }
        public void DopasujRozmiarDoOkna(System.Drawing.Size NowyRozm)
        {
            this.Width = NowyRozm.Width - 10;
            this.Height = NowyRozm.Height - NowyRozm.Height / 4;


            if (bDopasujSzerokoscPrzyZmianie)
                DopasujSzerokoscKolumnDoOkna();
        }
        private void DopasujSzerokoscKolumnDoOkna()
        {
            int NowaSzerokosc = Size.Width / Columns.Count - 2;
            for (int i = 0; i < Columns.Count; i++)
            {
                this.Columns[i].Width = NowaSzerokosc;
            }
        }
        private void DodajKolumny(string[] Kolumny)
        {
            for (int i = 0; i < Kolumny.Length; i++)
            {
                this.Columns.Add(Kolumny[i]);
            }

        }
        private void ZmienKolor()
        {
            BackColor = Motyw[0];
            ForeColor = Motyw[2];

            if (Items.Count != 0)
                for (int i = 0; i < Items.Count; i++)
                {
                    Items[i].BackColor = Motyw[0];
                    Items[i].ForeColor = Motyw[1];
                }
        }
        public void DodajPracownika(string[] Param)
        {
            Projekt oLVI = new Projekt(Param, Motyw);
            Items.Add(oLVI);
        }
        public void WylosujPracownika(int Opinia)//{"Nazwisko","Imie","Wynagrodzenie","Nowrma"};
        {
            Random R = new Random();
            string[] P = new string[] { dWylosujWyraz("nazwisko"), dWylosujWyraz("imie"), ((Opinia) / 10).ToString(), (Opinia / R.Next(2, 5)).ToString(), "" };
            DodajPracownika(P);
        }
        public int GetKtoryDzienPracownik()
        {
            return DzienNowegoPracownika;
        }
        public void KiedyNowyPracownik()
        {
            Random R = new Random();
            DzienNowegoPracownika += R.Next(1, 5);
        }
        public int SumaSubitemu(int ID, bool TylkoZaznaczone)
        {
            int Suma = 0;
            if (TylkoZaznaczone)
            {
                for (int i = 0; i < SelectedItems.Count; i++)
                {
                    Suma += int.Parse(Items[SelectedItems[i].Index].SubItems[ID].Text);
                }
            }
            else
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    Suma += int.Parse(Items[i].SubItems[ID].Text);
                }
            }
            return Suma;
        }
    }
}
