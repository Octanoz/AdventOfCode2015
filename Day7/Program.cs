// ushort x = 123;
// ushort y = 456;
// ushort d = x & y; //AND
// ushort e = x | y; //OR
// ushort f = (ushort)(x << 2); // l-shift
// ushort g = (ushort)(y >> 2); //r-shift
// ushort h = (ushort)(ushort.MaxValue + ~x);

#region Solution 1 -- Using Dictionary

/* // string filePath = @"..\Day7\example1.txt";
string filePath = @"..\Day7\input.txt";
List<string> input = File.ReadAllLines(filePath).ToList();
HashSet<string> wireNames = new();
Dictionary<string, ushort> wires = new();

foreach (var item in input)
{
    string[] parts = item.Split(" -> ");
    if (!wireNames.Add(parts[1]))
        Console.WriteLine($"Error adding name {parts[1]}");
}

foreach (var wireName in wireNames)
{
    WireStrength(wireName);
}

ushort WireStrength(string wireName)
{
    if (wires.TryGetValue(wireName, out ushort wireStrength))
        return wireStrength;

    string instruction = input.FirstOrDefault(line => line.EndsWith($"-> {wireName}"))
                        ?? throw new InvalidOperationException("Instruction not found");

    // string[] parts = instruction.Split(new[] { ' ', '-', '>', ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

    if (instruction.Contains("AND"))
    {
        string[] parts = instruction.Split(' '); // [0] [AND] [2] [->] [4]
        if (!ushort.TryParse(parts[0], out ushort inputValue1))
        {
            inputValue1 = WireStrength(parts[0]);
        }
        ushort inputValue2 = WireStrength(parts[2]);
        ushort result = (ushort)(inputValue1 & inputValue2);
        wires[wireName] = result;
        return result;
    }
    else if (instruction.Contains("OR"))
    {
        string[] parts = instruction.Split(' '); // [0] [OR] [2] [->] [4]
        ushort inputValue1 = WireStrength(parts[0]);
        ushort inputValue2 = WireStrength(parts[2]);
        ushort result = (ushort)(inputValue1 | inputValue2);
        wires[wireName] = result;
        return result;
    }
    else if (instruction.StartsWith("NOT"))
    {
        string[] parts = instruction.Split(' '); // [NOT] [1] [->] [3]
        ushort inputValue = WireStrength(parts[1]);
        ushort result = (ushort)~inputValue;
        wires[wireName] = result;
        return result;
    }
    else if (instruction.Contains("LSHIFT"))
    {
        string[] parts = instruction.Split(' '); // [0] [LSHIFT] [2] [->] [4]
        ushort inputValue = WireStrength(parts[0]);
        int shift = int.Parse(parts[2]);
        ushort result = (ushort)(inputValue << shift);
        wires[wireName] = result;
        return result;
    }
    else if (instruction.Contains("RSHIFT"))
    {
        string[] parts = instruction.Split(' '); // [0] [LSHIFT] [2] [->] [4]
        ushort inputValue = WireStrength(parts[0]);
        int shift = int.Parse(parts[2]);
        ushort result = (ushort)(inputValue >> shift);
        wires[wireName] = result;
        return result;
    }
    else if (Char.IsDigit(instruction[0]))
    {
        string[] parts = instruction.Split(' '); // [0] [->] [2]
        ushort result = ushort.Parse(parts[0]);
        wires[wireName] = result;
        return result;
    }
    else
    {
        string[] parts = instruction.Split(' '); // [0] [->] [2]
        ushort result = WireStrength(parts[0]);
        wires[wireName] = result;
        return result;
    }
}

Console.WriteLine(wires["a"]); */

//Using wire class
/* int loops = 0;
while (loops < 2)
{
    for (int i = 0; i < input.Count; i++)
    {
        if (input[i].Contains("AND"))
        {
            string[] parts = input[i].Split(' '); // [0] [AND] [2] [->] [4]
            ANDGate ag = new(parts[4], parts[0], parts[2]);
        }
        else if (input[i].Contains("OR"))
        {
            string[] parts = input[i].Split(' '); // [0] [OR] [2] [->] [4]
            ORGate og = new(parts[4], parts[0], parts[1]);
        }
        else if (input[i].StartsWith("NOT"))
        {
            string[] parts = input[i].Split(' '); // [NOT] [1] [->] [3]
            NOTWire nw = new(parts[3], parts[1]);
        }
        else if (input[i].Contains("LSHIFT"))
        {
            string[] parts = input[i].Split(' '); // [0] [LSHIFT] [2] [->] [4]
            LeftShiftWire lsw = new(parts[4], parts[0], int.Parse(parts[2]));
        }
        else if (input[i].Contains("RSHIFT"))
        {
            string[] parts = input[i].Split(' '); // [0] [RSHIFT] [2] [->] [4]
            RightShiftWire rsw = new(parts[4], parts[0], int.Parse(parts[2]));
        }
        else if (Char.IsDigit(input[i][0]))
        {
            string[] parts = input[i].Split(' '); // [0] [->] [2]
            Wire wire = new(parts[2], ushort.Parse(parts[0]));
        }
        else
        {
            string[] parts = input[i].Split(' '); // [0] [->] [2]
            EqualWire ew = new(parts[2], parts[0]);
        }
    }

    loops++;
} */

