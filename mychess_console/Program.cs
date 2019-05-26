using System;
using Board;
using Chess;

namespace mychess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Gameboard gameboard = new Gameboard(8, 8);

            gameboard.PlacePiece(new Tower(gameboard, Color.Black), new Position(0, 0));
            gameboard.PlacePiece(new Tower(gameboard, Color.Black), new Position(1, 3));
            gameboard.PlacePiece(new King(gameboard, Color.Black), new Position(2, 4));

            Screen.printGameboard(gameboard);

        }
    }
}
