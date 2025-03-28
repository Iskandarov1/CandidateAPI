using CandidateApi.Controllers;
using CandidateApi.Dtos;
using CandidateApi.Models;
using CandidateApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CandidateApi.Tests
{
    public class CandidateControllerTests
    {
        [Fact]
        public void UpsertCandidate_ReturnsCreatedResult_ForNewCandidate()
        {
            var candidateDto = new CandidateDto
            {
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice@test.com",
                Comment = "Hello"
            };

            var createdCandidate = new Candidate
            {
                Id = 100,
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice@test.com",
                Comment = "Hello",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var serviceMock = new Mock<ICandidateService>();
            serviceMock.Setup(s => s.UpsertCandidate(candidateDto)).Returns(createdCandidate);

            var controller = new CandidateController(serviceMock.Object);

            IActionResult result = controller.UpsertCandidate(candidateDto);

            var createdAtAction = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdAtAction.StatusCode);
            var returnedCandidate = Assert.IsType<Candidate>(createdAtAction.Value);
            Assert.Equal("alice@test.com", returnedCandidate.Email);
        }

        [Fact]
        public void UpsertCandidate_ReturnsOkResult_ForUpdatedCandidate()
        {
            var candidateDto = new CandidateDto
            {
                FirstName = "Bob",
                LastName = "Jones",
                Email = "bob@test.com",
                Comment = "Update"
            };

            var updatedCandidate = new Candidate
            {
                Id = 42,
                FirstName = "Bob",
                LastName = "Jones",
                Email = "bob@test.com",
                Comment = "Update",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow
            };

            var serviceMock = new Mock<ICandidateService>();
            serviceMock.Setup(s => s.UpsertCandidate(candidateDto)).Returns(updatedCandidate);

            var controller = new CandidateController(serviceMock.Object);

            IActionResult result = controller.UpsertCandidate(candidateDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            var returnedCandidate = Assert.IsType<Candidate>(okResult.Value);
            Assert.Equal(42, returnedCandidate.Id);
        }
    }
}
