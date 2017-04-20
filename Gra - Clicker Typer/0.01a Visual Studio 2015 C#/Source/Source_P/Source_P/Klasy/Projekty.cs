using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using ClickerTajper_00_Console_P;

namespace Source_P.Klasy
{
    class Projekty : ListView
    {
        public bool bDopasujSzerokoscPrzyZmianie = true;
        private int DzienNowegoProjektu = 0;

        public delegate string WylosujWyraz(string Co);
        public WylosujWyraz dWylosujWyraz;      

        private Color[] Motyw;     ///0. tlo; 1. czcionka1; 2. czcionka2;         
        public Projekty(int[] Param, Color[] motyw, string[] Kolumny)
        {
            Motyw = motyw;
            Inicjalizacja(Param, Kolumny);

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
        private void Inicjalizacja(int[] Param, string[] Kolumny)
        {
            Console.WriteLine("1");
            ZmienPozycjeOkna(Param[0], Param[1]);
            Console.WriteLine("2");
            ZmienRozmiarOkna(Param[2], Param[3]);


            //Projekt oP = new Projekt(new string[] { "asd", "1000", "20" }, Motyw);
            //this.Items.Add(oP);


            Console.WriteLine("3");
            DodajKolumny(Kolumny);
            Console.WriteLine("4");
            DopasujSzerokoscKolumnDoOkna();

            Console.WriteLine("5");
            ZmienKolor();
        }
        public void DopasujRozmiarDoOkna(System.Drawing.Size NowyRozm)
        {
            this.Width = NowyRozm.Width - 10;
            this.Height = NowyRozm.Height - NowyRozm.Height/4;

            
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
        public void DodajProjekt(string[] Param)
        {
            Projekt oLVI = new Projekt(Param ,Motyw);
            Items.Add(oLVI);
        }
        public void WylosujProjekt(int Opinia)//{"Nazwa","Wynagrodzenie","Deadline","Nowrma","Opinia" };
        {
            Random R = new Random();
            string[] P = new string[] { dWylosujWyraz("imie"), (R.Next(20, 50) * Opinia).ToString(), ((Opinia) / 10).ToString(), (Opinia / R.Next(2, 5)).ToString(), (Opinia / R.Next(2, 5)).ToString() };
            DodajProjekt(P);
        }
        public void Update(object sender, EventArgs e)
        {

        }                                          
        public int GetKtoryDzienProjekt()
        {
            return DzienNowegoProjektu;
        }
        public void KiedyNowyProjekt()
        {
            Random R = new Random();
            DzienNowegoProjektu += R.Next(1, 5);
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
        public string[] GetSubItemy(int ID)
        {
            string[] Zwracana = new string[Items.Count];

            for (int i = 0; i < Items.Count; i++)
            {
                Zwracana[i] = Items[i].SubItems[ID].Text;
            }

            return Zwracana;
        }         
    }
}
