using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Back_Tracking
{
    public class ChessTile
    {
        private bool isWhite;
        private bool hasPiece;

        public ChessTile(bool isWhite)
        {
            this.isWhite = isWhite;
            this.hasPiece = false;
        }

        public bool DoesItHaveAPiece() 
        {
            return hasPiece;
        }

        public void SetHasPiece(bool hasPiece)
        {
            this.hasPiece = hasPiece;
        }

        public void PrintTile()
        {
            Console.BackgroundColor = isWhite ? ConsoleColor.White : ConsoleColor.Black;
            Console.ForegroundColor = isWhite ? ConsoleColor.Black : ConsoleColor.White;
            Console.Write(hasPiece ? "X " : "  ");
        }
    }
}
