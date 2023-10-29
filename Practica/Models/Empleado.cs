using System;
using System.Collections.Generic;

namespace Practica.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public int? Cedula { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Cargo { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<ExperienciaLaboral> ExperienciaLaborals { get; set; } = new List<ExperienciaLaboral>();
}
