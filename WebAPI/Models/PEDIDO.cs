namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PEDIDO")]
    public partial class PEDIDO
    {
        [Key]
        public Guid IdPedido { get; set; }

        public Guid IdUsuario { get; set; }

        public DateTime? FechPedido { get; set; }

        public int? IdTipoPago { get; set; }

        public int? EstadoPedido { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? IdDeliveryPrecio { get; set; }

        public virtual TIPOPAGO TIPOPAGO { get; set; }

        public virtual USUARIO USUARIO { get; set; }

        public virtual PEDIDODETALLE PEDIDODETALLE { get; set; }
        
        public virtual DELIVERYPRECIO DELIVERYPRECIO { get; set; }
    }
}
