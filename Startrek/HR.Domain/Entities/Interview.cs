namespace HR.Domain.Entities;
public class Interview
{
    public Guid Id { get; set; }

    /// <summary>
    /// Проведено
    /// </summary>
    public bool Conducted { get; set; } = false;

    /// <summary>
    /// Комментарий
    /// </summary>
    public string? Comment { get; set; } = default!;

    /// <summary>
    /// Отзыв
    /// </summary>
    public string? Feedback { get; set; } = default!;
    /// <summary>
    /// Дата проведения
    /// </summary>
    public DateTime DateOfEvent { get; set; }
    /// <summary>
    /// Айди кандидата
    /// </summary>
    public Guid CandidateId { get; set; }
    /// <summary>
    /// Айди сотрудника
    /// </summary>
    public Guid AuthorId { get; set; }
    /// <summary>
    /// Айди вакансии
    /// </summary>
    public Guid VacancyId { get; set; }

}
