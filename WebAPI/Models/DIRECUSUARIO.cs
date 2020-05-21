namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIRECUSUARIO")]
    public partial class DIRECUSUARIO
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        ////public DIRECUSUARIO()
        ////{
        ////    USUARIO = new HashSet<USUARIO>();
        ////}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDirecUsuario { get; set; }

        public Guid IdUsuario { get; set; }

        [StringLength(50)]
        public string Longitud { get; set; }

        [StringLength(50)]
        public string Latitud { get; set; }

        [StringLength(100)]
        public string DescDireccion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
