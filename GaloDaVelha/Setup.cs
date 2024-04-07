using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaloDaVelha
{
    /// <summary>
    /// This class creates everything for the game
    /// </summary>
    public class Setup
    {
        // Defining Setups variables
        private Piece[] pieces;
        private Board board;

        /// <summary>
        /// This method creates a new game
        /// </summary>
        /// <returns>
        /// All the possible Pieces, the Board and the Players
        /// </returns>
        public (Piece[], Piece[,], string, string) GameSetup()
        {
            Console.WriteLine("HEllo! You are playing Galo da Velha.");
            // Asking player 1 name
            Console.Write("What is Player 1's name? ");
            string player1 = Console.ReadLine();
            // Asking player 2 name
            Console.Write("what is Player's 2 name? ");
            string player2 = Console.ReadLine();

            Console.WriteLine($"\nPlayer: {player1} and {player2}");

            // Creating new Board
            board = new Board();

            return (pieces, board.GetBoard(), player1, player2);
        }
    }
}