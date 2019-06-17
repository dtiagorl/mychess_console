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
        private HashSet<Piece> pieces;
        private HashSet<Piece> captures;

        public ChessMatch()
        {
            Gameboard = new Gameboard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            pieces = new HashSet<Piece>();
            captures = new HashSet<Piece>();
            PlacePieces();
        }

        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece p = Gameboard.RemovePiece(origin);
            p.IncrementMovementsQty();
            Piece capturedPiece = Gameboard.RemovePiece(destination);
            Gameboard.PlacePiece(p, destination);
            if (capturedPiece != null)
            {
                captures.Add(capturedPiece);
            }
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

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captures)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> InGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Gameboard.PlacePiece(piece, new ChessPosition(column, row).ToPosition());
            pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece('c', 1, new Tower(Gameboard, Color.White));
            PlaceNewPiece('c', 2, new Tower(Gameboard, Color.White));
            PlaceNewPiece('d', 2, new Tower(Gameboard, Color.White));
            PlaceNewPiece('e', 2, new Tower(Gameboard, Color.White));
            PlaceNewPiece('e', 1, new Tower(Gameboard, Color.White));
            PlaceNewPiece('d', 1, new King(Gameboard, Color.White));

            PlaceNewPiece('c', 7, new Tower(Gameboard, Color.Black));
            PlaceNewPiece('c', 8, new Tower(Gameboard, Color.Black));
            PlaceNewPiece('d', 7, new Tower(Gameboard, Color.Black));
            PlaceNewPiece('e', 7, new Tower(Gameboard, Color.Black));
            PlaceNewPiece('e', 8, new Tower(Gameboard, Color.Black));
            PlaceNewPiece('d', 8, new King(Gameboard, Color.Black));
        }
    }
}
