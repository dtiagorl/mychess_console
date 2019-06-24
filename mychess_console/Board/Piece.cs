using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
   abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementsQty { get; protected set; }
        public Gameboard Gameboard { get; protected set; }

        public Piece(Gameboard gameboard, Color color)
        {
            Position = null;
            Gameboard = gameboard;
            Color = color;
            MovementsQty = 0;
        }

        public void IncrementMovementsQty()
        {
            MovementsQty++;
        }

        public void DecrementMovementsQty()
        {
            MovementsQty--;
        }

        public bool PossibleMovementsExists()
        {
            bool[,] mat = PossibleMovements();
            for (int i=0; i < Gameboard.Rows; i++)
            {
                for (int j=0; j < Gameboard.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossibleMovements()[pos.Row, pos.Column];
        }

        public abstract bool[,] PossibleMovements();
    }
}
