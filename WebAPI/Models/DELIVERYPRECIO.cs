namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DELIVERYPRECIO")]
    public partial class DELIVERYPRECIO
    {
        [Key]
        public int? IdDeliveryPrecio { get; set; }

        public int? DistanciaDelivery { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PrecioDelivery { get; set; }

        public virtual ICollection<PEDIDO> PEDIDO { get; set; }
    }
}