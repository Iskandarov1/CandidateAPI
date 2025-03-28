using CandidateApi.Dtos;
using CandidateApi.Models;

namespace CandidateApi.Services
{
    public interface ICandidateService
    {
        Candidate UpsertCandidate(CandidateDto candidateData);
    }
}
