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
        /// This method creates the initial conditions for the game
        /// </summary>
        /// <returns>
        /// All the possible Pieces, the Board and the Players
        /// </returns>
        public (Piece[], Piece[,], string, string) GameSetup()
        {
            Console.WriteLine("Hello! You are playing Galo da Velha.");
            // Asking player 1 name
            Console.Write("What is Player 1's name? ");
            string player1 = Console.ReadLine();
            // Asking player 2 name
            Console.Write("what is Player's 2 name? ");
            string player2 = Console.ReadLine();

            Console.WriteLine($"\nPlayer: {player1} and {player2}");

            Instructions();


            // Creating new Board
            board = new Board();

            return (CreatePieces(), board.GetBoard(), player1, player2);
        }

        /// <summary>
        /// This method creates all the possible pieces with their specific
        /// characteristics
        /// </summary>
        /// <returns>
        /// An array with all the 16 Pieces
        /// </returns>
        private Piece[] CreatePieces()
        {
            Piece swth = new Piece("swth", "\u25A0\u25E6", true, true, true, true); // ■◦
            Piece swtp = new Piece("swtp", "\u25A0-", true, true, true, false); // ■
            Piece swsh = new Piece("swsh", "\u25C6\u25E6", true, true, false, true); // ◆◦
            Piece swsp = new Piece("swsp", "\u25C6-", true, true, false, false); // ◆
            Piece sbth = new Piece("sbth", "\u25A1\u25E6", true, false, true, true); // □◦
            Piece sbtp = new Piece("sbtp", "\u25A1-", true, false, true, false); // □
            Piece sbsh = new Piece("sbsh", "\u25C7\u25E6", true, false, false, true); // ◇◦
            Piece sbsp = new Piece("sbsp", "\u25C7-", true, false, false, false); // ◇
            Piece cwth = new Piece("cwth", "\u25CF\u25E6", false, true, true, true); // ●◦
            Piece cwtp = new Piece("cwtp", "\u25CF-", false, true, true, false); // ●
            Piece cwsh = new Piece("cwsh", "\u25BC\u25E6", false, true, false, true); // ▼◦
            Piece cwsp = new Piece("cwsp", "\u25BC-", false, true, false, false); // ▼
            Piece cbth = new Piece("cbth", "\u25CB\u25E6", false, false, true, true); // ○◦
            Piece cbtp = new Piece("cbtp", "\u25CB-", false, false, true, false); // ○
            Piece cbsh = new Piece("cbsh", "\u25BD\u25E6", false, false, false, true); // ▽◦
            Piece cbsp = new Piece("cbsp", "\u25BD-", false, false, false, false); // ▽
            return pieces = new Piece[16] {swth, swtp, swsh, swsp, sbth, sbtp,
            sbsh, sbsp, cwth, cwtp, cwsh, cwsp, cbth, cbtp, cbsh, cbsp};
        }

        /// <summary>
        /// Method to show the instructions to the players
        /// </summary>
        private void Instructions()
        {
            Console.WriteLine();
            Console.WriteLine("Instructions:");
            Console.WriteLine();
            Console.WriteLine("Each player will pick the piece for the opponent.");
            Console.Write("Then the opponent must place the piece on one of");
            Console.WriteLine(" the available spaces.");
            Console.Write("The goal is to be the player that places a piece");
            Console.Write(" in a way that it forms a line of 4 pieces with 1");
            Console.WriteLine(" characteristic in common.");
            Console.WriteLine();
            Console.WriteLine("The names of the pieces indicate its characteristics:");
            Console.WriteLine("First letter: s for square and c for circle");
            Console.WriteLine("Second letter: w for white and b for black");
            Console.WriteLine("Third letter: t for tall and s for short");
            Console.WriteLine("Fourth letter: h for hole and p for plain");
        }
    }
}