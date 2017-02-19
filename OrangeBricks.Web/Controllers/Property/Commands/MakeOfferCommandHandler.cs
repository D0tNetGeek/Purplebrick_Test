using System;
using System.Collections.Generic;
using OrangeBricks.Web.Models;
using System.Linq;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeOfferCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public MakeOfferCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public bool Handle(MakeOfferCommand command)
        {
            var property = _context.Properties.Find(command.PropertyId);

            if (property.Offers != null && property.Offers.Count(o => o.BuyerUserId == command.BuyerUserId) > 0) {  return false; }

            var offer = new Offer
            {
                Amount = command.Offer,
                Status = OfferStatus.Pending,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                BuyerUserId = command.BuyerUserId
            };

            if (property.Offers == null)
            {
                property.Offers = new List<Offer>();
            }

            property.Offers.Add(offer);
            
            _context.SaveChanges();

            return true;
        }
    }
}