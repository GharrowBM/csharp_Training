global using System.Text;
using Test01.Classes;

Console.OutputEncoding = Encoding.UTF8;

#region InheranceExample

//Random rnd = new Random();
//Mammal[] mammals = new Mammal[10];

//for(int i = 0; i < mammals.Length; i++)
//{
//    int rng = rnd.Next(2);

//    if (rng == 0) mammals[i] = new Cat();
//    else mammals[i] = new Dog();
//}

//foreach(Mammal mammal in mammals)
//{
//    mammal.DoSomething();

//    Console.WriteLine();
//    Console.WriteLine($"Without Switch Exp : {mammal.Move()}");


//    string message = mammal switch
//    {
//        Dog => ((Dog)mammal).Move(),
//        Cat => ((Cat)mammal).Move(),
//        _ => mammal.Move()
//    };

//    Console.WriteLine($"With Switch Exp : {message}");

//    if (mammal is Dog) ((Dog) mammal).Bark();
//    if (mammal is Cat) ((Cat)mammal).Meow();

//    Console.WriteLine();
//}

#endregion

#region Switch exp C# 8

//Console.WriteLine();
//Console.WriteLine("=== Switch Expression en C# 8 ===\n");

//object[] passengers = {
//  new FirstClassPassenger { AirMiles = 1_419 },
//  new FirstClassPassenger { AirMiles = 16_562 },
//  new BusinessClassPassenger(),
//  new CoachClassPassenger { CarryOnKG = 25.7 },
//  new CoachClassPassenger { CarryOnKG = 0 },
//};
//foreach (object passenger in passengers)
//{
//    decimal flightCost = passenger switch
//    {
//        FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
//        FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
//        FirstClassPassenger _ => 2000M,
//        BusinessClassPassenger _ => 1000M,
//        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
//        CoachClassPassenger _ => 650M,
//        _ => 800M
//    };
//    Console.WriteLine($"Flight costs {flightCost:C} for {passenger}");
//}

#endregion

#region Switch exp C# 9

//Console.WriteLine();
//Console.WriteLine("=== Switch Expression en C# 9 ===\n");

//foreach (object passenger in passengers)
//{
//    decimal flightCost = passenger switch
//    {
//        FirstClassPassenger { AirMiles: > 35000 } => 1500,
//        FirstClassPassenger { AirMiles: > 15000 } => 1750M,
//        FirstClassPassenger => 2000M,
//        BusinessClassPassenger => 1000M,
//        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
//        CoachClassPassenger => 650M,
//        _ => 800M
//    };
//    Console.WriteLine($"Flight costs {flightCost:C2} for {passenger}");
//}

#endregion

#region AppelMethodes

//TestMajoriity();
//GetNumberFromInput("Entrez un nombre : ");
//PlayMysteryNumber(10);
//PrintASCITable();

#endregion

#region TestFormatString

//int age = 25;
//double price = 125.99;

//Console.WriteLine($"Vous avez {age:N0} ans et vous devez payer {price.ToString("C", CultureInfo.GetCultureInfo("en-US"))}");

//Console.WriteLine("Vous avez {0:N0} ans et vous devez payer {1:C}", age, price);

#endregion

#region Example region

//Person john = new Person() { Name = "John" };
//john.Shout += Person_Shout;
//for (int i = 0; i < 5; i++) john.Poke();

#endregion

#region IterationCardinal

//for (int number = 1; number <= 40; number++)
//{
//    Console.Write($"{CardinalToOrdinal(number)} ");
//}
//Console.WriteLine();

#endregion

#region TestBinaire

//int nombreenBase10;

//Console.Write("Quel nombre voulez vous convertir en binaire ? ");
//int.TryParse(Console.ReadLine(), out nombreenBase10);

//Console.WriteLine($"{nombreenBase10:N} a pour valeur en binaire : {ConvertToBinary(nombreenBase10), 10}.");

#endregion

#region TestTableauxCopie

//string[] listAnimaux = new[] { "Chien", "Chat", "Souris" };
//string[] listAnimaux2 = listAnimaux;
//string[] listAnimaux3 = (string[])listAnimaux.Clone();
//string[] listAnimauxEtendue = new string[20];

//listAnimaux.CopyTo(listAnimauxEtendue, 0);

//listAnimaux[1] = "Renard";

//Console.WriteLine($"Liste d'animaux de base : {string.Join(", ", listAnimaux)}");
//Console.WriteLine($"Liste d'animaux 2 avec même référence que l'originale : {string.Join(", ", listAnimaux2)}");
//Console.WriteLine($"Liste d'animaux dupliquée : {string.Join(", ", listAnimaux3)}");
//Console.WriteLine($"Liste d'animaux étendue : {string.Join(", ", listAnimauxEtendue)}");

#endregion

#region Deconstructor

//Person Arnold = new("Arnold", 6);
//var (nameOfPerson, angerOfPerson) = Arnold;

//Console.WriteLine($"{nameOfPerson} a un niveau de colère de {angerOfPerson}");

#endregion

#region CalcAge

//DateTime aujourdhui = DateTime.Now;

//int age = 29;

