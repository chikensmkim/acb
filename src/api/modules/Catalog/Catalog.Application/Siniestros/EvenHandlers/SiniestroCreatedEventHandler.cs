using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.EvenHandlers;
public class SiniestroCreatedEventHandler(ILogger<SiniestroCreatedEventHandler> logger) : INotificationHandler<SiniestroCreated>
{
    public async Task Handle(SiniestroCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling siniestro created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling siniestro created domain event..");
    }
}
