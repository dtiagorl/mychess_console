using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(Gameboard gameboard, Color color) : base(gameboard, color)
        {

        }

        public override string ToString()
        {
            return "Q";
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
            while (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Gameboard.Piece(pos) != null && Gameboard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row - 1;
            }

            // south
            pos.DefineValues(Position.Row + 1, Position.Column);
            while (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Gameboard.Piece(pos) != null && Gameboard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row + 1;
            }

            // east
            pos.DefineValues(Position.Row, Position.Column + 1);
            while (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Gameboard.Piece(pos) != null && Gameboard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            // west
            pos.DefineValues(Position.Row, Position.Column - 1);
            while (Gameboard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Gameboard.Piece(pos) != null && Gameboard.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

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
