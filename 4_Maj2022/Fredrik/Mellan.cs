using System;

public class EmailValidator
{
    public bool EmailIsValid(string email)
    {
        if (email.Count(x => x == '@') != 1 ||
            email.Split('@')[0].Length < 2 ||
            email.Split('@')[1].Count(x => x == '.') != 1 ||
            email.Split('@')[1][0] == '.' ||
            email.Split('@')[1].Split('.')[0].Length < 3 ||
            email.Split('@')[1].Split('.')[1].Length < 2)
        {
            return false;
        }

        return true;
    }
}
