namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONFIGURADOR")]
    public partial class CONFIGURADOR
    {
        [Key]
        public Guid IdConfigurador { get; set; }

        [StringLength(10)]
        public string ColorTienda { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}
