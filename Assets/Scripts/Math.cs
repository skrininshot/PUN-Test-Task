using System;

public class Math
{
    private static Random _random = new ();

    public static string GetRandomDigits(int length)
    {
        string returnString = "";

        for (int i = 0; i < length; i++)
        {
            returnString += _random.Next(10);
        }

        return returnString;
    }
}