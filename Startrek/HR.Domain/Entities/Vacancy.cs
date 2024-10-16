﻿namespace HR.Domain.Entities;
/// <summary>
/// Вакансия
/// </summary>
public class Vacancy
{
    /// <summary>
    /// Айди
    /// </summary>
    public Guid Id { get; set; }
    public Guid PositionId { get; set; }
    public int Experience { get; set; }
    public DateTime CreatedDate { get; set; }
    public IEnumerable<Candidate>? Candidates { get; set; }

}
