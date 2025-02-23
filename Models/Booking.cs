namespace CAGolfClubDB.Models;

using System.ComponentModel.DataAnnotations;
using CAGolfClubDB.Validators;


public class Booking
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "PlayerId is required.")]
    public int PlayerId { get; set; }
    [Required(ErrorMessage = "Date is required.")]
    [FutureDate]
    public DateTime Date { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // FKs
    public required Player Player { get; set; }

}



