namespace HR.Domain.Entities;
public class Offer
{
    /// <summary>
    /// Айди
    /// </summary>                              
    public Guid Id { get; set; }

    /// <summary>
    /// Состояние
    /// </summary>
    public bool IsActive { get; set; } = false;
    public string? Comment { get; set; }
    /// <summary>
    /// Айди интервью
    /// </summary>
    public Guid InterviewId { get; set; }
    /// <summary>
    /// Дата выдачи
    /// </summary>
    public DateTime? DateOfIssue { get; set; }
    /// <summary>
    /// Срок действия
    /// </summary>
    public DateTime? ExpiryDate { get; set; }
    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }


}
