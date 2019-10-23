using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class King : Piece
    {
        private ChessMatch match;

        public King(Gameboard gameboard, Color color, ChessMatch match) : base(gameboard, color)
        {
            this.match = match;
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

        private bool CastlingTowerTest(Position pos)
        {
            Piece p = Gameboard.Piece(pos);
            return p != null && p is Tower && p.Color == Color && p.MovementsQty == 0;
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

            // Special Movement Castling
            if (MovementsQty == 0 && !match.Check)
            {
                // Special Movement Castling Short
                Position posT1 = new Position(Position.Row, Position.Column + 3);
                if (CastlingTowerTest(posT1))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (Gameboard.Piece(p1) == null && Gameboard.Piece(p2) == null)
                    {
                        mat[Position.Row, Position.Column + 2] = true;
                    }
                }

                // Special Movement Castling Long
                Position posT2 = new Position(Position.Row, Position.Column - 4);
                if (CastlingTowerTest(posT2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    if (Gameboard.Piece(p1) == null && Gameboard.Piece(p2) == null && Gameboard.Piece(p3) == null)
                    {
                        mat[Position.Row, Position.Column - 2] = true;
                    }
                }
            }


            return mat;
        }
    }
}
