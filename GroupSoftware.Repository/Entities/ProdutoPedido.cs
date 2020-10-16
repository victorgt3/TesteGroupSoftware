using GroupSoftware.Repository.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GroupSoftware.Repository.Entities
{
    public class ProdutoPedido : IEntityCommonProperty
    {
        [Key]
        [Column("id")]
        [JsonIgnore]
        public Guid Id { get; set; }
        [Column("idProduto")]
        [JsonIgnore]
        public Guid IdProduto { get; set; }
        [Column("idPedido")]
        [JsonIgnore]
        public Guid IdPedido { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        [ForeignKey(nameof(IdProduto))]
        [JsonIgnore]
        public virtual Produto Produto { get; set; }
        [ForeignKey(nameof(IdPedido))]
        [JsonIgnore]
        public virtual Pedido Pedido { get; set; }
        [Required]
        [Column("quantidade")]
        public int Quantidade { get; set; }
    }
}
