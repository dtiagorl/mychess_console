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
                    Console.Clear();
                    Screen.printGameboard(match.Gameboard);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    match.ExecuteMovement(origin, destination);
                }

                
            }
            catch (GameboardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
