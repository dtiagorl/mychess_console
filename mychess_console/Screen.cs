﻿using System;
using System.Collections.Generic;
using System.Text;
using Board;
using Chess;

namespace mychess_console
{
    class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            PrintGameboard(match.Gameboard);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);
            if (!match.Finished)
            {
                Console.WriteLine("Current Player: " + match.CurrentPlayer);
                if (match.Check)
                {
                    Console.WriteLine("Check!");
                }
            }
            else
            {
                Console.WriteLine("Checkmate!");
                Console.WriteLine("Winner: " + match.CurrentPlayer);
            }
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            PrintSet(match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void PrintGameboard(Gameboard gameboard)
        {
            for (int i=0; i < gameboard.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j=0; j < gameboard.Columns; j++)
                {
                    PrintPiece(gameboard.Piece(i, j));
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintGameboard(Gameboard gameboard, bool[,] possiblePositions)
        {
            ConsoleColor stdBackground = Console.BackgroundColor;
            ConsoleColor customBackground = ConsoleColor.DarkGray;


            for (int i = 0; i < gameboard.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < gameboard.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = customBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = stdBackground;
                    }
                    PrintPiece(gameboard.Piece(i, j));
                    Console.BackgroundColor = stdBackground;
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = stdBackground;
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");
            }
        }
    }
}
