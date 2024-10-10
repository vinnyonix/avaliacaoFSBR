using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AvaliacaoMVCValnei.Data.Entities
{
    public class ProcessEntity
    {
        [Key]
        [Column("ProcessId", TypeName = "int")]
        public int ProcessId { get; set; }

        [Column("Name", TypeName = "VARCHAR(100)")]
        public string? Name { get; set; }

        [Column("NPU", TypeName = "VARCHAR(20)")]
        public string? NPU { get; set; }

        [Column("CreateAt", TypeName = "datetime")]
        public DateTime? CreateAt { get; set; }

        [Column("ViewedAt", TypeName = "datetime")]
        public DateTime? ViewedAt { get; set; }

        [Column("Municipality", TypeName = "VARCHAR(50)")]
        public string? Municipality { get; set; }

        [Column("UF", TypeName = "VARCHAR(2)")]
        public string? FederativeUnit { get; set; }
    }
}
