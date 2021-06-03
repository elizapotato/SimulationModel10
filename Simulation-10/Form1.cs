using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Simulation_10
{
    public partial class Form1 : Form
    {
        Game Player;
        Game Comp;
        private readonly double[] freqPlayer = { 0.02, 0.03, 0.05, 0.1, 0.3, 0.5 };
        private readonly double[] freqComp = { 0.5, 0.3, 0.1, 0.05, 0.03, 0.02 };
        int NumRoll = 5;

        public Form1()
        {           
            InitializeComponent();
            Player = new Game(freqPlayer);
            Comp = new Game(freqComp);
            labWin.Text = "";
        }

        private void startB_Click(object sender, EventArgs e)
        {            
            if (NumRoll > 1)
            for (int i = 0; i < 3; i++)     //Тряска кнопки
            {
                startB.Location = new Point(startB.Location.X + 3, startB.Location.Y);
                Thread.Sleep(100);
                startB.Location = new Point(startB.Location.X - 3, startB.Location.Y);
                Thread.Sleep(100);
            }

            switch (NumRoll)
            {
                case 5:
                    {
                        Pbox1.Text = Player.Roll() + "";
                        Cbox1.Text = Comp.Roll() + "";
                        NumRoll--;
                        break;
                    }
                case 4:
                    {
                        Pbox2.Text = Player.Roll() + "";
                        Cbox2.Text = Comp.Roll() + "";
                        NumRoll--;
                        break;
                    }
                case 3:
                    {
                        Pbox3.Text = Player.Roll() + "";
                        Cbox3.Text = Comp.Roll() + "";
                        NumRoll--;
                        break;
                    }
                case 2:
                    {
                        Pbox4.Text = Player.Roll() + "";
                        Cbox4.Text = Comp.Roll() + "";
                        NumRoll--;
                        break;
                    }
                case 1:
                    {
                        Pbox5.Text = Player.Roll() + "";
                        Cbox5.Text = Comp.Roll() + "";
                        if (Player.value > Comp.value) labWin.Text = "You are winner!";                        
                        else
                        {
                            if (Player.value < Comp.value) labWin.Text = "You are loser! :(";
                            else labWin.Text = "Draw!" + Player.value + " ";
                        }
                        RestartB.Text = "Start New Game";
                        break;
                    }
                case 0: break;
            }

        }

        public class Game
        {
            private readonly double[] queue;
            public int value = 0;

            public Game(double[] freq)
            {
                queue = freq;
            }

            public int Roll()
            {
                Random random = new Random();
                int score = 0;
                var k = random.NextDouble();
                for (int i = 0; i < queue.Length; i++)
                {
                    k -= queue[i];
                    if (k <= 0)
                    {
                        score = i + 1;
                        value += score;
                        break;
                    }
                    
                }

                return score;
            }
        }

        private void RestartB_Click(object sender, EventArgs e)
        {
            RestartB.Text = "Restart";
            NumRoll = 5;
            Player.value = Comp.value = 0;
            Pbox1.Text = Pbox2.Text = Pbox3.Text = Pbox4.Text = Pbox5.Text = "";
            Cbox1.Text = Cbox2.Text = Cbox3.Text = Cbox4.Text = Cbox5.Text = "";
            labWin.Text = "";

        }
    }
}
