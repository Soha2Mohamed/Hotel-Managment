using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smsark.Models
{
    public class Bed
    {
        [key]
        public int BedId { get; set; }  
        [Required]
        public float BedPrice { get; set; }
        [Required]
        public bool IsReserved { get; set; }
        public ICollection<ReservationItem>? reservationItems { get; set; }
        [ForeignKey("RoomId")]
        public int RoomId { get; set; }
        public Room room { get; set; }


    }

}
