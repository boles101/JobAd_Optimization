using Microsoft.Extensions.Logging;
using Moq;
using NET_Developer_Intern_API_Coding_Assessment.Data;
using NET_Developer_Intern_API_Coding_Assessment.Model;
using NET_Developer_Intern_API_Coding_Assessment.Services;

namespace JobAdOptimization.Api.Tests
{
    public class AdOptimizerTests
    {
        private readonly AdOptimizer _optimizer;
        private readonly Mock<AssesmentDbContext> _dbContextMock;
        private readonly Mock<ILogger<AdOptimizer>> _loggerMock = new Mock<ILogger<AdOptimizer>>();

        public AdOptimizerTests()
        {
            _optimizer = new AdOptimizer(_loggerMock.Object);
            _dbContextMock = new Mock<AssesmentDbContext>();

        }


        [Fact]
        public void Optimize_ShouldReturnOptimizedContent_WhenCalledWithValidData()
        {
            var loggerMock = new Mock<ILogger<AdOptimizer>>();
            var optimizer = new AdOptimizer(loggerMock.Object);
            var jobRequest = new JobRequest
            {
                Title = "Senior Developer Position Available",
                Description = "We are looking for a senior developer with over 10 years of experience in software development, including extensive knowledge of .NET, JavaScript, and SQL. Must be proficient in backend and frontend development and familiar with agile methodologies.",
                Keywords = new List<string> { "senior", "developer", "experienced", ".NET", "JavaScript", "SQL", "backend", "frontend", "agile"},
                Platform = SocialMediaPlatform.Twitter
            };
            var result = optimizer.Optimize(jobRequest);

            Assert.Contains("...", result); 
        }

        [Fact]
        public void Optimize_ContentUnderTwitterLimit_ShouldReturnUnchanged()
        {

            var jobRequest = new JobRequest
            {
                Title = "Need Devs",
                Description = "Looking for experienced devs for a quick project.",
                Keywords = new List<string> { "developer", "contract" },
                Platform = SocialMediaPlatform.Twitter
            };

            string expectedContent = $"{jobRequest.Title} - {string.Join(", ", jobRequest.Keywords)} - {jobRequest.Description}";


            var result = _optimizer.Optimize(jobRequest);

            Assert.Equal(expectedContent, result); 
            Assert.False(result.EndsWith("...")); 
        }
    }
}