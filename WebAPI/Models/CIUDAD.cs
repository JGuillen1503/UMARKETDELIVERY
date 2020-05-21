namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CIUDAD")]
    public partial class CIUDAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CIUDAD()
        {
           // TIENDAS = new HashSet<TIENDAS>();
            FechaCreacion = DateTime.Now;
        }

        [Key]
        public Guid IdCiudad { get; set; }

        [StringLength(100)]
        public string DescCiudad { get; set; }

        public bool? EstadoCiudad { get; set; }

        public DateTime? FechaCreacion { get; set; }
        
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")] 
      //  public virtual ICollection<TIENDAS> TIENDAS { get; set; }
    }
}
