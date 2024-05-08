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

    public Pet GetPet (int id)
    {
        if (petStorage.pets.ContainsKey(id))
        {
           return petStorage.pets[id];
        }
        else 
        {
            Console.WriteLine("Invalid Pet ID entered please try again"); 
            return null;   
        }

    }


}