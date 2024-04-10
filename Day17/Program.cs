// #define MORELINQ
#define REGULAR
// #define VISUALIZE

using MoreLinq;

Dictionary<string, string> filePaths = new()
{
    ["example1"] = @"..\Day17\example1.txt",
    ["challenge"] = @"..\Day17\input.txt"
};

Dictionary<string, int> eggnogs = new()
{
    ["test"] = 25,
    ["challenge"] = 150
};

string[] input = File.ReadAllLines(filePaths["challenge"]);
int[] containers = input.Select(int.Parse).ToArray();

#if MORELINQ

var combos = containers.Subsets().Where(subsets => subsets.Sum() == eggnogs["challenge"]).ToList();
int shortestCombo = combos.Min(list => list.Count);
var shortestLists = combos.Where(list => list.Count == shortestCombo).ToList();

#if VISUALIZE
foreach (var combo in combos)
{
    Console.WriteLine(String.Join(", ", combo));
}
#endif

foreach (var list in shortestLists)
{
    Console.WriteLine(String.Join(" ", list));
}

Console.WriteLine($"\nThere is a total of {combos.Count} combinations.");
Console.WriteLine($"Shortest combo is {shortestCombo} containers.");
Console.WriteLine($"Possible combinations with {shortestCombo} containers is {shortestLists.Count}");

#elif REGULAR

containers = containers.OrderDescending().ToArray();

var combinations = StoreOptions(eggnogs["challenge"], containers);

var shortestCombo = combinations.Min(dict => dict.Sum(pair => pair.Value));
var shortestCombos = combinations.Where(dict => dict.Values.Sum() == shortestCombo).ToList();

foreach (var item in shortestCombos)
{
    Console.WriteLine(String.Join(", ", item.Where(pair => pair.Value != 0)));
}

Console.WriteLine($"There was a total of {combinations.Count} combinations.");
Console.WriteLine($"The lowest possible combination of containers is {shortestCombo}.");
Console.WriteLine($"There are {shortestCombos.Count} combinations possible with that many containers.");

List<Dictionary<int, int>> StoreOptions(int target, int[] containers)
{
    List<Dictionary<int, int>> result = new();
    StoreHelper(target, containers, new Dictionary<int, int>());

    return result;

    void StoreHelper(int target, int[] containers, Dictionary<int, int> containerSizes)
    {
        if (target < 0)
            return;

        if (target == 0)
        {
            result.Add(new(containerSizes));
            return;
        }

        for (int i = 0; i < containers.Length; i++)
        {
            if (target >= containers[i])
            {
                if (!containerSizes.TryAdd(containers[i], 1))
                    containerSizes[containers[i]]++;
                StoreHelper(target - containers[i], containers.Skip(i + 1).ToArray(), containerSizes);
                containerSizes[containers[i]]--;
            }
        }

    }
}

#endif

