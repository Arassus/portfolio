using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ClickerTajper_00_Console_P;

namespace Wisielec_P
{
    class Przepisz:MiniGra
    {
        public CheckBox EntersprawdzaWyraz_ChkBx = new CheckBox();

        public Przepisz(ref int o)
        {                       
            DomyslnaKontrolka(Slowo_Label, 400, 0, 25, 200);
            Slowo_Label.Font = new Font("MS Sans Serif", 14f, FontStyle.Bold);

            DomyslnaKontrolka(Slowo_TxtBx, 400, 50, 50, 200);
            Slowo_TxtBx.Font = new Font("MS Sans Serif", 14f, FontStyle.Bold);

            DomyslnaKontrolka(EntersprawdzaWyraz_ChkBx, 400, 15, 50, 200);
            EntersprawdzaWyraz_ChkBx.Text = "Automatycznie sprawdzaj";
            EntersprawdzaWyraz_ChkBx.Checked = true;

            //DomyslnaKontrolka(Output_Label, 50, 300, 50, 200);
            //Output_Label.Font = new Font("MS Sans Serif", 14f, FontStyle.Bold);   

            Slowo_Label.Text = "";
        }
        public override void JesliWyrazSieZgadza()
        {
            if (Slowo_Label.Text == Slowo_TxtBx.Text)
            {
                PunktZaWyraz();   
                WylosujWyraz();
            }
        }
        public override void Zainicjalizuj(TabPage Gdzie, ref Baza o)
        {
            Gdzie.Controls.Add(Slowo_Label);
            //Gdzie.Controls.Add(Output_Label);
            Gdzie.Controls.Add(Slowo_TxtBx);
            Gdzie.Controls.Add(EntersprawdzaWyraz_ChkBx);  
            Slowo_TxtBx.TextChanged += WpisanoWyraz;
            Slowo_TxtBx.KeyDown += WcisnietoEnter;
            EntersprawdzaWyraz_ChkBx.CheckedChanged += ZmienionoEnterChkBx;
                  
            Losowanie = o.WylosujWyraz;
            WylosujWyraz();
        }
        public override void Usun(TabPage Gdzie)
        {
            Gdzie.Controls.Remove(this.Slowo_Label);
            Gdzie.Controls.Remove(this.Slowo_TxtBx);
            Gdzie.Controls.Remove(this.EntersprawdzaWyraz_ChkBx);
            //Gdzie.Controls.Remove(this.Output_Label);
        }
        public override void WylosujWyraz()
        {
            Slowo_Label.Text = Losowanie("slowo");

            Slowo_TxtBx.Text = "";
        }




        public void ZmienionoEnterChkBx(object sender, EventArgs e)
        {
            if (!EntersprawdzaWyraz_ChkBx.Checked)
            {
                Slowo_TxtBx.TextChanged -= WpisanoWyraz;
                Slowo_TxtBx.KeyDown += WcisnietoEnter;
            }
            else
            {
                Slowo_TxtBx.KeyDown -= WcisnietoEnter;
                Slowo_TxtBx.TextChanged += WpisanoWyraz;
            }
        }
    }
}
