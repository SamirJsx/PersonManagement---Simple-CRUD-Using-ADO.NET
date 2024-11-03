using System.Data.SqlClient;

namespace ClassLibrary;

public static class PersonUtils
{
    public static HashSet<Person> persons = new HashSet<Person>();

    public static bool isCached = false;

    public static bool Create(Person person)
    {
        try
        {
            SqlConnection conn = new SqlConnection(Person.connectionString);
            var insertQuery = "INSERT INTO Person (Name, BirthDate, Gender) VALUES (@Name, @BirthDate, @Gender)";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@Name", person.Name);
            cmd.Parameters.AddWithValue("@BirthDate", person.BirthDate);
            cmd.Parameters.AddWithValue("@Gender", person.Gender.ToString());
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            var selectQuery = "SELECT TOP 1 * FROM Person ORDER BY Id DESC";
            SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
            conn.Open();
            using (SqlDataReader reader = selectCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    persons.Add
                    (
                      new Person
                      (
                        $"{reader["Name"]}",
                        DateTime.Parse($"{reader["BirthDate"]}"),
                        Enum.Parse<Gender>($"{reader["Gender"]}"),
                        (int)reader["Id"]
                      )
                    );
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool Read()
    {
        try
        {
            SqlConnection conn = new SqlConnection(Person.connectionString);
            string query = "SELECT * FROM Person";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        persons.Add
                        (
                          new Person
                          (
                            $"{reader["Name"]}",
                            DateTime.Parse($"{reader["BirthDate"]}"),
                            Enum.Parse<Gender>($"{reader["Gender"]}"),
                            (int)reader["Id"]
                          )
                        );
                    }
                    isCached = true;
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool Contains(int id)
    {
        try
        {
            SqlConnection conn = new SqlConnection(Person.connectionString);
            var query = "SELECT Id FROM Person WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }
        catch
        {
            return false;
        }
    }

    public static bool TryFindById(int id, out Person? person)
    {
        try
        {
            SqlConnection conn = new SqlConnection(Person.connectionString);
            string query = "SELECT Id, Name, BirthDate, Gender FROM Person WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        person = new Person
                        (
                          $"{reader["Name"]}",
                          DateTime.Parse($"{reader["BirthDate"]}"),
                          Enum.Parse<Gender>($"{reader["Gender"]}"),
                          (int)reader["Id"]
                        );
                        return true;
                    }
                }
            }
            person = null;
            return false;
        }
        catch
        {
            person = null;
            return false;
        }
    }

    public static bool Update(int id, Person newPerson)
    {
        bool success = TryFindById(id, out Person? person);
        if (!success)
        {
            return false;
        }
        persons.Remove(person);
        try
        {
            SqlConnection conn = new SqlConnection(Person.connectionString);
            string query = "UPDATE Person SET Name = @Name, BirthDate = @BirthDate, Gender = @Gender WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", newPerson.Name);
                cmd.Parameters.AddWithValue("@BirthDate", newPerson.BirthDate);
                cmd.Parameters.AddWithValue("@Gender", newPerson.Gender.ToString());
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    persons.Add(newPerson);
                    return true;
                }
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    public static bool Delete(int id)
    {
        bool success = TryFindById(id, out Person? person);
        if (!success)
        {
            return false;
        }
        try
        {
            SqlConnection conn = new SqlConnection(Person.connectionString);
            var query = "DELETE FROM Person WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    persons.Remove(person);
                    return true;
                }
                return false;
            }
        }
        catch
        {
            return false;
        }
    }
}
