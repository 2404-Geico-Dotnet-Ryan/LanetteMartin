using Microsoft.Data.SqlClient;
class PetRepo
{
    /* This class is in the Data Access / Repository layer of the application */ 
    /* This verson of the class is using ADO.NET */
    /* for processing with the database          */
    private readonly string _connectionString;

    public PetRepo (string connString)
    {
        _connectionString = connString;
    }

    /***********************************************/
    /* Method Name - AddPet                        */
    /* Input       - Pet Object                    */
    /* Returns     - Pet Object                    */
    /***********************************************/
    public Pet? AddPet(Pet pe)
    {
        try
        {
            /* Set up DB connection  */ 
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            /* Create the SQL string with your data fields */ 
            string sql = "INSERT into dbo.[Pet] OUTPUT inserted.* VALUES (@PersonId, @PetName, @Color,  @FurType, @Gender, @Weight, @Age, @InSidePet, @AppointmentDate, @SeenBy, @RainbowBridgeDate)"; 

            /* Set up the command to use your passed in data */
            using SqlCommand  cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@PersonId", pe.PersonId);
            cmd.Parameters.AddWithValue("@PetName", pe.PetName);
            cmd.Parameters.AddWithValue("@Color", pe.Color);
            cmd.Parameters.AddWithValue("@FurType", pe.FurType);
            cmd.Parameters.AddWithValue("@Gender", pe.Gender);
            cmd.Parameters.AddWithValue("@Weight", pe.Weight);
            cmd.Parameters.AddWithValue("@Age", pe.Age);
            cmd.Parameters.AddWithValue("@InSidePet", pe.InSidePet);
            cmd.Parameters.AddWithValue("@AppointmentDate", pe.AppointmentDate);
            cmd.Parameters.AddWithValue("@SeenBy", pe.SeenBy);
            cmd.Parameters.AddWithValue("@RainbowBridgeDate", pe.RainbowBridgeDate);
    

            /* Adds new row to the DB and returns that newly inserted rows data*/ 
            using SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                /* If read found data we will extract it */ 
                Pet newPet = BuildPet(reader);
                return newPet;
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
    /* Method Name - GetPet                        */
    /* Input       - PetId                         */
    /* Returns     - Pet that matched to the passed*/ 
    /*               in PetId                      */
    /***********************************************/
    public Pet? GetPet(int id)
    {
        try
        {
            /* Set up DB connection  */ 
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            /* Create the SQL string to pull all data on table */ 
            string sql = "SELECT * FROM dbo.[Pet] where PetId = @PetId";

            /* Set up the SqlCommand Object */
            using SqlCommand  cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@PetId", id);

            /* Read table */ 
            using SqlDataReader reader = cmd.ExecuteReader();

            /* Extract the results from the table read */ 
           if(reader.Read())
            {
                /* If read found data we will extract it */ 
                Pet getPet = BuildPet(reader);
                return getPet;
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
    /* Method Name - GetAllPets                    */
    /* Input       - No Input                      */
    /* Returns     - List of all Pets in system    */
    /***********************************************/
    public List<Pet> GetAllPets()
    {
        List<Pet> pets = new(); 
 
        try
        {
            /* Set up DB connection  */ 
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            /* Create the SQL string to pull all data on table */ 
            string sql = "SELECT * FROM dbo.[Pet]";

            /* Set up the SqlCommand Object */
            using SqlCommand  cmd = new(sql, connection);

            /* Read table */ 
            using SqlDataReader reader = cmd.ExecuteReader();

            /* Extract the results from the table read */ 
            while (reader.Read())
            {
                /* If read found data we will extract it and add to list*/
                Pet allPet = BuildPet(reader);
                pets.Add(allPet);
            }

            return pets; 
        }

        catch (Exception e)
        {
            Console.WriteLine (e.Message);
            Console.WriteLine (e.StackTrace);
            return null; 
        } 
    }

    /***********************************************/
    /* Method Name - UpdatePet                     */
    /* Input       - Pet Object                    */
    /* Returns     - Updated Pet Object            */
    /***********************************************/
    public Pet? UpdatePet(Pet updateP)
    {
        try
        {
            /* Set up DB connection  */ 
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            /* Create the SQL string with your data fields */ 
            string sql = "UPDATE dbo.[Pet] SET Weight = @Weight, Age = @Age, InSidePet = @InSidePet, AppointmentDate = @AppointmentDate, SeenBy = @Seenby, RainbowBridgeDate = @RainbowBridgeDate OUTPUT inserted.* WHERE PetId = @PetId"; 

            /* Set up the command to use your passed in data */
            using SqlCommand  cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@PetId", updateP.PetId);
            cmd.Parameters.AddWithValue("@Weight", updateP.Weight);
            cmd.Parameters.AddWithValue("@Age", updateP.Age);
            cmd.Parameters.AddWithValue("@InSidePet", updateP.InSidePet);
            cmd.Parameters.AddWithValue("@AppointmentDate", updateP.AppointmentDate);
            cmd.Parameters.AddWithValue("@SeenBy", updateP.SeenBy);
            cmd.Parameters.AddWithValue("@RainbowBridgeDate", updateP.RainbowBridgeDate);

            /* Adds new row to the DB and returns that newly inserted rows data*/ 
            using SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                /* If read found data we will extract it */ 
                Pet updatedUser = BuildPet(reader);
                return updatedUser;
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
    /* Method Name - BuildPet                      */
    /* Input       - Row of data read off the DB   */
    /* Returns     - New Pet Object                */
    /***********************************************/
    private static Pet BuildPet(SqlDataReader reader)
    {
        Pet newPet = new();
        newPet.PetId = (int)reader["PetId"];
        newPet.PersonId = (int)reader["PersonId"];
        newPet.PetName = (string)reader["PetName"];
        newPet.Color = (string)reader["Color"];
        newPet.FurType = (string)reader["FurType"];
        newPet.Gender = (string)reader["Gender"];
        newPet.Weight = (int)reader["Weight"];
        newPet.Age = (int)reader["Age"];
        newPet.InSidePet = (bool)reader["InSidePet"];
        newPet.AppointmentDate  = (DateTime)reader["AppointmentDate"];
        newPet.SeenBy = (string)reader["SeenBy"];
        newPet.RainbowBridgeDate = (string)reader["RainbowBridgeDate"];
        return newPet;
    }
}