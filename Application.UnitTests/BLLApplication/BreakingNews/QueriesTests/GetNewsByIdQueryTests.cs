using BreakingNewsCore.BreakingNews.Queries;
using BreakingNewsCore.Common.Exceptions;
using BreakingNewsCore.Interfaces.Repositories;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.Entities.CommentEntity;
using BreakingNewsCore.Entities.NewsEntity;
using BreakingNewsCore.Entities.NewsToCategoryEntity;
using BreakingNewsCore.Entities.NewsToReactionEntity;
using BreakingNewsCore.Entities.NewsToTagEntity;
using BreakingNewsCore.Entities.NewsToUserEntity;

namespace Application.UnitTests.BLLApplication.BreakingNews.QueriesTests
{
    public class GetNewsByIdQueryTests
    {
        private readonly GetNewsByIdQuery.GetNewsByIdQueryHandler _sut;
        private readonly Mock<IRepository<News, string>> _mockContext = new Mock<IRepository<News, string>>();

        public GetNewsByIdQueryTests()
        {
            _sut = new GetNewsByIdQuery.GetNewsByIdQueryHandler(_mockContext.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockContext.Verify();
        }

        [Test]
        public async Task Handle_GetById_ReturnsCorrectValue()
        {
            var news = WithNews();
            var request = new GetNewsByIdQuery()
            {
                Id = news.Id
            };

            SetupGetById();

            var result = await _sut.Handle(request, CancellationToken.None);

            result.Id.Should().Be(WithNews().Id);
            result.Text.Should().Be(WithNews().Text);
            result.Topic.Should().Be(WithNews().Topic);
            result.TimeCreated.Should().Be(WithNews().TimeCreated);
            result.LastTimeUpdated.Should().Be(WithNews().LastTimeUpdated);
            result.Users.Count.Should().Be(WithNews().Users.Count);
            result.Tags.Count.Should().Be(WithNews().Tags.Count);
            result.Comments.Count.Should().Be(WithNews().Comments.Count);
            result.Categories.Count.Should().Be(WithNews().Categories.Count);
            result.Reactions.Count.Should().Be(WithNews().Reactions.Count);
        }

        [Test]
        public void Handle_WithIncorrectId_ThrowsNotFoundException()
        {
            var request = new GetNewsByIdQuery()
            {
                Id = "aewe"
            };

            Func<Task> result = async () =>
            {
                await _sut.Handle(request, CancellationToken.None);
            };

            result.Should().ThrowAsync<NotFoundException>();
        }

        public void SetupGetById()
        {
            _mockContext.Setup(x => x.GetByIdAsync(WithNews().Id))
                        .ReturnsAsync(WithNews())
                        .Verifiable();
        }

        protected News WithNews()
        {
            return new News()
            {
                Id = "00245b0e-37be-4b07-8b93-891aab92c0af",
                Topic = "new topic",
                Text = "some text",
                TimeCreated = DateTime.Now.ToShortDateString(),
                LastTimeUpdated = DateTime.Now.ToShortDateString(),
                Tags = new List<NewsToTag>()
                {
                    new NewsToTag()
                    {
                        TagId = "01245b0e-37be-4b07-8b93-891aab92c0af",
                        NewsId = "00245b0e-37be-4b07-8b93-891aab92c0af"
                    }
                },
                Categories = new List<NewsToCategory>()
                {
                    new NewsToCategory()
                    {
                        CategoryId = "02245b0e-37be-4b07-8b93-891aab92c0af",
                        NewsId = "00245b0e-37be-4b07-8b93-891aab92c0af"
                    }
                },
                Users = new List<NewsToUser>()
                {
                    new NewsToUser()
                    {
                        UserId = "03245b0e-37be-4b07-8b93-891aab92c0af",
                        NewsId = "00245b0e-37be-4b07-8b93-891aab92c0af"
                    }
                },
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Id = "30245b0e-37be-4b07-8b93-891aab92c0af",
                        Text = "cool",
                        UserId = "04245b0e-37be-4b07-8b93-891aab92c0af"
                    }
                },
                Reactions = new List<NewsToReaction>()
                {
                    new NewsToReaction()
                    {
                        ReactionId = "05245b0e-37be-4b07-8b93-891aab92c0af",
                        NewsId = "00245b0e-37be-4b07-8b93-891aab92c0af"
                    }
                }
            };
        }
    }
}