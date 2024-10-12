using HR.Domain.Entities;

namespace HR.Domain.Repositories;

public interface IOfferRepository
{
    public void Add(Offer offer);
    public void Issuance(Offer offer);
    public IEnumerable<Offer> GetAll();
    public Offer GetById(Guid id);
    public void Apply(Offer offer);
    public void Revoke(Offer offer);
}