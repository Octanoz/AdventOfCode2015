namespace Day9;

class Location
{
    public string Name { get; set; }
    public Dictionary<Location, int> Destinations { get; set; }
    public Location(string name)
    {
        Name = name;
        Destinations = new Dictionary<Location, int>();
    }

    public void AddDestination(Location destination, int distance)
    {
        Destinations.Add(destination, distance);
    }

    public List<int> VisitAllLocations(HashSet<Location> locations, int stops, int distanceTravelled, List<int> routeLengths)
    {
        List<string> locs = new();

        foreach (var loc in locations)
        {
            locs.Add(loc.Name);
        }

        foreach (var loc in locations)
        {
            locs.Remove(loc.Name);
            RouteFinder(locs, loc, stops, distanceTravelled, routeLengths);
            locs.Add(loc.Name);
        }

        void RouteFinder(List<string> locs, Location origin, int stops, int distanceTravelled, List<int> routeLengths)
        {
            if (stops == 0)
            {
                routeLengths.Add(distanceTravelled);
                return;
            }

            foreach (var dest in origin.Destinations)
            {
                if (!locs.Contains(dest.Key.Name))
                    continue;

                Location destination = locations.First(loc => loc.Name == dest.Key.Name);
                int newDistance = distanceTravelled + dest.Value;
                locs.Remove(destination.Name);
                RouteFinder(locs, destination, stops - 1, newDistance, routeLengths);
                locs.Add(destination.Name);
            }
        }

        return routeLengths;
    }
}