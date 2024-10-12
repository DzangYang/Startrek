using HR.Application.DTO.Requests.Offers;

namespace HR.Application.Abstractions;

public interface IOfferService
{
    CreateOfferResponce Add(CreateOfferRequest request);
    void Revoke(RevokeOfferRequest request);
    GetByIdOfferResponce GetById(Guid id);
   GetOffersResponce GetAll();
    void Apply(ApplyOfferRequest request);
    void Issuance(IssuanceOfferRequest request);



}