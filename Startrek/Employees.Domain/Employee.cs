namespace Employees.Domain;
public class Employee
{
    public Guid Id { get;  set; }
    public string LastName { get;  set; } = string.Empty;
    public string FirstName { get;  set; } = string.Empty;
    public string MiddleName { get;  set; } = string.Empty;
    public int Experience { get;  set; }
    public Gender Gender { get;  set; }
    public DateTime BirthDay { get;  set; }
    public DateTime DateOfEmployment { get;  set; }
    public Guid OfferId { get;  set; }
    public IEnumerable<Position> Positions { get; set; }
}


public enum Gender
{
    Man,
    Woman
}

