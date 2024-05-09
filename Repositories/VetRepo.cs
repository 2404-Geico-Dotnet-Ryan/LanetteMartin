class VetRepo
{
    /* This class is in the Data Access / Repository layer of the application */ 
    PersonStorage personStorage = new PersonStorage(); 
    PetStorage  petStorage = new PetStorage(); 

    /***********************************************/
    /* Method Name - AddPerson                     */
    /* Input       - Person Object                 */
    /* Returns     - Person Object                 */
    /***********************************************/
    public Person AddPerson(Person pr)
    {
        /* Prep counter for adding new record*/
        pr.PersonId = personStorage.IdCounter++;

        /* Add Person into the collection */
        personStorage.persons.Add(pr.PersonId, pr);

        /* Return newly Added Person data */
        return pr;
    }

    /***********************************************/
    /* Method Name - AddPet                        */
    /* Input       - Pet Object                    */
    /* Returns     - Pet Object                    */
    /***********************************************/
    public Pet AddPet(Pet pe)
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
    public Pet? GetPet (int id)
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
            Console.WriteLine("Invalid Pet ID entered please try again"); 
            Console.WriteLine(); 
            return null;   
        }
    }

    /***********************************************/
    /* Method Name - UpdatePet                     */
    /* Input       - Pet Object                    */
    /* Returns     - Updated Pet Object            */
    /***********************************************/
    public Pet? UpdatePet( Pet updateP)
    {
        /* Try to update a Pet in the collection */
        try
        {
            petStorage.pets[updateP.PetIdNum] = updateP;

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