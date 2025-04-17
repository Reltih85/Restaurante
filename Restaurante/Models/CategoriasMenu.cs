using System;
using System.Collections.Generic;

namespace Restaurante.Models;

public partial class CategoriasMenu
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Plato> Platos { get; set; } = new List<Plato>();
}
