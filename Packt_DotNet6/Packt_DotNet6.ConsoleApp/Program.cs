global using System.Text;

Console.OutputEncoding = Encoding.UTF8;

static void RunTuple()
{
    ValueTuple<bool, string> ModifyInside(bool newBool, string newString)
    {
        return ValueTuple.Create(newBool, newString);
    }

    ValueTuple<bool, string> maTuple = ValueTuple.Create(false, "Blabla");
    Console.WriteLine($"{maTuple}");

    maTuple = ModifyInside(true, "Blabla Edited");
    Console.WriteLine($"{maTuple}");
}

static void RunFactorial()
{
    int Factorial(int number)
    {
        if (number < 1)
        {
            return 0;
        }
        else if (number == 1)
        {
            return 1;
        }
        else
        {
            checked // Pour le dépassement
            {
                return number * Factorial(number - 1);
            }
        }
    }

    for (int i = 1; i < 15; i++)
    {
        try
        {
            Console.WriteLine($"{i}! = {Factorial(i):N0}");
        }
        catch (System.OverflowException)
        {
            Console.WriteLine($"{i}! est trop grand pour un Int32.");
        }
    }
}

/// <summary>
/// Pass a 32-bit integer and it will be converted into its ordinal equivalent.
/// </summary>
/// <param name="number">Number is a cardinal value e.g. 1, 2, 3, and so on.</param>
/// <returns>Number as an ordinal value e.g. 1st, 2nd, 3rd, and so on.</returns>
static string CardinalToOrdinal(int number)
{
    switch (number)
    {
        case 11: // Cas spécifique pour 11, 12 et 13
        case 12:
        case 13:
            return $"{number}th";
        default:
            int lastDigit = number % 10;
            string suffix = lastDigit switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            };
            return $"{number}{suffix}";
    }
}

static void RunFibImperative()
{
    int FibImperative(int term)
    {
        if (term == 1)
        {
            return 0;
        }
        else if (term == 2)
        {
            return 1;
        }
        else
        {
            return FibImperative(term - 1) + FibImperative(term - 2);
        }
    }

    for (int i = 1; i <= 30; i++)
    {
        Console.WriteLine("Le {0} terme de la suite de Fibonacci est {1:N0}",
          arg0: CardinalToOrdinal(i),
          arg1: FibImperative(term: i));
    }
}

static void RunFibFunctional()
{
    int FibFunctional(int term) => term switch
        {
            1 => 0,
            2 => 1,
            _ => FibFunctional(term - 1) + FibFunctional(term - 2)
        };

    for (int i = 1; i <= 30; i++)
    {
        Console.WriteLine("Le {0} terme de la suite de Fibonacci est {1:N0}.",
          arg0: CardinalToOrdinal(i),
          arg1: FibFunctional(term: i));
    }
}

static void RunCardinalToOrdinal()
{
    for (int number = 1; number <= 40; number++)
    {
        Console.Write($"{CardinalToOrdinal(number)} ");
    }
    Console.WriteLine();
}

static void BinaryToString()
{
    int tableLength;

    Console.Write("Longueur du tableau de bytes : ");
    int.TryParse(Console.ReadLine(), out tableLength);

    byte[] binaryObject = new byte[tableLength]; // Allouer un tableau de bytes
    
    new Random().NextBytes(binaryObject); // Ajout de valeurs aléatoires au tableau

    Console.WriteLine("Object en bytes :");
    for (int index = 0; index < binaryObject.Length; index++)
    {
        Console.Write($"{binaryObject[index]:X} ");
    }
    Console.WriteLine();
    Console.WriteLine();
    
    string encoded = Convert.ToBase64String(binaryObject); // Conversion en String de base 64 et écriture dans la console
    Console.WriteLine("Objet en string :");
    Console.WriteLine(encoded);
}

static void ControlRounding()
{
    Console.WriteLine("=== ARRONDIR DES VALEURS ===");
    Console.WriteLine();

    double[] doubles = { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };


    Console.WriteLine("- Sans modifications");
    foreach (double n in doubles)
    {
        Console.WriteLine($"Convert.ToInt32({n}) donne {Convert.ToInt32(n)}");
    }

    Console.WriteLine();
    Console.WriteLine("- Avec modifications");
    foreach (double n in doubles)
    {
        Console.WriteLine(format: "Math.Round({0}, 0, MidpointRounding.AwayFromZero) donne {1}",
          arg0: n,
          arg1: Math.Round(value: n, digits: 0, mode: MidpointRounding.AwayFromZero));
    }
}

