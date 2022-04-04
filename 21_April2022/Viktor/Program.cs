//Räkna antalet "D" i en mening.
Console.WriteLine(CountD("My friend Dylan got distracted in school."));
Console.WriteLine(CountD("Debris was scattered all over the yard."));
Console.WriteLine(CountD("The rodents hibernated in their den."));

int CountD(string sentence) => sentence.ToUpper().Count(x => x == 'D');