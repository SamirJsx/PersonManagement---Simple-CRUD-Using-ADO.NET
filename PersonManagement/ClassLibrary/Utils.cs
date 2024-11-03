namespace ClassLibrary;

public static class Utils
{
  static (string name, string gender, DateTime birthDate) ReadPerson()
  {
  N: Console.Clear();
    Console.Write("Enter the name: ");
    string name = Console.ReadLine() ?? "";
    if (String.IsNullOrEmpty(name))
    {
      Console.WriteLine("Invalid name! Please try again.");
      Console.ReadKey(true);
      goto N;
    }
  Gender: Console.Clear();
    Console.Write("Enter the gender (Male/Female): ");
    string gender = Console.ReadLine() ?? "";
    if (gender != "Male" && gender != "Female")
    {
      Console.WriteLine("Invalid gender! Please try again.");
      Console.ReadKey(true);
      goto Gender;
    }
  BirthDate: Console.Clear();
    Console.Write("Enter the birth date (YYYY-MM-DD): ");
    bool successBirthDate = DateTime.TryParse(Console.ReadLine(), out DateTime birthDate);
    if (!successBirthDate)
    {
      Console.WriteLine("Invalid birth date! Please try again.");
      Console.ReadKey(true);
      goto BirthDate;
    }
    Console.Clear();
    return (name, gender, birthDate);
  }

  static int ReadId()
  {
  I: Console.Clear();
    Console.Write("Enter the id: ");
    bool successId = int.TryParse(Console.ReadLine(), out int id);
    if (!successId || id <= 0)
    {
      Console.WriteLine("Invalid id! Please try again.");
      Console.ReadKey(true);
      goto I;
    }
    Console.Clear();
    if (PersonUtils.Contains(id))
    {
      return id;
    }
    return -1;
  }

  public static void DeletePerson()
  {
    int id = ReadId();
    if (id == -1)
    {
      Console.WriteLine("No person to update.");
      return;
    }
    bool success = PersonUtils.Delete(id);
    if (!success)
    {
      Console.WriteLine("Something went wrong! Please try later.");
      Console.ReadKey(true);
      Console.Clear();
      return;
    }
    Console.WriteLine("The person has been deleted successfully!");
    Console.ReadKey(true);
  }

  public static void UpdatePerson()
  {
    int id = ReadId();
    if (id == -1)
    {
      Console.WriteLine("No person to update.");
      return;
    }
    var person = ReadPerson();
    bool success = PersonUtils.Update(id, new Person(person.name, person.birthDate, Enum.Parse<Gender>(person.gender), id));
    if (!success)
    {
      Console.WriteLine("Something went wrong! Please try later.");
      Console.ReadKey(true);
      Console.Clear();
      return;
    }
    Console.WriteLine("The person has been updated successfully!");
    Console.ReadKey(true);
  }

  public static void ViewPersons()
  {
    if (!PersonUtils.isCached)
    {
      bool success = PersonUtils.Read();
      if (!success)
      {
        Console.WriteLine("Something went wrong! Please try Later.");
        Console.ReadKey(true);
        return;
      }
      if (PersonUtils.persons.Count == 0)
      {
        Console.WriteLine("No person to display!");
        Console.ReadKey(true);
        return;
      }
      PersonUtils.isCached = true;
    }
    Console.WriteLine(new String('-', 50));
    Console.WriteLine($"| {"Id",-5} | {"Name",-15} | {"BirthDate",-10} | {"Gender",-5} |");
    Console.WriteLine(new String('-', 50));
    foreach (var person in PersonUtils.persons)
    {
      Console.WriteLine($"| {person.Id,-5} | {person.Name,-15} | {person.BirthDate.ToShortDateString(),-10} | {person.Gender,-5} |");
    }
    Console.WriteLine(new String('-', 50));
    Console.ReadKey(true);
    Console.Clear();
  }

  public static void AddPerson()
  {
    var person = ReadPerson();
    bool success = PersonUtils.Create(new Person(person.name, person.birthDate, Enum.Parse<Gender>(person.gender)));
    if (!success)
    {
      Console.WriteLine("Something went wrong! Please try later.");
      Console.ReadKey(true);
      Console.Clear();
      return;
    }
    Console.WriteLine("The person has been added successfully!");
    Console.ReadKey(true);
  }
}
