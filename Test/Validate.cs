using Microsoft.IdentityModel.Tokens;
using Takeshi.Models;
using Test.Models;

namespace Takeshi;

public class Validate
{
    public static void isPositive(int input)
    {
        if (input < 0)
        {
            throw new ArgumentException("cannot be negative.");
        }
    }

    public static void isPositive(double input)
    {
        if (input < 0)
        {
            throw new ArgumentException("cannot be negative.");
        }
    }

    public static void isString(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException("Null input is not allowed ");
        }
    }
    public static string CanString()
    {
        string input = Console.ReadLine(); ;

        if (input == null)
        {
            throw new ArgumentNullException("Null input is not allowed");
        }

        return input;
    }
    /*public static void isNull(Weapon input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("Null input is not allowed");
        }
    }

    public static void isNull(Armor input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("Null input is not allowed");
        }
    }

    public static void isNull(Ability input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("Null input is not allowed");
        }
    }*/
    public static void isNull(Potion input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("Null input is not allowed");
        }
    }
}
