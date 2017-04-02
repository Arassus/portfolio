using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ClickerTajper_00_Console_P
{
    class Zasoby
    {
        public ListView Projekty = new ListView(), Pracownicy = new ListView();

        public Label Lejbel = new Label();
        public int Opinia, Budzet;



        public Label Slowo_Label = new Label();
        public TextBox Slowo_TextBox = new TextBox();

        public ComboBox KtoCo_ComboBox = new ComboBox();
        public CheckBox KtoCo_CheckBox = new CheckBox();



        public delegate void dG();
        public dG NowaGra;
        public dG StaraGra;
        


        public Zasoby(int opinia, int budzet, Point LblLoc, int LblWys, int LblSzer, string SlowoDomyslne)
        {
            DomyslneProjekty(new Point(0, 0), 200, 400, View.Details);
            DomyslnePracownicy(new Point(0, 200), 200, 400, View.Details);
            DomyslneSlowa(new Point(400, 0), new Size(300, 30), new Point(400, 30), new Size(300, 100));
            DomyslneKtoCo(new Point(400, 400), new Size(200, 50), new Point(610, 400), new Size(100, 20));

            Opinia = opinia;
            Budzet = budzet;

            Domyslny_BudzetLabel(LblLoc, LblWys, LblSzer);

            Slowo_Label.Text = SlowoDomyslne;
        }

        private void Domyslny_BudzetLabel(Point Lokalizacja, int Wysokosc, int Szerokosc)
        {                                   
            Lejbel.Location = Lokalizacja;
            Lejbel.Height = Wysokosc;
            Lejbel.Width = Szerokosc;
            Lejbel.Font = new Font("MS Sans Serif", 14f, FontStyle.Bold);
            Lejbel.Text = "Opijnia : " + Opinia.ToString() + "\n\rBudzet : " + Budzet.ToString();
            Lejbel.BackColor = Color.Transparent;
            Lejbel.ForeColor = Color.Black;
            OdswiezLabel();
        }
        private void DomyslneProjekty(Point Lokalizacja, int Wysokosc, int Szerokosc, View Widok)
        {
            Projekty.Location = Lokalizacja;
            Projekty.Width = Szerokosc;
            Projekty.Height = Wysokosc;
            Projekty.View = Widok;

            Projekty.Columns.Add("[@] Nazwa");
            Projekty.Columns.Add("[X] DeadLine");
            Projekty.Columns.Add("[#] Norma");
            Projekty.Columns.Add("[$] Wynagrodzenie");
            Projekty.Columns.Add("[-] Koszt");
        }
        private void DomyslnePracownicy(Point Lokalizacja, int Wysokosc, int Szerokosc, View Widok)
        {
            Pracownicy.Location = Lokalizacja;
            Pracownicy.Width = Szerokosc;
            Pracownicy.Height = Wysokosc;
            Pracownicy.View = Widok;

            Pracownicy.Columns.Add("[N] Nazwisko");
            Pracownicy.Columns.Add("[I] Imie");
            Pracownicy.Columns.Add("[$] Wyplata");
            Pracownicy.Columns.Add("[#] Norma");
            Pracownicy.Columns.Add("[^] Pracuje Nad");
        }
        private void DomyslneSlowa(Point Lab_Loc, Size Lab_Siz, Point TxBx_Loc, Size TxBx_Siz)
        {
            Slowo_Label.Location = Lab_Loc;
            Slowo_Label.Size = Lab_Siz;
            Slowo_Label.Font = new Font("MS Sans Serif", 14f, FontStyle.Bold);        
                                       
            Slowo_TextBox.Location = TxBx_Loc;
            Slowo_TextBox.Size = TxBx_Siz;  
            Slowo_TextBox.Font = new Font("MS Sans Serif", 14f, FontStyle.Bold);
        }
        private void DomyslneKtoCo(Point Combo_Loc, Size Combo_Size, Point Check_Loc, Size Check_Size)
        {
            KtoCo_ComboBox.Location = Combo_Loc;
            KtoCo_ComboBox.Size = Combo_Size;

            KtoCo_CheckBox.Location = Check_Loc;
            KtoCo_CheckBox.Size = Check_Size;
            KtoCo_CheckBox.Text = "Auto";
        }

        public void OdswiezLabel()
        {
            Lejbel.Text = "Opijnia : " + Opinia.ToString() + "\n\rBudzet : " + Budzet.ToString();
        }
        public void TransjakcjaOdejmij(int Stawka_Opinia, int Stawka_Budzet, int Stawka_Morale)
        {
            Opinia -= Stawka_Opinia;
            Budzet -= Stawka_Budzet;
        }
        public void TransjakcjaDodaj(int Stawka_Opinia, int Stawka_Budzet, int Stawka_Morale)
        {
            Opinia += Stawka_Opinia;
            Budzet += Stawka_Budzet;
        }
        public void PokazKontrolki()
        {
            Slowo_Label.Show();
            Slowo_TextBox.Show();
        }
        public void UkryjKontrolki()
        {
            Slowo_Label.Hide();
            Slowo_TextBox.Hide();
        }
        public void PokazKtoCo()
        {
            KtoCo_ComboBox.Show();
            KtoCo_CheckBox.Show();
        }
        public void UkryjKtoCo()
        {
            KtoCo_ComboBox.Hide();
            KtoCo_CheckBox.Hide();
        }
        public void WpisanoSlowo()
        {
            if (Projekty.SelectedItems.Count != 0)
            {
                int StaraWart = int.Parse(Projekty.SelectedItems[0].SubItems[2].Text);
                --StaraWart;
                Projekty.SelectedItems[0].SubItems[2].Text = StaraWart.ToString();

                if (StaraWart < 0)
                {
                    ZwrocProjekt();
                }
            }  
        }
        public void SpieprzonoSprawe()
        {
            Opinia -= 1;
            OdswiezLabel();
        }
        public void ZwrocProjekt()
        {
            Budzet += int.Parse(Projekty.SelectedItems[0].SubItems[3].Text);
            Opinia += 2 * int.Parse(Projekty.SelectedItems[0].SubItems[4].Text);
            Projekty.SelectedItems[0].Remove();
            OdswiezLabel();
        }
        private void ZwrocProjekt(int ID)
        {
            Budzet += int.Parse(Projekty.Items[ID].SubItems[3].Text);
            Opinia += 2 * int.Parse(Projekty.Items[ID].SubItems[4].Text);
            Projekty.Items[ID].Remove();
            OdswiezLabel();
        }
        public void ZaladujComboBoxa(object sender, EventArgs e)
        {
            if (KtoCo_ComboBox.Items.Count != 0)
            for (int i = 0, j = Projekty.Items.Count; i < j; i++)
            {
                KtoCo_ComboBox.Items.RemoveAt(0);               
            }
            for (int i = 0, j = Projekty.Items.Count; i < j; i++)
            {
                KtoCo_ComboBox.Items.Add(Projekty.Items[i].Text);
            }
        }
        public void ComboBoxIdChanged(object sender, EventArgs e)
        {
            for (int i = 0, j = Pracownicy.SelectedItems.Count; i < j; i++)
            {
                if (Pracownicy.SelectedItems[i].SubItems.Count == 4)
                {
                    Pracownicy.SelectedItems[i].SubItems.Add(KtoCo_ComboBox.Text);
                }
                else
                {
                    Pracownicy.SelectedItems[i].SubItems[4].Text = KtoCo_ComboBox.Text;
                }
            }
        }
        public void ProjektyIdSelectChanged(object sender, EventArgs e)
        {
            if (Projekty.SelectedItems.Count > 0)
            {
                PokazKontrolki();
                NowaGra();
            }
            else
            {
                UkryjKontrolki();
                StaraGra();
            }
        }
        public void PracownicyIdSelectChanged(object sender, EventArgs e)
        {
            if (Pracownicy.SelectedItems.Count > 0)
            {
                PokazKtoCo();
            }
            else
            {
                UkryjKtoCo();
            }
        }
        public void PrzeliczNorme()//object sender, EventHandler e)
        {
            for (int i = 0, j = Projekty.Items.Count; i < j; i++)
            {
                int Wartosc = int.Parse(Projekty.Items[i].SubItems[2].Text);

                for (int x = 0, y = Pracownicy.Items.Count; x < y; x++)
                {
                    if (Pracownicy.Items[x].SubItems[4].Text == Projekty.Items[i].Text)
                    {
                        Wartosc -= int.Parse(Pracownicy.Items[x].SubItems[3].Text);
                    }
                }

                if (Wartosc < 0)
                {
                    for (int x = 0, y = Pracownicy.Items.Count; x < y; x++)
                    {
                        if (Pracownicy.Items[x].SubItems[4].Text == Projekty.Items[i].Text)
                        {
                            Pracownicy.Items[x].SubItems[4].Text = "";
                        }
                    }
                    ZwrocProjekt(i);
                    --i; --j;  
                }
                else
                {
                    Projekty.Items[i].SubItems[2].Text = Wartosc.ToString();
                }
            }
        }
    }
}
