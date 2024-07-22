using HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.DTO.Requests.Interviews;
public sealed record CreateInterviewRequest(
        Guid candidateId, bool conducted,
        DateTime dateOfEvent, string? comment, string? feedback, Guid authorId, Guid vacancyId);
