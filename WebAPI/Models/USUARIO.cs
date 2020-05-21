namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
           // DIRECUSUARIO = new HashSet<DIRECUSUARIO>();
           PEDIDO = new HashSet<PEDIDO>();  
        }

        [Key]
        public Guid IdUsuario { get; set; }

        [StringLength(50)]
        public string NomUsuario { get; set; }

        [StringLength(50)]
        public string ApeUsuario { get; set; }

        public int? DNIUsuario { get; set; }

        public int? TelefUsuario { get; set; }

        [StringLength(50)]
        public string CorreoUsuario { get; set; }

        public bool? EstadoUsuario { get; set; }

        [StringLength(100)]
        public string PasswordUsuario { get; set; }

        public int? IdTipoUsuario { get; set; }

        public DateTime? FechaCreacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       // public virtual ICollection<DIRECUSUARIO> DIRECUSUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PEDIDO> PEDIDO { get; set; }
        public virtual TIPOUSUARIO TIPOUSUARIO { get; set; }

    }
}
