using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreakingNewsCore.Helpers;
using BreakingNewsCore.DTO.TagsDTO;
using BreakingNewsCore.Entities.TagEntity;
using BreakingNewsCore.Interfaces.Repositories;
using MediatR;

namespace BreakingNewsCore.Tags.Queries
{
    public class GetAllTagsQuery : IRequest<List<TagDTO>>
    {
        public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, List<TagDTO>>
        {

            private readonly IRepository<Tag, string> _repository;

            public GetAllTagsQueryHandler(IRepository<Tag, string> repository)
            {
                _repository = repository;
            }

            public async Task<List<TagDTO>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
            {
                var news = await _repository.GetAllAsync(cancellationToken);
                var list = new List<TagDTO>();

                foreach (var t in news)
                {
                    list.Add(t.Mapping<Tag, TagDTO>());
                }

                return list;
            }
        }
    }
}