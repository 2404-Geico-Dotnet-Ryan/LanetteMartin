using Microsoft.Data.SqlClient;
class PersonRepo
{
    /* This class is in the Data Access / Repository layer of the application */ 
    private readonly string _connectionString;

    public PersonRepo (string connString)
    {
        _connectionString = connString;
    }

    /* This verson of the class is using ADO.NET */
    /* for processing with the database          */

    /***********************************************/
    /* Method Name - AddPerson                     */
    /* Input       - Person Object                 */
    /* Returns     - Person Object                 */
    /***********************************************/
    public Person? AddPerson(Person pr)
    {
        try
        {
            /* Set up DB connection  */ 
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            /* Create the SQL string with your data fields */ 
            string sql = "INSERT into dbo.[Person] OUTPUT inserted.* VALUES (@PersonType, @FirstName, @LastName, @PhoneNum, @JobTitle, @UserName, @UserPassword, @AccessLevel)"; 

            /* Set up the command to use your passed in data */
            using SqlCommand  cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@PersonType", pr.PersonType);
            cmd.Parameters.AddWithValue("@FirstName", pr.FirstName);
            cmd.Parameters.AddWithValue("@LastName", pr.LastName);
            cmd.Parameters.AddWithValue("@PhoneNum", pr.PhoneNum);
            cmd.Parameters.AddWithValue("@JobTitle", pr.JobTitle);
            cmd.Parameters.AddWithValue("@UserName", pr.UserName);
            cmd.Parameters.AddWithValue("@UserPassword", pr.UserPassword);
            cmd.Parameters.AddWithValue("@AccessLevel", pr.AccessLevel);

            /* Adds new row to the DB and returns that newly inserted rows data*/ 
            using SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                /* If read found data we will extract it */ 
                Person newPerson = BuildPerson(reader);
                return newPerson;
            }
            else 
            {
                /* Read found nothing ie insert failed */ 
                return null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine (e.Message);
            Console.WriteLine (e.StackTrace);
            return null; 
        } 
    }

    /***********************************************/
    /* Method Name - GetPerson                     */
    /* Input       - PersonId                      */
    /* Returns     - Person that matched to the    */ 
    /*               passed in PersonId            */
    /***********************************************/
    public Person? GetPerson(int id)
    {
        try
        {
            /* Set up DB connection  */ 
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            /* Create the SQL string to pull all data on table */ 
            string sql = "SELECT * FROM dbo.[Person] where PersonId = @PersonId";

            /* Set up the SqlCommand Object */
            using SqlCommand  cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@PersonId", id);

            /* Read table */ 
            using SqlDataReader reader = cmd.ExecuteReader();

            /* Extract the results from the table read */ 
           if(reader.Read())
            {
                /* If read found data we will extract it */ 
                Person getPerson = BuildPerson(reader);
                return getPerson;
            }
            else 
            {
                /* Read found nothing ie insert failed */ 
                return null;
            }; 
        }

        catch (Exception e)
        {
            Console.WriteLine (e.Message);
            Console.WriteLine (e.StackTrace);
            return null; 
        } 
    }

    /***********************************************/
    /* Method Name - GetAllPersons                 */
    /* Input       - No Input                      */
    /* Returns     - List of all Pets in system    */
    /***********************************************/
    public List<Person> GetAllPersons()
    {
        List<Person> persons = new(); 
 
        try
        {
            /* Set up DB connection  */ 
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            /* Create the SQL string to pull all data on table */ 
            string sql = "SELECT * FROM dbo.[Person]";

            /* Set up the SqlCommand Object */
            using SqlCommand  cmd = new(sql, connection);

            /* Read table */ 
            using SqlDataReader reader = cmd.ExecuteReader();

            /* Extract the results from the table read */ 
            while (reader.Read())
            {
                /* If read found data we will extract it and add to list*/
                Person allPerson = BuildPerson(reader);
                persons.Add(allPerson);
            }

            return persons; 
        }

        catch (Exception e)
        {
            Console.WriteLine (e.Message);
            Console.WriteLine (e.StackTrace);
            return null; 
        } 
    }

    /***********************************************/
    /* Method Name - BuildPerson                   */
    /* Input       - Row of data read off the DB   */
    /* Returns     - New Person Object             */
    /***********************************************/
    private static Person BuildPerson(SqlDataReader reader)
    {
        Person newPerson = new();
        newPerson.PersonId = (int)reader["PersonId"];
        newPerson.PersonType = (int)reader["PersonType"];
        newPerson.FirstName = (string)reader["FirstName"];
        newPerson.LastName = (string)reader["LastName"];
        newPerson.PhoneNum = (string)reader["PhoneNum"];
        newPerson.JobTitle = (string)reader["JobTitle"];
        newPerson.UserName = (string)reader["UserName"];
        newPerson.UserPassword = (string)reader["UserPassword"];
        newPerson.AccessLevel = (int)reader["AccessLevel"];
        return newPerson;
    }
}