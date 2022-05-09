using System;

public class GodMode
{
    public int Size { get; set; }

    public int[,] Matrix { get; set; }

    public GodMode(int size)
    {
        Matrix = new int[size, size];
        Size = size;

        int counter = 1;

        for (int y = 0; y < Matrix.GetLength(0); y++)
        {
            for (int x = 0; x < Matrix.GetLength(1); x++)
            {
                Matrix[x, y] = counter;
                counter++;
                if (counter > 9)
                {
                    counter = 1;
                }
            }
        }
    }

    public void PrintMatrix()
    {
        for (int y = 0; y < Matrix.GetLength(0); y++)
        {
            for (int x = 0; x < Matrix.GetLength(1); x++)
            {
                Console.Write(Matrix[x, y] + " ");
            }
            Console.WriteLine();
        }
    }

    public void TwistMatrix()
    {
        int[,] temp = new int[Size, Size];

        for (int y = 0; y < Matrix.GetLength(0); y++)
        {
            for (int x = 0; x < Matrix.GetLength(1); x++)
            {
                temp[x, y] = Matrix[y, Size - 1 - x];
            }
        }

        Matrix = temp;
    }
}
