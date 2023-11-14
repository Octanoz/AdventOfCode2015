//*Row 2978, Column 3083

#region Regular solution

/* long startCode = 20_151_125;
long multiplier = 252_533;
long divider = 33_554_393;

long currentRow = 0;
CodeCoord cc = new(0, 0);
(long, long) targetLocation = (2978, 3083);
long[,] codes = new long[10000, 10000];
codes[0, 0] = 20151125;

CodeFiller(targetLocation, codes, cc);

void CodeFiller((long, long) targetLocation, long[,] codes, CodeCoord cc)
{
    targetLocation = (targetLocation.Item1 - 1, targetLocation.Item2 - 1);

    while (cc.Row != targetLocation.Item1 || cc.Col != targetLocation.Item2)
    {
        long currentValue = codes[cc.Row, cc.Col];
        cc = CodeTravel(cc);
        codes[cc.Row, cc.Col] = currentValue * multiplier % divider;
    }

    Console.WriteLine(codes[cc.Row, cc.Col]);
}

CodeCoord CodeTravel(CodeCoord cc)
{
    if (cc.Row == 0)
    {
        currentRow++;
        return new CodeCoord(currentRow, 0);
    }
    else
    {
        return new CodeCoord(cc.Row - 1, cc.Col + 1);
    }
}

record CodeCoord(long Row, long Col); */

#endregion

#region LINQ solution

long startCode = 20_151_125;
long multiplier = 252_533;
long divider = 33_554_393;

long result = Enumerable.Range(1, 10_000)
                        .SelectMany(diag => Enumerable.Range(1, diag), (diag, c) => new
                        {
                            Row = diag - c + 1,
                            Col = c
                        })
                        .TakeWhile(diag => !(diag.Row == 2978 && diag.Col == 3083))
                        .Aggregate(startCode, (acc, _) => acc * multiplier % divider);

Console.WriteLine(result);

#endregion