using System.ComponentModel.DataAnnotations;

namespace CandidateApi.Models
{
    public class Candidate
    {
        public int Id { get; set; } 

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Comment { get; set; }

        [Phone]
        public string? Phone { get; set; }

        public string? Availability { get; set; }

        [Url]
        public string? LinkedInUrl { get; set; }

        [Url]
        public string? GitHubUrl { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
