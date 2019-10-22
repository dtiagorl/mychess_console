using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(Gameboard gameboard, Color color) : base(gameboard, color)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        private bool EnemyExists(Position pos)
        {
            Piece p = Gameboard.Piece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Gameboard.Piece(pos) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Gameboard.Rows, Gameboard.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.DefineValues(Position.Row - 1, Position.Column);
                if (Gameboard.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row - 2, Position.Column);
                if (Gameboard.ValidPosition(pos) && Free(pos) && MovementsQty == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row - 1, Position.Column - 1);
                if (Gameboard.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row - 1, Position.Column + 1);
                if (Gameboard.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
            }
            else
            {
                pos.DefineValues(Position.Row + 1, Position.Column);
                if (Gameboard.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row + 2, Position.Column);
                if (Gameboard.ValidPosition(pos) && Free(pos) && MovementsQty == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row + 1, Position.Column - 1);
                if (Gameboard.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row + 1, Position.Column + 1);
                if (Gameboard.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
            }

            return mat;
        }
    }
}
