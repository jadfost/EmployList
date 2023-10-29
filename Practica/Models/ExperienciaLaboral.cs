using System;
using System.Collections.Generic;

namespace Practica.Models;

public partial class ExperienciaLaboral
{
    public int Id { get; set; }

    public int? EmpleadoId { get; set; }

    public string? Empresa { get; set; }

    public string? Cargo { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
