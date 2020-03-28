using System;

namespace Chess_Back_Tracking
{
    class Program
    {
        private static int width = 8;
        private static int height = 8;
        private static int queenCount = 8;
        private static ChessTile[,] ChessTable = new ChessTile[width, height];

        public static void Main()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    ChessTable[y, x] = new ChessTile((y % 2 == 0 && x % 2 == 0) || (y % 2 == 1 && x % 2 == 1));
                }
            }

            Console.WriteLine(PutQueenOnTile(0, 0, queenCount) ? "Successfull" : "NOPE");

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    ChessTable[y, x].PrintTile();
                }
                Console.WriteLine("");
            }

            Console.ReadKey();

        }

        public static bool PutQueenOnTile(int startX, int startY, int remainingQueens) 
        {
            for (int y = startY; y >= 0; y--) 
            {
                if (ChessTable[y, startX].DoesItHaveAPiece()) 
                {
                    return false;
                }
            }

            for (int x = startX; x >= 0; x--)
            {
                if (ChessTable[startY, x].DoesItHaveAPiece())
                {
                    return false;
                }
            }

            for (int x = startX, y = startY; x >= 0 && y >=0; x--, y--)
            {
                if (ChessTable[y, x].DoesItHaveAPiece()) 
                {
                    return false;
                }
            }

            for (int x = startX, y = startY; x < width && y >= 0; x++, y--)
            {
                if (ChessTable[y, x].DoesItHaveAPiece())
                {
                    return false;
                }
            }

            ChessTable[startY, startX].SetHasPiece(true);
            if (remainingQueens > 1)
            {
                bool subResult = false;
                for (int y = startY; y < height; y++)
                {
                    for (int x = y == startY ? startX + 1 : 0; x < width; x++)
                    {
                        subResult = PutQueenOnTile(x, y, remainingQueens - 1);

                        if (subResult)
                        {
                            break;
                        }
                    }

                    if (subResult)
                    {
                        break;
                    }

                    if (y == height - 1)
                    {
                        ChessTable[startY, startX].SetHasPiece(false);
                        return false;
                    }
                }
            }
            return true;

        }

    }
}
