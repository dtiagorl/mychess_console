using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    class Gameboard
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Gameboard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[Rows, Columns];
        }

        public Piece Piece(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece Piece(Position pos)
        {
            return pieces[pos.Row, pos.Column];
        }

        public bool PieceExists(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void PlacePiece(Piece p, Position pos)
        {
            if (PieceExists(pos))
            {
                throw new GameboardException("There is already a Piece on that position!");
            }
            pieces[pos.Row, pos.Column] = p;
            p.Position = pos;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Row < 0 || pos.Row >= Rows || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new GameboardException("Invalid Position!");
            }
        }
    }
}
