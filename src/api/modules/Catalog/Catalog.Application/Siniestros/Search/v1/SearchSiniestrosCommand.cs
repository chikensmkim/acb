using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.Siniestros.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Search.v1;
public record SearchSiniestrosCommand(PaginationFilter filter) : IRequest<PagedList<SiniestroResponse>>;
