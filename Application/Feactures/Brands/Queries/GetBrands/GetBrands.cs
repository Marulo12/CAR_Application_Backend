using Application.DTOs.Brand;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Feactures.Brands.Queries.GetBrands
{
    public class GetBrands: IRequest<IReadOnlyList<BrandDTO>>
    {
    }

    internal class GetBrandsHandler : IRequestHandler<GetBrands, IReadOnlyList<BrandDTO>>
    {
        private readonly IBrandRepositoryAsync brandRepositoryAsync;
        private readonly IMapper mapper;
        public GetBrandsHandler(IBrandRepositoryAsync brandRepositoryAsync, IMapper mapper)
        {
            this.brandRepositoryAsync = brandRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<BrandDTO>> Handle(GetBrands request, CancellationToken cancellationToken)
        {
            var brands = await brandRepositoryAsync.GetAllAsync(s => s.OrderBy(s => s.Name));
            var brandsDTO = mapper.Map<IReadOnlyList<BrandDTO>>(brands);

            return brandsDTO;
        }
    }
}
