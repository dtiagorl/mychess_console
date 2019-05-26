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
        public Board Board { get; protected set; }

        public Piece(Position position, Board board, Color color)
        {
            Position = position;
            Board = board;
            Color = color;
            MovementsQty = 0;
        }
    }
}
