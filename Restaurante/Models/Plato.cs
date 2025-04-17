using System;
using System.Collections.Generic;

namespace Restaurante.Models;

public partial class Plato
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int? CategoriaId { get; set; }

    public bool? Disponible { get; set; }

    public virtual CategoriasMenu? Categoria { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<PlatoIngrediente> PlatoIngredientes { get; set; } = new List<PlatoIngrediente>();
}
