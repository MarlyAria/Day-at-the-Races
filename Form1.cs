using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day_at_the_Races
{
    public partial class Form1 : Form
    {

        Guy[] NewGuy = new Guy[3];
        Greyhound[] Dog = new Greyhound[4];
        Random randomizer;
        public int WinningDog;
              

        public Form1()
        {
            
            InitializeComponent();
            SetupRaceTrack();
        }
        private void SetupRaceTrack()
        {
            randomizer = new Random();
            Dog[0] = new Greyhound
            {
                Name = "Toby",
                DogNummer = 1,
                MyPictureBox = PictureBox1,
                StartingPosition = PictureBox1.Left,
                RacetrackLength = racetrackPictureBox.Width - PictureBox1.Width,
                Randomizer = randomizer 
            };
            Dog[1] = new Greyhound
                {
                    DogNummer = 2,
                    Name = "Balou",
                    MyPictureBox = PictureBox2,
                    StartingPosition = PictureBox2.Left,
                    RacetrackLength = racetrackPictureBox.Width - PictureBox2.Width,
                    Randomizer = randomizer
            };
            Dog[2] = new Greyhound
            {
                Name = "Happy",
                DogNummer = 3,
                MyPictureBox = PictureBox3,
                StartingPosition = PictureBox3.Left,
                RacetrackLength = racetrackPictureBox.Width - PictureBox3.Width,
                Randomizer = randomizer
            };
            Dog[3] = new Greyhound
            {
                Name = "Caran",
                DogNummer = 4,
                MyPictureBox = PictureBox4,
                StartingPosition = PictureBox4.Left,
                RacetrackLength = racetrackPictureBox.Width - PictureBox4.Width,
                Randomizer = randomizer
            };
            
            label3.Text = Dog[0].Name + ", dog " + Dog[0].DogNummer;
            label4.Text = Dog[1].Name + ", dog " + Dog[1].DogNummer;
            label5.Text = Dog[2].Name + ", dog " + Dog[2].DogNummer;
            label6.Text = Dog[3].Name + ", dog " + Dog[3].DogNummer;

            NewGuy[0] = new Guy()
            {
                Name = "Joe",
                Cash = 50,
                MyLabel = joeBetLabel,
                MyRadioButton = joeRadioButton
            };
            NewGuy[1] = new Guy()
            {
                Name = "Bob",
                Cash = 75,
                MyLabel = bobBetLabel,
                MyRadioButton = bobRadioButton
            };
            NewGuy[2] = new Guy()
            {
                Name = "Al",
                Cash = 45,
                MyLabel = alBetLabel,
                MyRadioButton = alRadiobutton,
            };

            foreach (Guy guy in NewGuy)
            {
                guy.UpdateLabels();
            }
        }

        private void BetButton_Click(object sender, EventArgs e)
        {
            int BetAmount = Convert.ToInt32(BetAmountNUD.Value);
            int DogToWin = Convert.ToInt32(DogToWinNUD.Value);
            
            if (joeRadioButton.Checked)
            {
                NewGuy[0].PlaceBet(BetAmount, DogToWin);
            }
            if (bobRadioButton.Checked)
            {
                NewGuy[1].PlaceBet(BetAmount, DogToWin);
            }
            else if (alRadiobutton.Checked)
            {
                NewGuy[2].PlaceBet(BetAmount, DogToWin);
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            NameLabel.Text = NewGuy[0].Name;

        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            NameLabel.Text = NewGuy[1].Name;
        }

        private void alRadiobutton_CheckedChanged(object sender, EventArgs e)
        {
            NameLabel.Text = NewGuy[2].Name;
        }

        private void PermissionCheck()
        {
            foreach (Guy guy in NewGuy)
            {
                if (guy.BetPlaced == false)
                {
                    MessageBox.Show("Please make sure everybody has placed their bets!");
                    break;
                }
                else
                {
                    guy.PermissionToStart = true;
                }
            }
        }
        
        private void RaceButton_Click(object sender, EventArgs e)
        {
            PermissionCheck();
            
            if (NewGuy[0].PermissionToStart == true && NewGuy[1].PermissionToStart == true 
                   && NewGuy[2].PermissionToStart == true )
                {
                        Dog[0].TakeStartingPosition();
                        Dog[1].TakeStartingPosition();
                        Dog[2].TakeStartingPosition();
                        Dog[3].TakeStartingPosition();


                        BettingParlor.Enabled = false;
                        timer1.Start();
                }

                       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //de timer zorgt eervoor dat de hondjes daadwerkelijk gaan lopen
            for (int i = 0; i < Dog.Length; i++)
            {
                foreach (Greyhound greyhound in Dog)
                {

                
                Dog[i].Run();
                    if (Dog[i].Run() == true)
                    {
                        timer1.Stop();
                        timer1.Enabled = false;

                        MessageBox.Show(Dog[i].Name + " has won the race");
                        WinningDog = Dog[i].DogNummer;
                        BettingParlor.Enabled = true;

                        foreach (Guy guy in NewGuy)
                        {
                            guy.Collect(WinningDog);
                        }

                    }   
                }

            

            }
        }
    }
}
