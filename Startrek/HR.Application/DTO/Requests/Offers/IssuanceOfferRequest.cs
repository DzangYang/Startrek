namespace HR.Application.DTO.Requests.Offers;

public sealed record IssuanceOfferRequest(Guid Id, DateTime DateOfIssue, DateTime ExpiryDate);
