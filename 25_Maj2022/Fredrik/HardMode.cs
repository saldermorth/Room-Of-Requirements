using System;

public class HardMode
{
    public int FindSolution(int number)
    {
        return number - Convert.ToInt32(new string(Convert.ToString(number).OrderBy(x => x).ToArray()));
    }
}
