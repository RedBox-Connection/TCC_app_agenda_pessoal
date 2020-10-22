using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_checklist")]
    public partial class TbChecklist
    {
        public TbChecklist()
        {
            TbChecklistItem = new HashSet<TbChecklistItem>();
        }

        [Key]
        [Column("id_checklist", TypeName = "int(11)")]
        public int IdChecklist { get; set; }
        [Required]
        [Column("nm_checklist", TypeName = "varchar(100)")]
        public string NmChecklist { get; set; }
        [Column("id_cartao", TypeName = "int(11)")]
        public int IdCartao { get; set; }

        [ForeignKey(nameof(IdCartao))]
        [InverseProperty(nameof(TbCartao.TbChecklist))]
        public virtual TbCartao IdCartaoNavigation { get; set; }
        [InverseProperty("IdChecklistNavigation")]
        public virtual ICollection<TbChecklistItem> TbChecklistItem { get; set; }
    }
}
