using System.Diagnostics;

const int TargetValue = 29_000_000;
int house = 500_000;


int DeliveryOne(int house)
{
    int index = house;
    int currentValue = 0;

    while (currentValue <= TargetValue)
    {
        index += 20;

        if (index % 20 == 0)
        {
            currentValue = index + Enumerable.Range(1, index).Where(j => index % j == 0).Sum() * 10;
        }
    }

    Console.WriteLine($"House {index}, {currentValue} presents delivered.");

    return index;
}

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

Func<int, int> presentsForHouse = number => Enumerable.Range(1, number)
                                                        .Where(elf => number % elf == 0)
                                                        .Sum() * 10;

Func<int, int> presentsForHouseB = house => Enumerable.Range(1, house)
                                                            .Where(elf => house % elf == 0 && house / elf <= 50)
                                                            .Sum() * 11;

Console.WriteLine($"My method for the first delivery: {DeliveryOne(house)}");
DeliveryTwo(TargetValue);

Console.WriteLine($"Method using LINQ: {LINQDeliveryOne(TargetValue)}");
Console.WriteLine($"Method using nested loop: {DeliveryOneLoop(TargetValue)}");
Console.WriteLine($"My method for the second delivery: {DeliveryTwo(TargetValue)}");
Console.WriteLine($"Method using LINQ: {LINQDeliveryTwo(TargetValue)}");
Console.WriteLine($"Method using nested loop: {DeliveryTwoLoop(TargetValue)}");


int LINQDeliveryOne(int targetValue)
{
    int fact = 2 * 3 * 5 * 7 * 11;
    return Enumerable.Range(1, 1_000_000)
                            .Where(n => n % fact == 0)
                            .Select(h => new { House = h, Presents = presentsForHouse(h) })
                            .First(house => house.Presents >= targetValue).House;
}

int LINQDeliveryTwo(int targetValue)
{
    int factB = 2 * 2 * 2 * 3 * 3;
    return Enumerable.Range(700_000, 2_000_000)
                            .Where(n => n % factB == 0)
                            .Select(h => new { House = h, Presents = presentsForHouseB(h) })
                            .First(h => h.Presents >= targetValue).House;
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


int PresentsDeliveredAt(int house)
{
    int result = 0;

    int number = house;

    while (number > 1)
    {
        if (house % number == 0)
        {
            result += number * 10;
        }

        number--;
    }

    return result;
}



