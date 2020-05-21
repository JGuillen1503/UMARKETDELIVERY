namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TIENDAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIENDAS()
        {
            BANNER = new HashSet<BANNER>();
            PRODUCTOS = new HashSet<PRODUCTOS>();
        }

        [Key]
        public Guid IdTienda { get; set; }

        [StringLength(200)]
        public string DescTienda { get; set; }

        [StringLength(150)]
        public string DirecTienda { get; set; }

        public int? TelefTienda { get; set; }

        [StringLength(50)]
        public string CorreoTienda { get; set; }

        public bool? EstadoTienda { get; set; }

        public Guid? IdCiudad { get; set; }

        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANNER> BANNER { get; set; }

        public virtual CIUDAD CIUDAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTOS> PRODUCTOS { get; set; }
    }
}
