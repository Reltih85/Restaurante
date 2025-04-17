using System;
using System.Collections.Generic;

namespace Restaurante.Models;

public partial class Ingrediente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Stock { get; set; }

    public string? UnidadMedida { get; set; }

    public decimal? StockMinimo { get; set; }

    public virtual ICollection<PlatoIngrediente> PlatoIngredientes { get; set; } = new List<PlatoIngrediente>();
}