#endregion

#region Solution 2 -- Using Wire class

using Day7;

// string filePath = @"..\Day7\example1.txt";
string filePath = @"..\Day7\input.txt";
List<string> input = File.ReadAllLines(filePath).ToList();
HashSet<Wire> dummyWires = new();
List<Wire> wires = new();

foreach (var item in input)
{
    string[] parts = item.Split(" -> ");
    Wire wire = new(parts[1], 0);
    if (!dummyWires.Add(wire))
        Console.WriteLine($"Error adding wire {parts[1]}");
}

foreach (var wire in dummyWires)
{
    WireStrength(wire);
}

Wire WireStrength(Wire wire)
{
    if (wires.Contains(wire))
    {
        Wire stored = wires.Find(w => w.Name == wire.Name)!;
        return stored;
    }

    string instruction = input.FirstOrDefault(line => line.EndsWith($"-> {wire.Name}"))
                        ?? throw new InvalidOperationException("Instruction not found");

    if (instruction.Contains("AND"))
    {
        bool valueGiven = true;
        string[] parts = instruction.Split(' '); // [0] [AND] [2] [->] [4]
        Wire inputWire1 = new(parts[0], 0);
        Wire inputWire2 = new(parts[2], 0);

        if (!ushort.TryParse(parts[0], out ushort inputValue))
        {
            valueGiven = false;
            inputWire1 = WireStrength(inputWire1);
        }
        inputWire2 = WireStrength(inputWire2);

        wire.Strength = valueGiven ? (ushort)(inputValue & inputWire2.Strength) : (ushort)(inputWire1.Strength & inputWire2.Strength);
        wires.Add(wire);

        return wire;
    }
    else if (instruction.Contains("OR"))
    {
        string[] parts = instruction.Split(' '); // [0] [OR] [2] [->] [4]
        Wire inputWire1 = new(parts[0], 0);
        Wire inputWire2 = new(parts[2], 0);
        inputWire1 = WireStrength(inputWire1);
        inputWire2 = WireStrength(inputWire2);

        wire.Strength = (ushort)(inputWire1.Strength | inputWire2.Strength);
        wires.Add(wire);

        return wire;
    }
    else if (instruction.StartsWith("NOT"))
    {
        string[] parts = instruction.Split(' '); // [NOT] [1] [->] [3]
        Wire inputWire = new(parts[1], 0);
        inputWire = WireStrength(inputWire);

        wire.Strength = (ushort)~inputWire.Strength;
        wires.Add(wire);

        return wire;
    }
    else if (instruction.Contains("LSHIFT"))
    {
        string[] parts = instruction.Split(' '); // [0] [LSHIFT] [2] [->] [4]
        Wire inputWire = new(parts[0], 0);
        inputWire = WireStrength(inputWire);

        int shift = int.Parse(parts[2]);

        wire.Strength = (ushort)(inputWire.Strength << shift);
        wires.Add(wire);

        return wire;
    }
    else if (instruction.Contains("RSHIFT"))
    {
        string[] parts = instruction.Split(' '); // [0] [LSHIFT] [2] [->] [4]
        Wire inputWire = new(parts[0], 0);
        inputWire = WireStrength(inputWire);

        int shift = int.Parse(parts[2]);

        wire.Strength = (ushort)(inputWire.Strength >> shift);
        wires.Add(wire);

        return wire;
    }
    else if (Char.IsDigit(instruction[0]))
    {
        string[] parts = instruction.Split(' '); // [0] [->] [2]        

        wire.Strength = ushort.Parse(parts[0]);
        wires.Add(wire);

        return wire;
    }
    else
    {
        string[] parts = instruction.Split(' '); // [0] [->] [2]
        Wire inputWire = new(parts[0], 0);
        inputWire = WireStrength(inputWire);

        wire.Strength = inputWire.Strength;
        wires.Add(wire);

        return wire;
    }
}

Wire newInput = wires.Find(w => w.Name == "a")!;

wires.Clear();
wires.Add(new("b", newInput.Strength));

foreach (var wireName in dummyWires)
{
    WireStrength(wireName);
}

Wire wireA = wires.Find(wire => wire.Name == "a")!;

Console.WriteLine(wireA);



#endregion


