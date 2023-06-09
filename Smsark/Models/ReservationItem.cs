using System.ComponentModel.DataAnnotations.Schema;

namespace Smsark.Models
{
    public class ReservationItem
    {
        [key]
        public int ReservationItemID { get; set; }
        [ForeignKey("ReservationId")]
        public int ReservationId { get; set; }
        public Reservation? reservation { get; set; }
        [ForeignKey("BedId")]
        public int BedId { get; set; }
        public Bed? bed { get; set; }
    }
}
