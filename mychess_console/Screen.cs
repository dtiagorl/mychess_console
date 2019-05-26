﻿using System;
using System.Collections.Generic;
using System.Text;
using Board;
using Chess;

namespace mychess_console
{
    class Screen
    {
        public static void printGameboard(Gameboard gameboard)
        {
            for (int i=0; i < gameboard.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j=0; j < gameboard.Columns; j++)
                {
                    if (gameboard.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(gameboard.Piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
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
        }
    }
}
