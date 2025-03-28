using CandidateApi.Models;

namespace CandidateApi.Repositories
{
    public interface ICandidateRepository
    {
        Candidate? GetByEmail(string email);
        void Add(Candidate candidate);
        void Update(Candidate candidate);
        void SaveChanges();
    }
}
