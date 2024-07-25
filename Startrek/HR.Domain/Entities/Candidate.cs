using HR.Domain.Enums;

namespace HR.Domain.Entities;
/// <summary>
/// Кандидат
/// </summary>
public class Candidate
{
    /// <summary>
    /// Айди
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// Отчество
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;
    /// <summary>
    /// Пол
    /// </summary>
    public Gender Gender { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDay { get; set; }
    /// <summary>
    /// Опыт работы
    /// </summary>
    public int Experience { get; set; }
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedDate { get; set; }
    public ICollection<Vacancy> Vacancies { get; set; }
}

