using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(Gameboard gameboard, Color color) : base(gameboard, color)
        {

        }

        public override string ToString()
        {
            return "B";
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

            // NW
            pos.DefineValues(Position.Row - 1, Position.Column - 1);
            while (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Gameboard.Piece(pos) != null && Gameboard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row - 1, pos.Column - 1);
            }

            // NE
            pos.DefineValues(Position.Row - 1, Position.Column + 1);
            while (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Gameboard.Piece(pos) != null && Gameboard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row - 1, pos.Column + 1);
            }

            // SE
            pos.DefineValues(pos.Row + 1, Position.Column + 1);
            while (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Gameboard.Piece(pos) != null && Gameboard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row + 1, pos.Column + 1);
            }

            // SW
            pos.DefineValues(pos.Row + 1, pos.Column - 1);
            while (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Gameboard.Piece(pos) != null && Gameboard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row + 1, pos.Column - 1);
            }

            return mat;
        }
    }
}
