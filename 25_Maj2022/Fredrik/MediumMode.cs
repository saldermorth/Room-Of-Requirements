using System;

public class MediumMode
{
    public int Value { get; set; }
    public int[] Numbers { get; set; }

    public MediumMode(int value, int arrayLength)
    {
        Numbers = new int[arrayLength];
        Value = value;
        for (int i = 0; i < Numbers.Length; i++)
        {
            Numbers[i] = i + 1;
        }
    }

    public bool SumMatchesValue()
    {
        List<int> sums = new();

        for (int i = 0; i < Numbers.Length; i++)
        {
            for (int j = 0; j < Numbers.Length; j++)
            {
                if (Numbers[i] != Numbers[j])
                {
                    sums.Add(Numbers[i] + Numbers[j]);
                }
            }
        }

        return sums.Any(x => x == Value);
    }
