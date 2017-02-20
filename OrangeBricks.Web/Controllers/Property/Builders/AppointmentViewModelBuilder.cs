using System;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class AppointmentViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public AppointmentViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public AppointmentViewModel Build(int id, string buyerUserId)
        {
            if (buyerUserId == null) throw new ArgumentNullException(nameof(buyerUserId));

            var property = _context.Properties
                .Where(p => p.Id == id)
                .Include(x => x.Appointments)
                .SingleOrDefault();

            return new AppointmentViewModel
            {
                PropertyId = property.Id,
                BuyerUserId = buyerUserId,
                RequiredViewing=true
            };
        }
    }
}
