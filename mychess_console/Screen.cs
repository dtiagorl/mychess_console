using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace mychess_console
{
    class Screen
    {
        public static void printGameboard(Gameboard gameboard)
        {
            for (int i=0; i < gameboard.Rows; i++)
            {
                for (int j=0; j < gameboard.Columns; j++)
                {
                    if (gameboard.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(gameboard.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
