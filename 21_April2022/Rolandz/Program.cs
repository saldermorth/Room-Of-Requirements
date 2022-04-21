// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Linq;

Console.WriteLine("Hello, World!");

Stopwatch timer = new Stopwatch();
timer.Start();

string[] input = File.ReadAllLines("input.txt");
List<City> cityList = new List<City>();
int counter = 0;


foreach (var item in input)
{
    string[] splitString = item.Split(' ');
    int distance = int.Parse(splitString[4]);
    if (!cityList.Any(x => x.Name == splitString[0])) cityList.Add(new City(splitString[0]));

    int index = cityList.FindIndex(x => x.Name == splitString[0]);
    cityList[index].Neighbors.Add(splitString[2], distance);

    if (!cityList.Any(x => x.Name == splitString[2])) cityList.Add(new City(splitString[2]));
    index = cityList.FindIndex(x => x.Name == splitString[2]);
    cityList[index].Neighbors.Add(splitString[0], distance);

}

List<Path> posPaths = new List<Path>();
List<Path> checkedPaths = new List<Path>();
int shortestValue = int.MaxValue;
int longestValue = int.MinValue;

void FindPaths(List<City> cityList, City item)
{
    Path path = new Path(cityList);
    List<Path> localPosPaths = new();
    path.Cities.Add(item);
    localPosPaths.Add(path);

    while (localPosPaths.Count > 0)
    {
        int index = localPosPaths.Count - 1;
        List<Path> newPaths = new List<Path>();
        //if (localPosPaths.Last().Cost > shortestValue)
        //{
        //    localPosPaths.RemoveAt(index);
        //    continue;
        //}

        counter++;
        if (localPosPaths.Last().Cities.Count == cityList.Count)
        {
            checkedPaths.Add(localPosPaths.Last());
            if (localPosPaths.Last().TotalDistance < shortestValue) shortestValue = localPosPaths.Last().TotalDistance;
            if (localPosPaths.Last().TotalDistance > longestValue) longestValue = localPosPaths.Last().TotalDistance;

            localPosPaths.RemoveAt(index);
            continue;
        }


        foreach (var city in cityList)
        {
            if (localPosPaths.Last().Cities.Any(x => x.Name == city.Name)) continue;
            path = new Path(localPosPaths.Last(), cityList);
            if (path.Cities.Last().Neighbors.Any(x => x.Key == city.Name))
            {
                path.Cities.Add(city);
                path.TotalDistance += city.Neighbors.Where(x => x.Key == localPosPaths.Last().Cities.Last().Name).First().Value;
                newPaths.Add(path);
            }
        }

        localPosPaths.RemoveAt(index);
        foreach (var newitem in newPaths)
        {
            localPosPaths.Add(newitem);
        }
    }
    Console.WriteLine(item.Name);
}

List<Task> newPaths = new();
newPaths.AddRange(cityList.Select(item => Task.Factory.StartNew(() => FindPaths(cityList, item))));
Task.WaitAll(newPaths.ToArray());

timer.Stop();
Console.WriteLine(counter);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");

Console.WriteLine(checkedPaths.Count);
var OrderedPathsByMax = checkedPaths.OrderByDescending(x => x.TotalDistance);
var OrderedPathsByMin = checkedPaths.OrderBy(x => x.TotalDistance);

Console.WriteLine("Denna är bäst:");
Console.WriteLine(checkedPaths.MinBy(x => x.TotalDistance).TotalDistance);
Console.WriteLine(checkedPaths.MinBy(x => x.TotalDistance).CitiesOrder);
Console.WriteLine("Denna är längst:");
Console.WriteLine(checkedPaths.MaxBy(x => x.TotalDistance).TotalDistance);
Console.WriteLine(checkedPaths.MaxBy(x => x.TotalDistance).CitiesOrder);
Console.ReadKey();
Console.WriteLine("Nu kommer komma en superlång lista efter nästa tryck. På samtliga möjliga resvägara startande från högt till lågt.");
Console.ReadKey();
foreach (var item in OrderedPathsByMax)
{
    Console.WriteLine(item.TotalDistance);
    Console.WriteLine(item.CitiesOrder);
}
Console.ReadKey();
Console.WriteLine("Nu kommer komma en superlång lista efter nästa tryck. På samtliga möjliga resvägara startande från lågt till högt denna gång.");
Console.ReadKey();
foreach (var item in OrderedPathsByMin)
{
    Console.WriteLine(item.TotalDistance);
    Console.WriteLine(item.CitiesOrder);
}




class City
{
    public City()
    {
        Name = "";
        Neighbors = new Dictionary<string, int>();
    }

    public City(string name)
    {
        Name = name;
        Neighbors = new Dictionary<string, int>();
    }

    public string Name { get; set; }
    public Dictionary<string, int> Neighbors { get; }
}

class Path
{
    public List<City> Cities { get; set; }
    public List<City> AllCities { get; private set; }
    public int TotalDistance { get; set; }

    public int Cost
    {
        get
        {
            int output = TotalDistance;

            foreach (var item in AllCities)
            {
                if (Cities.Any(x => x.Name == item.Name)) continue;

                output += item.Neighbors.MinBy(x => x.Value).Value;
            }

            return output;
        }

    }

    public Path(List<City> cityList)
    {
        Cities = new List<City>();
        TotalDistance = 0;
        AllCities = new List<City>(cityList);

    }

    public Path(Path path, List<City> cityList)
    {
        Cities = new List<City>(path.Cities);
        TotalDistance = path.TotalDistance;
        AllCities = new List<City>(cityList);
    }

    public string CitiesOrder
    {
        get
        {
            string output = "";
            foreach (City city in Cities)
                output += city.Name + " -> ";
            output += "HEM!";
            return output;


        }
    }
}