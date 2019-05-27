using System;
using System.Collections.Generic;
using System.Text;
using Board;

namespace Chess
{
    class ChessMatch
    {
        public Gameboard Gameboard { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Gameboard = new Gameboard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
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

        public void MakeMove(Position origin, Position destination)
        {
            ExecuteMovement(origin, destination);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position pos)
        {
            if (Gameboard.Piece(pos) == null)
            {
                throw new GameboardException("There is no piece on this position!");
            }
            if (CurrentPlayer != Gameboard.Piece(pos).Color)
            {
                throw new GameboardException("This piece is not yours!");
            }
            if (!Gameboard.Piece(pos).PossibleMovementsExists())
            {
                throw new GameboardException("There is no possible movements for this piece!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!Gameboard.Piece(origin).CanMoveTo(destination))
            {
                throw new GameboardException("Invalid destination position!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
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
