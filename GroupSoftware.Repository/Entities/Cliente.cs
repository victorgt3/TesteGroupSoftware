using GroupSoftware.Repository.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GroupSoftware.Repository.Entities
{
    public class Cliente : IEntityCommonProperty
    {
        public Cliente()
        {
            Pedido = new HashSet<Pedido>();
        }
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(255)]
        public string Nome { get; set; }
        [Column("data-cadastro")]
        public DateTime DataCadastro { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [JsonIgnore]
        [InverseProperty("Cliente")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
