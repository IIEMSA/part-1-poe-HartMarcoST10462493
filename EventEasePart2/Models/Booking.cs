namespace EventEasePart2.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }

        [Required]
        [ForeignKey("Venue")]
        public int VenueId { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Booking Date")]
        public DateTime? BookingDate { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Seats Reserved")]
        public int SeatsReserved { get; set; }

        public virtual Event Event { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
