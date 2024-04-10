namespace Day14;

class Deer
{
    public string Name { get; set; }
    public float Speed { get; set; }
    public Dictionary<string, int> Times { get; set; }
    public Dictionary<int, float> TravelledPerSecond { get; set; }

    public Deer(string name, float speed, int moveTime, int restTime)
    {
        Name = name;
        Speed = speed;
        Times = new()
        {
            ["move"] = moveTime,
            ["rest"] = restTime
        };
        TravelledPerSecond = new();
    }

    public void AddTimes(int move, int rest)
    {
        Times.Add("move", move);
        Times.Add("rest", rest);
    }
}