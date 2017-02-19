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

        public void Handle(BookAppointmentCommand command)
        {
            var appointment = new Appointment
            {
                PropertyId = command.PropertyId,
                ViewingDateTime = command.ViewingDateTime,
                BuyerUserId = command.BuyerUserId,
                IsViewing = true
            };

            _context.Appointments.Add(appointment);

            _context.SaveChanges();
        }
    }
}