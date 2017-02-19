using System;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public DateTime ViewingDateTime { get; set; }
        public string BuyerUserId { get; set; }
        public bool IsViewing { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}