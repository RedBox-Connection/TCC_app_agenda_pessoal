using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_cartao")]
    public partial class TbCartao
    {
        public TbCartao()
        {
            TbCartaoComentario = new HashSet<TbCartaoComentario>();
            TbChecklist = new HashSet<TbChecklist>();
        }

        [Key]
        [Column("id_cartao")]
        public int IdCartao { get; set; }
        [Required]
        [Column("nm_cartao", TypeName = "varchar(100)")]
        public string NmCartao { get; set; }
        [Column("ds_cartao", TypeName = "varchar(500)")]
        public string DsCartao { get; set; }
        [Column("dt_inclusao", TypeName = "datetime")]
        public DateTime DtInclusao { get; set; }
        [Column("dt_termino", TypeName = "datetime")]
        public DateTime DtTermino { get; set; }
        [Required]
        [Column("ds_cor", TypeName = "varchar(100)")]
        public string DsCor { get; set; }
        [Required]
        [Column("ds_status", TypeName = "varchar(100)")]
        public string DsStatus { get; set; }
        [Column("id_quadro")]
        public int IdQuadro { get; set; }

        [ForeignKey(nameof(IdQuadro))]
        [InverseProperty(nameof(TbQuadro.TbCartao))]
        public virtual TbQuadro IdQuadroNavigation { get; set; }
        [InverseProperty("IdCartaoNavigation")]
        public virtual ICollection<TbCartaoComentario> TbCartaoComentario { get; set; }
        [InverseProperty("IdCartaoNavigation")]
        public virtual ICollection<TbChecklist> TbChecklist { get; set; }
    }
}
