using HR.Application.DTO.Requests.Offers;
using HR.Domain.Entities;

namespace HR.Application.Abstractions;

public interface IOfferService
{
    CreateOfferResponce Add(CreateOfferRequest request);
    void Revoke(RevokeOfferRequest request);
    void Apply(ApplyOfferRequest request);
    void Issuance(IssuanceOfferRequest request);



}