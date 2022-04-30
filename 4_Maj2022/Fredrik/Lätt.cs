using System;

public class NameOrderReverser
{
    public string ChangeOrderOfFullName(string fullName)
    {
        return fullName.Split(' ')[1] + " " + fullName.Split(' ')[0];
    }
}
