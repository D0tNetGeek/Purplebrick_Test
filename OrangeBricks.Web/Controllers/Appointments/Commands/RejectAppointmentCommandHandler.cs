using System;
using OrangeBricks.Web.Controllers.Offers.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Appointments.Commands
{
    public class RejectAppointmentCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public RejectAppointmentCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(RejectAppointmentCommand command)
        {
            var appointment = _context.Appointments.Find(command.AppointmentId);

            appointment.UpdatedAt = DateTime.Now;
            appointment.Status = AppointmentStatus.Rejected;

            _context.SaveChanges();
        }
    }
}