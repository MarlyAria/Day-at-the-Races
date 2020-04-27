using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Day_at_the_Races
{
    class Greyhound
    {
        public int StartingPosition = 0;        //where my picturebox starts
        public int RacetrackLength;             //how long my racetrack is
        public PictureBox MyPictureBox = null;  //my picturebox object
        public int Location = 0;                //my location on the racetrack
        public Random Randomizer;               //an instance of Random
        public String Name;
        public int DogNummer;



        public bool Run()
        {
            Randomizer = new Random();
            //move forward either 1,2,3 or 4 spaces at random int Move = Randomizer.Next(1, 4);
            int moveForward = Randomizer.Next(1, 4);
            Location += moveForward;
            MyPictureBox.Left = StartingPosition + Location;
                    
           //check to see if the finish line has been crossed
           if (MyPictureBox.Left >= RacetrackLength)
            {
                return true; //finish line crossed
            }
            else
            {
                return false; // finish line not crossed
            }
        

           
        }

        public void TakeStartingPosition()
        {
            //reset my location to ) and mypicturebox to startion position.
            Location = 0;
            MyPictureBox.Left = StartingPosition; // return to starting line

        }
    }
}