static void BitwiseOperators()
{
    string ToBinaryString(int value)
    {
        return Convert.ToString(value, toBase: 2).PadLeft(8, '0');
    }

    int a = 10; // 00001010
    int b = 6;  // 00000110
    Console.WriteLine($"a = {a}");
    Console.WriteLine($"b = {b}");
    Console.WriteLine($"a & b = {a & b}"); // 2-bit column only 
    Console.WriteLine($"a | b = {a | b}"); // 8, 4, and 2-bit columns 
    Console.WriteLine($"a ^ b = {a ^ b}"); // 8 and 4-bit columns

    Console.WriteLine();
    Console.WriteLine("En Binaire :");
    Console.WriteLine($"a =     {ToBinaryString(a)}");
    Console.WriteLine($"b =     {ToBinaryString(b)}");
    Console.WriteLine($"a & b = {ToBinaryString(a & b)}");
    Console.WriteLine($"a | b = {ToBinaryString(a | b)}");
    Console.WriteLine($"a ^ b = {ToBinaryString(a ^ b)}");

    Console.WriteLine();

    // 01010000 left-shift a by three bit columns
    Console.WriteLine($"a << 3 = {a << 3}");
    // multiply a by 8
    Console.WriteLine($"a * 8 = {a * 8}");
    // 00000011 right-shift b by one bit column
    Console.WriteLine($"b >> 1 = {b >> 1}");
}

static void SwitchExpressionTest()
{
    int value;
    Console.Write("Veuilliez donner un nombre : ");
    int.TryParse(Console.ReadLine(), out value);

    string message = value switch
    {
        666 => "Vous aimez Satan !?",
        > 18 => "Vous auriez la majorité s'sil s'agissait d'un âge !",
        _ => "Ce nombre ne me dit rien..."
    };

    Console.WriteLine(message);

}

static void TruthTable()
{
    bool DoStuff()
    {
        Console.WriteLine("Je fais des trucs.");
        return true;
    }

    Console.WriteLine("=== TABLE VERITE ===");
    Console.WriteLine();

    bool a = true;
    bool b = false;
    Console.WriteLine($"AND  | a     | b    ");
    Console.WriteLine($"a    | {a & a,-5} | {a & b,-5} ");
    Console.WriteLine($"b    | {b & a,-5} | {b & b,-5} ");
    Console.WriteLine();
    Console.WriteLine($"OR   | a     | b    ");
    Console.WriteLine($"a    | {a | a,-5} | {a | b,-5} ");
    Console.WriteLine($"b    | {b | a,-5} | {b | b,-5} ");
    Console.WriteLine();
    Console.WriteLine($"XOR  | a     | b    ");
    Console.WriteLine($"a    | {a ^ a,-5} | {a ^ b,-5} ");
    Console.WriteLine($"b    | {b ^ a,-5} | {b ^ b,-5} ");
    Console.WriteLine();

    Console.WriteLine("=== TYPES D'OPERATEURS LOGIQUES ===");
    Console.WriteLine();

    Console.WriteLine("- Le Simple & : Non stoppant");
    Console.WriteLine($"a & DoStuff() = {a & DoStuff()}"); // DoStuff() est executé
    Console.WriteLine($"b & DoStuff() = {b & DoStuff()}"); // DoStuff() est executé malgré le False de b


    Console.WriteLine();
    Console.WriteLine("- Le Double && : Stoppant");
    Console.WriteLine($"a && DoStuff() = {a && DoStuff()}"); // DoStuff() est executé
    Console.WriteLine($"b && DoStuff() = {b && DoStuff()}"); // DoStuff() n'est pas executé car b est False
}

static void TestEqualityDoubleDecimal()
{
    double doubleA, doubleB, doubleC;
    decimal decimalA, decimalB, decimalC;

    Console.WriteLine("=== TEST DECIMAL ===");
    Console.WriteLine();

    decimalA = 0.1M;
    decimalB = 0.2M;
    decimalC = 0.3M;

    Console.WriteLine($"{decimalA:N2} + {decimalB:N2} = {decimalC:N2} ? {(decimalA + decimalB == decimalC ? "Oui" : "Non")}");

    Console.WriteLine();
    Console.WriteLine("=== TEST DOUBLE ===");
    Console.WriteLine();

    doubleA = 0.1;
    doubleB = 0.2;
    doubleC = 0.3;

    Console.WriteLine($"{doubleA:N2} + {doubleB:N2} = {doubleC:N2} ? {(doubleA + doubleB == doubleC ? "Oui" : "Non")}");
}

static void AlignmentTest()
{
    int[] stocks = { 14_259, 2_547 };
    decimal[] prices = { 0.89M, 1.09M };
    string[] names = { "Apple", "Banana" };

    Console.WriteLine("=== LISTE PRODUITS ===");
    Console.WriteLine();

    Console.WriteLine($"{"Produit",-10} {"Prix", 10} {"Stock", 10}");
    Console.WriteLine();
    for(int i = 0; i < 2; i++) Console.WriteLine($"{names[i], -10} {prices[i],10:C2} {stocks[i], 10:N0}");
}

static void TestKey()
{
    Console.Write("Appuyez sur une touche : ");
    ConsoleKeyInfo key = Console.ReadKey();
    Console.WriteLine();
    Console.WriteLine($"Vous avez appuyé sur la touche {key.Key}, de valeur {key.KeyChar} avec comme modificateurs : {(key.Modifiers == 0 ? "Aucun" : key.Modifiers)}");
}