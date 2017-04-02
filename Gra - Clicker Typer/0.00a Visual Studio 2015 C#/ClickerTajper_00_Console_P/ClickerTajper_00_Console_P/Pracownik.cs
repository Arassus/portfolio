using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ClickerTajper_00_Console_P
{
    class Pracownik
    {
        public ListView Projekty = new ListView();
        public Button Widok_Button = new Button();
        public Button Zaplac_Button = new Button();

        public int MineloDni, Zasoby_Budzet;
        private int DzienDodania;

        public bool MoznaKupic = false;

        public delegate string dLosWyr(string Param1);
        public dLosWyr Losowanie;

        public Pracownik()
        {
            DomyslneProjekty(new Point(0, 200), 200, 400, View.Details);
            DomyslnyWidok_Button(new Point(400, 350), 50, 50);
            DomyslnyZaplac_Button(new Point(450, 350), 50, 50);

            SchowajKontrolki();
        }
        private void DomyslneProjekty(Point Lokalizacja, int Wysokosc, int Szerokosc, View Widok)
        {
            Projekty.Location = Lokalizacja;
            Projekty.Width = Szerokosc;
            Projekty.Height = Wysokosc;
            Projekty.View = Widok;

            Projekty.Columns.Add("[N] Nazwisko");
            Projekty.Columns.Add("[I] Imie");
            Projekty.Columns.Add("[$] Wyplata");
            Projekty.Columns.Add("[#] Norma");
        }
        private void DomyslnyWidok_Button(Point Lokalizacja, int Wysokosc, int Szerokosc)
        {
            Widok_Button.Location = Lokalizacja;
            Widok_Button.Width = Szerokosc;
            Widok_Button.Height = Wysokosc;

            Widok_Button.BackgroundImage = Image.FromFile("Obrazki/Widok.png");
        }
        private void DomyslnyZaplac_Button(Point Lokalizacja, int Wysokosc, int Szerokosc)
        {
            Zaplac_Button.Location = Lokalizacja;
            Zaplac_Button.Width = Szerokosc;
            Zaplac_Button.Height = Wysokosc;

            Zaplac_Button.BackgroundImage = Image.FromFile("Obrazki/Kup.png");
        }
        private void OdswiezZaplac_Button()
        {
            int Suma = SumaWyrazowZListView(ref Projekty, 2);
            Console.WriteLine("Suma kosztow :" + Suma);
            if (Suma > Zasoby_Budzet)
            {
                MoznaKupic = false;
                Zaplac_Button.BackgroundImage = Image.FromFile("Obrazki/KupMinus.png");
            }
            else
            {
                MoznaKupic = true;
                Zaplac_Button.BackgroundImage = Image.FromFile("Obrazki/KupPlus.png");
            }
        }
        private void PokazKontrolki()
        {
            Widok_Button.Show();
            Zaplac_Button.Show();
        }
        private void SchowajKontrolki()
        {
            Widok_Button.Hide();
            Zaplac_Button.Hide();
        }
        public int SumaWyrazowZListView(ref ListView L, int ID)
        {
            int Zwracana = 0;

            for (int i = 0, j = L.SelectedItems.Count; i < j; i++)
            {
                Zwracana += int.Parse(L.SelectedItems[i].SubItems[ID].Text);
            }

            return Zwracana;
        }
        private bool MineloInafDni_ByDodacProjekt()
        {
            if (MineloDni < DzienDodania)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private string WylosujParametry(char ZnakPomiedzy, char ZnakKonczacy)
        {
            string Zwracany = null;

            Zwracany += Losuj_Deadline(ZnakPomiedzy);
            //Zwracany += Losuj_Norma(ZnakPomiedzy);
            Zwracany += Losuj_Wynagrodzenie(ZnakPomiedzy);
            Zwracany += Losuj_Koszt(ZnakPomiedzy);

            return Zwracany + ZnakKonczacy;
        }
        private string Losuj_Nazwa(char ZnakPomiedzy)
        {
            Random r = new Random();
            string Zwracany = Losowanie("nazwisko");
            Console.WriteLine("Wylosowano nazwisko : " + Zwracany);
            return Zwracany + ZnakPomiedzy;
        }
        private string Losuj_Deadline(char ZnakPomiedzy)
        {
            Random r = new Random();
            string Zwracany = Losowanie("imie");
            Console.WriteLine("Wylosowano imie : " + Zwracany);
            return Zwracany + ZnakPomiedzy;
        }
        private string Losuj_Norma(char ZnakPomiedzy)
        {
            Random r = new Random();
            string Zwracany = r.Next(1, 20).ToString() + ZnakPomiedzy;
            Console.WriteLine("Wylosowano Norma : " + Zwracany);
            return Zwracany;
        }
        private string Losuj_Wynagrodzenie(char ZnakPomiedzy)
        {
            Random r = new Random();
            string Zwracany = r.Next(2000, 5000).ToString() + ZnakPomiedzy;
            Console.WriteLine("Wylosowano Wynagrodzenie : " + Zwracany);
            return Zwracany;
        }
        private string Losuj_Koszt(char ZnakPomiedzy)
        {
            Random r = new Random();
            string Zwracany = r.Next(1, 20).ToString() + ZnakPomiedzy;
            Console.WriteLine("Wylosowano Koszt : " + Zwracany);
            return Zwracany;
        }
        public void Projekty_SelectionChanged(object sender, EventArgs e)
        {
            if (Projekty.SelectedItems.Count > 0)
            {
                PokazKontrolki();
                OdswiezZaplac_Button();
            }
            else
            {
                SchowajKontrolki();
            }
        }
        public void ZmienWidokProj(object sender, EventArgs e)
        {
            switch (Projekty.View)
            {
                case View.Details:
                    {
                        Projekty.View = View.LargeIcon;
                        break;
                    }
                case View.LargeIcon:
                    {
                        Projekty.View = View.List;
                        break;
                    }
                case View.List:
                    {
                        Projekty.View = View.SmallIcon;
                        break;
                    }
                case View.SmallIcon:
                    {
                        Projekty.View = View.Tile;
                        break;
                    }
                case View.Tile:
                    {
                        Projekty.View = View.Details;
                        break;
                    }
                default:
                    {
                        Projekty.View = View.Details;
                        break;
                    }
            }
        }
        public void DodajProjekt(string Parametry, char ZnakPomiedzy)
        {
            ListViewItem oLVI = new ListViewItem(Uniwersalne.WyciagnijWyraz(Losuj_Nazwa(ZnakPomiedzy), ';', 0));
            for (int j = Uniwersalne.IleWyrazow(Parametry, ';'), i = 0; i < j; i++)
            {
                oLVI.SubItems.Add(Uniwersalne.WyciagnijWyraz(Parametry, ZnakPomiedzy, i));
            }
            Projekty.Items.Add(oLVI);
        }
        public void RegularnieDodawajProjekty(object sender, EventArgs e)
        {
            if (MineloInafDni_ByDodacProjekt())
            {
                DodajProjekt(WylosujParametry(';', '|'), ';');
                Random r = new Random();
                DzienDodania += r.Next(1, 3);
                Console.WriteLine("\nDzien : " + MineloDni + "; NastepneDodanie : " + DzienDodania);
            }
        }
    }
}
