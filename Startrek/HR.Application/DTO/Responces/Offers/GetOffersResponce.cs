using HR.Domain.Entities;

namespace HR.Application.DTO.Requests.Offers;

public sealed record GetOffersResponce(IEnumerable<Offer> Offers);