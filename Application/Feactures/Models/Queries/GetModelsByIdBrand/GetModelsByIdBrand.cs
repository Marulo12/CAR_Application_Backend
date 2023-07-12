using Application.DTOs.Model;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace Application.Feactures.Models.Queries.GetModelsByIdBrand
{
    public class GetModelsByIdBrand: IRequest<IReadOnlyList<ModelDTO>>
    {
        [Required]
        public long IdBrand { get; set; }
    }

    internal class GetModelsByIdBrandHandler : IRequestHandler<GetModelsByIdBrand, IReadOnlyList<ModelDTO>>
    {
        private readonly IModelRepositoryAsync modelRepositoryAsync;
        private readonly IMapper mapper;

        public GetModelsByIdBrandHandler(IModelRepositoryAsync modelRepositoryAsync, IMapper mapper)
        {
            this.modelRepositoryAsync = modelRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<ModelDTO>> Handle(GetModelsByIdBrand request, CancellationToken cancellationToken)
        {
            var models = await modelRepositoryAsync.GetAllAsync(predicate: s =>  s.IdBrand == request.IdBrand);
            var modelsDTO = mapper.Map<IReadOnlyList<ModelDTO>>(models);
            return modelsDTO;
        }
    }
}
