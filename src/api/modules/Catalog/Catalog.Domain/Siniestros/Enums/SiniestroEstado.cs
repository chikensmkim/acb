using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.Starter.WebApi.Catalog.Domain.Enums;
public static class SiniestroEstado
{
    public const string Pendiente = "Pendiente";
    public const string Presupuestado = "Presupuestado";
    public const string Ordenado = "Ordenado";
    public const string EnReparacion = "En Reparacion";
    public const string Finalizado = "Finalizado";
    public const string Cancelado = "Cancelado";

    public static readonly IReadOnlyList<string> ListaEstados = new List<string>
    {
        Pendiente,
        Presupuestado,
        Ordenado,
        EnReparacion,
        Finalizado,
        Cancelado
    };
}
