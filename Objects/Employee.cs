class Employee : Person
{
    public int EmployeeIdNum { get; set; }
    public string? JobTitle { get; set; }

    public Employee()
    {

    }

    public Employee(int employeeIdNum, string jobTitle)
    {
        EmployeeIdNum = employeeIdNum;
        JobTitle = jobTitle;
    }

}

