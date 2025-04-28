namespace FSH.Starter.WebApi.Catalog.Application.Siniestros.Get.v1;
public sealed record SiniestroResponse(
    Guid? Id,
    string Patente,
    DateTime FechaOcurrencia,
    DateTime FechaDenuncia,
    string Estado,
    string Zona,
    decimal CostoEstimado
  );
