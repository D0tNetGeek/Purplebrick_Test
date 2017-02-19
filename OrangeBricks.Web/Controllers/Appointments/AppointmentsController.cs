using System.Web.Mvc;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Appointments.Builders;
using OrangeBricks.Web.Controllers.Appointments.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Appointments
{
    [OrangeBricksAuthorize(Roles = "Seller")]
    public class AppointmentsController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public AppointmentsController(IOrangeBricksContext context)
        {
            _context = context;
        }

        public ActionResult OnProperty(int id)
        {
            var builder = new AppointmentsOnPropertyViewModelBuilder(_context);
            var viewModel = builder.Build(id);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Accept(AcceptAppointmentCommand command)
        {
            var handler = new AcceptAppointmentCommandHandler(_context);

            handler.Handle(command);

            return RedirectToAction("OnProperty", new { id = command.PropertyId });
        }

        [HttpPost]
        public ActionResult Reject(RejectAppointmentCommand command)
        {
            var handler = new RejectAppointmentCommandHandler(_context);

            handler.Handle(command);

            return RedirectToAction("OnProperty", new { id = command.PropertyId });
        }
    }
}