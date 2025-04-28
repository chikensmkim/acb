using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Asignaciones.EventHandlers.v1;
public class AsignacionCreatedEventHandler(ILogger<AsignacionCreatedEventHandler> logger) : INotificationHandler<AsignacionCreated>
{
    public async Task Handle(AsignacionCreated notification,
       CancellationToken cancellationToken)
    {
        logger.LogInformation("handling Asignacion created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling asignacion created domain event..");
    }
}
{
}
