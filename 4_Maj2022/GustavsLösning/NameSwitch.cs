string name = "Gustav Berg";

string[] namereverce = name.Split(' ');

name = "";

name = namereverce[1] + " ";


name += namereverce[0];


Console.WriteLine(name);

Console.ReadLine();
