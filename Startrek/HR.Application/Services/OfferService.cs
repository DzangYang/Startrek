using HR.Application.Abstractions;
using HR.Application.DTO.Requests.Offers;
using HR.Domain.Entities;
using HR.Domain.Interfaces;
using HR.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace HR.Application.Services;

public class OfferService(IOfferRepository offerRepository, IUnitOfWork unitOfWork) : IOfferService
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
        offerRepository.Issuance(request.Id, request.DateOfIssue, request.ExpiryDate);
        unitOfWork.SaveChangeAsync();
    }

    public void Revoke(RevokeOfferRequest request)
    {
        offerRepository.Revoke(request.Id, request.Comment);
        unitOfWork.SaveChangeAsync();
    }

    public void Apply(ApplyOfferRequest request)
    {
        offerRepository.Apply(request.Id);
        unitOfWork.SaveChangeAsync();
    }
}