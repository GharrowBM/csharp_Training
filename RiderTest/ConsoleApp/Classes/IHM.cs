namespace ConsoleApp.Classes;

public class IHM
{
    public void Start()
    {
        int mainMenuChoice = -1;

        do
        {
            Console.WriteLine("=== MENU PRINCIPAL ===");
            Console.WriteLine("1. Consulter les personnes");
            Console.WriteLine("2. Ajouter une personne");
            Console.WriteLine("3. Editer une personne");
            Console.WriteLine("4. Supprimer une personne");
            Console.WriteLine("0. Quitter le programme");

            try
            {
                mainMenuChoice = int.Parse(Console.ReadLine());

                switch (mainMenuChoice)
                {
                    case 0:
                        break;
                    case 1:
                        ShowPersons();
                        break;
                    case 2:
                        AddPerson();
                        break;
                    case 3:
                        EditPerson();
                        break;
                    case 4:
                        RemovePerson();
                        break;
                    default:
                        Console.WriteLine("Veuilliez indiquer l'un des choix proposés !");
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ce n'est pas un nombre !");
            }
            
            
        } while (mainMenuChoice !=0);
    }

    private void AddPerson()
    {
        
    }

    private void ShowPersons()
    {
        
    }

    private void EditPerson()
    {
        
    }

    private void RemovePerson()
    {
        
    }
}