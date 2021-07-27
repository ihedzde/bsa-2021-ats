using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Domain.Common;
using Domain.Interfaces;
using Application.Common.Models;

namespace Application.Generics.Queries
{
    public class GetEntityByIdQuery<TDto> : IRequest<TDto>
        where TDto : Dto
    {
        public Guid Id { get; }

        public GetEntityByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetEntityByIdQueryHandler<TEntity, TDto> : IRequestHandler<GetEntityByIdQuery<TDto>, TDto>
        where TEntity : Entity
        where TDto : Dto
    {
        protected readonly IReadRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GetEntityByIdQueryHandler(IReadRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TDto> Handle(GetEntityByIdQuery<TDto> query, CancellationToken _)
        {
            TEntity result = await _repository.GetAsync(query.Id);

            return _mapper.Map<TDto>(result);
        }
    }
}
