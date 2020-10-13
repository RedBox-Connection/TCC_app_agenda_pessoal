using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_cartao_comentario")]
    public partial class TbCartaoComentario
    {
        [Key]
        [Column("id_comentario")]
        public int IdComentario { get; set; }
        [Required]
        [Column("ds_comentario", TypeName = "varchar(300)")]
        public string DsComentario { get; set; }
        [Column("dt_inclusao", TypeName = "datetime")]
        public DateTime DtInclusao { get; set; }
        [Column("id_cartao")]
        public int IdCartao { get; set; }
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(IdCartao))]
        [InverseProperty(nameof(TbCartao.TbCartaoComentario))]
        public virtual TbCartao IdCartaoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(TbUsuario.TbCartaoComentario))]
        public virtual TbUsuario IdUsuarioNavigation { get; set; }
    }
}
