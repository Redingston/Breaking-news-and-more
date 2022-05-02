using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.BreakingNews.Commands;
using BreakingNewsCore.Entities.CommentEntity;
using BreakingNewsCore.Entities.NewsEntity;
using BreakingNewsCore.Entities.NewsToCategoryEntity;
using BreakingNewsCore.Entities.NewsToReactionEntity;
using BreakingNewsCore.Entities.NewsToTagEntity;
using BreakingNewsCore.Entities.NewsToUserEntity;
using BreakingNewsCore.Interfaces.Repositories;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Application.UnitTests.BLLApplication.BreakingNews.CommandsTests
{
    public class CreateNewsCommandTests
    {
        private readonly CreateNewsCommand.CreateNewsCommandHandler _sut;
        private readonly Mock<IRepository<News, string>> _mockContext = new Mock<IRepository<News, string>>();

        public CreateNewsCommandTests()
        {
            _sut = new CreateNewsCommand.CreateNewsCommandHandler(_mockContext.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockContext.Verify();
        }

        [Test]
        public async Task Handle_Executing_ReturnsNotNull()
        {
            var request = new CreateNewsCommand(){};
            var entity = WithNews();
            request.Text = entity.Text;
            request.Topic = entity.Topic;

            SetupInsert();
            SetupSaveChanges();

            var result = await _sut.Handle(request, CancellationToken.None);

            result.Should().NotBeNull();
        }

        public void SetupInsert()
        {
            _mockContext.Setup(x => x.Insert(WithNews()))
                        .ReturnsAsync(WithNews);
        }

        public void SetupSaveChanges()
        {
            _mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                        .ReturnsAsync(1)
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