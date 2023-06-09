using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smsark.Models
{
    public class ReservationData
    {
        public string CustomerEmail { get; set; }
        public List<int> BedsID { get; set; }
        public DateTime Checkin { get; set; } = DateTime.Now.Date; 
        public DateTime Checkout { get; set; } = DateTime.Now.Date.AddMonths(1); 
    }
    public class Reservation
    {
        [key]
        public int ReservationId { get; set; }
        public DateTime Checkin { get; set; } = DateTime.Now.Date;
        public DateTime Checkout { get; set; } = DateTime.Now.Date.AddMonths(1);

        public Customer? Customer { get; set; }
        public string? CustomerEmail { get; set; }
        public ICollection<ReservationItem>? reservationItems { get; set; }
        
    }
}
