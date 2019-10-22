using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Knight : Piece
    {
        public Knight(Gameboard gameboard, Color color) : base(gameboard, color)
        {

        }

        public override string ToString()
        {
            return "H";
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

            pos.DefineValues(Position.Row - 1, Position.Column - 2);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row - 2, Position.Column - 1);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row - 2, Position.Column + 1);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row - 1, Position.Column + 2);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row + 1, Position.Column + 2);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row + 2, Position.Column + 1);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row + 2, Position.Column - 1);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row + 1, Position.Column - 2);
            if (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }
    }
}
