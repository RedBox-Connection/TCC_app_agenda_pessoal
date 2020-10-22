using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_esqueci_senha")]
    public partial class TbEsqueciSenha
    {
        [Key]
        [Column("id_esqueci_senha", TypeName = "int(11)")]
        public int IdEsqueciSenha { get; set; }
        [Column("ds_email", TypeName = "varchar(100)")]
        public string DsEmail { get; set; }
        [Required]
        [Column("nr_codigo", TypeName = "mediumtext")]
        public long NrCodigo { get; set; }
        [Column("tm_inclusao", TypeName = "datetime")]
        public DateTime TmInclusao { get; set; }
        [Column("tm_expiracao", TypeName = "datetime")]
        public DateTime TmExpiracao { get; set; }
        [Column("id_login", TypeName = "int(11)")]
        public int IdLogin { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbEsqueciSenha))]
        public virtual TbLogin IdLoginNavigation { get; set; }
    }
}
