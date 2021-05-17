using System.Numerics;
using Numerics;

public static class BigNumber
{
    private static char[] symbols = { '\0',
        'k', 'm', 'b', 't', 'q', 's', 'o', 'n',
        'K', 'M', 'B', 'T', 'Q', 'S', 'O', 'N',
        '!', '@', '#', '$', '%', '^', '&', '*'};

    public static BigInteger Parse(string value)
    {
        try
        {
            return BigInteger.Parse(value);
        }
        catch (System.Exception e)
        {
            throw new System.Exception($"Can't parse string: {value} to BigInteger with error: {e.Message}, stack trace: {e.StackTrace}");
        }
    }

    public static BigInteger BigRationalMultiply(BigInteger value, float multiplier)
    {
        //UnityEngine.Debug.LogError(value + " " + multiplier);
        return (BigInteger)((new BigRational(value) / 100) * new BigInteger(multiplier * 100));
    }

    public static BigInteger BigRationalDivide(BigInteger value, float divider)
    {
        //UnityEngine.Debug.LogWarning("BigRationalDivide " + value + " " + divider);
        return (BigInteger)((new BigRational(value) * 100) / new BigInteger(divider * 100));
    }

    public static string StringTransform(BigInteger number)
    {
        string numberStr = number.ToString();
        int log10 = (int)BigInteger.Log10(number);
        int symbolIndex = (numberStr.Length - 1) / 3;
        if (log10 > 4)
        {
            if (numberStr.Length % 3 == 0)
            {
                return number.ToString().Substring(0, 3) + symbols[symbolIndex];
                //Debug.Log(number.ToString().Substring(0, 3) + symbols[symbolIndex]);
            }
            else if ((numberStr.Length - 1) % 3 == 0)
                return number.ToString().Substring(0, 1) + "." + number.ToString().Substring(1, 3) + symbols[symbolIndex];
            //Debug.Log(number.ToString().Substring(0, 1) + "." + number.ToString().Substring(1, 3) + symbols[symbolIndex]);
            else
                return number.ToString().Substring(0, 2) + "." + number.ToString().Substring(2, 3) + symbols[symbolIndex];
            //Debug.Log(number.ToString().Substring(0, 2) + "." + number.ToString().Substring(2, 3) + symbols[symbolIndex]);
        }
        else
        {
            return number.ToString();
        }
    }
}
