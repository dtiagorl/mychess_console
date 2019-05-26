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
    }
}
