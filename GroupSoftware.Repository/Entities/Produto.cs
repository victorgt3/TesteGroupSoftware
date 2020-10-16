using GroupSoftware.Repository.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GroupSoftware.Repository.Entities
{
    public class Produto : IEntityCommonProperty
    {
        public Produto()
        {
            ProdutoPedido = new HashSet<ProdutoPedido>();
        }

        [Required]
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [Column("valor")]
        public double Valor { get; set; }
        [Column("disponivel")]
        public bool Disponivel { get; set; }
        [JsonIgnore]
        [InverseProperty("Produto")]
        public virtual ICollection<ProdutoPedido> ProdutoPedido { get; set; }

    }
}
