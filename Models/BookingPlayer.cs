using System.ComponentModel.DataAnnotations;

namespace CAGolfClubDB.Models;
public class BookingPlayer
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "BookingId is required.")]
    public int BookingId { get; set; }
    [Required(ErrorMessage = "PlayerId is required.")]
    public int PlayerId { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
    [Required]

    // FKs
    public Booking Booking { get; set; }
    public Player Player { get; set; }

}
