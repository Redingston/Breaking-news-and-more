using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Helpers;
using Application.Interfaces;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BreakingNews.Queries
{
    public class GetAllNewsQuery : IRequest<List<BreakingNewsVm>>
    {

        public sealed class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, List<BreakingNewsVm>>
        {
            private readonly IRepository<News, string> _repository;
            //private IMapper _mapper;

            public GetAllNewsQueryHandler(IRepository<News, string> repository)
            {
                _repository = repository;
                // _mapper = mapper;
            }

            public async Task<List<BreakingNewsVm>> Handle(GetAllNewsQuery request,
                                                           CancellationToken cancellationToken)
            {
                var news = await _repository.GetAllAsync(cancellationToken);
                var list = new List<BreakingNewsVm>();

                foreach (var t in news)
                {
                    list.Add(t.Mapping<News, BreakingNewsVm>());
                }

                return list;
            }
        }
    }
}