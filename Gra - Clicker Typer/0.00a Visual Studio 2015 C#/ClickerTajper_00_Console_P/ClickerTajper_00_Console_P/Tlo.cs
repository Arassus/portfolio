using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickerTajper_00_Console_P
{
    class Tlo
    {
        public TabControl Pola = new TabControl();

        public Tlo()
        {
            DomyslnePola();
        }

        public void DomyslnePola()
        {
            Pola.TabPages.Add("Zatrudnianie");
            Pola.TabPages.Add("Praca");

            Pola.Width = 700;
            Pola.Height = 500;

            Pola.TabPages[0].BackgroundImage = System.Drawing.Image.FromFile("Obrazki/Tab_Tlo.png");
            Pola.TabPages[1].BackgroundImage = System.Drawing.Image.FromFile("Obrazki/Tab_Tlo.png");
        }
    }
}
