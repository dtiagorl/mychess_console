using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementsQty { get; protected set; }
        public Gameboard Gameboard { get; protected set; }

        public Piece(Gameboard gameboard, Color color)
        {
            Position = null;
            Gameboard = gameboard;
            Color = color;
            MovementsQty = 0;
        }
    }
}
