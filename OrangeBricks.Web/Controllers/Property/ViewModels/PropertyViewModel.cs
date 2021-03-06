using OrangeBricks.Web.Models;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class PropertyViewModel
    {
        public string StreetName { get; set; }
        public string Description { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string PropertyType { get; set; }
        public int Id { get; set; }
        public bool IsListedForSale { get; set; }
        public int SuggestedAskingPrice { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
