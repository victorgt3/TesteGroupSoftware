using GroupSoftware.Repository.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GroupSoftware.Repository.Entities
{
    public class Pedido : IEntityCommonProperty
    {
        public Pedido()
        {
            ProdutoPedidos = new HashSet<ProdutoPedido>();
        }
        [Required]
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Required]
        [Column("data-cadastro")]
        public DateTime DataCadastro { get; set; }
        [Required]
        [Column("idCliente")]
        public Guid IdCliente { get; set; }
        [Required]
        [Column("status-entrega")]
        public string StatusEntrega { get; set; }
        public virtual ProdutoPedido ProdutoPedido { get; set; }
        [ForeignKey(nameof(IdCliente))]
        public virtual Cliente Cliente { get; set; }
        [JsonIgnore]
        [InverseProperty("Pedido")]
        public virtual ICollection<ProdutoPedido> ProdutoPedidos { get; set; }
    }
}
