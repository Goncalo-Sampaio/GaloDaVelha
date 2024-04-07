using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaloDaVelha
{
    /// <summary>
    /// This class will check the current conditions of the game to see if the
    /// player that made the last move, won
    /// </summary>
    public class ConditionsChecker
    {
        public void CheckWin()
        {
            //which characteristic are we checking:
            //0 for shape, 1 for color, 2 for size and 3 for hole
            int checkingCharacteristic = 0;

            while (checkingCharacteristic < 4)
            {
                //int variable to count how many pieces in a row, column or
                //or diagonal have the same characteristic
                int similarityCounter = 0;

                //increases the counter for which characteristic are we checking
                checkingCharacteristic++;
            }
        }
    }
}