using System;
using System.Collections.Generic;

namespace RegistroVisitas.Server.Models;

public partial class Usuario
{
    public int Iduser { get; set; }

    public string? Nombre { get; set; }

    public string? Lastname { get; set; }

    public string? Rol { get; set; }

    public string Correo { get; set; } = null!;
}
