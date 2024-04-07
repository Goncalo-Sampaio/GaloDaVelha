using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaloDaVelha
{
    public class Piece
    {
        // defining Piece's variables
        private string name;
        private string symbol;
        private bool[] characteristics = new bool[4];

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
    }
}