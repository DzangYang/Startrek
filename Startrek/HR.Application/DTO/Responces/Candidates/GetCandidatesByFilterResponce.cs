using HR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.DTO.Responces.Candidates;
public sealed record GetCandidatesByFilterResponce(List<Candidate> candidates);

