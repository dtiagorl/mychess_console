using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class Pawn : Piece
    {

        private ChessMatch match;

        public Pawn(Gameboard gameboard, Color color, ChessMatch match) : base(gameboard, color)
        {
            this.match = match;
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

                // Special Movement En Passant
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Gameboard.ValidPosition(left) && EnemyExists(left) && Gameboard.Piece(left) == match.enPassantVulnerable)
                    {
                        mat[left.Row - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Gameboard.ValidPosition(right) && EnemyExists(right) && Gameboard.Piece(right) == match.enPassantVulnerable)
                    {
                        mat[right.Row - 1, right.Column] = true;
                    }
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

                // Special Movement En Passant
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Gameboard.ValidPosition(left) && EnemyExists(left) && Gameboard.Piece(left) == match.enPassantVulnerable)
                    {
                        mat[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Gameboard.ValidPosition(right) && EnemyExists(right) && Gameboard.Piece(right) == match.enPassantVulnerable)
                    {
                        mat[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}
