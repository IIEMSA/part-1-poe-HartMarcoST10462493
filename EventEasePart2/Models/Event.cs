namespace EventEasePart2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Event")]
    public partial class Event
    {
        public Event()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(100)]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime? EventDate { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [ForeignKey("Venue")]
        [Display(Name = "Venue")]
        public int? VenueId { get; set; }

        public virtual Venue Venue { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
