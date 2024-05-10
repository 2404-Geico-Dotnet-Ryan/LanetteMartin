class VetServices
{
    /*
    Services:
        - Get All Persons in system
        - Get All Pets in system
        - Get All Pets belonging to a Person
        - Get ALL Records belonging to a Pet   
    */

    VetRepo vr = new VetRepo();

    /***********************************************/
    /* Method Name - GetAllPerson                  */
    /* Inputs      - No Input                      */
    /* Returns     - List of all Person in system  */
    /***********************************************/
    public List<Person> GetAllPerson()
    {
        /* Get All Person in system */
        List<Person> allPerson = vr.GetAllPersons();

        return allPerson;
    }

    /***********************************************/
    /* Method Name - GetAllPet                     */
    /* Inputs      - No Input                      */
    /* Returns     - List of all Pet in system     */
    /***********************************************/
    public List<Pet> GetAllPet()
    {
        /* Get All Pet in system */
        List<Pet> allPets = vr.GetAllPets();

        return allPets; 
        
    }

    /***********************************************/
    /* Method Name - GetPersonsPets                */
    /* Inputs      - PersonId                      */
    /* Returns     - List of all Pets belonging to */
    /*               Person                        */
    /***********************************************/
    public List<Pet> GetPersonsPets(int id)
    {
        /* Get All Pets in system */
        List<Pet> allPets = vr.GetAllPets();

        /* Filter out only Pets belonging to Person */
        List<Pet> allPersonsPets = new();

        /* Filter out only Pets matching PersonId passed in */
        foreach (Pet pet in allPets)
        {
            if(pet.PersonId == id)
            {
                allPersonsPets.Add(pet);
            }
        }

        /* Return list of Pets belonging to Person */
        return allPersonsPets; 
    }

    /***********************************************/
    /* Method Name - GetPetsRecords                */
    /* Inputs      - PetId                         */
    /* Returns     - List of all records belonging */
    /*               to Pet                        */
    /***********************************************/
    public List<Pet> GetPetsRecords(int id)
    {
        /* Get All Pets in system */
        List<Pet> allPets = vr.GetAllPets();

        /* Filter out only records belonging to Pet */
        List<Pet> allPetsRecord = new();

        /* Filter out only Pets matching PetId passed in */
        foreach (Pet pet in allPets)
        {
            if(pet.PetId == id)
            {
                allPetsRecord.Add(pet);
            }
        }

        /* Return list of records belonging to Pet */
        return allPetsRecord; 
    }
}