using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smsark.Models
{
    public class Apartment
    {
        [Key]
        public int ApartmentId { get; set; }
        [Required]
        public string Region { get; set; }
        [Required (ErrorMessage = "Department description is required")]
        public string Description { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Rooms number is out of range")]
        public int NoOfRooms { get; set; }
        [Required]
        public string MainPhoto { get; set; }
        [Required]
        public string SecPhoto { get; set; }
        [Required]
        public string ThirdPhoto { get; set; }
        [Required]
        public string FourthPhoto { get; set; }
        [Required]
 
        public bool WiFi { get; set; }
        [Required]
        public int NoOfBeds { get; set; }
        [Required]
        public int NoOfBathrooms { get; set; }
        [Required]
        public string Location { get; set; }
        public ICollection<Room>? rooms { get; set; }
        [ForeignKey("OwnerId")]
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
        

    }
}
