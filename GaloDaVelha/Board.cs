using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaloDaVelha
{
    /// <summary>
    /// This is the Board's class
    /// </summary>
    public class Board
    {
        // Defining Piece's variables
        private Piece[,] board;
        private Piece[] pieces;

        /// <summary>
        /// This is the Board's constructor
        /// </summary>
        public Board()
        {
            board = new Piece[4, 4];
        }

        /// <summary>
        /// This method gets the Board state
        /// </summary>
        /// <returns>
        /// The Board state
        /// </returns>
        public Piece[,] GetBoard()
        {
            return board;
        }
    }
}