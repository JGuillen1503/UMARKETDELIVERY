namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BANNER")]
    public partial class BANNER
    {
        [Key]
        public Guid IdBanner { get; set; }

        public Guid IdTienda { get; set; }

        [MaxLength(1)]
        public byte[] IMGBanner { get; set; }

        [StringLength(100)]
        public string BannerFileName { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public virtual TIENDAS TIENDAS { get; set; }
    }
}
