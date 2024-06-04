using System;
public static class VladMath
{
    public static float ApproximationToNumber(float returnNumber, float a, float mainNumber)
    {
        if (Math.Floor(returnNumber) == Math.Floor(mainNumber)) return returnNumber;
        else
        {
            if (mainNumber < 0) returnNumber -= a;
            if (mainNumber > 0) returnNumber += a;

            return returnNumber;
        }
    }

    public static float OneOfTwoNumber(float a, float b)
    {
        Random random = new Random();
        float r = random.Next(0, 1);
        float x = r == 1 ? a : b;
        return x;
    }
}
