using System;

class Program
{
    /*
    This program will track pets seen by the staff of the Kitty City Vet Office.  

    Office Staff - will be able to create new Pet Records, Update Pet Records and Close Out Pet Records
    Pet Owners   - will be able to view their pet's records and reqeust a call back from the Vet staff
    */
    static VetServices vs = new();
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

        VetRepo vr = new VetRepo(); 

        while (keepWorking)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("- Welcome to the Pet Records System -");
            Console.WriteLine("-        Vet Staff Options          -");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Type '1' To Set up a New Pet Family ");
            Console.WriteLine("Type '2' To Set up a New Pet Record ");
            Console.WriteLine("Type '3' To Update a Pet Record     ");
            Console.WriteLine("Type '4' To View a Pet Record       ");
            Console.WriteLine("Type '5' To Close Out a Pet Record  ");
            Console.WriteLine("Type '6' To View List of All People in System ");
            Console.WriteLine("Type '7' To View List of All Pets in System ");
            Console.WriteLine("Type '8' Exit system                ");
            Console.WriteLine();
        
            int staffSelection =  int.Parse(Console.ReadLine() ?? "0");

            int taskToRun = ValidateTask(staffSelection, 8);

            switch (taskToRun)
            {
                case 1:
                {
                    NewPetFamilyRecord(vr);
                    break;
                }
                case 2:
                {
                    //NewPetRecord(vr);
                    break;
                }
                case 3:
                {
                    UpdatePetRecord(vr);
                    break;
                }
                case 4:
                {
                    ViewPetRecord(vr);
                    break;
                }
                case 5:
                {
                    CloseOutPetRecord(vr);
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
        
        VetRepo vr = new VetRepo(); 

        while (keepParenting)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("- Welcome to the Pet Records System -");
            Console.WriteLine("-        Pet Parent Options         -");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Type '1' To View a Pet Record        ");
            Console.WriteLine("Type '2' To Request Call Back        ");
            Console.WriteLine("Type '3' Exit system                 ");
            Console.WriteLine();
        
            int parentSelection =  int.Parse(Console.ReadLine() ?? "0");

            int taskToRun = ValidateTask(parentSelection, 3);
            switch (taskToRun)
            {
                case 1:
                {
                    ViewPetRecord(vr);
                    break;
                }
                case 2:
                {
                    RequstCallBack();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("Thank you for trusting use with your Kitty!");
                    Console.WriteLine();
                    keepParenting = false; 
                    break;
                }
            }
        }
    }

    /***********************************************/
    /* Method Name - NewPetFamilyRecord            */
    /* Inputs      - VetRepo Object, Console Input */
    /* Returns     - VOID (No Data Returned)       */
    /***********************************************/
    private static void NewPetFamilyRecord(VetRepo vr)
    {
        Console.WriteLine(); 
        Console.WriteLine("Please Enter Pet Parent Information");
        Console.WriteLine("-----------------------------------");

        Console.WriteLine("Pet Parent First Name :");
        string personFirstName = Console.ReadLine()?? "";

        Console.WriteLine("Pet Parent Last Name :");
        string personLastName = Console.ReadLine()?? "";

        Console.WriteLine("Pet Parent Phone Number :");
        string personPhoneNum = Console.ReadLine()?? "";

        /* Hard Coded Values for the time being*/
        string personTitle = "Pet Parent";
        string personUserName = "parent3";
        string personPassword = "123456";

        /* Creates a new Pet Parent (Person) */ 
        /* Will use the new Per Parents ID when builidng thier Pet's Record */ 
        Person newPerson = new Person(0, 2, personFirstName, personLastName, personPhoneNum, personTitle, personUserName, personPassword, 2);
        newPerson = vr.AddPerson(newPerson);

        Console.WriteLine();
        Console.WriteLine("Please Enter Pet Information");
        Console.WriteLine("----------------------------");

        Console.WriteLine("Pet Name :");
        string petName = Console.ReadLine()?? "";

        Console.WriteLine("Fur Color :");
        string petColor = Console.ReadLine()?? "";

        Console.WriteLine("Fur Type :");
        string petFurType = Console.ReadLine()?? "";

        Console.WriteLine("Gender :");
        string petGender = Console.ReadLine()?? "";

        Console.WriteLine("Age :");
        int petAge = int.Parse(Console.ReadLine() ?? ""); 
       
        Console.WriteLine("Weight :");
        int petWeight = int.Parse(Console.ReadLine() ?? ""); 

        Console.WriteLine("Inside Pet - True or False");
        string? petInside = Console.ReadLine();

        bool inSide =  true; 

        if (petInside !=null) 
        {
            if (petInside.ToUpper() == "TRUE")
            {
                inSide = true; 
            }
            else inSide  = false;
        }

        /* Need to update to set SeenBy based on who is logged into the system */
        /* Hard Coded until we know who is logged into the system then will update with their information */ 
        string petSeenBy = "HeadVet Dr Charlie Ho";

        /* Creates a new Pet */ 
        Pet newPet = new Pet(0, newPerson.PersonId, petName, petColor, petFurType, petGender, petWeight, petAge, inSide, petSeenBy, "0");

        /* Adds the new Pet to the Dictionary */ 
        newPet = vr.AddPet(newPet); 

        Console.WriteLine("Newly Added Pet Parent - " + newPerson);
        Console.WriteLine();
        Console.WriteLine("Newly Added Pet - " + newPet);
    }

