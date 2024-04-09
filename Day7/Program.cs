using Day7;

// ushort x = 123;
// ushort y = 456;
// ushort d = x & y; //AND
// ushort e = x | y; //OR
// ushort f = (ushort)(x << 2); // l-shift
// ushort g = (ushort)(y >> 2); //r-shift
// ushort h = (ushort)(ushort.MaxValue + ~x);

Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day7\example1.txt",
    ["challenge"] = @"..\Day7\input.txt"
};

Console.WriteLine($"The signal provided to wire 'a' is {PartOne(filePaths["challenge"])}");
Console.WriteLine($"The signal provided to wire 'a' in part two is {PartTwo(filePaths["challenge"])}");

ushort PartOne(string filePath)
{
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

        string instruction = input.Find(line => line.EndsWith($"-> {wireName}"))
                            ?? throw new InvalidOperationException("Instruction not found");

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

    return wires["a"];
}


ushort PartTwo(string filePath)
{
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

        string instruction = input.Find(line => line.EndsWith($"-> {wire.Name}"))
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

    return wires.Find(wire => wire.Name == "a")!.Strength;
}


