using System;
public class PrimeGenerator
{
    private static bool[] crossedOut;
    private static int[] result;
    public static int[] GeneratePrimeNumbers(int maxValue)
    {
        if (maxValue < 2)
            return new int[0];
        else
        {
            UncrossIntegersUpTo(maxValue);
            CrossOutMultiples();
            PutUncrossedIntegersIntoResult();
            return result;
        }
    }
    private static void UncrossIntegersUpTo(int maxValue)
    {
        crossedOut = new bool[maxValue + 1];
        for (int i = 2; i < crossedOut.Length; i++)
            crossedOut[i] = false;
    }
    private static void PutUncrossedIntegersIntoResult()
    {
        result = new int[NumberOfUncrossedIntegers()];
        for (int j = 0, i = 2; i < crossedOut.Length; i++)
        {
            if (NotCrossed(i))
                result[j++] = i;
        }
    }
    private static int NumberOfUncrossedIntegers()
    {
        int count = 0;
        for (int i = 2; i < crossedOut.Length; i++)
        {
            if (NotCrossed(i))
                count++; 
        }
        return count;
    }
    private static void CrossOutMultiples()
    {
        int limit = DetermineIterationLimit();
        for (int i = 2; i <= limit; i++)
        {
            if (NotCrossed(i))
                CrossOutputMultiplesOf(i);
        }
    }
    private static int DetermineIterationLimit()
    {

        double iterationLimit = Math.Sqrt(crossedOut.Length);
        return (int)iterationLimit;
    }
    private static void CrossOutputMultiplesOf(int i)
    {
        for (int multiple = 2 * i;
        multiple < crossedOut.Length;
        multiple += i)
            crossedOut[multiple] = true;
    }
    private static bool NotCrossed(int i)
    {
        return crossedOut[i] == false;
    }
}