using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//nicht vergessen!!!!!!!
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe_Spiel_WinForms
{
    //Starten des Programms
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new TicTacToe());
        }
    }

    //Spiel TicTacToe mit Logik+Grafik
    class TicTacToe : Form
    {
        private Button[] feld;
        private Button clearB;
        private bool[] isClicked;
        private string[] inhaltbutton;
        private int spieler;

        //c'tor
        public TicTacToe()
        {
            this.Size = new Size(300, 300);
            this.Text = "TicTacToe";
            feld = new Button[9];
            isClicked = new bool[9];
            for (int i = 0; i < 9; i++)
            {
                isClicked[i] = false;
            }
            spieler = 1;
            inhaltbutton = new String[9];
            for (int i = 0; i < 9; i++)
            {
                inhaltbutton[i] = " ";
            }
            Init_Button();
            Tooltip_Erzeugen();
        }

        //Initialisieren der Buttons
        public void Init_Button()
        {
            for (int i = 0; i < 9; i++)
            {
                //Initialisieren der Spielfeld-Buttons
                feld[i] = new Button();
                feld[i].Size = new Size(50, 50);
                this.feld[i].BackColor = Color.LightGray;
                switch (i)
                {
                    case 0: feld[i].Location = new Point(0, 0); feld[i].Click += TicTacToe_Click; feld[i].Name = "button0"; break;
                    case 1: feld[i].Location = new Point(50, 0); feld[i].Click += TicTacToe_Click; feld[i].Name = "button1"; break;
                    case 2: feld[i].Location = new Point(100, 0); feld[i].Click += TicTacToe_Click; feld[i].Name = "button2"; break;
                    case 3: feld[i].Location = new Point(0, 50); feld[i].Click += TicTacToe_Click; feld[i].Name = "button3"; break;
                    case 4: feld[i].Location = new Point(50, 50); feld[i].Click += TicTacToe_Click; feld[i].Name = "button4"; break;
                    case 5: feld[i].Location = new Point(100, 50); feld[i].Click += TicTacToe_Click; feld[i].Name = "button5"; break;
                    case 6: feld[i].Location = new Point(0, 100); feld[i].Click += TicTacToe_Click; feld[i].Name = "button6"; break;
                    case 7: feld[i].Location = new Point(50, 100); feld[i].Click += TicTacToe_Click; feld[i].Name = "button7"; break;
                    case 8: feld[i].Location = new Point(100, 100); feld[i].Click += TicTacToe_Click; feld[i].Name = "button8"; break;
                }
                this.Controls.Add(feld[i]);  
            }
            //Initialisieren des Reset-Buttons
            this.clearB = new Button();
            clearB.Size = new Size(50, 30);
            clearB.Location = new Point(200, 100);
            clearB.Text = "Reset";
            clearB.Click += clearB_Click;
            this.Controls.Add(clearB);

        }

        //Event für den Reset-Button
        void clearB_Click(object sender, EventArgs e)
        {
            ResetField();
           
        }

        //Event wenn ein Spielfeld-Button geklickt wurde
        void TicTacToe_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
               
         
            //geklickten Spielfeld-button auswählen 
            switch (clicked.Name)
            {
                case "button0": isClicked[0] = true; changeTitel(clicked); break;
                case "button1": isClicked[1] = true; changeTitel(clicked); break;
                case "button2": isClicked[2] = true; changeTitel(clicked); break;
                case "button3": isClicked[3] = true; changeTitel(clicked); break;
                case "button4": isClicked[4] = true; changeTitel(clicked); break;
                case "button5": isClicked[5] = true; changeTitel(clicked); break;
                case "button6": isClicked[6] = true; changeTitel(clicked); break;
                case "button7": isClicked[7] = true; changeTitel(clicked); break;
                case "button8": isClicked[8] = true; changeTitel(clicked); break;

            }
            
        }

        //sobald ein Button geklickt wurde, wird hier überprüft ob dieser bereits geklickt wurde oder nicht
        //--> wenn bereits geklickt, dann passiert nichts, 
        //--> ansonsten wird dieser als geklickt gesetzt und es wird überprüft, ob jemand gewonnen hat, ansonsten wird es 
        //nur überprüft, ob noch leere Felder vorhanden sind
        public void changeTitel(Button name)
        {
            Button clicked = name;
            string buchstabe="x";
            //spieler wechsel nach jedem klick
            if (this.spieler == 1)
            {
                buchstabe = "x";
                spieler = 2;
            }
            else
            {
                buchstabe = "o";
                spieler = 1;
            }
            switch (clicked.Name)
            {
                    //buchstabe setzten und feld als geklickt setzen
                case "button0": feld[0].Text = buchstabe; feld[0].Enabled = false; inhaltbutton[0] = buchstabe; break;
                case "button1": feld[1].Text = buchstabe; feld[1].Enabled = false; inhaltbutton[1] = buchstabe; break;
                case "button2": feld[2].Text = buchstabe; feld[2].Enabled = false; inhaltbutton[2] = buchstabe; break;
                case "button3": feld[3].Text = buchstabe; feld[3].Enabled = false; inhaltbutton[3] = buchstabe; break;
                case "button4": feld[4].Text = buchstabe; feld[4].Enabled = false; inhaltbutton[4] = buchstabe; break;
                case "button5": feld[5].Text = buchstabe; feld[5].Enabled = false; inhaltbutton[5] = buchstabe; break;
                case "button6": feld[6].Text = buchstabe; feld[6].Enabled = false; inhaltbutton[6] = buchstabe; break;
                case "button7": feld[7].Text = buchstabe; feld[7].Enabled = false; inhaltbutton[7] = buchstabe; break;
                case "button8": feld[8].Text = buchstabe; feld[8].Enabled = false; inhaltbutton[8] = buchstabe; break;

            }
            Ueberpruefen(buchstabe);

        }

        //ueberprueft, ob bereits jemand gewonnen hat oder ob alle felder belegt sind 
        public void Ueberpruefen(string buchstabe)
        {
            if ((inhaltbutton[0] == "x" && inhaltbutton[1] == "x" && inhaltbutton[2] == "x") ||
                (inhaltbutton[0] == "o" && inhaltbutton[1] == "o" && inhaltbutton[2] == "o") ||

                (inhaltbutton[3] == "x" && inhaltbutton[4] == "x" && inhaltbutton[5] == "x") ||
                (inhaltbutton[3] == "o" && inhaltbutton[4] == "o" && inhaltbutton[5] == "o") ||

                (inhaltbutton[6] == "x" && inhaltbutton[7] == "x" && inhaltbutton[8] == "x") ||
                (inhaltbutton[6] == "o" && inhaltbutton[7] == "o" && inhaltbutton[8] == "o") ||

                (inhaltbutton[0] == "x" && inhaltbutton[3] == "x" && inhaltbutton[6] == "x") ||
                (inhaltbutton[0] == "o" && inhaltbutton[3] == "o" && inhaltbutton[6] == "o") ||

                (inhaltbutton[1] == "x" && inhaltbutton[4] == "x" && inhaltbutton[7] == "x") ||
                (inhaltbutton[1] == "o" && inhaltbutton[4] == "o" && inhaltbutton[7] == "o") ||

                (inhaltbutton[2] == "x" && inhaltbutton[5] == "x" && inhaltbutton[8] == "x") ||
                (inhaltbutton[2] == "o" && inhaltbutton[5] == "o" && inhaltbutton[8] == "o") ||

                (inhaltbutton[0] == "x" && inhaltbutton[4] == "x" && inhaltbutton[8] == "x") ||
                (inhaltbutton[0] == "o" && inhaltbutton[4] == "o" && inhaltbutton[8] == "o") ||

                (inhaltbutton[2] == "x" && inhaltbutton[4] == "x" && inhaltbutton[6] == "x") ||
                (inhaltbutton[2] == "o" && inhaltbutton[4] == "o" && inhaltbutton[6] == "o"))
            {



                if ((inhaltbutton[0] == "x" && inhaltbutton[1] == "x" && inhaltbutton[2] == "x") ||
                (inhaltbutton[0] == "o" && inhaltbutton[1] == "o" && inhaltbutton[2] == "o"))
                {
                    feld[0].BackColor = Color.Green;
                    feld[1].BackColor = Color.Green;
                    feld[2].BackColor = Color.Green;
                }
                else if ((inhaltbutton[3] == "x" && inhaltbutton[4] == "x" && inhaltbutton[5] == "x") ||
                (inhaltbutton[3] == "o" && inhaltbutton[4] == "o" && inhaltbutton[5] == "o"))
                {
                    feld[3].BackColor = Color.Green;
                    feld[4].BackColor = Color.Green;
                    feld[5].BackColor = Color.Green;
                }
                else if ((inhaltbutton[6] == "x" && inhaltbutton[7] == "x" && inhaltbutton[8] == "x") ||
                (inhaltbutton[6] == "o" && inhaltbutton[7] == "o" && inhaltbutton[8] == "o"))
                {
                    feld[6].BackColor = Color.Green;
                    feld[7].BackColor = Color.Green;
                    feld[8].BackColor = Color.Green;
                }
                else if ((inhaltbutton[0] == "x" && inhaltbutton[3] == "x" && inhaltbutton[6] == "x") ||
                (inhaltbutton[0] == "o" && inhaltbutton[3] == "o" && inhaltbutton[6] == "o"))
                {
                    feld[0].BackColor = Color.Green;
                    feld[3].BackColor = Color.Green;
                    feld[6].BackColor = Color.Green;
                }
                else if ((inhaltbutton[1] == "x" && inhaltbutton[4] == "x" && inhaltbutton[7] == "x") ||
                (inhaltbutton[1] == "o" && inhaltbutton[4] == "o" && inhaltbutton[7] == "o"))
                {
                    feld[1].BackColor = Color.Green;
                    feld[4].BackColor = Color.Green;
                    feld[7].BackColor = Color.Green;
                }
                else if ((inhaltbutton[2] == "x" && inhaltbutton[5] == "x" && inhaltbutton[8] == "x") ||
                (inhaltbutton[2] == "o" && inhaltbutton[5] == "o" && inhaltbutton[8] == "o"))
                {
                    feld[2].BackColor = Color.Green;
                    feld[5].BackColor = Color.Green;
                    feld[8].BackColor = Color.Green;
                }
                else if ((inhaltbutton[0] == "x" && inhaltbutton[4] == "x" && inhaltbutton[8] == "x") ||
                (inhaltbutton[0] == "o" && inhaltbutton[4] == "o" && inhaltbutton[8] == "o"))
                {
                    feld[0].BackColor = Color.Green;
                    feld[4].BackColor = Color.Green;
                    feld[8].BackColor = Color.Green;
                }
                else
                {
                    feld[2].BackColor = Color.Green;
                    feld[4].BackColor = Color.Green;
                    feld[6].BackColor = Color.Green;
                }

                for (int i = 0; i < 9; i++)
                {
                    feld[i].Enabled = false;
                }
                if (buchstabe == "x")
                {
                    MessageBox.Show("Spieler 1 hat gewonnen!");
                }
                else
                {
                    MessageBox.Show("Spieler 2 hat gewonnen!");
                }

            }
            else 
            {
                if (alleVoll() == true)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        this.feld[i].BackColor = Color.LightSalmon;
                    }
                    MessageBox.Show("Es gibt keine leeren Felder mehr!");
                    
                }
            }
        }

        //Überprüft, ob alle Felder voll sind
        public bool alleVoll()
        {
            for (int i = 0; i < 9; i++)
            {
                if (inhaltbutton[i] == " ")
                {
                    return false;
                }
            }
            return true;
        }

        //Leert alles und setzt spielfeld auf Anfang
        public void ResetField()
        {
            for (int i = 0; i < 9; i++)
            {
                this.feld[i].Enabled = false;
                this.feld[i].BackColor = Color.LightGray;
                this.feld[i].Text = " ";
                this.isClicked[i] = false;
                this.inhaltbutton[i] = " ";
            }
            this.spieler = 1;

            MessageBox.Show("Reset!");
            for (int i = 0; i < 9; i++)
            {
                this.feld[i].Enabled = true;
            }
        }

        //Tooltip für Reset-Button erzeugen
        public void Tooltip_Erzeugen()
        {
            
            ToolTip toolTip1 = new ToolTip();

          //Wie lang Tooltip offen bleibt
            toolTip1.AutoPopDelay = 5000;
            //nach welcher Zeit Tooltip erscheint
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;


            toolTip1.SetToolTip(this.clearB, "Hier wird alles auf Anfang zurück gesetzt!");

        
        }

    }
    


}
