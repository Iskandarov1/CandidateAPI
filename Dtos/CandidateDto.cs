namespace CandidateApi.Dtos
{
    public class CandidateDto
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }

        public string? Phone { get; set; }
        public string? Availability { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GitHubUrl { get; set; }
    }
}
