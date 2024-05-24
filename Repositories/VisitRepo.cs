using Microsoft.Data.SqlClient;
class VisitRepo
{
    /* This class is in the Data Access / Repository layer of the application */ 
    /* This verson of the class is using ADO.NET */
    /* for processing with the database          */
    private readonly string _connectionString;

    public VisitRepo (string connString)
    {
        _connectionString = connString;
    }

    /***********************************************/
    /* Method Name - AddPetVisit                   */
    /* Input       - Visit Object                  */
    /* Returns     - Visit Object                  */
    /***********************************************/
    public Visit? AddPetVisit(Visit vi)
    {
        try
        {
            /* Set up DB connection  */ 
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            /* Create the SQL string with your data fields */ 
            string sql = "INSERT into dbo.[Visit] OUTPUT inserted.* VALUES (@PetId, @PersonId, @Weight, @Age, @InSidePet, @AppointmentDate, @SeenBy)"; 

            /* Set up the command to use your passed in data */
            using SqlCommand  cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@PetId", vi.PetId);
            cmd.Parameters.AddWithValue("@PersonId", vi.PersonId);
            cmd.Parameters.AddWithValue("@Weight", vi.Weight);
            cmd.Parameters.AddWithValue("@Age", vi.Age);
            cmd.Parameters.AddWithValue("@InSidePet", vi.InSidePet);
            cmd.Parameters.AddWithValue("@AppointmentDate", vi.AppointmentDate);
            cmd.Parameters.AddWithValue("@SeenBy", vi.SeenBy);

            /* Adds new row to the DB and returns that newly inserted rows data*/ 
            using SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                /* If read found data we will extract it */ 
                Visit newVisit = BuildVisit(reader);
                return newVisit;
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
    /* Method Name - GetAllPetVisits               */
    /* Input       - No Input                      */
    /* Returns     - List of all Vists for a Pet   */
    /*               in the system                 */
    /***********************************************/
    public List<Visit> GetAllPetVisits(int id)
    {
        List<Visit> visits = new(); 
 
        try
        {
            /* Set up DB connection  */ 
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            /* Create the SQL string to pull all data on table */ 
            string sql = "SELECT * FROM dbo.[Visit] where PetId = @PetId order by AppointmentDate";

            /* Set up the SqlCommand Object */
            using SqlCommand  cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@PetId", id);

            /* Read table */ 
            using SqlDataReader reader = cmd.ExecuteReader();

            /* Extract the results from the table read */ 
            while (reader.Read())
            {
                /* If read found data we will extract it and add to list*/
                Visit allVisit = BuildVisit(reader);
                visits.Add(allVisit);
            }

            return visits; 
        }

        catch (Exception e)
        {
            Console.WriteLine (e.Message);
            Console.WriteLine (e.StackTrace);
            return null; 
        } 
    }

    /***********************************************/
    /* Method Name - GetAllParentVisits            */
    /* Input       - No Input                      */
    /* Returns     - List of all Vists for all of  */
    /*               a Parents Pets in the system  */ 
    /***********************************************/
    public List<Visit> GetAllParentVisits(int id)
    {
        List<Visit> visits = new(); 
 
        try
        {
            /* Set up DB connection  */ 
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            /* Create the SQL string to pull all data on table */ 
            string sql = "SELECT * FROM dbo.[Visit] where PersonId = @PersonId order by PetId, AppointmentDate";

            /* Set up the SqlCommand Object */
            using SqlCommand  cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@PersonId", id);

            /* Read table */ 
            using SqlDataReader reader = cmd.ExecuteReader();

            /* Extract the results from the table read */ 
            while (reader.Read())
            {
                /* If read found data we will extract it and add to list*/
                Visit allVisit = BuildVisit(reader);
                visits.Add(allVisit);
            }

            return visits; 
        }

        catch (Exception e)
        {
            Console.WriteLine (e.Message);
            Console.WriteLine (e.StackTrace);
            return null; 
        } 
    }

    /***********************************************/
    /* Method Name - BuildVisit                     */
    /* Input       - Row of data read off the DB   */
    /* Returns     - New Visit Object                */
    /***********************************************/
    private static Visit BuildVisit(SqlDataReader reader)
    {
        Visit newVisit = new();
        newVisit.VisitId = (int)reader["VisitId"];
        newVisit.PetId = (int)reader["PetId"];
        newVisit.PersonId = (int)reader["PersonId"];
        newVisit.Weight = (int)reader["Weight"];
        newVisit.Age = (int)reader["Age"];
        newVisit.InSidePet = (bool)reader["InSidePet"];
        newVisit.AppointmentDate  = (DateTime)reader["AppointmentDate"];
        newVisit.SeenBy = (string)reader["SeenBy"];
        return newVisit;
    }
}