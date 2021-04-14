using System;

namespace _02.Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            // Кодът е чужд. Не успях да поправя моя...:( Дава 90/100 в Judge.
            // Големи благодарности на Viktor Neykov.


            int marioLives = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];


            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < currentRow.Length; col++)
                    matrix[row, col] = currentRow[col];
            }
            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            while (marioLives > 0)
            {
                string[] command = Console.ReadLine().Split();

                matrix[marioRow, marioCol] = '-';

                string moveDirection = command[0].ToString().ToLower();

                var spawnCoordinatesRow = int.Parse(command[1]);
                var spawnCoordinatesCol = int.Parse(command[2]);

                matrix[spawnCoordinatesRow, spawnCoordinatesCol] = 'B';

                var rowToReturn = marioRow;
                var colToReturn = marioCol;

                marioRow = MoveRow(marioRow, moveDirection);
                marioCol = MoveCol(marioCol, moveDirection);

                marioLives -= 1;
                if (marioLives <= 0)
                {
                    matrix[marioRow, marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }

                if (!isValid(marioRow, marioCol, n, n))
                {
                    // Трябва да остане на предишната позиция.

                    marioRow = rowToReturn;
                    marioCol = colToReturn;
                    matrix[marioRow, marioCol] = 'M';
                }

                if (matrix[marioRow, marioCol] == 'B')
                {
                    marioLives -= 2;
                    if (marioLives <= 0)
                    {
                        matrix[marioRow, marioCol] = 'X';
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                        break;
                    }
                }

                if (matrix[marioRow, marioCol] == 'P')
                {
                    matrix[marioRow, marioCol] = '-';

                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
                    break;
                }
                else
                {
                    matrix[marioRow, marioCol] = 'M';
                }

            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }


        public static int MoveRow(int row, string movement)
        {
            if (movement == "w") return row - 1;
            if (movement == "s") return row + 1;

            return row;

        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "a") return col - 1;
            if (movement == "d") return col + 1;

            return col;

        }

        public static bool isValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows) return false;
            if (col < 0 || col >= cols) return false;

            return true;
        }

    }
}
