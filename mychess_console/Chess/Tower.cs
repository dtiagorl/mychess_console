using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Tower : Piece
    {
        public Tower(Gameboard gameboard, Color color) : base(gameboard, color)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
