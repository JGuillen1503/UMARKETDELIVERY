namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TIPOUSUARIO")]
    public partial class TIPOUSUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPOUSUARIO()
        {
           // USUARIO = new HashSet<USUARIO>();
        }

        [Key]
        public int IdTipoUsuario { get; set; }

        [StringLength(50)]
        public string DescTipoUsuario { get; set; }

        public DateTime? FechaCreacion { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<USUARIO> USUARIO { get; set; }
    }
}