//Console.WriteLine($"Si j'ai {age:N0} ans aujourd'hui, alors je suis né en {DateTime.Now.Year-age}");

//Console.WriteLine($"{aujourdhui:dddd dd MMMM yyy}");

#endregion

#region Test Delegates

//List<string> maListeDeString = new List<string>() { "Albert", "Bernard", "Quentin", "Alfred"};

//List<string> maListeReduite = maListeDeString.ReduceList(e => e.StartsWith("Al")).ToList();

//Console.WriteLine(string.Join(", ", maListeDeString));
//Console.WriteLine(string.Join(", ", maListeReduite));
//Console.WriteLine(Extensions.GetFirst(maListeReduite));

#endregion

#region Test Evenements

//Person john = new("John", 0);

//john.Shout += Person_Shout;

//for(int i = 0; i < 10; i++)
//{
//    john.Poke();
//}

Sale mySale = new("I Phone X", 1199.99M);

mySale.Promotion += SendMessage;

mySale.Reduction(200);

#endregion

static void QCMWithDictionnary()
{
    Dictionary<string, string> qcmChoices = new();

    qcmChoices["A"] = "quit";
    qcmChoices["B"] = "continue";
    qcmChoices["C"] = "break";
    qcmChoices["D"] = "exit";

    List<string> strings = new();

    string input = string.Empty;
    do
    {
        Console.WriteLine("Quelle est l'instruction qui permet de sortir d'une boucle en C#");

        foreach (KeyValuePair<string, string> item in qcmChoices)
        {
            Console.WriteLine($"{item.Key}. {item.Value}");
        }

        Console.Write("Votre choix : ");
        input = Console.ReadLine().ToLower();

        Console.WriteLine();

    } while (input != "c");

    Console.WriteLine("Bravo, vous avez trouvé !");
}

static string ConvertToBinary(int value)
{
    return Convert.ToString(value, toBase: 2).PadLeft(8, '0');
}

static decimal CalcTaxPrice(decimal baseAmount)
{
    decimal taxes;

    Console.Write("Quel est le prix du produit ? ");
    if(decimal.TryParse(Console.ReadLine().Replace('.', ','), out taxes))
    {
        return baseAmount + taxes;
    }
    return baseAmount;
}

static void SendMessage(decimal amount)
{
    Console.WriteLine($"La vente bénéficie d'une promotion ! Son nouveau prix est de {amount:C2}");
}

static void Person_Shout(object? sender, EventArgs e)
{
    if (sender == null) return;
    Person p = (Person)sender;
    Console.WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
}

static string CardinalToOrdinal(int number)
{
    switch (number)
    {
        case 11: // special cases for 11th to 13th
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

static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
{
    decimal rate = 0.0M;
    switch (twoLetterRegionCode)
    {
        case "CH": // Switzerland
            rate = 0.08M;
            break;
        case "DK": // Denmark
        case "NO": // Norway
            rate = 0.25M;
            break;
        case "GB": // United Kingdom
        case "FR": // France
            rate = 0.2M;
            break;
        case "HU": // Hungary
            rate = 0.27M;
            break;
        case "OR": // Oregon
        case "AK": // Alaska
        case "MT": // Montana
            rate = 0.0M;
            break;
        case "ND": // North Dakota
        case "WI": // Wisconsin
        case "ME": // Maine
        case "VA": // Virginia
            rate = 0.05M;
            break;
        case "CA": // California
            rate = 0.0825M;
            break;
        default: // most US states
            rate = 0.06M;
            break;
    }
    return amount * rate;
}

static void TestMajoriity()
{
    while (true)
    {
        Console.Write("Votre âge : ");
        if (int.TryParse(Console.ReadLine(), out int age))
        {
            if (age >= 18)
            {
                Console.WriteLine("Vous êtes majeur et pouvez continuer...");
                break;
            }
            else
            {
                Console.WriteLine("Revenez quand vous serez majeur...");
            }
        }
        else
        {
            Console.WriteLine("L'entrée n'est pas au format correct pour un INT32");
        }
    }
}

static int GetNumberFromInput(string message)
{
    do
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            return value;

        }
        else
        {
            Console.WriteLine("La valeur entrée est incorrecte !");
        }
    } while (true);
    
}

static void PlayMysteryNumber(int maxValue)
{
    var random = new Random();
    int mysteryNumber = random.Next(0, maxValue + 1);
    int numberTried = -1;
    int compteur = 1;

    do
    {
        numberTried = GetNumberFromInput($"Tentative n°{compteur++} - Trouvez le nombre mystère");

        if (numberTried == mysteryNumber)
        {
            Console.WriteLine("Félicitation ! Vous avez trouvé le nombre mystère !");
            break;
        }
        else if (numberTried > mysteryNumber)
        {
            Console.WriteLine("Pas de chance ! Trop grand...");
        }
        else
        {
            Console.WriteLine("Pas de chance ! Trop petit...");
        }
    } while (true);
    //} while (numberTried != mysteryNumber);

}

static void PrintASCITable()
{
    int letterASCI = 65;
    string espaces = "";

    for (int i = 0; i < 26; i++)
    {
        Console.WriteLine($"{espaces}{(char)(letterASCI++)}");
        espaces += "   ";
    }
}