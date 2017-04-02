using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using ClickerTajper_00_Console_P;

namespace Wisielec_P
{
    class Wisielec:MiniGra
    {
        public Label Wisielec_Label = new Label();
        public TextBox Wisielec_TextBox = new TextBox();
        private string Slowo;
        private short StanWisielca;

        public Wisielec(ref int o)
        {                

            DomyslnaKontrolka(Slowo_Label, 480, 20, 50, 200);
            Slowo_Label.Font = new Font("MS Sans Serif", 14f, FontStyle.Bold);

            DomyslnaKontrolka(Slowo_TxtBx, 480, 70, 50, 200);
            Slowo_TxtBx.Font = new Font("MS Sans Serif", 14f, FontStyle.Bold);
                   
            //DomyslnaKontrolka(Output_Label, 350, 300, 50, 200);
            //Output_Label.Font = new Font("MS Sans Serif", 14f, FontStyle.Bold);      

            DomyslnaKontrolka(Wisielec_Label, 420, 70, 50, 50);
            //StanWisielca = 0;
            //Wisielec_Label.Image = Image.FromFile("Obrazki/Blad0.png");
        

            DomyslnaKontrolka(Wisielec_TextBox, 440, 20, 50, 30);
            Wisielec_TextBox.Font = new Font("MS Sans Serif", 14f, FontStyle.Bold);

            Slowo_Label.Text = "";
        }
        public override void JesliWyrazSieZgadza()
        {
            if (Slowo == Slowo_TxtBx.Text)
            {
                PunktZaWyraz();    
                WylosujWyraz();
            }
            else
            {

                PopelnilesBlad();
            }
        }
        public override void Zainicjalizuj(TabPage Gdzie, ref Baza o)
        {
            Gdzie.Controls.Add(Slowo_Label);

            //Gdzie.Controls.Add(Output_Label);
                                           
            Gdzie.Controls.Add(Slowo_TxtBx);
            Slowo_TxtBx.KeyDown += WcisnietoEnter;   

            Gdzie.Controls.Add(Wisielec_Label);  
            Gdzie.Controls.Add(Wisielec_TextBox);
            Wisielec_TextBox.KeyDown += ZgadnijLitere;
            Wisielec_TextBox.MaxLength = 1;

            Losowanie = o.WylosujWyraz;
            WylosujWyraz();
        }
        public override void Usun(TabPage Gdzie)
        {
            Gdzie.Controls.Remove(this.Slowo_Label);
            Gdzie.Controls.Remove(this.Slowo_TxtBx);               
            Gdzie.Controls.Remove(this.Wisielec_Label);
            Gdzie.Controls.Remove(this.Wisielec_TextBox);
            //Gdzie.Controls.Remove(this.Output_Label);
        }
        public override void WylosujWyraz()
        {
            StanWisielca = 0;
            Wisielec_Label.Image = Image.FromFile("Obrazki/Blad0.png");

            Wisielec_TextBox.Text = "";
            Slowo_TxtBx.Text = "";    
            Slowo_Label.Text = "";
            Slowo = Losowanie("slowo");

            MessageBox.Show("Nowe Wylosowane Słowo : \n" + Slowo);

            PrzerobLabel();
        }


        private void PrzerobLabel()
        {
            Slowo_Label.Text = "";
            for (int i = 0; i < Slowo.Length; i++)
            {
                Slowo_Label.Text += "_";
            }
        }           
        private void ZgadnijLitere(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Slowo.Contains(Wisielec_TextBox.Text))
                {
                    if (!Slowo_Label.Text.Contains(Wisielec_TextBox.Text))
                    {
                        WstawOdgadnieteSlowo();
                    }
                    else
                    {                            
                        PopelnilesBlad();
                    }
                }
                else
                {
                    PopelnilesBlad();
                }

                Wisielec_TextBox.Text = "";
            }
        }
        private void WisielecNastepnyImage()
        {
            MessageBox.Show("Bład");
            switch (StanWisielca)
            {
                case 0:
                    {
                        Wisielec_Label.Image = Image.FromFile("Obrazki/Blad1.png");
                        StanWisielca = 1;
                        break;
                    }
                case 1:
                    {
                        Wisielec_Label.Image = Image.FromFile("Obrazki/Blad2.png");
                        StanWisielca = 2;
                        break;
                    }
                case 2:
                    {
                        Wisielec_Label.Image = Image.FromFile("Obrazki/Blad3.png");
                        StanWisielca = 3;
                        break;
                    }
                case 3:
                    {
                        Wisielec_Label.Image = Image.FromFile("Obrazki/Blad4.png");
                        StanWisielca = 4;
                        break;
                    }
                case 4:
                    {
                        Wisielec_Label.Image = Image.FromFile("Obrazki/Blad5.png");
                        StanWisielca = 5;
                        break;
                    }
                case 5:
                    {
                        Wisielec_Label.Image = Image.FromFile("Obrazki/Blad6.png");
                        StanWisielca = 0;
                        Spieprzyles();
                        break;
                    }            
                default:
                    {
                        MessageBox.Show("StanWisielca : " + StanWisielca);
                        break;
                    }
            }
        }
        private void PopelnilesBlad()
        {
            WisielecNastepnyImage();
        }
        private void Spieprzyles()
        {
            PunktZaBlad();
            MessageBox.Show("Wisielec Nie ŻYJE\nOdjęcie PUNKTU");                                              
            WylosujWyraz();
        }
        private void WstawOdgadnieteSlowo()
        {
            string zastepczy = "";
            for (int i = 0; i < Slowo.Length; i++)
            {
                if (Slowo[i] == Wisielec_TextBox.Text[0])
                {
                    zastepczy += Slowo[i];
                }
                else
                {
                    zastepczy += Slowo_Label.Text[i];
                }
            }
            Slowo_Label.Text = zastepczy;
        }
    }
}
