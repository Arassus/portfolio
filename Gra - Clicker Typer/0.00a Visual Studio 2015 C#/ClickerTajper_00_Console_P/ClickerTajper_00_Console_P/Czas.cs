using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ClickerTajper_00_Console_P
{
    class Czas
    {            
        public Timer Zegar = new Timer();
        public Label Zegar_Label = new Label();   

        //////////////////////////////////////////////////////////////////////////Regulacja
        public HScrollBar HScrollBar_1_1M = new HScrollBar();             ///////////////
        public HScrollBar HScrollBar_1M_100M = new HScrollBar();            //////////////

        public Button Button_1 = new Button();
        public Button Button_3600 = new Button();
        public Button Button_86400 = new Button();
        public Button Button_2595000 = new Button();



        private int imSek = DateTime.Now.Millisecond, iSek = DateTime.Now.Second, iMin = DateTime.Now.Minute, iGod = DateTime.Now.Hour, iDzi = DateTime.Now.Day, iMie = DateTime.Now.Month, iRok = DateTime.Now.Year;
        public int MineloDni = 0, MilisekundNaTick = 1, OpoznienieTicku = 1;

        public Czas()
        {

            DomyslnyLabel(Zegar_Label, "", new Point(710, 10), new Size(150, 65));
            Zegar_Label.Font = new Font("MS Sans Serif", 14f, FontStyle.Bold);
            Zegar_Label.ForeColor = Color.Black;
            DomyslnyZegar(Zegar);

            ////////////////////////////////////////////////////////////////////////////////Regulacja/////
         //   HScrollBar_1_1M.Location = new Point(680, 80);                          ///////////////////
         //   HScrollBar_1_1M.Width = 100;                                            //////////////////
         //   HScrollBar_1_1M.Minimum = 1;                                            /////////////////
        //    HScrollBar_1_1M.Maximum = 100000;                                       ////////////////
                                                                                      ///////////////
        //    HScrollBar_1M_100M.Location = new Point(680, 100);                      //////////////
           // HScrollBar_1M_100M.Width = 100;                                         /////////////
           // HScrollBar_1M_100M.Minimum = 1000000;                                   ////////////
            //HScrollBar_1M_100M.Maximum = 100000000;                                 ///////////
                                                                                      //////////
            DomyslnaRegulacja();                                                      /////////
        }
        ~Czas()
        {
            ;
        }
        private void DomyslnaRegulacja()
        {
            DomyslnyButton(ref Button_1, new Point(700, 80), new Size(25, 25), "Szybkosc1");
            DomyslnyButton(ref Button_3600, new Point(725, 80), new Size(25, 25), "Szybkosc2");
            DomyslnyButton(ref Button_86400, new Point(750, 80), new Size(25, 25), "Szybkosc3");
            DomyslnyButton(ref Button_2595000, new Point(775, 80), new Size(25, 25), "Szybkosc4");
        }
        private void DomyslnyButton(ref Button C,Point Lokalizacja, Size Rozmiar, string NazwaObrazka)
        {
            C.Location = Lokalizacja;
            C.Size = Rozmiar;

            if (NazwaObrazka != "")
            {
                C.BackgroundImage = Image.FromFile("Obrazki/"+NazwaObrazka+".png");
            }
        }
        public void PrzeliczCzas()
        {
            imSek += MilisekundNaTick;

            while (imSek > 59)
            {
                imSek -= 60;
                iSek += 1;
                if (iSek > 59)
                {
                    iSek -= 60;
                    iMin += 1;
                    if (iMin > 59)
                    {
                        iMin -= 60;
                        iGod += 1;
                        if (iGod > 23)
                        {
                            iGod -= 24;
                            iDzi += 1;
                            MineloDni += 1;
                            Console.Beep(200, 20);          /////////////////////////////////////dzwiek
                            if (CzyMoznaDodacMies())
                            {
                                iDzi -= iDzi - 1;
                                iMie += 1;
                                if (iMie > 12)
                                {
                                    iMie -= iMie - 1;
                                    iRok += 1;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void WypiszDate()
        {
            Zegar_Label.Text = imSek.ToString("D2") + ":" + iSek.ToString("D2") + ":" + iMin.ToString("D2") + ":" + iGod.ToString("D2") + '\n' + iRok.ToString("D2") + ":" + iMie.ToString("D2") + ":" + iDzi.ToString("D2") + '\n' + '\n' + "Dzien : "+MineloDni.ToString() + '\n' + "ms * " + MilisekundNaTick;
        }
        private bool CzyMoznaDodacMies()
        {
            bool bZwracany = false;

            switch (iDzi)
            {
                case 29:
                    {
                        if (iRok % 4 != 0 && iMie == 2)
                        {
                            bZwracany = true;
                        }
                        break;
                    }
                case 30:
                    {
                        if (iMie == 2)
                        {
                            bZwracany = true;
                        }
                        break;
                    }
                case 31:
                    {
                        if (iMie == 4 || iMie == 6 || iMie == 9 || iMie == 11)
                        {
                            bZwracany = true;
                        }
                        break;
                    }
                case 32:
                    {
                        bZwracany = true;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return bZwracany;
        }
        private void DomyslnyLabel(Label oLa, string Txt, Point Lokalizacja, Size Rozmiar)
        {
            oLa.Text = Txt;
            oLa.Location = Lokalizacja;
            oLa.Size = Rozmiar;
            oLa.BackColor = Color.Transparent;
        }
        private void DomyslnyZegar(Timer oZe)
        {
            Zegar.Interval = OpoznienieTicku;
            Zegar.Start();
        }



        public void Zegar_Tick(object sender, EventArgs e)
        {
            PrzeliczCzas();
            WypiszDate();
        }



        //////////////////////////////////////////////////////////////////////////Regulacja
        public void VC_1_1M(object sender, EventArgs e)
        {
            MilisekundNaTick = HScrollBar_1_1M.Value;
        }
        public void VC_1M_100M(object sender, EventArgs e)
        {
            MilisekundNaTick = HScrollBar_1M_100M.Value;
        }
        public void Btn1_Click(object sender, EventArgs e)
        {
            MilisekundNaTick = 1;
        }
        public void Btn3600_Click(object sender, EventArgs e)
        {
            MilisekundNaTick = 3600;
        }
        public void Btn86400_Click(object sender, EventArgs e)
        {
            MilisekundNaTick = 86400;
        }
        public void Btn2595000_Click(object sender, EventArgs e)
        {
            MilisekundNaTick = 2595000;
        }
    }
}
