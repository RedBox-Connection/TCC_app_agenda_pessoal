using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_time")]
    public partial class TbTime
    {
        public TbTime()
        {
            TbTimeIntegrante = new HashSet<TbTimeIntegrante>();
        }

        [Key]
        [Column("id_time", TypeName = "int(11)")]
        public int IdTime { get; set; }
        [Required]
        [Column("nm_time", TypeName = "varchar(100)")]
        public string NmTime { get; set; }
        [Column("ds_time", TypeName = "varchar(500)")]
        public string DsTime { get; set; }
        [Column("ds_link_convite", TypeName = "varchar(100)")]
        public string DsLinkConvite { get; set; }
        [Column("id_quadro", TypeName = "int(11)")]
        public int IdQuadro { get; set; }

        [ForeignKey(nameof(IdQuadro))]
        [InverseProperty(nameof(TbQuadro.TbTime))]
        public virtual TbQuadro IdQuadroNavigation { get; set; }
        [InverseProperty("IdTimeNavigation")]
        public virtual ICollection<TbTimeIntegrante> TbTimeIntegrante { get; set; }
    }
}
