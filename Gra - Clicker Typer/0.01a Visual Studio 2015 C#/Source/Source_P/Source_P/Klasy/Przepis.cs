using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace Source_P.Klasy
{
    class Przepis : Minigra
    {                                            
        int LiczbaProb;
        
        public Przepis(char Poziom, Iwent S,Iwent P,TabControl oTP, Color[] TColors,string Slowo)//Iwent[] Del)
        {
            Text = "Mini Gra";
            Kontrolki = new Control[] { new Label(), new TextBox() };
            Ustawienia_PoziomTrudnosci(Poziom);
            Inicjalizacja_Kontrolek();
            Sukces = S;// Del[0];
            Porazka = P;// Del[1];
            NieudanaProba = ZleWpisano;
            Pokoloruj(TColors);

            Kontrolki[0].Text = Slowo;
            oTP.TabPages.Add(this); 
        }

        private void Inicjalizacja_Kontrolek()
        {
            Kontrolki[0].Location = new Point(10, 10); 
            Controls.Add(Kontrolki[0]);

            Kontrolki[1].KeyDown += new KeyEventHandler(KliknietoEnter);
            Kontrolki[1].Location = new Point(10, 50);     
            Controls.Add(Kontrolki[1]);
        }
        private void Pokoloruj(Color[] TColors)
        {                            
            this.BackColor = TColors[1];
            this.ForeColor = TColors[3];        

            Kontrolki[0].ForeColor = TColors[4];
            //Kontrolki[0].BackColor = Color.Black;//TColors[4];

            Kontrolki[1].ForeColor = TColors[3];
            Kontrolki[1].BackColor = TColors[0];
        }

        private void KliknietoEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (Kontrolki[0].Text == Kontrolki[1].Text)
                {
                    Sukces();
                }
                else
                {
                    NieudanaProba();
                    if (LiczbaProb < 0)
                    {
                        Porazka();
                    }
                }
        }

        private void Ustawienia_PoziomTrudnosci(char Poziom)
        {
            switch (Poziom)
            {
                default:
                    {
                        LiczbaProb = 1;
                        break;
                    }
            }
        }
        private void ZleWpisano()
        {
            LiczbaProb--;
            MessageBox.Show("Wpisano zły wyraz");
        }
        public override void DopasujKontrolki(Size S)
        {
            Kontrolki[0].Width = S.Width / 2 - 60;
            Kontrolki[0].Height = S.Height/30;
            Kontrolki[0].Font = new Font(new FontFamily("OCR A Extended"), S.Height/40, GraphicsUnit.Pixel);

            Kontrolki[1].Width = S.Width / 2 - 60;
            Kontrolki[1].Top = S.Height / 12;
            Kontrolki[1].Font = new Font(new FontFamily("OCR A Extended"), S.Height / 40, GraphicsUnit.Pixel);
        }
        /*public void ZaznaczonoTabPage(object sender, EventArgs e)
        {
            for (int i = 0; i < Rynek_oTB.TabPages.Count; i++)
            {
                if (Rynek_oTB.SelectedIndex == i)
                {
                    Rynek_oTB.TabPages[i].BackColor = TColors[0];
                    Rynek_oTB.TabPages[i].ForeColor = TColors[3];
                }
                else
                {
                    Rynek_oTB.TabPages[i].BackColor = TColors[1];
                    Rynek_oTB.TabPages[i].ForeColor = TColors[3];
                }
            }
        } */
    }
}
