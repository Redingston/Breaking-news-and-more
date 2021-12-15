using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BreakingNews.Queries
{
    public class GetAllNewsQuery : IRequest<List<BreakingNewsVm>>
    {



        public sealed class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, List<BreakingNewsVm>>
        {
            private IApplicationDbContext _context;
            private IMapper _mapper;

            public GetAllNewsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<BreakingNewsVm>> Handle(GetAllNewsQuery request,
                                                           CancellationToken cancellationToken)
            {
                List<BreakingNewsVm> news = await _context.BreakingNews
                                                          .ProjectTo<BreakingNewsVm>(_mapper.ConfigurationProvider)
                                                          .ToListAsync();

                return news;
            }
        }
    }
}