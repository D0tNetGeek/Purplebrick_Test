using System;
using OrangeBricks.Web.Controllers.Offers.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Appointments.Commands
{
    public class AcceptAppointmentCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public AcceptAppointmentCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(AcceptAppointmentCommand command)
        {
            var appointment = _context.Appointments.Find(command.AppointmentId);

            appointment.UpdatedAt = DateTime.Now;
            appointment.Status = AppointmentStatus.Accepted;

            _context.SaveChanges();
        }
    }
}