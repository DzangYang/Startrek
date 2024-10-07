using HR.Application.Abstractions;
using HR.Application.DTO.Requests.Offers;
using HR.Domain.Entities;
using HR.Domain.Interfaces;
using HR.Domain.Repositories;

namespace HR.Application.Services;

public class OfferService(IUnitOfWork unitOfWork, IOfferRepository offerRepository) : IOfferService
{
    public CreateOfferResponce Add(CreateOfferRequest request)
    {
        var offer = new Offer()
        {
            Id = new Guid(),
            InterviewId = request.InterviewId,
            Description = request.Description,
            
        };
        offerRepository.Add(offer);
        unitOfWork.SaveChangeAsync();
        return new CreateOfferResponce(offer.Id);
    }
    public void Issuance(IssuanceOfferRequest request)
    {
        var existOffer = offerRepository.GetById(request.Id);

        existOffer.DateOfIssue = request.DateOfIssue;
        existOffer.ExpiryDate = request.ExpiryDate;
        
        offerRepository.Issuance(existOffer);
        unitOfWork.SaveChangeAsync();
    }


    public GetOffersResponce GetAll()
    {
        var offers = offerRepository.GetAll();
        return new GetOffersResponce(offers);
    }

    public void Revoke(RevokeOfferRequest request)
    {
        var existOffer = offerRepository.GetById(request.Id);
        offerRepository.Revoke(existOffer);
        if (true)
        {
            Console.WriteLine();
        }

        if (true)
        {
            Console.WriteLine();
        }

        existOffer.IsActive = false;
        existOffer.Comment = request.Comment;
        unitOfWork.SaveChangeAsync();
    }

    public GetByIdOfferResponce GetById(Guid id)
    {
        var offer = offerRepository.GetById(id);
        return new GetByIdOfferResponce(offer);
    }

    public void Apply(ApplyOfferRequest request)
    {
        var existOffer = offerRepository.GetById(request.Id);

        existOffer.IsActive = true;
        
        offerRepository.Apply(existOffer);
        unitOfWork.SaveChangeAsync();
    }
}