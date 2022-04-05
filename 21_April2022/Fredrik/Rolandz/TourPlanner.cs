using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolandz
{
    public class TourPlanner
    {
        private readonly string[] input = File.ReadAllLines("input.txt");
        public List<City> Cities { get; set; }
        public List<Trip> Trips { get; set; }
        public List<Tour> PossibleTours { get; set; } = new();

        public TourPlanner()
        {
            Cities = AllCities();
            Trips = AllTrips();
        }

        private List<City> AllCities()
        {
            List<City> result = new();

            foreach (string line in input)
            {
                string cityOne = line.Split(' ')[0];
                string cityTwo = line.Split(' ')[2];

                if (!result.Any(x => x.Name == cityOne))
                {
                    result.Add(new City(cityOne));
                }

                if (!result.Any(x => x.Name == cityTwo))
                {
                    result.Add(new City(cityTwo));
                }
            }

            return result.OrderBy(x => x.Name).ToList();
        }

        private List<Trip> AllTrips()
        {
            List<Trip> result = new();

            foreach (string line in input)
            {
                City cityOne = Cities.First(x => x.Name == line.Split(' ')[0]);
                City cityTwo = Cities.First(x => x.Name == line.Split(' ')[2]);
                int distance = Convert.ToInt32(line.Split(' ')[4]);

                result.Add(new Trip(cityOne, cityTwo, distance));
            }

            return result;
        }

        public void FindTours(Tour tour, City currentCity)
        {
            foreach (Trip trip in Trips.Where(x => x.Cities.Contains(currentCity)))
            {
                City? nextCity = trip.Cities.Where(x => !tour.VisitedCities.Contains(x)).FirstOrDefault();

                if (nextCity != null)
                {
                    tour.VisitedCities.Add(nextCity);
                    tour.TotalDistance += trip.Distance;

                    if (tour.VisitedCities.Count == Cities.Count)
                    {
                        Tour fullTour = new(tour.TotalDistance);

                        foreach (City city in tour.VisitedCities)
                        {
                            fullTour.VisitedCities.Add(new City(city.Name));
                        }
                            
                        PossibleTours.Add(fullTour);
                    }

                    FindTours(tour, nextCity);
                    tour.TotalDistance -= trip.Distance;
                    tour.VisitedCities.Remove(nextCity);
                }
            }
        }
    }
}
