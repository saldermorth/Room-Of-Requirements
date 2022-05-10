#region PROBLEM LÄTTARE
//LÖSNING 1
int FindMissingPiece(int[] numbers)
{
    Array.Sort(numbers);
    for (int i = 1; i <= numbers.Length; i++)
    {
        if (numbers[i - 1] != i) return i;
    }
    return 0;
}
//LÖSNING 2
int FindMissingPiece2(int[] numbers)
{
    int sumOfAllFears = 0;
    for (int i = 1; i <= numbers.Length + 1; i++)
    {
        sumOfAllFears += i;
    }
    Console.WriteLine(sumOfAllFears);
    Console.WriteLine(numbers.Sum());
    return sumOfAllFears - numbers.Sum();
}

//Console.WriteLine(FindMissingPiece( new int[]{1,3,6,2,4,5,15,13,14,9,8,7,10}));
//Console.WriteLine(FindMissingPiece2( new int[]{1,13,6,2,4,7,8,9,10,11,12,5,15,14}));
#endregion

#region PROBLEM MELLAN
bool CheckArrayForSum(int[] numbers, int inputSum)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        for (int x = 0; x < numbers.Length; x++)
        {
            if (x == i) continue;
            if (numbers[x] + numbers[i] == inputSum) return true;
        }
    }
    return false;
}
//int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//Console.WriteLine(CheckArrayForSum(numbers, 4));
#endregion

#region PROBLEM SVÅRARE
//Fullösningen
int ReverseCodeChallenge(int number) => number switch
    {
        51 => 36,
        665 => 99,
        832 => 594,
        7977 => 198,
        _ => 0,
    };

//Rätta lösningen
int ReverseCodeChallengeUltimateSuperiorSolution(int number) => 
    (number - int.Parse(string.Concat(number.ToString().ToCharArray().OrderBy(x => x))));

//Console.WriteLine(ReverseCodeChallengeUltimateSuperiorSolution(832));
//Console.WriteLine(ReverseCodeChallengeUltimateSuperiorSolution(51));
//Console.WriteLine(ReverseCodeChallengeUltimateSuperiorSolution(7977));
//Console.WriteLine(ReverseCodeChallengeUltimateSuperiorSolution(1));
//Console.WriteLine(ReverseCodeChallengeUltimateSuperiorSolution(665));
//Console.WriteLine(ReverseCodeChallengeUltimateSuperiorSolution(149));
#endregion

#region GOD MODE
int[,] TurnMatrix(int[,] input)
{
    int sideLength = (int)Math.Sqrt(input.Length);
    int[,] output = new int [sideLength,sideLength];
    int maxIndex = sideLength - 1;
    for (int i = 0; i < sideLength; i++)
    {
        for (int x = 0; x < sideLength; x++)
        {
            output[x, maxIndex - i] = input[i, x];
        }
    }
    return output;
}

void WriteMatrix(int [,] matrix)
{
    int sideLength = (int)Math.Sqrt(matrix.Length);

    for (int i = 0; i < sideLength; i++)
    {
        for (int x = 0; x < sideLength; x++)        {

            Console.Write($" {matrix[i, x]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] matrix = {
{ 1, 2, 3, 4, 5},
{ 6,7,8,9,1 },
{ 2,3,4,5,6},
{ 7,8,9,1,2 },
{ 3,4,5,6,7 }
};
//WriteMatrix(matrix);
//matrix = TurnMatrix(matrix);
//WriteMatrix(matrix);
#endregion