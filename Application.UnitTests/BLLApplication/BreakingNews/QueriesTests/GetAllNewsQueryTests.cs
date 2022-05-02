using BreakingNewsCore.BreakingNews.Queries;
using BreakingNewsCore.Interfaces.Repositories;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.Entities.NewsEntity;

namespace Application.UnitTests.BLLApplication.BreakingNews.QueriesTests
{
    public class GetAllNewsQueryTests
    {
        private readonly GetAllNewsQuery.GetAllNewsQueryHandler _sut;
        private readonly Mock<IRepository<News, string>> _mockContext = new Mock<IRepository<News, string>>();

        public GetAllNewsQueryTests()
        {
            _sut = new GetAllNewsQuery.GetAllNewsQueryHandler(_mockContext.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockContext.Verify();
        }

        [Test]
        public async Task Handle_IfExistElements_ShouldNotBeEmpty()
        {
            var request = new GetAllNewsQuery() { };

            SetupGetAllAsync();

            var result = await _sut.Handle(request, CancellationToken.None);

            result.Should().NotBeEmpty();
        }

        [Test]
        public async Task Handle_Counts_ShouldBeTheSameAsMocked()
        {
            var request = new GetAllNewsQuery() { };

            SetupGetAllAsync();

            var result = await _sut.Handle(request, CancellationToken.None);

            result.Count.Should().Be(WithNews().Count);
        }

        public void SetupGetAllAsync()
        {
            _mockContext.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
                        .ReturnsAsync(WithNews)
                        .Verifiable();
        }

        protected List<News> WithNews()
        {
            return new List<News>()
            {
                new News(){
                    Id = "00245b0e-37be-4b07-8b93-891aab92c0af",
                    Topic = "new topic",
                    Text = "some text",
                    TimeCreated = DateTime.Now.ToShortDateString(),
                    LastTimeUpdated = DateTime.Now.ToShortDateString()
                },
                new News(){
                    Id = "10245b0e-37be-4b07-8b93-891aab92c0af",
                    Topic = "old topic",
                    Text = "some text",
                    TimeCreated = DateTime.Now.ToShortDateString(),
                    LastTimeUpdated = DateTime.Now.ToShortDateString()
                },
                new News(){
                    Id = "20245b0e-37be-4b07-8b93-891aab92c0af",
                    Topic = "future topic",
                    Text = "some text",
                    TimeCreated = DateTime.Now.ToShortDateString(),
                    LastTimeUpdated = DateTime.Now.ToShortDateString()
                }
            };
        }

    }
}