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
        int taskToRun = 0; 

        Console.WriteLine("------------------------------------");
        Console.WriteLine("- Wecome to the Pet Records System -");
        Console.WriteLine("-        Vet Staff Options         -");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Type '1' To Set up a New Pet Record ");
        Console.WriteLine("Type '2' To Update a Pet Record     ");
        Console.WriteLine("Type '3' To View a Pet Record       ");
        Console.WriteLine("Type '4' To Close Out a Pet Record  ");
        Console.WriteLine();
    
        string? staffSelection = Console.ReadLine();

        if (staffSelection !=null) taskToRun = int.Parse(staffSelection);

        switch (taskToRun)
        {
            case 1:
            {
                NewPetRecord();
                break;
            }
            case 2:
            {
                //UpdatePetRecord();
                break;
            }
            case 3:
            {
                //ViewPetRecord();
                break;
            }
            case 4:
            {
                //CloseOutPetRecord();
                break;
            }
        }
    }

    private static void NewPetRecord()
    {
        Pet pet1 = new Pet();
        Console.WriteLine("Please Enter Pet Information");
        Console.WriteLine("----------------------------");

        Console.WriteLine("Pet Name :");
        pet1.Name = Console.ReadLine();

        Console.WriteLine("Fur Color :");
        pet1.Color = Console.ReadLine();

        Console.WriteLine("Fur Type :");
        pet1.FurType = Console.ReadLine();

        Console.WriteLine("Gender :");
        pet1.Gender = Console.ReadLine();

        Console.WriteLine("Age :");
        string? petAge = Console.ReadLine();
        if (petAge !=null) pet1.Age = int.Parse(petAge);

        Console.WriteLine("Weight :");
        string? petWeight = Console.ReadLine();
        if (petWeight !=null) pet1.Weight = int.Parse(petWeight);

        Console.WriteLine("Inside Pet - True or False");
        string? petInside = Console.ReadLine();

        if (petInside !=null) 
        {
            if (petInside.ToUpper() == "TRUE")
            {
                pet1.InSidePet = true; 
            }
            else pet1.InSidePet  = false;
        }

        pet1.AppointmentDate = DateTime.Now; 

        Console.WriteLine(pet1.ToString());
    }

    /***********************************************************/
    /* The following section of code runs Pet Parent Functions */ 
    /***********************************************************/
    public static void PetOwnerOptions()
    {
        int taskToRun = 0; 

        Console.WriteLine("------------------------------------");
        Console.WriteLine("- Wecome to the Pet Records System -");
        Console.WriteLine("-        Pet Parent Options        -");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Type '1' To View a Pet Record       ");
        Console.WriteLine("Type '2' To Request Call Back       ");
    
        string? parentSelection = Console.ReadLine();

        if (parentSelection !=null) taskToRun = int.Parse(parentSelection);

        switch (taskToRun)
        {
            case 1:
            {
                //ViewPetRecord();
                break;
            }
            case 2:
            {
                RequstCallBack();
                break;
            }
        }
    }

    public static void RequstCallBack()
    {
        Console.WriteLine("Call Back Name : ");
        string? parentName = Console.ReadLine();

        Console.WriteLine("Call Back Number : ");
        string? parentNumber = Console.ReadLine();

        Console.WriteLine("Name of Pet Calling about : ");
        string? petName = Console.ReadLine();

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
        }
    }
}
