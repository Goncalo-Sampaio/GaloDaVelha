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

                //checks for a winning row
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    //checks if there still an empty space on that row
                    if (board[row, j] == null)
                    {
                        break;
                    }

                    //gets the piece on the position [row, j]
                    Piece piece = board[row, j];

                    //checks if the characteristic of the piece is true and adds
                    //1 or false and subtracts 1
                    if (piece.GetCharacteristics()[checkingCharacteristic])
                    {
                        similarityCounter++;
                    }
                    else
                    {
                        similarityCounter--;
                    }

                    //if 4 of the pieces have the same characteristic,
                    //returns true and player wins
                    if (similarityCounter == 4 || similarityCounter == -4)
                    {
                        return true;
                    }
                }

                //increases the counter for which characteristic are we checking
                checkingCharacteristic++;
            }
        }
    }
}