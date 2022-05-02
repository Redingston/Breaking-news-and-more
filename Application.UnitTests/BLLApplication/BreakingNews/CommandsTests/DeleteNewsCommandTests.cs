using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.BreakingNews.Commands;
using BreakingNewsCore.Common.Exceptions;
using BreakingNewsCore.Entities.CommentEntity;
using BreakingNewsCore.Entities.NewsEntity;
using BreakingNewsCore.Entities.NewsToCategoryEntity;
using BreakingNewsCore.Entities.NewsToReactionEntity;
using BreakingNewsCore.Entities.NewsToTagEntity;
using BreakingNewsCore.Entities.NewsToUserEntity;
using BreakingNewsCore.Interfaces.Repositories;
using FluentAssertions;
using MediatR;
using Moq;
using NUnit.Framework;

namespace Application.UnitTests.BLLApplication.BreakingNews.CommandsTests
{
    public class DeleteNewsCommandTests
    {
        private readonly DeleteNewsCommand.DeleteNewsCommandHandler _sut;
        private readonly Mock<IRepository<News, string>> _mockContext = new Mock<IRepository<News, string>>();

        public DeleteNewsCommandTests()
        {
            _sut = new DeleteNewsCommand.DeleteNewsCommandHandler(_mockContext.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockContext.Verify();
        }

        [Test]
        public void Handle_DeleteNews_ReturnsVoid()
        {
            var updatedNews = WithNews();
            var request = new DeleteNewsCommand()
            {
                Id = "00245b0e-37be-4b07-8b93-891aab92c0af"
            };
            SetupInsert();
            SetupSaveChanges();

            SetupFindFirstOrDefaultAsync(updatedNews.Id);
            SetupDelete(updatedNews);
            SetupSaveChanges();

            var result = _sut.Handle(request, It.IsAny<CancellationToken>());
            result.Result.Should().Be(Unit.Value);
        }

        [Test]
        public void Handle_WithIncorrectId_ThrowsNotFoundException()
        {
            var request = new DeleteNewsCommand()
            {
                Id = "aewe"
            };

            Func<Task> result = async () =>
            {
                await _sut.Handle(request, CancellationToken.None);
            };

            result.Should().ThrowAsync<NotFoundException>();
        }

        public void SetupDelete(News item)
        {
            _mockContext.Setup(x=>x.Delete(item));
        }

        public void SetupFindFirstOrDefaultAsync(string id)
        {
            _mockContext.Setup(x => x.FindFirstOrDefaultAsync(id))
                        .ReturnsAsync(WithNews)
                        .Verifiable();
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