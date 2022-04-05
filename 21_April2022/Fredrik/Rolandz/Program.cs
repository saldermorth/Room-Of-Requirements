using Rolandz;

//BERÄKNING UTFÖRS
TourPlanner tourPlan = new();

foreach (City city in tourPlan.Cities)
{
    Tour tour = new(city);
    tourPlan.FindTours(tour, city);
}


//RESULTAT PRESENTERAS
IEnumerable<Tour> tours = tourPlan.PossibleTours.OrderBy(x => x.TotalDistance);

Console.WriteLine($"Kortade turnén ({tours.First().TotalDistance} km)");
foreach (City city in tours.First().VisitedCities)
{
    Console.Write($"{city} -");
}

Console.WriteLine($"\n\nLängsta turnén ({tours.Last().TotalDistance} km)");
foreach (City city in tours.Last().VisitedCities)
{
    Console.Write($"{city} -");
}

Console.WriteLine($"\n\n");




