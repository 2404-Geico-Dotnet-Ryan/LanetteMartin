class PetRepo
{
    /* This class is in the Data Access / Repository layer of the application */ 
    PetStorage  petStorage = new PetStorage(); 

    /***********************************************/
    /* Method Name - AddPet                        */
    /* Input       - Pet Object                    */
    /* Returns     - Pet Object                    */
    /***********************************************/
    public Pet? AddPet(Pet pe)
    {
        /* Prep counter for adding new record*/
        pe.PetId = petStorage.IdCounter++;

        /* Add Pet into the collection */
        petStorage.pets.Add(pe.PetId, pe);

        /* Return newly Added Pet data */
        return pe;
    }

    /***********************************************/
    /* Method Name - GetPet                        */
    /* Input       - PetId                         */
    /* Returns     - Pet that matched to the passed*/ 
    /*               in PetId                      */
    /***********************************************/
    public Pet? GetPet(int id)
    {
        /* Check if PetId is in the collection   */
        /* If it is we will return the Pet tied to the PetId to the user */
        if (petStorage.pets.ContainsKey(id))
        {
           return petStorage.pets[id];
        }
        /* We will let user know the passed in PetId was invalid/not found */
        else 
        {
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
        return petStorage.pets.Values.ToList(); 
    }

    /***********************************************/
    /* Method Name - UpdatePet                     */
    /* Input       - Pet Object                    */
    /* Returns     - Updated Pet Object            */
    /***********************************************/
    public Pet? UpdatePet(Pet updateP)
    {
        /* Try to update a Pet in the collection */
        try
        {
            petStorage.pets[updateP.PetId] = updateP;

            return updateP; 
        }
        /* We will let user know the passed in PetId was invalid/not found */
        catch(Exception)
        {
            Console.WriteLine("Invalid Pet ID entered please try again"); 
            Console.WriteLine(); 
            return null; 
        }
    }
}