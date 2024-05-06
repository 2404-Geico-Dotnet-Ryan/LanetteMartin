class Parent : Person
{
    public int ParentIdNum { get; set; }
    public string? ParentPhoneNum { get; set; }

    public Parent()
    {

    }

    public Parent(int parentIdNum, string parentPhoneNum)
    {
    ParentIdNum = parentIdNum; 
    ParentPhoneNum = parentPhoneNum; 
    }
}