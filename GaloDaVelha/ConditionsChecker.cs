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
        public bool CheckWin(Piece[,] board, int row, int column)
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

                //checks for a winning column

                //resets similarityCounter to make a new check for column
                similarityCounter = 0;

                //checks for a winning column
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    //checks if there still an empty space on that column
                    if (board[i, column] == null)
                    {
                        break;
                    }

                    //gets the piece on the position [i, column]
                    Piece piece = board[i, column];

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

                //checks for a winning diagonals

                //LEFT DIAGONAL
                //resets similarityCounter to make a new check for diagonal
                similarityCounter = 0;

                //auxiliary int for diagonal checking
                int n = 0;

                while (n < 4)
                {
                    //checks if there still an empty space on that row
                    if (board[n, n] == null)
                    {
                        break;
                    }

                    //gets the piece on the position [row, j]
                    Piece piece = board[n, n];

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

                    //increases the counter to check the next piece in the
                    //diagonal
                    n++;
                }

                //RIGHT DIAGONAL
                //resets similarityCounter to make a new check for diagonal
                similarityCounter = 0;

                //auxiliary int for diagonal checking
                n = 0;

                while (n < 4)
                {
                    //checks if there still an empty space on that row
                    if (board[n, 3-n] == null)
                    {
                        break;
                    }

                    //gets the piece on the position [row, j]
                    Piece piece = board[n, n];

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

                    //increases the counter to check the next piece in the
                    //diagonal
                    n++;
                }

                //increases the counter for which characteristic are we checking
                checkingCharacteristic++;
            }
            return false;
        }
    }
}