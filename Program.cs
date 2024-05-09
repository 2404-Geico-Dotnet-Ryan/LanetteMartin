using System;

class Program
{
    /*
    This program will track pets seen by the staff of the Kitty City Vet Office.  

    Office Staff - will be able to create new Pet Records, Update Pet Records and Close Out Pet Records
    Pet Owners   - will be able to view their pets records 
    */
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

    public static int DetermineSystemUser()
    {
        int systemUser = 0;

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("- Welcome to the Kitty City Vet Office -");
        Console.WriteLine("-          Pet Records System          -");
        Console.WriteLine("-      Who is using system today?      -"); 
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Type '1' if you are Vet Staff");
        Console.WriteLine("Type '2' if you are a Pet Parent");
        Console.WriteLine();
    
        string? userSelection = Console.ReadLine();

        if (userSelection !=null) systemUser = int.Parse(userSelection);

        return systemUser;
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
            int taskToRun = 0; 

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("- Welcome to the Pet Records System -");
            Console.WriteLine("-        Vet Staff Options          -");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Type '1' To Set up a New Pet Record ");
            Console.WriteLine("Type '2' To Update a Pet Record     ");
            Console.WriteLine("Type '3' To View a Pet Record       ");
            Console.WriteLine("Type '4' To Close Out a Pet Record  ");
            Console.WriteLine("Type '5' Exit system                ");
            Console.WriteLine();
        
            string? staffSelection = Console.ReadLine();

            if (staffSelection !=null) taskToRun = int.Parse(staffSelection);

            switch (taskToRun)
            {
                case 1:
                {
                    NewPetRecord(vr);
                    break;
                }
                case 2:
                {
                    UpdatePetRecord(vr);
                    break;
                }
                case 3:
                {
                    ViewPetRecord(vr);
                    break;
                }
                case 4:
                {
                    CloseOutPetRecord(vr);
                    break;
                }

                case 5:
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
            int taskToRun = 0;

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("- Welcome to the Pet Records System -");
            Console.WriteLine("-        Pet Parent Options         -");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Type '1' To View a Pet Record        ");
            Console.WriteLine("Type '2' To Request Call Back        ");
            Console.WriteLine("Type '3' Exit system                 ");
            Console.WriteLine();
        
            string? parentSelection = Console.ReadLine();

            if (parentSelection !=null) taskToRun = int.Parse(parentSelection);

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


    /***************************/
    /* Methods ran by program */
    /**************************/
    private static void NewPetRecord(VetRepo vr)
    {
        /* Need to update to ti build a new Pet Parent Person for now will set it to known number */
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

        Person newPerson = new Person(0, 2, personFirstName, personLastName, personPhoneNum, personTitle, personUserName, personPassword, 2);
        newPerson = vr.AddPerson(newPerson);

        /* Need to update to add SeenBY based on who is logged into the system */
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

        /* Hard Coded until we know who is logged into the system then will update with their informaiton */ 
        string petSeenBy = "HeadVet Dr Charlie Ho";

        Pet newPet = new Pet(0, newPerson.PersonId, petName, petColor, petFurType, petGender, petWeight, petAge, inSide, petSeenBy, "0");

        newPet = vr.AddPet(newPet); 

        Console.WriteLine("Newly Added Pet Parent - " + newPerson);
        Console.WriteLine();
        Console.WriteLine("Newly Added Pet - " + newPet);
    }

    private static void UpdatePetRecord(VetRepo vr)
    {
        Console.WriteLine();
        Console.WriteLine("Please Enter Updated Pet Information");
        Console.WriteLine("       Based On Todays Visit        ");     
        Console.WriteLine("------------------------------------");

        // We are making the assumtion that user knowns IDs that will work 
        Pet? updatePet = PromotForId(vr); 

        // We are making the assumtion that user knowns IDs that will work
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

    private static void ViewPetRecord(VetRepo vr)
    {
        // We are making the assumtion that user knowns IDs that will work 
        Pet? retrievePet = PromotForId(vr); 

        /* After Pet retrieved display its information*/
        Console.WriteLine();
        Console.WriteLine("Retrieved Pet - " + retrievePet);
    }


    private static void CloseOutPetRecord(VetRepo vr)
    {
        Console.WriteLine();
        Console.WriteLine("  Please Enter Date Kitty   ");
        Console.WriteLine(" Crossed the Rainbow Bridge ");     
        Console.WriteLine("----------------------------");

        // We are making the assumtion that user knowns IDs that will work 
        Pet?closePet = PromotForId(vr); 

        Console.WriteLine("What day did Kitty cross the Rainbow Bridge:");
        closePet.RainbowBridgeDate = Console.ReadLine()?? "";      
        
        /* Update the Pet in the collection */
        closePet = vr.UpdatePet(closePet);

        /* After Pet updated display its new information */
        Console.WriteLine();
        Console.WriteLine("Pet Record has been closed out - " + closePet);
    }

    public static Pet PromotForId(VetRepo vr)
    {
        // We are making the assumtion that user knowns IDs that will work 
        Pet? retrievePet = null; 

        /* Loop asking for valid ID until one is entered by User*/
        while (retrievePet == null)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a Pet ID");
            int input = int.Parse(Console.ReadLine() ?? "0");
            retrievePet = vr.GetPet(input);
        }

        return retrievePet; 
    }

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
}
