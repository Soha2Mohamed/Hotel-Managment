using System.ComponentModel.DataAnnotations.Schema;

namespace Smsark.Models
{
    public class Room
    {
        [key]
        public int RoomId { get; set; }
        [ForeignKey("ApartmentId")]
        public int ApartmentId { get; set; }
        public Apartment? apartment { get; set; }
        public ICollection <Bed>? Beds { get; set; }

    }
}
