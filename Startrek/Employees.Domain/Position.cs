namespace Employees.Domain;
public class Position
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    /// <summary>
    /// Заработная плата
    /// </summary>
    public int SalaryAmount { get; private set; }
    public IEnumerable<Employee> Employees { get; set; }
}
