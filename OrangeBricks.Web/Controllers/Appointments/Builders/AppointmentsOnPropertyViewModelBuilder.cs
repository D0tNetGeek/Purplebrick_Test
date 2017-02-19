using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.Appointments.ViewModels;

namespace OrangeBricks.Web.Controllers.Appointments.Builders
{
    public class AppointmentsOnPropertyViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public AppointmentsOnPropertyViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public AppointmentsOnPropertyViewModel Build(int id)
        {
            var property = _context.Properties
                .Where(p => p.Id == id)
                .Include(x => x.Appointments)
                .SingleOrDefault();

            var appointments = property.Appointments ?? new List<Appointment>();

            return new AppointmentsOnPropertyViewModel
            {
                HasAppointments = appointments.Any(),
                Appointments = appointments.Select(x => new AppointmentViewModel
                {
                    Id = x.Id,
                    ViewingDateTime = x.ViewingDateTime,
                    IsViewing = x.IsViewing,
                    Status = x.Status
                }),
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                NumberOfBedrooms = property.NumberOfBedrooms
            };
        }
    }
}