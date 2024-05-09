class VetRepo
{
    /* This class is in the Data Access / Repository layer of the application */ 
    PersonStorage personStorage = new PersonStorage(); 
    PetStorage  petStorage = new PetStorage(); 

    public Person AddPerson(Person pr)
    {
        /* Prep counter for adding new record*/
        pr.PersonId = personStorage.IdCounter++;

        /* Add Pet into the collection */
        personStorage.persons.Add(pr.PersonId, pr);

        /* Return newly Add Pets data */
        return pr;
    }

    public Pet AddPet(Pet pe)
    {
        /* Prep counter for adding new record*/
        pe.PetIdNum = petStorage.IdCounter++;

        /* Add Pet into the collection */
        petStorage.pets.Add(pe.PetIdNum, pe);

        /* Return newly Add Pets data */
        return pe;
    }

    public Pet? GetPet (int id)
    {
        /* Checik if Pet ID is in the collection   */
        /* If it is we will return the Pet tied to the ID to the user */
        if (petStorage.pets.ContainsKey(id))
        {
           return petStorage.pets[id];
        }
        /* We will let user know the passed in ID was invalid/not found */
        else 
        {
            Console.WriteLine("Invalid Pet ID entered please try again"); 
            Console.WriteLine(); 
            return null;   
        }
    }

    public Pet? UpdatePet( Pet updateP)
    {
        /* Try to update a pet in the collection */
        try
        {
            petStorage.pets[updateP.PetIdNum] = updateP;

            return updateP; 
        }
        /* We will let user know the passed in ID was invalid/not found */
        catch(Exception)
        {
            Console.WriteLine("Invalid Pet ID entered please try again"); 
            Console.WriteLine(); 
            return null; 
        }
    }
}