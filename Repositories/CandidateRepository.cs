using CandidateApi.Data;
using CandidateApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateApi.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _db;

        public CandidateRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public Candidate? GetByEmail(string email)
        {
            return _db.Candidates.FirstOrDefault(c => c.Email == email);
        }

        public void Add(Candidate candidate)
        {
            _db.Candidates.Add(candidate);
        }

        public void Update(Candidate candidate)
        {
            _db.Candidates.Update(candidate);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
