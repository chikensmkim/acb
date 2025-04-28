
using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class SiniestroNotFoundException : NotFoundException
{
    public SiniestroNotFoundException(Guid id)
         : base($"siniestro whith id {id} not found")
    {        
    }
}
