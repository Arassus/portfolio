using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Input;
using ClickerTajper_00_Console_P;

namespace Wisielec_P
{
    abstract class MiniGra
    {                     
        public Label Slowo_Label = new Label();
        public TextBox Slowo_TxtBx = new TextBox();
                                               
        public delegate string dL(string Parametr);
        public dL Losowanie;

        public delegate void dZ();
        public dZ ZwrocProjekt;
        public dZ PunktZaWyraz;
        public dZ PunktZaBlad;


        public MiniGra()
        {
        }

        public void DomyslnaKontrolka(Control C, int X, int Y, int Dlug, int Szer)
        {
            C.Location = new Point(X,Y);
            C.Size = new Size(Szer, Dlug); 
        }                                    
        public void WpisanoWyraz(object sender, EventArgs e)
        {
            JesliWyrazSieZgadza();
        }
        public void WcisnietoEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                JesliWyrazSieZgadza();
            }
        }
        public virtual void JesliWyrazSieZgadza()
        {
            if (Slowo_Label.Text == Slowo_TxtBx.Text)
            {
                MessageBox.Show("BRAVO, Odgadłeś Słowo\nPodniesiono Punkt");
                WylosujWyraz();
            }
        }
        public virtual void Zainicjalizuj(TabPage Gdzie, ref Baza o)
        {
            Gdzie.Controls.Add(Slowo_Label);

            Gdzie.Controls.Add(Slowo_TxtBx);
            Slowo_TxtBx.TextChanged += WpisanoWyraz;
            Slowo_TxtBx.KeyDown += WcisnietoEnter;                               

            Losowanie = o.WylosujWyraz;
            WylosujWyraz();
        }

        public virtual void Usun(TabPage Gdzie)
        {
            Gdzie.Controls.Remove(this.Slowo_Label);
            Gdzie.Controls.Remove(this.Slowo_TxtBx);
            //Gdzie.Controls.Remove(this.EntersprawdzaWyraz_ChkBx);
        }
        public virtual void WylosujWyraz()
        {                 
            Slowo_Label.Text = Losowanie("slowo");

            Slowo_TxtBx.Text = "";
        }
        private void WczytajOpinie()
        {
            //Output_Label.Text = "Opinia : " + Opinia.ToString();
        }                 
        public void Update(object sender, EventArgs e)
        {
            ZwrocProjekt();


            WczytajOpinie();
        }
    }
}
