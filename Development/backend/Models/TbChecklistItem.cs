using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_checklist_item")]
    public partial class TbChecklistItem
    {
        [Key]
        [Column("id_item", TypeName = "int(11)")]
        public int IdItem { get; set; }
        [Required]
        [Column("nm_item", TypeName = "varchar(100)")]
        public string NmItem { get; set; }
        [Column("bt_feito")]
        public bool BtFeito { get; set; }
        [Column("id_checklist", TypeName = "int(11)")]
        public int IdChecklist { get; set; }

        [ForeignKey(nameof(IdChecklist))]
        [InverseProperty(nameof(TbChecklist.TbChecklistItem))]
        public virtual TbChecklist IdChecklistNavigation { get; set; }
    }
}
