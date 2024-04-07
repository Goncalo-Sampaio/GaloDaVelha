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
        private Board board;
        private Piece[,] spaces;
        private bool gameEnded = false;
        private int row;
        private int column;
        private ConditionsChecker checker = new ConditionsChecker();


        public void Start(){
            board = new Board();
            spaces = board.GetBoard();

            //Main game loop that keeps going as long as there isn't a winner or
            //a draw
            while (!gameEnded)
            {
                gameEnded = checker.CheckWin(spaces, row, column);
            }
            Console.WriteLine("Game Over!");
        }
    }
}