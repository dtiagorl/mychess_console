using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class King : Piece
    {
        public King(Gameboard gameboard, Color color) : base(gameboard, color)
        {

        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Gameboard.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Gameboard.Rows, Gameboard.Columns];

            Position pos = new Position(0, 0);

            // north
            pos.DefineValues(Position.Row - 1, Position.Column);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // northeast
            pos.DefineValues(Position.Row - 1, Position.Column + 1);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // east
            pos.DefineValues(Position.Row, Position.Column + 1);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // southeast
            pos.DefineValues(Position.Row + 1, Position.Column + 1);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // south
            pos.DefineValues(Position.Row + 1, Position.Column);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // southwest
            pos.DefineValues(Position.Row + 1, Position.Column - 1);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // west
            pos.DefineValues(Position.Row, Position.Column - 1);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // northwest
            pos.DefineValues(Position.Row - 1, Position.Column - 1);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }
    }
}
