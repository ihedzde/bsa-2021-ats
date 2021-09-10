using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Read;
using Domain.Interfaces.Abstractions;
using Application.ElasticEnities.Dtos;
using Application.VacancyCandidates.Dtos;

namespace Application.VacancyCandidates.Queries
{
    public class GetFullVacancyCandidateByIdQuery : IRequest<VacancyCandidateFullDto>
    {
        public string Id { get; set; }
        public string VacancyId { get; set; }

        public GetFullVacancyCandidateByIdQuery(string id, string vacancyId)
        {
            Id = id;
            VacancyId = vacancyId;
        }
    }

    public class GetFullVacancyCandidateByIdQueryHandler
        : IRequestHandler<GetFullVacancyCandidateByIdQuery, VacancyCandidateFullDto>
    {
        private readonly IVacancyCandidateReadRepository _readRepository;
        private readonly IElasticReadRepository<ElasticEntity> _elasticEntityRepository;
        private readonly ICandidateCvReadRepository _candidateCvReadRepository;
        private readonly IReadRepository<FileInfo> _fileInfoReadRepository;
        private readonly IMapper _mapper;

        public GetFullVacancyCandidateByIdQueryHandler(
            IVacancyCandidateReadRepository readRepository,
            ICandidateCvReadRepository candidateCvReadRepository,
            IReadRepository<FileInfo> fileInfoReadRepository,
            IElasticReadRepository<ElasticEntity> elasticEntityRepository,
            IMapper mapper
        )
        {
            _readRepository = readRepository;
            _fileInfoReadRepository = fileInfoReadRepository;
            _elasticEntityRepository = elasticEntityRepository;
            _candidateCvReadRepository = candidateCvReadRepository;
            _mapper = mapper;
        }

        public async Task<VacancyCandidateFullDto> Handle(GetFullVacancyCandidateByIdQuery query, CancellationToken _)
        {
            VacancyCandidate candidate = await _readRepository.GetFullAsync(query.Id, query.VacancyId);
            if (candidate.CvFileInfoId != null)
            {
                candidate.CvFileInfo = await _fileInfoReadRepository.GetAsync(candidate.CvFileInfoId);
                candidate.CvFileInfo.Name = candidate.CvFileInfo.Name.Split('-')[5];
                candidate.CvFileInfo.PublicUrl = await _candidateCvReadRepository.GetSignedUrlAsync(candidate.Id);
            }
            VacancyCandidateFullDto candidateFullDto = _mapper.Map<VacancyCandidate, VacancyCandidateFullDto>(candidate);

            ElasticEntity tags = await _elasticEntityRepository.GetAsync(candidate.ApplicantId);

            if (tags != null)
            {
                candidateFullDto.Tags = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagDto>>(tags.Tags);
            }
            else
            {
                candidateFullDto.Tags = new List<TagDto>();
            }

            return candidateFullDto;
        }
    }
}
