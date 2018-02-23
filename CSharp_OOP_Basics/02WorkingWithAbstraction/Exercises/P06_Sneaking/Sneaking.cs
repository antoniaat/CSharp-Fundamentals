using System;

internal class Sneaking
{
    static char[][] room;

    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        room = CreateMatrix(n);

        var moves = Console.ReadLine()
            ?.ToCharArray();

        var samPosition = FindSamPosition(room);

        for (int i = 0; i < moves.Length; i++)
        {
            MoveEnemies();
            var getEnemy = FindEnemyPosition(samPosition);
            CheckIfSamIsDead(samPosition, getEnemy);
            ReadCommands(moves, samPosition, i);

            for (int index = 0; index < room[samPosition[0]].Length; index++)
            {
                if (room[samPosition[0]][index] != '.' && room[samPosition[0]][index] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = index;
                }
            }

            CheckIfNikoladzeIsDead(getEnemy, samPosition);
        }
    }

    private static int[] FindEnemyPosition(int[] samPosition)
    {
        var getEnemy = new int[2];
        for (int j = 0; j < room[samPosition[0]].Length; j++)
        {
            if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
            {
                getEnemy[0] = samPosition[0];
                getEnemy[1] = j;
            }
        }

        return getEnemy;
    }

    private static void MoveEnemies()
    {
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'b')
                {
                    if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                    {
                        room[row][col] = '.';
                        room[row][col + 1] = 'b';
                        col++;
                    }
                    else
                    {
                        room[row][col] = 'd';
                    }
                }
                else if (room[row][col] == 'd')
                {
                    if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                    {
                        room[row][col] = '.';
                        room[row][col - 1] = 'd';
                    }
                    else
                    {
                        room[row][col] = 'b';
                    }
                }
            }
        }
    }

    private static void CheckIfNikoladzeIsDead(int[] getEnemy, int[] samPosition)
    {
        if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
        {
            room[getEnemy[0]][getEnemy[1]] = 'X';
            Console.WriteLine("Nikoladze killed!");
            PrintMatrix();
        }
    }

    private static void ReadCommands(char[] moves, int[] samPosition, int i)
    {
        room[samPosition[0]][samPosition[1]] = '.';
        switch (moves[i])
        {
            case 'U':
                samPosition[0]--;
                break;
            case 'D':
                samPosition[0]++;
                break;
            case 'L':
                samPosition[1]--;
                break;
            case 'R':
                samPosition[1]++;
                break;
        }
        room[samPosition[0]][samPosition[1]] = 'S';
    }

    private static void CheckIfSamIsDead(int[] samPosition, int[] getEnemy)
    {
        if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
        {
            room[samPosition[0]][samPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            PrintMatrix();
        }
        else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
        {
            room[samPosition[0]][samPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            PrintMatrix();
        }
    }

    private static void PrintMatrix()
    {
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                Console.Write(room[row][col]);
            }
            Console.WriteLine();
        }
        Environment.Exit(0);
    }

    private static int[] FindSamPosition(char[][] c)
    {
        var samPosition = new int[2];
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'S')
                {
                    samPosition[0] = row;
                    samPosition[1] = col;
                }
            }
        }

        return samPosition;
    }

    private static char[][] CreateMatrix(int n)
    {
        room = new char[n][];

        for (int row = 0; row < n; row++)
        {
            var input = Console.ReadLine().ToCharArray();
            room[row] = new char[input.Length];
            for (int col = 0; col < input.Length; col++)
            {
                room[row][col] = input[col];
            }
        }

        return room;
    }
}
