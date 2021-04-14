using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            // Кодът е чужд. Не успях да поправя моя...:(  [Даваше ми 90/100 в Judge.]
            // Големи благодарности на Viktor Neykov. Използвах неговия и той ми даде 90/100.
            // Този е на Диляна Николаева. Тя твърди че нейния е 100/100.
            // Изпитът свърши, но все пак да бъда с по-хубавия код тук.
            // Взех го от нашата Messenger група „C# Advanced“.

            int marioLives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, 20];
            int playerRow = 0;
            int playerCol = 0;
            bool IsSaved = false;

            for (int i = 0; i < n; i++)
            {
                string currentRow = Console.ReadLine();
                for (int j = 0; j < currentRow.Length; j++)
                {
                    matrix[i, j] = currentRow[j];

                    if (matrix[i, j] == 'M')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }


            while (true)
            {
                if (marioLives <= 0)
                {
                    matrix[playerRow, playerCol] = 'X';
                    break;
                }

                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = line[0];

                int bowserRow = int.Parse(line[1]);
                int bowserCol = int.Parse(line[2]);
                matrix[bowserRow, bowserCol] = 'B';

                matrix[playerRow, playerCol] = '-';
                marioLives--;

                if (IsOut(command, playerRow, playerCol, n)) continue;

                playerRow = MoveRow(command, playerRow);
                playerCol = MoveCol(command, playerCol);

                if (matrix[playerRow, playerCol] == 'B')
                {
                    marioLives -= 2;
                    if (marioLives <= 0)
                    {
                        matrix[playerRow, playerCol] = 'X';
                        break;
                    }
                    else matrix[playerRow, playerCol] = '-';
                }
                else if (matrix[playerRow, playerCol] == 'P')
                {
                    IsSaved = true;
                    matrix[playerRow, playerCol] = '-';
                    break;
                }

                matrix[playerRow, playerCol] = 'M';
            }

            if (IsSaved == true) Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
            else Console.WriteLine($"Mario died at {playerRow};{playerCol}.");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                    Console.Write($"{matrix[row, col]}");
                Console.WriteLine();
            }
        }


        private static int MoveCol(string command, int position)
        {
            switch (command)
            {
                case "A": return --position;
                case "D": return ++position;
                default: return position;
            }
        }

        private static int MoveRow(string command, int position)
        {
            switch (command)
            {
                case "W": return --position;
                case "S": return ++position;

                default: return position;
            }
        }

        private static bool IsOut(string command, int playerRow, int playerCol, int n)
        {
            switch (command)
            {
                case "W": return playerRow - 1 < 0;
                case "S": return playerRow + 1 >= n;
                case "A": return playerCol - 1 < 0;
                case "D": return playerCol + 1 >= n;
                default: return false;
            }
        }
    }
}