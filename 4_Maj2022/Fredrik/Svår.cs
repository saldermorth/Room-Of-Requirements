using System;

public class LinkedListReverser
{
    private string[] cities = new string[] { "Atlanta", "Bangkok", "Calcutta", "Damaskus", "Eslöv", "Frankfurt", "Glasgow", "Hong Kong", "Islamabad", "Johannesburg" };
    public LinkedList<string> cityList { get; set; }

    public LinkedListReverser()
    {
        cityList = new LinkedList<string>(cities);
    }

    public LinkedList<string> ReverseOrder()
    {
        for (int i = 0; i < cityList.Count / 2; i++)
        {
            string cityToMoveUp = cityList.ElementAt(cityList.Count / 2 - 1);
            string cityToMoveDown = cityList.Count % 2 == 0 ? cityList.ElementAt(cityList.Count / 2) : cityList.ElementAt((int)Math.Ceiling((double)cityList.Count / 2));

            cityList.Remove(cityList.ElementAt(cityList.Count / 2 - 1));
            if (cityList.Count % 2 == 0)
            {
                cityList.Remove(cityList.ElementAt((int)Math.Ceiling((double)cityList.Count / 2)));
            }
            else
            {
                cityList.Remove(cityList.ElementAt(cityList.Count / 2));
            }

            cityList.AddLast(cityToMoveUp);
            cityList.AddFirst(cityToMoveDown);
        }

        return cityList;
    }
}
