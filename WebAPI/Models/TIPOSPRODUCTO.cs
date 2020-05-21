namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TIPOSPRODUCTO")]
    public partial class TIPOSPRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPOSPRODUCTO()
        {
            PRODUCTOS = new HashSet<PRODUCTOS>();
        }

        [Key]
        public int IdTipoProducto { get; set; }

        [StringLength(100)]
        public string DescTipoProducto { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public bool? EstadoTipoProducto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTOS> PRODUCTOS { get; set; }
    }
}
