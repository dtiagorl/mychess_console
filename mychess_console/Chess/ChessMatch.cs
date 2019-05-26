using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class ChessMatch
    {
        public Gameboard Gameboard { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Gameboard = new Gameboard(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            Finished = false;
            PlacePieces();
        }

        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece p = Gameboard.RemovePiece(origin);
            p.IncrementMovementsQty();
            Piece capturedPiece = Gameboard.RemovePiece(destination);
            Gameboard.PlacePiece(p, destination);
        }

        private void PlacePieces()
        {
            Gameboard.PlacePiece(new Tower(Gameboard, Color.White), new ChessPosition('c', 1).ToPosition());
            Gameboard.PlacePiece(new Tower(Gameboard, Color.White), new ChessPosition('c', 2).ToPosition());
            Gameboard.PlacePiece(new Tower(Gameboard, Color.White), new ChessPosition('d', 2).ToPosition());
            Gameboard.PlacePiece(new Tower(Gameboard, Color.White), new ChessPosition('e', 2).ToPosition());
            Gameboard.PlacePiece(new Tower(Gameboard, Color.White), new ChessPosition('e', 1).ToPosition());
            Gameboard.PlacePiece(new King(Gameboard, Color.White), new ChessPosition('d', 1).ToPosition());

            Gameboard.PlacePiece(new Tower(Gameboard, Color.Black), new ChessPosition('c', 7).ToPosition());
            Gameboard.PlacePiece(new Tower(Gameboard, Color.Black), new ChessPosition('c', 8).ToPosition());
            Gameboard.PlacePiece(new Tower(Gameboard, Color.Black), new ChessPosition('d', 7).ToPosition());
            Gameboard.PlacePiece(new Tower(Gameboard, Color.Black), new ChessPosition('e', 7).ToPosition());
            Gameboard.PlacePiece(new Tower(Gameboard, Color.Black), new ChessPosition('e', 8).ToPosition());
            Gameboard.PlacePiece(new King(Gameboard, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
