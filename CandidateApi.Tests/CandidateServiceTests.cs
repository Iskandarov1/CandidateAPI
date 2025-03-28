using CandidateApi.Dtos;
using CandidateApi.Models;
using CandidateApi.Repositories;
using CandidateApi.Services;
using Moq;
using Xunit;

namespace CandidateApi.Tests
{
    public class CandidateServiceTests
    {
        private readonly Mock<ICandidateRepository> _repoMock;
        private readonly CandidateService _service;

        public CandidateServiceTests()
        {
            _repoMock = new Mock<ICandidateRepository>();
            _service = new CandidateService(_repoMock.Object);
        }

        [Fact]
        public void UpsertCandidate_CreatesNewCandidate_WhenEmailNotFound()
        {
           
            var candidateDto = new CandidateDto
            {
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice@test.com",
                Comment = "New candidate"
            };

            _repoMock.Setup(r => r.GetByEmail("alice@test.com")).Returns((Candidate)null);

           
            Candidate result = _service.UpsertCandidate(candidateDto);

           
            _repoMock.Verify(r => r.Add(It.Is<Candidate>(c => c.Email == "alice@test.com")), Times.Once);
            _repoMock.Verify(r => r.SaveChanges(), Times.Once);
            Assert.Equal("Alice", result.FirstName);
        }

        [Fact]
        public void UpsertCandidate_UpdatesExistingCandidate_WhenEmailFound()
        {
           
            var existingCandidate = new Candidate
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                Email = "bob@test.com",
                Comment = "Old comment",
                Phone = "123-4567",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1)
            };

            var candidateDto = new CandidateDto
            {
                FirstName = "Bob",
                LastName = "Jones",
                Email = "bob@test.com",
                Comment = "Updated comment",
                Phone = null  
            };

            _repoMock.Setup(r => r.GetByEmail("bob@test.com")).Returns(existingCandidate);

            
            Candidate result = _service.UpsertCandidate(candidateDto);

           
            _repoMock.Verify(r => r.Update(existingCandidate), Times.Once);
            _repoMock.Verify(r => r.SaveChanges(), Times.Once);
            Assert.Equal("Updated comment", result.Comment);
            Assert.Equal("123-4567", result.Phone);
        }
    }
}
