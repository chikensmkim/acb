
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Get.v1;
public class GetSiniestroRequest : IRequest<SiniestroResponse>
{
    public Guid Id { get; set; }
    public GetSiniestroRequest(Guid id) => Id = id;
}
