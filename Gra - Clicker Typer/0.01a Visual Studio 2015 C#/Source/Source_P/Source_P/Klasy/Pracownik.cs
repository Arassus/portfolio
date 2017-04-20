using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace Source_P.Klasy
{
    class Pracownik : ListViewItem
    {
        private Color[] Motyw;
        public Pracownik(string[] param, Color[] motyw)
        {
            Motyw = motyw;
            if (param != null)
                for (int i = 0; i < param.Length; i++)
                {
                    if (i > 0)
                    {
                        SubItems.Add("");
                    }
                    SubItems[i].Text = param[i];
                }
            this.ImageIndex = 0;
        }
    }
}