    /***********************************************/
    /* Method Name - UpdatePetRecord               */
    /* Inputs      - VetRepo Object, Console Input */
    /* Returns     - VOID (No Data Returned)       */
    /***********************************************/
    private static void UpdatePetRecord(VetRepo vr)
    {
        Console.WriteLine();
        Console.WriteLine("Please Enter Updated Pet Information");
        Console.WriteLine("       Based On Todays Visit        ");     
        Console.WriteLine("------------------------------------");

        // We are making the assumption that user knowns IDs that will work 
        Pet? updatePet = PromotForId(); 

        Console.WriteLine("Current Pet Age is " + updatePet.Age);
        Console.WriteLine("New Pet Age this appointment");
        updatePet.Age = int.Parse(Console.ReadLine() ?? ""); 

        Console.WriteLine("Current Pet Weight is " + updatePet.Weight);
        Console.WriteLine("New Pet Weight this appointment");
        updatePet.Weight = int.Parse(Console.ReadLine() ?? ""); 

        Console.WriteLine("Inside Pet - True or False");
        string? petInside = Console.ReadLine();

        if (petInside !=null) 
        {
            if (petInside.ToUpper() == "TRUE")
            {
                updatePet.InSidePet = true; 
            }
            else updatePet.InSidePet  = false;
        }

        updatePet.AppointmentDate = DateTime.Now; 

        /* Update the Pet in the collection */
        updatePet = vr.UpdatePet(updatePet);

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
        List<Person> persons = vs.GetAllPerson();

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
        List<Pet> pets = vs.GetAllPet();

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
    private static void ViewPetRecord(VetRepo vr)
    {
        // We are making the assumption that user knowns IDs that will work 
        Pet? retrievePet = PromotForId(); 

        /* After Pet retrieved display its information*/
        Console.WriteLine();
        Console.WriteLine("Retrieved Pet - " + retrievePet);
    }


    /***********************************************/
    /* Method Name - CloseOutPetRecord             */
    /* Input       - VetRepo Object, Console Input */
    /* Returns     - VOID (No Data Returned)       */
    /***********************************************/
    private static void CloseOutPetRecord(VetRepo vr)
    {
        Console.WriteLine();
        Console.WriteLine("  Please Enter Date Kitty   ");
        Console.WriteLine(" Crossed the Rainbow Bridge ");     
        Console.WriteLine("----------------------------");

        // We are making the assumtion that user knowns IDs that will work 
        Pet?closePet = PromotForId(); 

        Console.WriteLine("What day did Kitty cross the Rainbow Bridge:");
        closePet.RainbowBridgeDate = Console.ReadLine()?? "";      
        
        /* Update the Pet in the collection */
        closePet = vr.UpdatePet(closePet);

        /* After Pet updated display its new information */
        Console.WriteLine();
        Console.WriteLine("Pet Record has been closed out - " + closePet);
    }

    /***********************************************/
    /* Method Name - PromotForId                   */
    /* Input       - VetRepo Object, Console Input */
    /* Returns     - Pet Object                    */
    /***********************************************/
    public static Pet PromotForId()
    {
        // We are making the assumtion that user knowns IDs that will work 
        Pet? retrievePet = null; 

        /* Loop asking for valid ID until one is entered by User*/
        while (retrievePet == null)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a Pet ID");
            int input = int.Parse(Console.ReadLine() ?? "0");
            retrievePet = vs.GetPet(input);
        }

        return retrievePet; 
    }

    /***********************************************/
    /* Method Name - RequstCallBack                */
    /* Input       - Console Input                 */
    /* Returns     - VOID (No Data Returned)       */
    /***********************************************/
    public static void RequstCallBack()
    {
        Console.WriteLine("Call Back Name : ");
        string? parentName = Console.ReadLine()?? "0";

        Console.WriteLine("Call Back Number : ");
        string? parentNumber = Console.ReadLine()?? "0";

        Console.WriteLine("Name of Pet Calling about : ");
        string? petName = Console.ReadLine()?? "0";

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

}
