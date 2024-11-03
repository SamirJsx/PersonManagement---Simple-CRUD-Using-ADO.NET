namespace ClassLibrary;

public class Person
{
  public readonly static string connectionString = "Server=.\\SQLEXPRESS;Database=MyDatabase;Integrated Security=True;";

  public int Id { get; }

  public string Name { get; }

  public DateTime BirthDate { get; }

  public Gender Gender { get; }

  public Person(string name, DateTime birthDate, Gender gender, int id = 0)
  {
    Id = id;
    Name = name;
    BirthDate = birthDate;
    Gender = gender;
  }

  public override bool Equals(object? obj)
  {
    if (obj == null || GetType() != obj.GetType())
    {
      return false;
    }
    Person other = (Person)obj;
    return Id == other.Id;
  }

  public override int GetHashCode()
  {
    return Id.GetHashCode();
  }

  public override string ToString()
  {
    return $"{{\n  'id': {Id},\n  'name': {Name},\n  'birthDate': {BirthDate.ToShortDateString()}\n  'gender': {Gender}\n}}";
  }
}
