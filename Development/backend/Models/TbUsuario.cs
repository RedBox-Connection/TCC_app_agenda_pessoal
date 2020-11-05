using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_usuario")]
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            TbCartaoComentario = new HashSet<TbCartaoComentario>();
            TbQuadro = new HashSet<TbQuadro>();
            TbTimeIntegrante = new HashSet<TbTimeIntegrante>();
        }

        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Required]
        [Column("nm_perfil", TypeName = "varchar(100)")]
        public string NmPerfil { get; set; }
        [Required]
        [Column("nm_usuario", TypeName = "varchar(100)")]
        public string NmUsuario { get; set; }
        [Required]
        [Column("ds_foto", TypeName = "varchar(200)")]
        public string DsFoto { get; set; }
        [Column("bt_receber_email")]
        public bool BtReceberEmail { get; set; }
        [Column("id_login")]
        public int IdLogin { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbUsuario))]
        public virtual TbLogin IdLoginNavigation { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<TbCartaoComentario> TbCartaoComentario { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<TbQuadro> TbQuadro { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<TbTimeIntegrante> TbTimeIntegrante { get; set; }
    }
}
