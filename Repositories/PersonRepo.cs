class PersonRepo
{
    /* This class is in the Data Access / Repository layer of the application */ 
    PersonStorage personStorage = new PersonStorage();

    /***********************************************/
    /* Method Name - AddPerson                     */
    /* Input       - Person Object                 */
    /* Returns     - Person Object                 */
    /***********************************************/
    public Person? AddPerson(Person pr)
    {
        /* Prep counter for adding new record*/
        pr.PersonId = personStorage.IdCounter++;

        /* Add Person into the collection */
        personStorage.persons.Add(pr.PersonId, pr);

        /* Return newly Added Person data */
        return pr;
    }

    /***********************************************/
    /* Method Name - GetPerson                     */
    /* Input       - PersonId                      */
    /* Returns     - Person that matched to the    */ 
    /*               passed in PersonId            */
    /***********************************************/
    public Person? GetPerson(int id)
    {
        /* Check if PetId is in the collection   */
        /* If it is we will return the Pet tied to the PetId to the user */
        if (personStorage.persons.ContainsKey(id))
        {
           return personStorage.persons[id];
        }
        /* We will let user know the passed in PetId was invalid/not found */
        else 
        {
            Console.WriteLine("Invalid Person ID entered please try again"); 
            Console.WriteLine(); 
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
        return personStorage.persons.Values.ToList(); 
    }
}