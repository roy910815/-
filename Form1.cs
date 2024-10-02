using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace c64091104_practice_12_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[] pic = new PictureBox[30];

        int score1 = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            SoundPlayer player1 = new SoundPlayer(@"..\..\..\c64091104_practice_12_1\Backgroundmusic.WAV");
            player1.SoundLocation = @"..\..\..\c64091104_practice_12_1\Backgroundmusic.WAV";
            player1.Load();
            player1.PlayLooping();
            pic[0] = pop1; pic[1] = pop2; pic[2] = pop3;
            pic[3] = pop4; pic[4] = pop5; pic[5] = pop6;
            pic[6] = pop7; pic[7] = pop8; pic[8] = pop9;
            pic[9] = pop10; pic[10] = pop11; pic[11] = pop12;
            pic[12] = pop13; pic[13] = pop14; pic[14] = pop15;
            pic[15] = pop16; pic[16] = pop17; pic[17] = pop18; pic[18] = pop19;
            pic[19] = pop20; pic[20] = pop21; pic[21] = pop22;
            pic[22] = pop23; pic[23] = pop24; pic[24] = pop25;
            pic[25] = pop26; pic[26] = pop27; pic[27] = pop28;
            pic[28] = pop29; pic[29] = pop30; 
            this.KeyPreview = true;
            for (int i = 0; i < 30; i++)  
            {
                pic[i].Visible = false;
            }
               
            //  popbox.Changed = false;  
        }
        int timeLeft;
        private void start_Click(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            start.Enabled = false;
            timeLeft = 30;
            time.Text = timeLeft.ToString();
            timer1.Start();
            score1 = 0;
            score.Text = score1.ToString();
        }
        //
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                Random rnd1 = new Random();
                int ran = rnd1.Next(0, 30);
                pic[ran].Visible = true;
                for (int i = 0; i < 30; i++)  
                {
                    if (pic[i].Visible == true)
                    {
                        pic[i].Top += 30;
                        if (pic[i].Location.Y + 50 >= 260) 
                        {
                            if (!(pic[i].Location.X +28 > (popbox.Location.X + 100) || (pic[i].Location.X + 56) < popbox.Location.X))
                            //   if ((pic[i].Location.X) > popbox.Location.X  && (pic[i].Location.X ) < popbox.Location.X+100)
                            {
                                SystemSounds.Exclamation.Play();
                                pic[i].Visible = false;
                                score1 = score1 + 1;
                                score.Text = score1.ToString();
                                pic[i].Top = 0;
                            }

                        }
                        if (pic[i].Location.Y + 50 >= 355)
                        {
                            pic[i].Visible = false;
                            pic[i].Top = 0;
                        }
                    }
                   
                }
                timeLeft = timeLeft - 1;
                time.Text = timeLeft.ToString();
            }
            else if (timeLeft == 0)
            {
                start.Enabled = true;
                timer1.Stop();

            }
                     
        }
       
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            this.KeyPreview = true;
            if (popbox.Left > 0 && popbox.Left < 233)
            {
                switch (e.KeyCode)        // 根據e.KeyCode分別執行
                {
                    case Keys.A:        // 若按向左鍵
                        popbox.Left = popbox.Left - 5;
                        break;
                    case Keys.D:       // 若按向右鍵
                        popbox.Left = popbox.Left + 5;
                        break;
                }
            }
            else if (popbox.Left <= 0)
            {
                switch (e.KeyCode)        // 根據e.KeyCode分別執行
                {
                    case Keys.A:        // 若按向左鍵
                        popbox.Left = popbox.Left - 0;
                        break;
                    case Keys.D:       // 若按向右鍵
                        popbox.Left = popbox.Left + 5;
                        break;
                }
            }
            else if (popbox.Location.X >= 223)
            {
                switch (e.KeyCode)        // 根據e.KeyCode分別執行
                {
                    case Keys.A:        // 若按向左鍵
                        popbox.Left = popbox.Left - 5;
                        break;
                    case Keys.D:       // 若按向右鍵
                        popbox.Left = popbox.Left + 0;
                        break;
                }
            }
        }

        private void popbox_Click(object sender, EventArgs e)
        {

        }
    }
}
