using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Helpers;
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
    }

    public sealed class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, List<BreakingNewsVm>>
    {
        private IApplicationDbContext _context;
        //private IMapper _mapper;

        public GetAllNewsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
            // _mapper = mapper;
        }

        public async Task<List<BreakingNewsVm>> Handle(GetAllNewsQuery request,
                                                       CancellationToken cancellationToken)
        {
            var news = await _context.BreakingNews.AsNoTracking().ToListAsync(cancellationToken);
            var list = new List<BreakingNewsVm>();

            foreach (var t in news)
            {
                list.Add(t.Mapping<News, BreakingNewsVm>());
            }

            return list;
        }
    }
}