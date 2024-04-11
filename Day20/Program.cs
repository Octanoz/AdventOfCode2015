
const int TargetValue = 33_100_000;

Console.WriteLine($"Method using nested loop, part one: {DeliveryOneLoop(TargetValue)}");
Console.WriteLine($"Method using nested loop, part two: {DeliveryTwoLoop(TargetValue)}");
Console.WriteLine($"Alternative method for the second delivery: {DeliveryTwo(TargetValue)}");

int DeliveryOneLoop(int targetValue)
{
    int[] houses = new int[targetValue / 10 + 1];

    for (int elf = 1; elf < houses.Length; elf++)
    {
        for (int house = elf; house < houses.Length; house += elf)
        {
            houses[house] += elf * 10;
        }

        if (houses[elf] > targetValue)
            break;
    }

    return Array.FindIndex(houses, val => val > targetValue);
}

int DeliveryTwoLoop(int targetValue)
{
    int[] houses = new int[targetValue / 11 + 1];
    for (int elf = 0; elf < houses.Length; elf++)
    {
        for (int house = elf, n = 0; house < houses.Length && n < 50; house += elf, n++)
        {
            houses[house] += elf * 11;
        }
    }

    return Array.FindIndex(houses, val => val >= targetValue);
}

int DeliveryTwo(int TargetValue)
{
    int[] houses = new int[1_000_000];

    for (int i = 1; i < houses.Length; i++)
    {
        int deliveryRoute = 50;
        int house = i;

        while (deliveryRoute > 0 && house < houses.Length)
        {
            houses[house] += 11 * i;
            house += i;
            deliveryRoute--;
        }

        if (houses[i] >= TargetValue)
        {
            Console.WriteLine($"First house to pass {TargetValue} is house {i} with {houses[i]} presents delivered.");
            return i;
        }
    }

    return 0;
}

