using System.Globalization;
using ClassLibrary;

namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(new String('-', 43));
            Console.WriteLine("| Welcome to my Person System Management! |");
            Console.WriteLine(new String('-', 43));
            Console.WriteLine("1. Add Person");
            Console.WriteLine("2. View Persons");
            Console.WriteLine("3. Update Person");
            Console.WriteLine("4. Delete Person");
            Console.WriteLine("5. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Utils.AddPerson();
                    break;
                case "2":
                    Utils.ViewPersons();
                    break;
                case "3":
                    Utils.UpdatePerson();
                    break;
                case "4":
                    Utils.DeletePerson();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Thank you for using the program! Goodbye.");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }
}
