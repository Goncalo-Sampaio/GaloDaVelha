using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaloDaVelha
{
    /// <summary>
    /// This is the Piece's class
    /// </summary>
    public class Piece
    {
        // defining Piece's variables
        private string name;
        private string symbol;
        private bool[] characteristics = new bool[4];

        /// <summary>
        /// This is the class Piece constructor
        /// </summary>
        /// <param name="name">
        /// This is the Piece's name
        /// </param>
        /// <param name="symbol">
        /// This is the Piece's symbol/symbols
        /// </param>
        /// <param name="square">
        /// This says the Piece is a square(true) or a circle(false)
        /// </param>
        /// <param name="white">
        /// This says the Piece is a white(true) or a black(false)
        /// </param>
        /// <param name="tall">
        /// This says if the Piece is tall(true) or small(false)
        /// </param>
        /// <param name="hole">
        /// This says if the Piece has a hole(true) or not(false)
        /// </param>
        public Piece(string name, string symbol, bool square, bool white,
            bool tall, bool hole)
        {
            this.name = name;
            this.symbol = symbol;
            characteristics[0] = square;
            characteristics[1] = white;
            characteristics[2] = tall;
            characteristics[3] = hole;
        }
        /// <summary>
        /// This a method to get the Piece's name
        /// </summary>
        /// <returns>
        /// The Piece's name
        /// </returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// This is a method to get the Piece's symbol/s
        /// </summary>
        /// <returns>
        /// The Piece's symbol/s
        /// </returns>
        public string GetSymbol()
        {
            return symbol;
        }

        /// <summary>
        /// This is a method to get the Piece's characteristics
        /// </summary>
        /// <returns>
        /// The Piece's characteristics
        /// </returns>
        public bool[] GetCharacteristics()
        {
            return characteristics;
        }
    }
}