using System;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class AppointmentViewModel
    {
        public int PropertyId { get; set; }
        public DateTime ViewingDateTime { get; set; }
        public string BuyerUserId { get; set; }
        public bool RequiredViewing { get; set; }
    }
}