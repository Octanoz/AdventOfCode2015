﻿using System.Text.RegularExpressions;
using Day9;


Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day9\example1.txt",
    ["challenge"] = @"..\Day9\input.txt"
};

string[] input = File.ReadAllLines(filePaths["challenge"]);

int resultOne = PartOne(input);
Console.WriteLine($"Shortest route was: {resultOne}");

int resultTwo = PartTwo(input);
Console.WriteLine($"Longest route was {resultTwo}");

int PartOne(string[] input)
{
    List<string> routeSet = new();
    HashSet<Location> locations = new();

    Regex routeMatch = new(@"(\w{4,})|(\d+)");

    foreach (var line in input)
    {
        routeSet.Add(String.Join(" ", routeMatch.Matches(line)
                                                .Cast<Match>()
                                                .Select(m => m.Value)
                                                .ToArray()));
    }

    foreach (string route in routeSet)
    {
        string[] parts = route.Split(' ');
        string currentLocationName = parts[0];
        string destinationName = parts[1];
        int distance = int.Parse(parts[2]);

        Location currentLocation = locations.FirstOrDefault(loc => loc.Name == currentLocationName)!;
        Location destination = locations.FirstOrDefault(loc => loc.Name == destinationName)!;

        if (currentLocation is null)
        {
            currentLocation = new(currentLocationName);
            locations.Add(currentLocation);
        }

        if (destination is null)
        {
            destination = new(destinationName);
            locations.Add(destination);
        }

        currentLocation.AddDestination(destination, distance);
        destination.AddDestination(currentLocation, distance);

    }

    Location origin = locations.First();
    int stops = locations.Count - 1;

    List<int> result = origin.VisitAllLocations(locations, stops, 0, new List<int>());

    return result.Min();
}

int PartTwo(string[] input)
{
    List<string> routeSet = new();
    HashSet<Location> locations = new();

    Regex routeMatch = new(@"(\w{4,})|(\d+)");

    foreach (var line in input)
    {
        routeSet.Add(String.Join(" ", routeMatch.Matches(line)
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .ToArray()));
    }

    foreach (string route in routeSet)
    {
        string[] parts = route.Split(' ');
        string currentLocationName = parts[0];
        string destinationName = parts[1];
        int distance = int.Parse(parts[2]);

        Location currentLocation = locations.FirstOrDefault(loc => loc.Name == currentLocationName)!;
        Location destination = locations.FirstOrDefault(loc => loc.Name == destinationName)!;

        if (currentLocation is null)
        {
            currentLocation = new(currentLocationName);
            locations.Add(currentLocation);
        }

        if (destination is null)
        {
            destination = new(destinationName);
            locations.Add(destination);
        }

        currentLocation.AddDestination(destination, distance);
        destination.AddDestination(currentLocation, distance);

    }

    Location origin = locations.First();
    Location finalDestination = locations.Last();
    int stops = locations.Count - 1;

    List<int> result = origin.VisitAllLocations(locations, stops, 0, new List<int>());

    return result.Max();
}


