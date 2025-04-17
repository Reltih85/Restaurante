using System;
using System.Collections.Generic;

namespace Restaurante.Models;

public partial class Factura
{
    public int Id { get; set; }

    public int? PedidoId { get; set; }

    public decimal Total { get; set; }

    public string? MetodoPago { get; set; }

    public DateTime? FechaEmision { get; set; }

    public virtual Pedido? Pedido { get; set; }
}
