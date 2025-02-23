using System.ComponentModel.DataAnnotations;

namespace CAGolfClubDB.Models
{
    public class Player
    {

        [Key]
        public int Id { get; set; }
        public string? MembershipNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Handicap is required.")]
        [Range(1, 100, ErrorMessage = "Handicap must be between 1 and 100.")]
        public double Handcap { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}



