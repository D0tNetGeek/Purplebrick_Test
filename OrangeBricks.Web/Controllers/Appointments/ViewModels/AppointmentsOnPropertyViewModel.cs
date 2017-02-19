using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Appointments.ViewModels
{
    public class AppointmentsOnPropertyViewModel
    {
        public string PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string StreetName { get; set; }
        public bool HasAppointments { get; set; }
        public IEnumerable<AppointmentViewModel> Appointments { get; set; }
        public int PropertyId { get; set; }
    }
    

    public class AppointmentViewModel
    {
        public int Id;
        public DateTime ViewingDateTime { get; set; }
        public bool IsViewing { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}