using HR.Domain.Entities;
using HR.Domain.Repositories;
using HR.Infrastructure.DataAccess;
using HR.Infrastructure.Migrations;

namespace HR.Infrastructure.Repositories;

public class OfferRepository(DbContextEF contextEf) : IOfferRepository
{
   
      /// <summary>
      /// Создание 
      /// </summary>
      /// <param name="offer"></param>
      public void Add(Offer offer)
      {
            contextEf.Offers.Add(offer);
      }

      /// <summary>
      /// Отозвать
      /// </summary>
      /// <param name="id"></param>
     
      public void Revoke(Offer offer)
      {
            contextEf.Offers.Update(offer);
            
      }

      public IEnumerable<Offer> GetAll()
      {
            return contextEf.Offers.ToList();
      }

      public Offer GetById(Guid id)
      {
            var existOffer = contextEf.Offers.FirstOrDefault(o => o.Id == id);

            return existOffer;
      }

      
      /// <summary>
      /// Принять
      /// </summary>
      /// <param name="id"></param>
      public void Apply(Offer offer)
      {
            contextEf.Offers.Update(offer);
      }

      /// <summary>
      /// Выдача   кандидату
      /// </summary>
      /// <param name="id"></param>
      /// <exception cref="NotImplementedException"></exception>
      public void Issuance(Offer offer)
      {
            contextEf.Offers.Update(offer);
      }

   
}