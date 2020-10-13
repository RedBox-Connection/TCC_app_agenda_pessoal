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
        [Column("id_esqueci_senha")]
        public int IdEsqueciSenha { get; set; }
        [Column("ds_email_alternativo", TypeName = "varchar(100)")]
        public string DsEmailAlternativo { get; set; }
        [Required]
        [Column("nr_codigo", TypeName = "mediumtext")]
        public string NrCodigo { get; set; }
        [Column("tm_inclusao", TypeName = "datetime")]
        public DateTime TmInclusao { get; set; }
        [Column("tm_expiracao", TypeName = "datetime")]
        public DateTime TmExpiracao { get; set; }
        [Column("id_login")]
        public int IdLogin { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbEsqueciSenha))]
        public virtual TbLogin IdLoginNavigation { get; set; }
    }
}
