namespace CAGolfClubDB.Models;

using System.ComponentModel.DataAnnotations;
using CAGolfClubDB.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Booking
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "PlayerId is required.")]
    // Foreign key property
    public int PlayerId { get; set; }
    [Required(ErrorMessage = "Date is required.")]
    [FutureDate]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Slot is required.")]
    public string Slot { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation Property
    [ValidateNever]
    public Player Player { get; set; } = null!;

}



