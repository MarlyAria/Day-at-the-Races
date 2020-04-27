using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day_at_the_Races
{
    class Bet
    {
        public int Amount;
        public int Dog;
        public String Bettor;
        

        public string GetDescription()
        {
            
            if (Amount == 0)
            {
                return Bettor + " hasn't placed a bet!";
                //if the amount is zero, no bet was placed
                //(Guy.Name + (" hasn't placed a bet!") Maybe?
            }
           else
            {

                return Bettor + " bets $" + Amount + " on Dog " + Dog;
                //return a string that says who placed the bet, ho much
                //cash was bet, and which dog he bet on
                // "Joe bets 8 on dog 4#"
            }
            
        }

        public int PayOut(int Winner)
        {
            if (Dog == Winner)
            {
                return +Amount;
            }
            else
            {
                return -Amount;
            }
            //the parameter is the winner of the race. If the dog won,
            //return the amount bet. Otherwist, return the negative of the amount bet
        }
    }
}
