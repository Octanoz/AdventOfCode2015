namespace Day2;

class Wrapping
{
    public static int PaperNeeded(int length, int width, int height)
    {
        int lw = 2 * length * width;
        int wh = 2 * width * height;
        int hl = 2 * height * length;

        int lowestDimension = Math.Min(lw, Math.Min(wh, hl)) / 2;

        return lw + wh + hl + lowestDimension;
    }

    public static int RibbonNeeded(int length, int width, int height)
    {
        int intermediate = 2 * length + 2 * width + 2 * height;

        int biggestDimension = Math.Max(length, Math.Max(width, height));

        int perimeter = intermediate - 2 * biggestDimension;

        int bow = length * width * height;

        return perimeter + bow;
    }
}