using System;

public class EasyMode
{
    public static int[] InputExample = { 4, 3, 6, 2, 9, 8, 1, 5 };

    public int FindMissingNumber()
    {
        int[] numbers = InputExample.OrderBy(x => x).ToArray();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (i + 1 != numbers[i])
            {
                return numbers[i] - 1;
            }
        }

        return -1;
    }
}
