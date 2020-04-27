using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day_at_the_Races
{
    class Guy
    {
      
        public Bet MyBet = new Bet();
        public string Name;
        public int Cash;
        public bool BetPlaced = false;
        public RadioButton MyRadioButton;
        public Label MyLabel;


        public void UpdateLabels()
        {
            MyBet.Bettor = Name;
            MyLabel.Text = MyBet.GetDescription(); // sets label to show the bet placed
            MyRadioButton.Text = Name + " has " + Cash + " bucks";

            //this is placed here so that if someone can't bet anymore 
            //they don't have to click the bet button
            //everytime for the race to continue
            if (Cash < 5)
            {
                BetPlaced = true;
                //this way the game can continue even if some can't bet anymore
            }
        }

        public void ClearBet()
        {
            MyBet.Amount = 0;
            BetPlaced = false;
         //reset my bet so it's zero
        }

        public bool PlaceBet (int BetAmount, int DogToWin)
        {
            if (BetAmount <= Cash)
            {
                MyBet.Bettor = Name;
                MyBet.Amount = BetAmount;
                MyBet.Dog = DogToWin;
                BetPlaced = true;
                //lets program know this guy has placed so the race can begin
                UpdateLabels();
                return true;
            }              
            else
            {
                UpdateLabels();
                return false;    
            }
            
        }

        public void Collect (int Winner)
        {
            Cash += MyBet.PayOut(Winner);
            UpdateLabels();
            ClearBet();
            
            //ask my bet to pay out, clear my bet and update my labels
        }
    }

    
}
