using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace Build_00a_VS15.Klasy
{
    class Okno : Form
    {                                  
        Dijijijjikstyyra oD = new Dijijijjikstyyra();
        public Button Btn1 = new Button();
        public Button Btn2 = new Button();
        public Button Btn_WyczyscV = new Button();
        public Button Btn_Kraw = new Button();

        public TextBox TxtBx1 = new TextBox();
        public TextBox TxtBx2 = new TextBox();
        public TextBox TxtBx3 = new TextBox();

        public ComboBox CB1 = new ComboBox();
        public ComboBox CB2 = new ComboBox();

        public VScrollBar SB_Dlug = new VScrollBar();
        public Label Label_Dlug = new Label();

        public Label Label_Start = new Label();
        public TextBox TxtBx_Start = new TextBox();
        public Label Label_End = new Label();
        public TextBox TxtBx_End = new TextBox();
        public Button Btn_Ustaw_StartEnd = new Button();
        public Okno()
        {
            this.ClientSize = new Size(800, 600);

            this.Paint += new PaintEventHandler(DrawLinePoint); 
            this.BackgroundImage = Image.FromFile("test.png");

            Btn1.Text = "Znajdz";
            Btn1.Left = 700;
            Btn1.Top = 550;
            Btn1.Click += new EventHandler(Btn1_Click);
            Controls.Add(Btn1);

            Btn2.Text = "Dodaj Wierzcholek";
            //Btn2.Left = 700; 
            //Btn2.Top = 470;
            Btn2.Left = 700;
            Btn2.Top = 440;
            Btn2.Click += new EventHandler(Btn2_Click);
            Controls.Add(Btn2);

            Btn_WyczyscV.Text = "Wyczysc Wierzcholki";
            Btn_WyczyscV.Left = 600;
            Btn_WyczyscV.Top = 440;
            Btn_WyczyscV.Click += new EventHandler(Btn_Wyczysc_Click);
            Controls.Add(Btn_WyczyscV);

            Btn_Kraw.Text = "Dodaj";
            Btn_Kraw.Left = 695;
            Btn_Kraw.Top = 150;
            Btn_Kraw.Click += new EventHandler(Btn_Kraw_Click);
            Controls.Add(Btn_Kraw);

            TxtBx1.Left = 600;
            TxtBx1.Top = 400;
            TxtBx1.Width = 50;
            Controls.Add(TxtBx1);

            TxtBx2.Left = 660;
            TxtBx2.Top = 400;
            TxtBx2.Width = 50;
            Controls.Add(TxtBx2);

            TxtBx3.Left = 720;
            TxtBx3.Top = 400;
            TxtBx3.Width = 50;
            Controls.Add(TxtBx3);

            CB1.Left = 650;
            CB1.Top = 50;
            CB1.SelectedIndexChanged += new EventHandler(CB1_IndexChanged);
            Controls.Add(CB1);

            CB2.Left = 650;
            CB2.Top = 100;
            CB2.SelectedIndexChanged += new EventHandler(CB2_IndexChanged);
            Controls.Add(CB2);

            SB_Dlug.Left = 600;
            SB_Dlug.Top = 50;
            SB_Dlug.Height = 150;
            SB_Dlug.Width = 30;
            SB_Dlug.Minimum = 0;
            SB_Dlug.Maximum = 30;
            SB_Dlug.ValueChanged += new EventHandler(ZmienionoWartosc_SB);
            Controls.Add(SB_Dlug);

            Label_Dlug.BackColor = Color.Orange;
            Label_Dlug.Text = "Dlug: " + SB_Dlug.Value.ToString();
            Label_Dlug.Tag = "X";
            Label_Dlug.Left = 650;
            Label_Dlug.Top = 150;
            Label_Dlug.Width = 30;
            Label_Dlug.Height = 40;
            Controls.Add(Label_Dlug);

            Label_Start.Text = "Start";
            Label_Start.Left = 50;
            Label_Start.Top = 500;
            Label_Start.Width = 30;
            Label_Start.Height = 20;
            Controls.Add(Label_Start);

            TxtBx_Start.Left = 50;
            TxtBx_Start.Top = 520;
            Controls.Add(TxtBx_Start);

            Label_End.Text = "End";
            Label_End.Left = 150;
            Label_End.Top = 500;
            Label_End.Width = 30;
            Label_End.Height = 20;
            Controls.Add(Label_End);

            TxtBx_End.Left = 150;
            TxtBx_End.Top = 520;
            Controls.Add(TxtBx_End);

            Btn_Ustaw_StartEnd.Text = "Ustaw";
            Btn_Ustaw_StartEnd.Left = 50;
            Btn_Ustaw_StartEnd.Top = 550;
            Btn_Ustaw_StartEnd.Click += new EventHandler(Btn_Ustaw_Click);
            Controls.Add(Btn_Ustaw_StartEnd);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();                                 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Okno";
            this.Text = "1";
            this.ResumeLayout(false);

        }

        public void Odswiez(bool CzyDoda)
        {
            WyczyscLabele();
            NarysujWierzcholki();
            NarysujKrawedzie();

            OdswiezCB(CzyDoda);

        }
        private void OdswiezCB(bool CzyDoda)
        {
            WyczyscCB();

            WypelnijCB1(CzyDoda);
        }
        private void WyczyscCB()
        {
            if (oD.V != null)
            {
                for (int i = 0; i < oD.V.Length; i++)
                {
                    CB1.Items.Remove(oD.V[i].Nazwa);
                    CB2.Items.Remove(oD.V[i].Nazwa);
                }
            }
        }
        private void WypelnijCB1(bool CzyDoda)
        {
            if (CzyDoda)
                if (oD.V != null)
                {
                    for (int i = 0; i < oD.V.Length; i++)
                    {
                        CB1.Items.Add(oD.V[i].Nazwa);
                    }
                }
        }
        private void WypelnijCB2(bool CzyDoda)
        {
            if (CzyDoda)
                if (oD.V != null)
                {
                    for (int i = 0; i < oD.V.Length; i++)
                    {
                        //if(i!=CB1.SelectedIndex)
                        CB2.Items.Add(oD.V[i].Nazwa);
                    }
                }
        }
        private void WyczyscLabele()
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].GetType() == typeof(Label) && Controls[i].Tag == null)
                {
                    Controls[i].Dispose();
                    i--;
                }
            }
        }
        public void NarysujWierzcholki()
        {

            if (oD.V != null)
                for (int i = 0; i < oD.V.Length; i++)
                {
                    Label ol = new Label();
                    ol.Location = new Point(oD.V[i].X - 10, oD.V[i].Y - 10);
                    ol.Text = oD.V[i].Nazwa;
                    ol.Size = new Size(20, 20);
                    ol.BackColor = Color.Cyan;
                    this.Controls.Add(ol);
                }    
                                         
        }
        public void NarysujKrawedzie()
        {
            if (oD.Ei != null&&oD.V!=null)
                for (int j = 0; j < oD.Ei.Length; j++)
                {
                    Label ol = new Label();
                    ol.Location = new Point((oD.V[oD.Ei[j].V1_ID].X + oD.V[oD.Ei[j].V2_ID].X) / 2 - 10, (oD.V[oD.Ei[j].V1_ID].Y + oD.V[oD.Ei[j].V2_ID].Y) / 2 - 10);
                    ol.Size = new Size(20, 20);
                    ol.Text = oD.Ei[j].Dlugosc.ToString();
                    ol.BackColor = Color.Yellow;
                    this.Controls.Add(ol);
                }
        }
        public void NarysujKrawedz(int j)
        {
            Label ol = new Label();
            ol.Location = new Point((oD.V[oD.Ei[j].V1_ID].X + oD.V[oD.Ei[j].V2_ID].X) / 2 - 10, (oD.V[oD.Ei[j].V1_ID].Y + oD.V[oD.Ei[j].V2_ID].Y) / 2 - 10);
            ol.Size = new Size(20, 20);
            ol.Text = oD.Ei[j].Dlugosc.ToString();
            ol.BackColor = Color.Yellow;
            this.Controls.Add(ol);
        }
        public void DrawLinePoint(object sender, PaintEventArgs e)
        {
            NarysujWierzcholki();
            OdswiezCB(true);
            Pen blackPen = new Pen(Color.Black, 3);
            if (oD.Ei != null && oD.V != null)
                for (int j = 0; j < oD.Ei.Length; j++)
                {
                    e.Graphics.DrawLine(blackPen, oD.V[oD.Ei[j].V1_ID].Location, oD.V[oD.Ei[j].V2_ID].Location);
                    NarysujKrawedz(j);
                }

        }
        public void Btn1_Click(object sender, EventArgs e)
        {
            int[] Temp = oD.Algorytm();
            string sDroga = "";
            for (int i = 0; i < Temp.Length; i++)
            {
                sDroga += oD.V[Temp[i]].Nazwa;
                if (Temp[i] != oD.IDEnd) sDroga += " > ";
            }
            MessageBox.Show(sDroga);
        }
        public void Btn2_Click(object sender, EventArgs e)
        {
            if (TxtBx1.Text != "" && TxtBx2.Text != "" && TxtBx3.Text != "")
            {
                oD.NadajWartosci(new string[] { TxtBx1.Text + "!" + TxtBx2.Text + "@" + TxtBx3.Text + "#;","" });
                TxtBx1.Text = TxtBx2.Text = TxtBx3.Text = "";
            }
            Odswiez(true);
            Refresh();
        }
        public void Btn_Wyczysc_Click(object sender, EventArgs e)
        {
            Odswiez(false);
            oD.V = null;
            oD.Ei = null;
            Refresh();
        }
        public void Btn_Kraw_Click(object sender, EventArgs e)
        {
            if (CB1.SelectedIndex != -1 && CB2.SelectedIndex != -1)
            {
                oD.NadajWartosci(new string[] { "", CB1.SelectedIndex.ToString() + "!" + CB2.SelectedIndex.ToString() + "@false#" + SB_Dlug.Value.ToString() + "$;" });
            }
            Odswiez(true);
            Refresh();
        }
        public void CB1_IndexChanged(object sender, EventArgs e)
        {
            WypelnijCB2(true);
        }
        public void CB2_IndexChanged(object sender, EventArgs e)
        {
            if (CB2.SelectedIndex == CB1.SelectedIndex)
            {
                CB2.SelectedIndex = -1;
            }
        }
        public void ZmienionoWartosc_SB(object sender, EventArgs e)
        {
            Label_Dlug.Text = "Dlug: " + SB_Dlug.Value.ToString();
        }
        public void Btn_Ustaw_Click(object sender, EventArgs e)
        {
            if (TxtBx_End.Text != "")
            {
                oD.IDEnd = int.Parse(TxtBx_End.Text);
            }
            if (TxtBx_Start.Text != "")
            {
                oD.IDStart = int.Parse(TxtBx_Start.Text);
            }
        }
    }
}
