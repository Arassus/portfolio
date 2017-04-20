using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Source_P.Klasy
{
    class Settings : Form
    {
        public CheckBox Fullscreen_CB = new CheckBox();
        public Button Apply_ChB = new Button();
        public ComboBox Resolution_CoB = new ComboBox();
        public ComboBox Background_CoB = new ComboBox();

        //public Button Up = new Button();
        //public Button Down = new Button();
        //int HZZ = 200;
        //public Label LB = new Label();

        public Settings()
        {
            Inicjalizacja();
        }
        private void Zwieksz(object sender, EventArgs e)
        {
            //Random r = new Random();
            //HZZ = r.Next(150, 600);
            //LB.Text = HZZ.ToString();
            //Console.Beep(HZZ, 100); 
            //Console.WriteLine("\a");
        }
        private void Zmniejsz(object sender, EventArgs e)
        {
            //LB.Text = HZZ.ToString();
            //Console.Beep(HZZ, 100);
            //Console.WriteLine("\a");
            //if (HZZ > 0)
            //{
            //    Random r = new Random();         
            //    HZZ = r.Next(150,600);
            //}
        }
        private void Inicjalizacja()
        {
            //Controls.Add(Up);
            //Controls.Add(Down);
            //Controls.Add(LB);
            //Up.Click += new EventHandler(Zwieksz);
            //Down.Click += new EventHandler(Zmniejsz);
            //Up.Location = new System.Drawing.Point(100, 100);
            //Down.Location = new System.Drawing.Point(100, 130);
            //LB.Location = new System.Drawing.Point(100, 160);




            this.SuspendLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Name = "Ustawienia";
            this.Text = "Ustawienia";                                  
            this.ResumeLayout(false);

            Fullscreen_CB.CheckedChanged += new EventHandler(Zabezpiecz_Fullscreen);
            Apply_ChB.Click += new EventHandler(Zatwierdz);

            //FormBorderStyle = FormBorderStyle.None; 
            //WindowState = FormWindowState.Maximized;


            ///Dodawanie do Kontrolek do Formatki


            ZainicjalizujKontrolke(Fullscreen_CB, 10, 10, this, "Full screen");

            ZainicjalizujKontrolke(Resolution_CoB, 10, 50, this, null);
            Resolution_CoB.Items.Add("800x600");
            Resolution_CoB.Items.Add("1280x720");
            Resolution_CoB.Items.Add("1920x1080");
            Resolution_CoB.SelectedIndex = 0;

            ZainicjalizujKontrolke(Background_CoB,150,50,this,null);
            Background_CoB.Items.Add("Jasne Tło");
            Background_CoB.Items.Add("Ciemne Tło");
            Background_CoB.SelectedIndex = 0;

            ZainicjalizujKontrolke(Apply_ChB, 10, 100, this, "OK");


            //Controls.Add(btn1);
            //Controls.Add(Prjekty_oLV);
            //Controls.Add(Pracownicy_oLV);


        }
        public static void ZainicjalizujKontrolke(Control Co, int X, int Y, Form Gdzie, string Text)
        {
            Co.Location = new System.Drawing.Point(X, Y);
            Gdzie.Controls.Add(Co);
            if (Text != null)
            {
                Co.Text = Text;
            }       
        }
        private void Zabezpiecz_Fullscreen(object sender, EventArgs e)
        {
            if (Fullscreen_CB.Checked)
            {
                Resolution_CoB.Hide();
            }
            else
            {
                Resolution_CoB.Show();
            }
        }
        private void Zatwierdz(object sender, EventArgs e)
        {
            this.Close();
        }

        public static int ResolutionToID(string Resolution)
        {
            int zwracana = 0;

            if (Resolution == "800x600")
            {
                zwracana = 0;
            }
            if (Resolution == "1280x720")
            {
                zwracana = 1;
            }
            if (Resolution == "1920x1080")
            {
                zwracana = 2;
            }

            return zwracana;
        }
    }
}
