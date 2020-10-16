using GroupSoftware.Repository.DependencyInjection;
using GroupSoftware.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroupSoftware.Repository
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoPedido> ProdutoPedido { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DependencyInjectionSupport.ConfigureOptionsBuilder(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pedido_fk");
            });
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
            modelBuilder.Entity<ProdutoPedido>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Pedido)
                     .WithMany(p => p.ProdutoPedidos)
                     .HasForeignKey(d => d.IdPedido)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("pedido_fk_produto");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.ProdutoPedido)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produto_fk_pedido");
            });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
