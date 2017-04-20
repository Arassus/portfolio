using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace Source_P.Klasy
{
    class Minigra : TabPage
    {                                      
        //public ContainerControl Kontrolki = new ContainerControl();
        public Control[] Kontrolki;
        public delegate void Iwent();
        public Iwent Sukces;
        public Iwent NieudanaProba;
        public Iwent Porazka;
        public virtual void DopasujKontrolki(Size S)
        { }
    }    
}
