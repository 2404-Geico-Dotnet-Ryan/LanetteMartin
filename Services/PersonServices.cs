using System.Reflection.Metadata.Ecma335;

class PersonServices
{
    /*
    Services:
        - Add New Person to the system
        - Look up Person in the system
        - Log User into the system
        - Get All Persons in system
    */

    PersonRepo pr = new PersonRepo();

    public Person? AddNewPerson(Person p)
    {
         /*Will not let you register a new person if the UserName is already in use */
        List<Person> allPersons = pr.GetAllPersons();

        foreach (Person person in allPersons)
        {
            if (person.UserName == p.UserName)
            {
                Console.WriteLine("User Name is already taken");
                return null; 
            }
        }      

        /* If pass both check add the new user */
        return pr.AddPerson(p);
    }

    public Person? LookUpUser(string userName, string phoneNumber)
    {
        /* Look thru all users for a match to UserName or PhoneNumber*/ 
        List<Person> allPersons = pr.GetAllPersons();

        foreach (Person person in allPersons)
        {
            if (person.UserName == userName && person.PhoneNum == phoneNumber)
            {
                return person;
            }
        } 

        return null; 
    }
    
    public Person? LookUpPetParent(string phoneNumber)
    {
        /* Look thru all users for a match to UserName or PhoneNumber*/ 
        List<Person> allPersons = pr.GetAllPersons();

        foreach (Person person in allPersons)
        {
            if (person.PhoneNum == phoneNumber)
            {
                return person;
            }
        } 

        return null; 
    }

    public Person? LoginUser(string userName, string userPassword)
    {
        /* Look thru all users for a match to UserName and Password*/ 
        List<Person> allPersons = pr.GetAllPersons();

        foreach (Person person in allPersons)
        {
            if (person.UserName == userName)
            {
                if (person.UserPassword == userPassword)
                {
                    return person;
                }
                else
                {
                    Console.WriteLine("Password was invalid");
                    return null; 
                }
            }
        }  

        /* If loop found no match means we never found a match */
        Console.WriteLine("Person was not found in the system");
        return null; 
    }

    /***********************************************/
    /* Method Name - GetAllPerson                  */
    /* Inputs      - No Input                      */
    /* Returns     - List of all Person in system  */
    /***********************************************/
    public List<Person> GetAllPerson()
    {
        /* Get All Person in system */
        List<Person> allPerson = pr.GetAllPersons();

        return allPerson;
    }

   
}