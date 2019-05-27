using System;
using Board;
using Chess;

namespace mychess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintGameboard(match.Gameboard);
                        Console.WriteLine();
                        Console.WriteLine("Turn: " + match.Turn);
                        Console.WriteLine("Current Player: " + match.CurrentPlayer);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = match.Gameboard.Piece(origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintGameboard(match.Gameboard, possiblePositions);

                        Console.WriteLine();

                        Console.Write("Destination: ");
                        Position destination = Screen.ReadChessPosition().ToPosition();
                        match.ValidateDestinationPosition(origin, destination);

                        match.MakeMove(origin, destination);
                    }
                    catch (GameboardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }

                
            }
            catch (GameboardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
