using BreakingNewsCore.Interfaces.Repositories;
using BreakingNewsCore.Tags.Queries;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.Entities.TagEntity;

namespace Application.UnitTests.BLLApplication.Tags.QueriesTests
{
    public class GetAllTagsQueryTests
    {
        private readonly GetAllTagsQuery.GetAllTagsQueryHandler _sut;
        private readonly Mock<IRepository<Tag, string>> _mockContext = new Mock<IRepository<Tag, string>>();

        public GetAllTagsQueryTests()
        {
            _sut = new GetAllTagsQuery.GetAllTagsQueryHandler(_mockContext.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockContext.Verify();
        }

        [Test]
        public async Task Handle_IfExistElements_ShouldNotBeEmpty()
        {
            var request = new GetAllTagsQuery() { };

            SetupGetAllAsync();

            var result = await _sut.Handle(request, CancellationToken.None);

            result.Should().NotBeEmpty();
        }

        [Test]
        public async Task Handle_Counts_ShouldBeTheSameAsMocked()
        {
            var request = new GetAllTagsQuery() { };

            SetupGetAllAsync();

            var result = await _sut.Handle(request, CancellationToken.None);

            result.Count.Should().Be(WithTags().Count);
        }

        public void SetupGetAllAsync()
        {
            _mockContext.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
                        .ReturnsAsync(WithTags)
                        .Verifiable();
        }

        protected List<Tag> WithTags()
        {
            return new List<Tag>()
            {
                new Tag()
                {
                    Id = "00245b0e-37be-4b07-8b93-891aab92c0af",
                    Color = "213213",
                    Name = "pink"
                },
                new Tag()
                {
                    Id = "20245b0e-37be-4b07-8b93-891aab92c0af",
                    Color = "213233",
                    Name = "red"
                },
                new Tag()
                {
                    Id = "10245b0e-37be-4b07-8b93-891aab92c0af",
                    Color = "253213",
                    Name = "blue"
                }
            };
        }

    }
}