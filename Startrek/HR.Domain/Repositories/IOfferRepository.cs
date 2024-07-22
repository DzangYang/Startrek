using HR.Domain.Entities;

namespace HR.Domain.Repositories;

public interface IOfferRepository
{
    public void Add(Offer offer);
    public void Update(Guid id);
    public void Issuance(Guid id, DateTime dateOfIssue,DateTime expiryDate);
    public void Apply(Guid id);
    public void Revoke(Guid id, string comment);
}