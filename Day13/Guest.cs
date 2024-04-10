namespace Day13;

class Guest
{
    public string Name { get; set; }
    public Dictionary<Guest, int> Neighbours { get; set; }

    public Guest(string name)
    {
        Name = name;
        Neighbours = new();
    }

    public void AddNeighbour(Guest neighbour, int distance)
    {
        Neighbours.Add(neighbour, distance);
    }

    public static List<int> SeatAllGuests(HashSet<Guest> guests, int seats, int happiness, List<int> totalHappiness)
    {
        List<string> seating = new();

        foreach (var seat in guests)
        {
            seating.Add(seat.Name);
        }

        foreach (var seat in guests)
        {
            Seater(seating, seat, seat, seats, happiness, totalHappiness);
        }

        void Seater(List<string> seating, Guest current, Guest head, int seats, int happiness, List<int> totalHappiness)
        {

            if (seats == 0)
            {
                int newHappiness = happiness + current.Neighbours[head] + head.Neighbours[current];
                totalHappiness.Add(newHappiness);
                return;
            }

            foreach (var neighbourName in head.Neighbours.Select(kvp => kvp.Key.Name))
            {
                if (!seating.Contains(neighbourName) || neighbourName == head.Name)
                    continue;

                Guest next = guests.First(seat => seat.Name == neighbourName);
                int newHappiness = happiness + current.Neighbours[next] + next.Neighbours[current];
                seating.Remove(next.Name);
                Seater(seating, next, head, seats - 1, newHappiness, totalHappiness);
                seating.Add(next.Name);
            }


        }

        return totalHappiness;
    }
}