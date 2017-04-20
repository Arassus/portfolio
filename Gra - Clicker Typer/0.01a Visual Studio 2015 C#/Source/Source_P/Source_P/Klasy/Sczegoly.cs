using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace Source_P.Klasy
{
    class Szczegoly : TabPage
    {                       
        public string[] Adresy;        //0.Avatar  1.Naglowek
        public Control[] C;
        //public delegate void DT(Size S, FontFamily F);
        //DT Temp;                                    

        public ComboBox Zajecia;
        public delegate void MinalDzien();
        public MinalDzien MD;
    }
    class Szczegoly_Proj : Szczegoly
    {
        private ListViewItem oLVI = new ListViewItem();

        public Szczegoly_Proj(string[] adresy, Size RozmiarOkna, FixedTabControl Gdzie, Color[] C, ListViewItem olvi)
        {
            MD += WypelnijLabel;
            oLVI = olvi;
            Adresy = adresy;
            Inicjalizacja(RozmiarOkna, C);
            DodajKontrolkiDo(ref Gdzie);
            //Temp = DopasujKontrolki
        }
        private void Inicjalizacja(Size R, Color[] C)
        {
            if (C != null)
                Init_Self(C);
            if (R != null)
                Init_C(R);
            Init_Adres();
        }
        private void Init_Adres()
        {
            if (Adresy != null)
            {
                for (int i = 0; i < Adresy.Length; i++)
                {
                    if (Adresy[i] != null)
                    {
                        LoadAdressFromID(i, Adresy[i]);
                    }
                }
            }
        }
        private void Init_C(Size R)
        {
            C = new Control[] { new Label(), new Label(), new Button() };
            DopasujKontrolkiDo(R);
        }
        private void LoadAdressFromID(int ID, string Adres)
        {
            switch (ID)
            {
                case 0:
                    {
                        C[0].BackgroundImage = Image.FromFile(Adres);
                        break;
                    }
                case 1:
                    {
                        Name = Adres;
                        Text = "Projekt " + Adres;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        public void DopasujKontrolkiDo(Size RozmiarOkna)
        {
            C[0].Size = new Size(100, 100);
            C[0].Location = new Point(0, 0);
            C[2].Size = new Size(100, 100);
            C[2].Location = new Point(100, 0);
            C[1].Size = new Size(200, 100);
            C[1].Location = new Point(0, 100);
            WypelnijLabel();
        }
        public void WypelnijLabel()
        {
            if (oLVI != null)
            {
                C[1].Text = "Wynagrodzenie : " + oLVI.SubItems[1].Text + " $\n";
                C[1].Text += "Deadline : " + oLVI.SubItems[2].Text + " Dni\n";
                C[1].Text += "Norma : " + oLVI.SubItems[3].Text + " Wyrazow\n";
                C[1].Text += "Opinia : " + oLVI.SubItems[4].Text + " #";
            }
        }
        public void DodajKontrolkiDo(ref FixedTabControl FTC)
        {
            if (FTC != null)
            {
                Controls.Add(C[0]);
                Controls.Add(C[1]);
                Controls.Add(C[2]);
                FTC.TabPages.Add(this);
            }
        }
        private void Init_Self(Color[] Col)
        {

            BackColor = Col[0];
            ForeColor = Col[3];
        }
    }
    class Szczegoly_Prac : Szczegoly
    {
        private ListViewItem oLVI = new ListViewItem();

        public Szczegoly_Prac(string[] adresy, Size RozmiarOkna, FixedTabControl Gdzie, Color[] C, ListViewItem olvi, bool Zatrudniony)
        {
            MD += WypelnijLabel;
            oLVI = olvi;
            Adresy = adresy;
            Inicjalizacja(RozmiarOkna, C);
            DodajKontrolkiDo(ref Gdzie);
            if (Zatrudniony)
            {
                Zajecia = new ComboBox();
                Zajecia.Items.Add("Bez zajecia");
                //Zajecia.Items.Add("Armida");
                Zajecia.SelectedIndex = 0;
                Zajecia.Location = new Point(200,0);
                Gdzie.TabPages[0].Controls.Add(Zajecia);
            }                                 
            //Temp = DopasujKontrolki
        }
        private void Inicjalizacja(Size R, Color[] C)
        {
            if (C != null)
                Init_Self(C);
            if (R != null)
                Init_C(R);
            Init_Adres();
        }
        private void Init_Adres()
        {
            if (Adresy != null)
            {
                for (int i = 0; i < Adresy.Length; i++)
                {
                    if (Adresy[i] != null)
                    {
                        LoadAdressFromID(i, Adresy[i]);
                    }
                }
            }
        }
        private void Init_C(Size R)
        {
            C = new Control[] { new Label(), new Label(), new Button() };
            DopasujKontrolkiDo(R);
        }
        private void LoadAdressFromID(int ID, string Adres)
        {
            switch (ID)
            {
                case 0:
                    {
                        C[0].BackgroundImage = Image.FromFile(Adres);
                        break;
                    }
                case 1:
                    {
                        Name = Adres;
                        Text = "Pracownik " + Adres;
                        break;
                    }
                case 2:
                    {
                        Name += " " + Adres;
                        Text += " " + Adres;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        public void DopasujKontrolkiDo(Size RozmiarOkna)
        {
            C[0].Size = new Size(100, 100);
            C[0].Location = new Point(0, 0);
            C[2].Size = new Size(100, 100);
            C[2].Location = new Point(100, 0);
            C[1].Size = new Size(200, 100);
            C[1].Location = new Point(0, 100);
            WypelnijLabel();
        }
        public void WypelnijLabel()
        {
            if (oLVI != null)
            {
                C[1].Text = "Wynagrodzenie : " + oLVI.SubItems[2].Text + " $\n";
                C[1].Text += "Norma : " + oLVI.SubItems[3].Text + " Projektow na dzien";               
            }
        }
        public void DodajKontrolkiDo(ref FixedTabControl FTC)
        {
            if (FTC != null)
            {
                Controls.Add(C[0]);
                Controls.Add(C[1]);
                Controls.Add(C[2]);
                FTC.TabPages.Add(this);
            }
        }
        private void Init_Self(Color[] Col)
        {

            BackColor = Col[0];
            ForeColor = Col[3];
        }
    }

}
