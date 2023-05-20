using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int rows = 1;
        int columns = 1;
        Stack<(int, int)> undoStack = new Stack<(int, int)>();
        Stack<(int, int)> redoStack = new Stack<(int, int)>();

        while (true)
        {
            int move = int.Parse(Console.ReadLine());

            if (move == 11)
                break;
            else if (move == 9 && undoStack.Count > 0)
            {
                (rows, columns) = undoStack.Pop();
                redoStack.Push((rows, columns));
                continue;
            }
            else if (move == 10 && redoStack.Count > 0)
            {
                (rows, columns) = redoStack.Pop();
                undoStack.Push((rows, columns));
                continue;
            }
            else if (move != 9 && move != 10)
            {
                int x = int.Parse(Console.ReadLine());
                if (CheckMove(move, rows, columns, x))
                {
                    undoStack.Push((rows, columns));
                    Move(move, ref rows, ref columns, x);
                    redoStack.Clear();
                }
            }
        }

        Console.WriteLine(Convert.ToChar(columns - 1 + 'A') + " " + rows);
    }

    static bool CheckMove(int action, int rows, int columns, int x)
    {
        switch (action)
        {
            case 1:
                return rows + x <= 8;
            case 2:
                return rows + x <= 8 && columns - 1 > 0;
            case 3:
                return columns - x > 0;
            case 4:
                return rows - x > 0 && columns - x > 0;
            case 5:
                return rows - x > 0;
            case 6:
                return rows - x > 0 && columns + x <= 8;
            case 7:
                return columns + x <= 8;
            case 8:
                return rows + x <= 8 && columns + x <= 8;
            default:
                return false;
        }
    }

    static void Move(int action, ref int rows, ref int columns, int x)
    {
        switch (action)
        {
            case 1:
                rows += x;
                break;
            case 2:
                rows += x;
                columns -= x;
                break;
            case 3:
                columns -= x;
                break;
            case 4:
                rows -= x;
                columns -= x;
                break;
            case 5:
                rows -= x;
                break;
            case 6:
                rows -= x;
                columns += x;
                break;
            case 7:
                columns += x;
                break;
            case 8:
                rows += x;
                columns += x;
                break;
        }
    }
}
