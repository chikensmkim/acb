using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiAlphatracker.Domain.Common.Events;

namespace FSH.Starter.WebApi.Catalog.Application.Asignaciones.Delete.v1;
//internal class DeleteAsignacionCommand
//{
//}

public class DeleteEntityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteEntityRequest(Guid id) => Id = id;
}

public class DeleteEntityRequestHandler : IRequestHandler<DeleteEntityRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Entity> _repository;
    private readonly IStringLocalizer _t;

    public DeleteEntityRequestHandler(IRepositoryWithEvents<Entity> repository, IStringLocalizer<DeleteEntityRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeleteEntityRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = entity ?? throw new NotFoundException(_t["Entity {0} Not Found."]);

        await _repository.DeleteAsync(entity, cancellationToken);

        return request.Id;
    }
}
