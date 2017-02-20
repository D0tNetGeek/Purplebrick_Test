using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class BookAppointmentCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public BookAppointmentCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public bool Handle(BookAppointmentCommand command)
        {
            var property = _context.Properties.Find(command.PropertyId);

            //if (property.Appointments != null && property.Appointments.Count(o => o.BuyerUserId == command.BuyerUserId) > 0) { return false; }

            var appointment = new Appointment
            {
                PropertyId = command.PropertyId,
                ViewingDateTime = command.ViewingDateTime,
                BuyerUserId = command.BuyerUserId,
                IsViewing = true,
                UpdatedAt = DateTime.Now
            };

            if (property.Appointments == null)
            {
                property.Appointments = new List<Appointment>();
            }

            property.Appointments.Add(appointment);

            _context.SaveChanges();

            return true;
        }
    }
}
