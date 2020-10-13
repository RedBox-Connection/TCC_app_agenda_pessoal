using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_time_integrante")]
    public partial class TbTimeIntegrante
    {
        [Key]
        [Column("id_integrante")]
        public int IdIntegrante { get; set; }
        [Column("id_time")]
        public int IdTime { get; set; }
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(IdTime))]
        [InverseProperty(nameof(TbTime.TbTimeIntegrante))]
        public virtual TbTime IdTimeNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(TbUsuario.TbTimeIntegrante))]
        public virtual TbUsuario IdUsuarioNavigation { get; set; }
    }
}
