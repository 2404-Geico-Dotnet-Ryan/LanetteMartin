using System;
using System.Linq.Expressions;

class Program
{
    /*
    This program will track pets seen by the staff of the Kitty City Vet Office.  

    Office Staff - will be able to create new Pet Records, Update Pet Records and Close Out Pet Records
    Pet Owners   - will be able to view their pet's records and reqeust a call back from the Vet staff
    */
    static PersonServices prs = new();
    static PetServices pet = new();

    static void Main(string[] args)
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine("    Kitty City Vet Office    ");
        Console.WriteLine("-----------------------------");
        Console.WriteLine();

        int typeOfUser = DetermineSystemUser(); 
        
        switch (typeOfUser)
        {
            case 1:
            {
                VetStaffOptions();
                break;
            }
            case 2:
            {
                PetOwnerOptions();
                break;
            }
        }
    }

    /*********************************************************************/
    /* The following section of code determines who is useing the system */ 
    /*********************************************************************/
    public static int DetermineSystemUser()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("- Welcome to the Kitty City Vet Office -");
        Console.WriteLine("-          Pet Records System          -");
        Console.WriteLine("-      Who is using system today?      -"); 
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Type '1' if you are Vet Staff");
        Console.WriteLine("Type '2' if you are a Pet Parent");
        Console.WriteLine();
    
        int userSelection = int.Parse(Console.ReadLine()?? "0");

        userSelection = ValidateTask(userSelection, 2);

        return userSelection;
    }

    /***********************************************************/
    /* The following section of code runs Vet Staff Functions  */ 
    /***********************************************************/
    public static void VetStaffOptions()
    {
        bool keepWorking = true; 

        while (keepWorking)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("- Welcome to the Pet Records System -");
            Console.WriteLine("-        Vet Staff Options          -");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Type '1' To Set Up a New Pet Family  ");
            Console.WriteLine("Type '2' To Set Up a New Pet Record  ");
            Console.WriteLine("Type '3' To View All of a Parent's Pets");
            Console.WriteLine("Type '4' To Update a Pet Record      ");
            Console.WriteLine("Type '5' To Close Out a Pet Record   ");
            Console.WriteLine("Type '6' To View List of All People in System ");
            Console.WriteLine("Type '7' To View List of All Pets in System ");
            Console.WriteLine("Type '8' Exit System                 ");
            Console.WriteLine();
        
            int staffSelection =  int.Parse(Console.ReadLine() ?? "0");

            int taskToRun = ValidateTask(staffSelection, 8);

            switch (taskToRun)
            {
                case 1:
                {
                    NewPetFamilyRecord();
                    break;
                }
                case 2:
                {
                    NewPetRecord();
                    break;
                }
                case 3:
                {
                    ViewPetRecord();
                    break;
                }                
                case 4:
                {
                    UpdatePetRecord();
                    break;
                }
                case 5:
                {
                    CloseOutPetRecord();
                    break;
                }
                case 6:
                {
                    ViewAllPerson();
                    break;
                }
                case 7:
                {
                    ViewAllPet();
                    break;
                }
                case 8:
                {
                    Console.WriteLine("Have a PURRfectly great remaninder of your work day!");
                    Console.WriteLine();
                    keepWorking = false;  
                    break;  
                }
            }
        }
    }

    /***********************************************************/
    /* The following section of code runs Pet Parent Functions */ 
    /***********************************************************/
    public static void PetOwnerOptions()
    {
        bool keepParenting = true; 

        while (keepParenting)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("- Welcome to the Pet Records System  -");
            Console.WriteLine("-        Pet Parent Options          -");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Type '1' To View All Your Pets Records");
            Console.WriteLine("Type '2' To Request A Call Back       ");
            Console.WriteLine("Type '3' Exit System                  ");
            Console.WriteLine();
        
            int parentSelection =  int.Parse(Console.ReadLine() ?? "0");

            int taskToRun = ValidateTask(parentSelection, 3);
            switch (taskToRun)
            {
                case 1:
                {
                    ViewPetRecord();
                    break;
                }
                case 2:
                {
                    RequstCallBack();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("Thank you for trusting us with your Kitty!");
                    Console.WriteLine();
                    keepParenting = false; 
                    break;
                }
            }
        }
    }

    /***********************************************/
    /* Method Name - NewPetFamilyRecord            */
    /* Inputs      - Console Input                 */
    /* Returns     - VOID (No Data Returned)       */
    /***********************************************/
    private static void NewPetFamilyRecord()
    {
        Console.WriteLine(); 
        Console.WriteLine("  Please Enter Pet Parent Information   ");
        Console.WriteLine(" to check if they are already in system ");
        Console.WriteLine("----------------------------------------");

        Person? lookUp = LookUpParent();

        if (lookUp != null)
        {
            Console.WriteLine(); 
            Console.WriteLine("Pet Parent was located in the system please use option 2 to add in their new pet");
            return;
        }
       
        Console.WriteLine();
        Console.WriteLine("We did not find the Pet Parent in our system lets get them and their kitty added");
        
        string personFirstName = "";
        while (personFirstName == "")
        {
            Console.WriteLine();
            Console.WriteLine("Pet Parent First Name :");
            personFirstName = Console.ReadLine()?? "";
        }

        string personLastName = "";
        while (personLastName == "")
        {
            Console.WriteLine();
            Console.WriteLine("Pet Parent Last Name :");
            personLastName = Console.ReadLine()?? "";
        }

        string personPhoneNumber = "";
        while (personPhoneNumber == "")
        {
            Console.WriteLine();
            Console.WriteLine("Pet Parent Phone Number :");
            personPhoneNumber = Console.ReadLine()?? "";
        }

        string personUserName = "";
        while (personUserName == "")
        {
            Console.WriteLine();
            Console.WriteLine("Pet Parent Account User Name :");
            personUserName = Console.ReadLine()?? "";
        }

        string personPassword = "";
        while (personPassword == "")
        {
            Console.WriteLine();
            Console.WriteLine("Pet Parent Account Password :");
            personPassword = Console.ReadLine()?? "";
        }
        
        /* Create a new Pet Parent (Person) */ 
        /* Hard Coded Values as for now only new Pet Parents can be added to system*/
        string personTitle = "Pet Parent";

        /* Will use the new Per Parents ID when builidng thier Pet's Record */ 
        Person? newPerson = new Person(0, 2, personFirstName, personLastName, personPhoneNumber, personTitle, personUserName, personPassword, 2);
        prs?.AddNewPerson(newPerson);

        Console.WriteLine(); 
        Console.WriteLine("Newly Added Pet Parent - " + newPerson);

        Pet? newPet = NewPet(newPerson.PersonId);

        Console.WriteLine(); 
        Console.WriteLine("Newly Added Pet - " + newPet);
    }
    
    /***********************************************/
    /* Method Name - NewPetRecord                  */
    /* Inputs      - Console Input                 */
    /* Returns     - VOID (No Data Returned)       */
    /***********************************************/
    private static void NewPetRecord()
    {
        Console.WriteLine(); 
        Console.WriteLine(" Please Enter Pet Parent Account Information ");
        Console.WriteLine("---------------------------------------------");

        Person? lookUp = LookUpParent();

        Pet? newPet = NewPet(lookUp.PersonId);

        Console.WriteLine("Newly Added Pet - " + newPet);
    }

    /***********************************************/
    /* Method Name - NewPet                        */
    /* Inputs      - Pet Parent's personId         */
    /* Returns     - Newly created Pet             */
    /***********************************************/
    private static Pet? NewPet(int personId)
    {
        Console.WriteLine();
        Console.WriteLine("Please Enter Pet Information");
        Console.WriteLine("----------------------------");

        string petName = "";
        while (petName == "")
        {
            Console.WriteLine("Pet Name :");
            petName = Console.ReadLine()?? "";
        }

        string petColor = "";
        while (petColor == "")
        {
            Console.WriteLine();
            Console.WriteLine("Fur Color :");
            petColor = Console.ReadLine()?? "";
        }

        string petFurType = "";
        while (petFurType == "")
        {
            Console.WriteLine();
            Console.WriteLine("Fur Type :");
            petFurType = Console.ReadLine()?? "";
        }

        string petGender = "";
        while (petGender == "")
        {
            Console.WriteLine();
            Console.WriteLine("Gender :");
            petGender = Console.ReadLine()?? "";
        }

        int petAge = 0;
        while (petAge == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Age :");
            petAge = int.Parse(Console.ReadLine() ?? "0"); 
        }
       
        int petWeight = 0;
        while (petWeight == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Weight :");
            petWeight = int.Parse(Console.ReadLine() ?? ""); 
        }

        string petInside = "";
        while (petInside == "")
        {
            Console.WriteLine();
            Console.WriteLine("Inside Pet - True or False");
            petInside = Console.ReadLine()?? "";
        }

        bool inSide =  true; 

        if (petInside !=null) 
        {
            if (petInside.ToUpper() == "TRUE")
            {
                inSide = true; 
            }
            else inSide  = false;
        }

        /* Need to update to set SeenBy based on Vet employee who is logged into the system */
        /* Hard Coded until we know who is logged into the system then will update with their information */ 
        string petSeenBy = "HeadVet Dr Charlie Ho";

        /* Creates a new Pet */ 
        Pet newPet = new Pet(0, personId, petName, petColor, petFurType, petGender, petWeight, petAge, inSide, petSeenBy, "0");

        /* Adds the new Pet to the Dictionary */ 
        return pet.AddPet(newPet);
    }

    /***********************************************/
    /* Method Name - UpdatePetRecord               */
    /* Inputs      - VetRepo Object, Console Input */
    /* Returns     - VOID (No Data Returned)       */
    /***********************************************/
    private static void UpdatePetRecord()
    {
        Console.WriteLine();
        Console.WriteLine("Please Enter Updated Pet Information");
        Console.WriteLine("       Based On Todays Visit        ");     
        Console.WriteLine("------------------------------------");

        // We are making the assumption that vet employee knowns IDs that will work
        // as the have already looked up the Parent's Pets 
        Pet? updatePet = PromotForId(); 

        Console.WriteLine();
        Console.WriteLine("Current Pet Age is " + updatePet.Age);
        int newAge = 0;
        while (newAge == 0)
        {
            Console.WriteLine("New Pet Age this appointment");
            newAge = int.Parse(Console.ReadLine() ?? ""); 
        }
        updatePet.Age = newAge;

        Console.WriteLine();
        Console.WriteLine("Current Pet Weight is " + updatePet.Weight);
        int newWeight = 0;
        while (newWeight == 0)
        {
            Console.WriteLine("New Pet Weight this appointment");
            newWeight = int.Parse(Console.ReadLine() ?? "");
        } 
        updatePet.Weight = newWeight; 

        string petInside = "";
        while (petInside == "")
        {
            Console.WriteLine();
            Console.WriteLine("Inside Pet - True or False");
            petInside = Console.ReadLine()?? "";
        }

        if (petInside.ToUpper() == "TRUE")
        {
            updatePet.InSidePet = true; 
        }
        else updatePet.InSidePet  = false;
     
        updatePet.AppointmentDate = DateTime.Now; 

        /* Need to update to set SeenBy based on Vet employee who is logged into the system */
        /* Hard Coded until we know who is logged into the system then will update with their information */ 
        updatePet.SeenBy = "HeadVet Dr Charlie Ho";

        /* Update the Pet in the collection */
        updatePet = pet.UpdatePet(updatePet);

        /* After Pet updated display its new information */
        Console.WriteLine();
        Console.WriteLine("Pet was updated as follows - " + updatePet);
    }

    /***********************************************/
    /* Method Name - ViewAllPerson                 */
    /* Input       - No Input                      */
    /* Returns     - List of all Person in the     */ 
    /*               system                        */
    /***********************************************/
    private static void ViewAllPerson()
    {
        Console.WriteLine();
        Console.WriteLine("List of all Vet Employees and Pet Parents ");
        Console.WriteLine("              in the system               ");
        Console.WriteLine("------------------------------------------");
        /* Get list of all Person in the system */
        List<Person> persons = prs.GetAllPerson();

        /* Write the list to the Console */
        foreach (Person person in persons)
        {
            Console.WriteLine(person); 
        }
    }
    
    /***********************************************/
    /* Method Name - ViewAllPet                    */
    /* Input       - No Input                      */
    /* Returns     - List of all Pet in the        */ 
    /*               system                        */
    /***********************************************/
    private static void ViewAllPet()
    {
        Console.WriteLine();
        Console.WriteLine(" List of all Kitty Cats ");
        Console.WriteLine("     in the system      ");
        Console.WriteLine("------------------------");
        /* Get list of all Person in the system */
        List<Pet> pets = pet.GetAllPet();

        /* Write the list to the Console */
        foreach (Pet pet in pets)
        {
            Console.WriteLine(pet); 
        }
    }

    /***********************************************/
    /* Method Name - ViewPetRecord                 */
    /* Input       - VetRepo Object                */
    /* Returns     - VOID (No Data Returned)       */
    /***********************************************/
    private static void ViewPetRecord()
    {
        Console.WriteLine(); 
        Console.WriteLine(" Please Enter Pet Parent Account Information ");
        Console.WriteLine("---------------------------------------------");

        Person? lookUp = LookUpParent();

        List<Pet> allPersonsPets = new(); 

        try
        { 
            allPersonsPets = pet.GetPersonsPets(lookUp.PersonId); 
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Pet Parent was not located in the system");
        }
    
        /* After Pets retrieved display its information*/
        foreach (Pet pet in allPersonsPets)
        {
            Console.WriteLine();
            Console.WriteLine(pet);
        }
    }

    /***********************************************/
    /* Method Name - CloseOutPetRecord             */
    /* Input       - VetRepo Object, Console Input */
    /* Returns     - VOID (No Data Returned)       */
    /***********************************************/
    private static void CloseOutPetRecord()
    {
        Console.WriteLine();
        Console.WriteLine("  Please Enter Date Kitty   ");
        Console.WriteLine(" Crossed the Rainbow Bridge ");     
        Console.WriteLine("----------------------------");

        // We are making the assumption that user knowns IDs that will work 
        Pet? closePet = PromotForId(); 

        Console.WriteLine();
        Console.WriteLine("Pet to close out - " + closePet);

        string petsRainbowBridgeDate = "";
        while (petsRainbowBridgeDate == "")
        {
            Console.WriteLine();
            Console.WriteLine("What day did Kitty cross the Rainbow Bridge:");
            petsRainbowBridgeDate = Console.ReadLine()?? "";   
        }   

        closePet.RainbowBridgeDate = petsRainbowBridgeDate;

        /* Update the Pet in the collection */
        closePet = pet.UpdatePet(closePet);

        /* After Pet updated display its new information */
        Console.WriteLine();
        Console.WriteLine("Pet Record has been closed out - " + closePet);
    }

    /***********************************************/
    /* Method Name - RequstCallBack                */
    /* Input       - Console Input                 */
    /* Returns     - VOID (No Data Returned)       */
    /***********************************************/
    public static void RequstCallBack()
    {
        string parentName = "";
        while (parentName == "")
        {
            Console.WriteLine();
            Console.WriteLine("Call Back Name : ");
            parentName = Console.ReadLine()?? "0";
        }

        string parentNumber = "";
        while (parentNumber == "")
        {
            Console.WriteLine();
            Console.WriteLine("Call Back Number : ");
            parentNumber = Console.ReadLine()?? "0";
        }

        string petName = "";
        while(petName == "")
        {
            Console.WriteLine();
            Console.WriteLine("Name of Pet Calling about : ");
            petName = Console.ReadLine()?? "0";
        }

        string filepath = "KittyCityCallBackLog.txt";
        WriteToFile(filepath, parentName, parentNumber, petName);
    }

    /***********************************************/
    /* Method Name - WriteToFile                   */
    /* Inputs      - filepath, parentName,         */
    /*               parentNumber, petName         */
    /* Returns     - VOID (No Data Returned)       */
    /***********************************************/
    public static void WriteToFile(string filepath, string parentName, string parentNumber, string petName) 
    {
        using (StreamWriter writer = new StreamWriter(filepath, true))
        {
        /* Write data out to the file */
        writer.WriteLine("Pet Parent to Call Back :" + parentName);
        writer.WriteLine("Pet Called About        :" + petName);
        writer.WriteLine("Call Back Number        :" + parentNumber);

        /* Display on screen message after file was written to */
        Console.WriteLine("The vet staff has been messaged to call you back. ");
        Console.WriteLine();
        }
    }

    /***********************************************/
    /* Method Name - ValidateTask                  */
    /* Inputs      - Task number keyed in by user  */
    /* Returns     - Validated Task Number         */
    /***********************************************/
    public static int ValidateTask(int task, int maxOption)
    {
        while (task < 0 || task > maxOption)
        {
            Console.WriteLine("Invalid Option - Please enter an option number between 1 " + maxOption);
            task = int.Parse(Console.ReadLine()?? "0");
        }


        return task;
    }

    /***********************************************/
    /* Method Name - LookUpParent                  */
    /* Inputs      - Console Input                 */
    /* Returns     - Person matching to inputs     */
    /***********************************************/
    private static Person? LookUpParent()
    {
        string personPhoneNum = "";
        while (personPhoneNum == "")
        {
            Console.WriteLine("Pet Parent Phone Number :");
            personPhoneNum = Console.ReadLine()?? "";
        }

        Person? lookUp = prs.LookUpPetParent(personPhoneNum);

        return lookUp; 
    }

    /***********************************************/
    /* Method Name - PromotForId                   */
    /* Input       - VetRepo Object, Console Input */
    /* Returns     - Pet Object                    */
    /***********************************************/
    public static Pet? PromotForId()
    {
        /* Loop asking for valid ID until one is entered by User*/
        int inputId = 0;
        Pet? locatedPet = new();

        while (inputId == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a Pet ID");
            string? userInput = Console.ReadLine();

            if (userInput != null && userInput != "")
            {           
                try
                {
                    inputId = int.Parse(userInput);
                    if (inputId < 0)
                    {
                        inputId = 0;
                    } 
                } 
                catch (Exception)
                {
                    inputId = 0;
                }

                if (inputId != 0)
                {
                    try
                    {
                        locatedPet = pet.GetPet(inputId);
                        if (locatedPet == null)
                        {
                        inputId = 0; 
                        }
                    }
                    catch (Exception)
                    {
                        inputId = 0;
                    }
                }
            }
        }
       
        return locatedPet; 
    }
}
