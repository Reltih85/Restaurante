using System;
using System.Collections.Generic;

namespace Restaurante.Models;

public partial class PlatoIngrediente
{
    public int Id { get; set; }

    public int? PlatoId { get; set; }

    public int? IngredienteId { get; set; }

    public decimal? CantidadUsada { get; set; }

    public virtual Ingrediente? Ingrediente { get; set; }

    public virtual Plato? Plato { get; set; }
}
