using System;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.Siniestros.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Search.v1;
public sealed class SearchSiniestrosHandler : IRequestHandler<SearchSiniestrosCommand, PagedList<SiniestroResponse>>
{
    
   
    public SearchSiniestrosHandler([FromKeyedServices("catalog:siniestros")] IReadRepository<Siniestro> repository)
    {
        ArgumentNullException.ThrowIfNull(repository);
        this.repository = repository;
    }
    private readonly IReadRepository<Siniestro> repository;
    public async Task<PagedList<SiniestroResponse>> Handle(SearchSiniestrosCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new EntitiesByPaginationFilterSpec<Siniestro, SiniestroResponse>(request.filter);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<SiniestroResponse>(items, request.filter.PageNumber, request.filter.PageSize, totalCount);
    }
}
