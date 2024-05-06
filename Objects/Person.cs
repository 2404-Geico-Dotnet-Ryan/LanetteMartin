class Person
{
    public int PersonType { get; set; }  /* 1 - Employee  2 - Pet Parent  */ 
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? UserPassword { get; set; }
    public int AccessLevel { get; set; }  /* 1 - Update  2 - ReadOnly */

    public Person()
    {

    }

    public Person(int personType, string firstName, string lastName, string userName, string userPassword)
    {
    PersonType = personType;
    FirstName = firstName; 
    LastName = lastName;  
    UserName = userName;
    UserPassword = userPassword; 
    }
}