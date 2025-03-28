using CandidateApi.Dtos;
using CandidateApi.Models;
using CandidateApi.Repositories;

namespace CandidateApi.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;

        public CandidateService(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public Candidate UpsertCandidate(CandidateDto candidateData)
        {
            Candidate? existing = _repository.GetByEmail(candidateData.Email);
            if (existing == null)
            {
                var newCandidate = new Candidate
                {
                    FirstName = candidateData.FirstName,
                    LastName = candidateData.LastName,
                    Email = candidateData.Email,
                    Comment = candidateData.Comment,
                    Phone = candidateData.Phone,
                    Availability = candidateData.Availability,
                    LinkedInUrl = candidateData.LinkedInUrl,
                    GitHubUrl = candidateData.GitHubUrl,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                _repository.Add(newCandidate);
                _repository.SaveChanges();
                return newCandidate;
            }
            else
            {
                existing.FirstName = candidateData.FirstName;
                existing.LastName = candidateData.LastName;
                existing.Comment = candidateData.Comment;
                if (candidateData.Phone != null) existing.Phone = candidateData.Phone;
                if (candidateData.Availability != null) existing.Availability = candidateData.Availability;
                if (candidateData.LinkedInUrl != null) existing.LinkedInUrl = candidateData.LinkedInUrl;
                if (candidateData.GitHubUrl != null) existing.GitHubUrl = candidateData.GitHubUrl;
                existing.UpdatedAt = DateTime.UtcNow;

                _repository.Update(existing);
                _repository.SaveChanges();
                return existing;
            }
        }
    }
}
