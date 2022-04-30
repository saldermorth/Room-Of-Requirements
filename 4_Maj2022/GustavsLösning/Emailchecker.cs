string email = "gustav.berg@domain.aa";

bool isCorrect = false;
char[] emailA = email.ToArray();
int indexOne = 0;
int indexTwo = 0;
int indexThree = 0;


if (email.Contains('.') && email.Contains('@'))
{    
    indexOne = email.LastIndexOf('.');
    indexTwo = email.Length;
    indexThree = email.IndexOf('@');
    if (indexTwo - indexOne > 1)
    {
        
        if (indexOne - indexThree > 2)
        {
            isCorrect = true;
            Console.WriteLine("Correct email");
        }
        else
        {
            Console.WriteLine("Email need a minimum of three characters between @ and last .");
        }
    }
    else
    {
        Console.WriteLine("Email need a minimum of two characters after last . ");
    }

}
else
{
    Console.WriteLine("Needs both . and @ in email");
}
