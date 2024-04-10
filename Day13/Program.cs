using System.Text.RegularExpressions;
using Day13;

Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day13\example1.txt",
    ["challenge"] = @"..\Day13\input.txt"
};

string[] input = File.ReadAllLines(filePaths["challenge"]);

Console.WriteLine($"The total change in happiness for the optimal seating arrangement is {Seating(input, false)}.");
Console.WriteLine($"The total change in happiness for the optimal seating arrangement with me included is {Seating(input, true)}.");

int Seating(string[] input, bool IsPartTwo)
{
    HashSet<Guest> guestSet = new();
    Regex relationships = new(@"([A-Z]\w{2,})|(gain|lose)|(\d+)");

    foreach (var line in input)
    {
        string[] parts = relationships.Matches(line).Cast<Match>().Select(match => match.Value).ToArray();

        string guestName = parts[0];
        int happinessLevel = int.Parse(parts[2]);
        happinessLevel = parts[1] == "lose" ? -happinessLevel : happinessLevel;
        string neighbourName = parts[3];

        Guest guest = guestSet.FirstOrDefault(g => g.Name == guestName)!;
        Guest neighbour = guestSet.FirstOrDefault(g => g.Name == neighbourName)!;

        if (guest is null)
        {
            guest = new(guestName);
            guestSet.Add(guest);
        }

        if (neighbour is null)
        {
            neighbour = new(neighbourName);
            guestSet.Add(neighbour);
        }

        guest.AddNeighbour(neighbour, happinessLevel);
    }

    if (IsPartTwo)
    {
        Guest me = new("Robin");
        foreach (var g in guestSet)
        {
            g.AddNeighbour(me, 0);
            me.AddNeighbour(g, 0);
        }
        guestSet.Add(me);
    }

    int seats = guestSet.Count - 1;

    List<int> result = Guest.SeatAllGuests(guestSet, seats, 0, new List<int>());

    return result.Max();
}

