using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_quadro")]
    public partial class TbQuadro
    {
        public TbQuadro()
        {
            TbCartao = new HashSet<TbCartao>();
            TbTime = new HashSet<TbTime>();
        }

        [Key]
        [Column("id_quadro")]
        public int IdQuadro { get; set; }
        [Required]
        [Column("nm_quadro", TypeName = "varchar(100)")]
        public string NmQuadro { get; set; }
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(TbUsuario.TbQuadro))]
        public virtual TbUsuario IdUsuarioNavigation { get; set; }
        [InverseProperty("IdQuadroNavigation")]
        public virtual ICollection<TbCartao> TbCartao { get; set; }
        [InverseProperty("IdQuadroNavigation")]
        public virtual ICollection<TbTime> TbTime { get; set; }
    }
}
