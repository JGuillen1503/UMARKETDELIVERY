namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PEDIDODETALLE")]
    public partial class PEDIDODETALLE
    {
        [Key]
        public Guid IdPedido { get; set; }

        public Guid IdProducto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CantProducto { get; set; }

        public decimal? PrecProducto { get; set; }

        public virtual PEDIDO PEDIDO { get; set; }

        public virtual PRODUCTOS PRODUCTOS { get; set; }
    }
}
