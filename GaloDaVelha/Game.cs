using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaloDaVelha
{
    /// <summary>
    /// Class where most of the game logic will run
    /// </summary>
    public class Game
    {
        private Piece[] availablePieces;
        private Piece[,] board;
        private bool gameEnded = false;
        private string player1;
        private string player2;
        private int row;
        private int column;
        private ConditionsChecker checker = new ConditionsChecker();


        public void Start(){
            //Instantiates a new Setup and gets the necessary variables
            Setup setup = new Setup();
            (availablePieces, board, player1, player2) = setup.GameSetup();

            //Main game loop that keeps going as long as there isn't a winner or
            //a draw
            while (!gameEnded)
            {
                GameState();
                gameEnded = checker.CheckWin(board, row, column);
            }
            Console.WriteLine("Game Over!");
        }

                /// <summary>
        /// Shows the current game state to the user
        /// </summary>
        private void GameState()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (j == board.GetLength(1) - 1)
                    {
                        if (board[i, j] == null)
                        {
                            Console.WriteLine("  ");
                        }
                        else
                        {
                            Console.WriteLine(board[i, j].GetSymbol());
                        }
                    }
                    else
                    {
                        if (board[i, j] == null)
                        {
                            Console.Write("  |");
                        }
                        else
                        {
                            Console.Write($"{board[i, j].GetSymbol()}|");
                        }
                    }
                }
                if (i < board.GetLength(0) - 1)
                {
                    Console.WriteLine("-----------");
                }
            }
            // Explaining symbols to the player
            Console.WriteLine("Label:");
            Console.WriteLine("\u25A1 = Big Squares"); // □
            Console.WriteLine("\u25C7 = Small Squares"); // ◇
            Console.WriteLine("\u25CB = Big Circles"); // ○
            Console.WriteLine("\u25BD = Small Circles"); // ▽
            Console.WriteLine("\u25E6 = Holes"); //◦
            Console.WriteLine("- = No Holes"); //-
        }
    }
}