using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Tags.Queries
{
    public class GetAllTagsQuery : IRequest<List<TagVm>>
    {
        public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, List<TagVm>>
        {

            private readonly IRepository<Tag, string> _repository;

            public GetAllTagsQueryHandler(IRepository<Tag, string> repository)
            {
                _repository = repository;
            }

            public async Task<List<TagVm>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
            {
                var news = await _repository.GetAllAsync(cancellationToken);
                var list = new List<TagVm>();

                foreach (var t in news)
                {
                    list.Add(t.Mapping<Tag, TagVm>());
                }

                return list;
            }
        }
    }
}