using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.BreakingNews.Queries;
using BreakingNewsCore.Entities.NewsEntity;
using BreakingNewsCore.Helpers;
using BreakingNewsCore.Interfaces;
using BreakingNewsCore.Interfaces.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using NUnit.Framework;

namespace Application.UnitTests.MediatorHandlers.NewsTests
{
    //TODO: move this logic with mock dbcontext into BLL tests
    //TODO: for controller just test controller methods(actions) with mocked BLL invocations


    [TestFixture]
    public class GetAllNewsTests
    {
        private readonly Mock<IRepository<News, string>> _mockContext;

        public GetAllNewsTests()
        {
            _mockContext = new Mock<IRepository<News, string>>();
        }

        [TearDown]
        public void TearDown()
        {
            _mockContext.Verify();
        }

        [Test]
        public async Task GetAllNews_Query_ReturnsNotNull()
        {
            SetupToListAsync(new [] {WithNews()});
            var request = new GetAllNewsQuery();

            var handler = new GetAllNewsQuery.GetAllNewsQueryHandler(_mockContext.Object);
            var result = await handler.Handle(request, CancellationToken.None);

            result.Should().NotBeNull();
        }

        

        protected void SetupAdd()
        {
            _mockContext.Setup(x => x.Insert(It.IsNotNull<News>()));
        }

        protected void SetupSaveChanges()
        {
            _mockContext.Setup(x => x.SaveChangesAsync(It.IsNotNull<CancellationToken>()))
                        .ReturnsAsync(1)
                        .Verifiable();
        }

        protected void SetupToListAsync(News [] elements)
        {
            _mockContext.Setup(x => x.GetAllAsync(It.IsNotNull<CancellationToken>()))
                        .ReturnsAsync(new List<News>(elements))
                        .Verifiable();
        }
        //private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        //{
        //    var elementsAsQueryable = elements.AsQueryable(); var dbSetMock = new Mock<DbSet<T>>();

        //    dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
        //    dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
        //    dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
        //    dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator()); 
        //    return dbSetMock;
        //}
        protected News WithNews()
        {
            return new News()
            {
                Id = new Guid().ToString(), 
                Topic = "new topic", 
                Text = "some text"
            };
        }

        private News WitSeededNews()
        {
            return
                new News()
                {
                    Id = new Guid().ToString(),
                    Topic = "new topic",
                    Text = "some text"
                };
        }
    }
}