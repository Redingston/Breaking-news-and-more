//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using BreakingNewsCore.Interfaces;
//using BreakingNewsCore.Interfaces.Repositories;
//using Domain.Entities;
//using NUnit.Framework;
//using FluentAssertions;
//using Infrastructure.Persistence;
//using Infrastructure.Persistence.Repositories;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Moq;

//namespace BreakingNewsCore.UnitTests.Infrastructure.Repositories
//{
//    [TestFixture]
//    public class NewsRepositoryTests
//    {
//        private readonly NewsRepository _sut;
//    //    private readonly Mock<(NewsRepository, IRepository<News, string>)> _mockContext = new Mock<(NewsRepository, IRepository<News, string)>();

//        public NewsRepositoryTests()
//        {
//      //      _sut = new NewsRepository(_mockContext.Object);
//        }

//        [TearDown]
//        public void TearDown()
//        {
// //           _mockContext.Verify();
//        }
        
//        [Test]
//        public async Task GetAllAsync_IfExistElements_ShouldNotBeEmpty()
//        {
//            SetupGetAllAsync();

//            var result = await _sut.GetAllAsync(CancellationToken.None);

//            result.Should().NotBeEmpty();
//        }
        
//        public void SetupGetAllAsync()
//        {
//  //          _mockContext.Setup(x => x.BreakingNews.ToListAsync(It.IsAny<CancellationToken>()))
//                .ReturnsAsync(WithNews)
//                .Verifiable();
//        }
//        // public void SetupInsert(News news)
//        // {
//        //     _mockContext.Setup(x => 
//        //             x.BreakingNews.AddAsync(news))
//        //         .ReturnsAsync(WithNews);
//        // }

//        public void SetupSaveChanges()
//        {
//            _mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
//                .ReturnsAsync(1)
//                .Verifiable();
//        }
        
//        protected List<News> WithNews()
//        {
//            return new List<News>()
//            {
//                new News(){
//                    Id = "00245b0e-37be-4b07-8b93-891aab92c0af",
//                    Topic = "new topic",
//                    Text = "some text",
//                    TimeCreated = DateTime.Now.ToShortDateString(),
//                    LastTimeUpdated = DateTime.Now.ToShortDateString()
//                },
//                new News(){
//                    Id = "10245b0e-37be-4b07-8b93-891aab92c0af",
//                    Topic = "old topic",
//                    Text = "some text",
//                    TimeCreated = DateTime.Now.ToShortDateString(),
//                    LastTimeUpdated = DateTime.Now.ToShortDateString()
//                },
//                new News(){
//                    Id = "20245b0e-37be-4b07-8b93-891aab92c0af",
//                    Topic = "future topic",
//                    Text = "some text",
//                    TimeCreated = DateTime.Now.ToShortDateString(),
//                    LastTimeUpdated = DateTime.Now.ToShortDateString()
//                }
//            };
//        }
        
//        protected News WithSingleNews()
//        {
//            return new News()
//            {
//                Id = "00245b0e-37be-4b07-8b93-891aab92c0af",
//                Topic = "new topic",
//                Text = "some text",
//                TimeCreated = DateTime.Now.ToShortDateString(),
//                LastTimeUpdated = DateTime.Now.ToShortDateString(),
//                Tags = new List<NewsToTag>()
//                {
//                    new NewsToTag()
//                    {
//                        TagId = "01245b0e-37be-4b07-8b93-891aab92c0af",
//                        NewsId = "00245b0e-37be-4b07-8b93-891aab92c0af"
//                    }
//                },
//                Categories = new List<NewsToCategory>()
//                {
//                    new NewsToCategory()
//                    {
//                        CategoryId = "02245b0e-37be-4b07-8b93-891aab92c0af",
//                        NewsId = "00245b0e-37be-4b07-8b93-891aab92c0af"
//                    }
//                },
//                Users = new List<NewsToUser>()
//                {
//                    new NewsToUser()
//                    {
//                        UserId = "03245b0e-37be-4b07-8b93-891aab92c0af",
//                        NewsId = "00245b0e-37be-4b07-8b93-891aab92c0af"
//                    }
//                },
//                Comments = new List<Comment>()
//                {
//                    new Comment()
//                    {
//                        Id = "30245b0e-37be-4b07-8b93-891aab92c0af",
//                        Text = "cool",
//                        UserId = "04245b0e-37be-4b07-8b93-891aab92c0af"
//                    }
//                },
//                Reactions = new List<NewsToReaction>()
//                {
//                    new NewsToReaction()
//                    {
//                        ReactionId = "05245b0e-37be-4b07-8b93-891aab92c0af",
//                        NewsId = "00245b0e-37be-4b07-8b93-891aab92c0af"
//                    }
//                }
//            };
//        }

//    }
//}