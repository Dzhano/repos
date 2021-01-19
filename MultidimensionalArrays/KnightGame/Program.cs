using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Код от Слави Капсалов.
            // Code by Slavi Kapsalov. 
            int n = int.Parse(Console.ReadLine());
            char[,] chessBoard = new char[n,n];
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                    chessBoard[i, j] = input[j];
            }
            int removedKnights = 0;
            while (true)
            {
                int maxAttackedKnights = 0;
                int knightRow = -1;
                int knightCol = -1;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        char symbol = chessBoard[row, col];
                        if (symbol != 'K') continue;
                        int count = CountAttackedKnights(chessBoard, row, col);
                        if (count > maxAttackedKnights)
                        {
                            maxAttackedKnights = count;
                            knightCol = col;
                            knightRow = row;
                        }
                    }
                }
                if (maxAttackedKnights == 0) break;
                chessBoard[knightRow, knightCol] = '0';
                removedKnights++;
            }
            Console.WriteLine(removedKnights);
        }

        private static int CountAttackedKnights(char[,] chessBoard, int row, int col)
        {
            int count = 0;
            if (ContainsKnight(chessBoard, row - 2, col - 1)) count++;
            if (ContainsKnight(chessBoard, row - 2, col + 1)) count++;
            if (ContainsKnight(chessBoard, row - 1, col - 2)) count++;
            if (ContainsKnight(chessBoard, row - 1, col + 2)) count++;
            if (ContainsKnight(chessBoard, row + 1, col - 2)) count++;
            if (ContainsKnight(chessBoard, row + 1, col + 2)) count++;
            if (ContainsKnight(chessBoard, row + 2, col - 1)) count++;
            if (ContainsKnight(chessBoard, row + 2, col + 1)) count++;
            return count;
        }

        private static bool ContainsKnight(char[,] chessBoard, int row, int col)
        {
            if (!(row >= 0 && row < chessBoard.GetLength(0) && col >= 0 && col < chessBoard.GetLength(0)))
                return false;
            return chessBoard[row, col] == 'K';
        }
    }
}
