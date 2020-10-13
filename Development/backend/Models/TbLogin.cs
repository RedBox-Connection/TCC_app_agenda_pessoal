using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_login")]
    public partial class TbLogin
    {
        public TbLogin()
        {
            TbEsqueciSenha = new HashSet<TbEsqueciSenha>();
            TbUsuario = new HashSet<TbUsuario>();
        }

        [Key]
        [Column("id_login")]
        public int IdLogin { get; set; }
        [Required]
        [Column("ds_email", TypeName = "varchar(100)")]
        public string DsEmail { get; set; }
        [Required]
        [Column("ds_senha", TypeName = "varchar(100)")]
        public string DsSenha { get; set; }
        [Column("dt_ult_login", TypeName = "datetime")]
        public DateTime DtUltLogin { get; set; }

        [InverseProperty("IdLoginNavigation")]
        public virtual ICollection<TbEsqueciSenha> TbEsqueciSenha { get; set; }
        [InverseProperty("IdLoginNavigation")]
        public virtual ICollection<TbUsuario> TbUsuario { get; set; }
    }
}
