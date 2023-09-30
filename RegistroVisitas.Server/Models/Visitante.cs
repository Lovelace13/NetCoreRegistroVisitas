using System;
using System.Collections.Generic;

namespace RegistroVisitas.Server.Models;

public partial class Visitante
{
    public int Idvisita { get; set; }

    public DateTime? Fechaingreso { get; set; }

    public TimeSpan? Hora { get; set; }

    public string? Nombre { get; set; }

    public string? Cedula { get; set; }

    public string? Motivo { get; set; }

    public string? Departamento { get; set; }

    public bool Estado { get; set; }

    public string? Novedad { get; set; }
}
