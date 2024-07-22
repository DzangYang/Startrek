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
      public void Revoke(Guid id, string comment)
      {
            var offer = contextEf.Offers.FirstOrDefault(o => o.Id == id);
            offer.IsActive = false;
            offer.Comment = comment;
      }
      
      /// <summary>
      /// Принять
      /// </summary>
      /// <param name="id"></param>
      public void Apply(Guid id)
      {
            var offer = contextEf.Offers.FirstOrDefault(o => o.Id == id);
            offer.IsActive = true;
      }

      /// <summary>
      /// Выдача   кандидату
      /// </summary>
      /// <param name="id"></param>
      /// <exception cref="NotImplementedException"></exception>
      public void Issuance(Guid id, DateTime dateOfIssue, DateTime expiryDate)
      {
            var offer = contextEf.Offers.FirstOrDefault(o => o.Id == id);
            offer.DateOfIssue = dateOfIssue;
            offer.ExpiryDate = expiryDate;
      }

      /// <summary>
      /// Обновить 
      /// </summary>
      /// <param name="id"></param>
      /// <exception cref="NotImplementedException"></exception>
      public void Update(Guid id)
      {
            throw new NotImplementedException();
      }
}