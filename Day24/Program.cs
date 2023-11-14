#region Morelinq Solution

/* using MoreLinq;

// string filePath = @"..\Day24\example1.txt";
string filePath = @"..\Day24\input.txt";

long[] packages = File.ReadAllLines(filePath).Select(long.Parse).ToArray();
// long[] packages = File.ReadAllLines(filePath).Select(long.Parse).ToArray();

long weightPerSection = packages.Sum() / 4; //3 for part 1

var compartmentOptions = packages.Subsets()
                                                            .Where(set => set.Sum() == weightPerSection && set.Count < 7);

long minPackages = compartmentOptions.Min(set => set.Count);

var firstCompartmentOptions = compartmentOptions.Where(set => set.Count == minPackages).ToList();

long lowestProduct = firstCompartmentOptions.Select(o => new { QE = o.Aggregate((a, b) => a * b) })
                                            .First().QE;

Console.WriteLine($"Lowest Quantum Entanglement: {lowestProduct}"); */

#endregion

#region Regular Solution

string filePath = @"..\Day24\input.txt";
long[] packages = File.ReadAllLines(filePath).Select(long.Parse).ToArray();
long groups = 3; //Part 1
// long groups = 4; //Part 2
long weightPerSection = packages.Sum() / groups;

var combinations = CompartmentOptions(weightPerSection, packages);

long shortestCombo = combinations.Min(l => l.Count);
long lowestQE = combinations.Where(l => l.Count == shortestCombo)
                            .Select(g => new { QE = g.Aggregate((a, b) => a * b) })
                            .OrderBy(g => g.QE)
                            .First().QE;

Console.WriteLine($"The lowest possible combination of packages is {shortestCombo}.");
Console.WriteLine($"Lowest Quantum Entanglement is {lowestQE}");

List<IList<long>> CompartmentOptions(long target, long[] packages)
{
    List<IList<long>> result = new();
    long currentBest = 1 + packages.Length / groups;
    OptionsHelper(target, packages, new List<long>());

    return result;

    void OptionsHelper(long target, long[] packages, List<long> packageWeights)
    {
        if (target < 0)
            return;

        if (target == 0)
        {
            result.Add(new List<long>(packageWeights));
            currentBest = Math.Min(currentBest, packageWeights.Count);
            return;
        }

        if (packageWeights.Count > currentBest)
            return;

        for (int i = 0; i < packages.Length; i++)
        {
            if (target >= packages[i])
            {
                packageWeights.Add(packages[i]);
                OptionsHelper(target - packages[i], packages.Skip(i + 1).ToArray(), packageWeights);
                packageWeights.Remove(packages[i]);
            }
        }
    }
}

#endregion

