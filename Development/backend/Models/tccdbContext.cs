using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.Models
{
    public partial class tccdbContext : DbContext
    {
        public tccdbContext()
        {
        }

        public tccdbContext(DbContextOptions<tccdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCartao> TbCartao { get; set; }
        public virtual DbSet<TbCartaoComentario> TbCartaoComentario { get; set; }
        public virtual DbSet<TbChecklist> TbChecklist { get; set; }
        public virtual DbSet<TbChecklistItem> TbChecklistItem { get; set; }
        public virtual DbSet<TbEsqueciSenha> TbEsqueciSenha { get; set; }
        public virtual DbSet<TbLogin> TbLogin { get; set; }
        public virtual DbSet<TbQuadro> TbQuadro { get; set; }
        public virtual DbSet<TbTime> TbTime { get; set; }
        public virtual DbSet<TbTimeIntegrante> TbTimeIntegrante { get; set; }
        public virtual DbSet<TbUsuario> TbUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql("server=localhost;user id=root;password=1234;database=tccdb", x => x.ServerVersion("8.0.21-mysql"));
                optionsBuilder.UseMySql("server=localhost;user id=root;password=A1234;database=tccdb", x => x.ServerVersion("8.0.21-mysql"));
                //optionsBuilder.UseMySql("server=localhost;user id=admin;password=Red@Box123;database=tccdb", x => x.ServerVersion("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCartao>(entity =>
            {
                entity.HasKey(e => e.IdCartao)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdQuadro)
                    .HasName("id_quadro");

                entity.Property(e => e.DsCartao)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsCor)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsStatus)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmCartao)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdQuadroNavigation)
                    .WithMany(p => p.TbCartao)
                    .HasForeignKey(d => d.IdQuadro)
                    .HasConstraintName("tb_cartao_ibfk_1");
            });

            modelBuilder.Entity<TbCartaoComentario>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCartao)
                    .HasName("id_cartao");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("id_usuario");

                entity.Property(e => e.DsComentario)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCartaoNavigation)
                    .WithMany(p => p.TbCartaoComentario)
                    .HasForeignKey(d => d.IdCartao)
                    .HasConstraintName("tb_cartao_comentario_ibfk_1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbCartaoComentario)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("tb_cartao_comentario_ibfk_2");
            });

            modelBuilder.Entity<TbChecklist>(entity =>
            {
                entity.HasKey(e => e.IdChecklist)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCartao)
                    .HasName("id_cartao");

                entity.Property(e => e.NmChecklist)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCartaoNavigation)
                    .WithMany(p => p.TbChecklist)
                    .HasForeignKey(d => d.IdCartao)
                    .HasConstraintName("tb_checklist_ibfk_1");
            });

            modelBuilder.Entity<TbChecklistItem>(entity =>
            {
                entity.HasKey(e => e.IdItem)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdChecklist)
                    .HasName("id_checklist");

                entity.Property(e => e.NmItem)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdChecklistNavigation)
                    .WithMany(p => p.TbChecklistItem)
                    .HasForeignKey(d => d.IdChecklist)
                    .HasConstraintName("tb_checklist_item_ibfk_1");
            });

            modelBuilder.Entity<TbEsqueciSenha>(entity =>
            {
                entity.HasKey(e => e.IdEsqueciSenha)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdLogin)
                    .HasName("id_login");

                entity.Property(e => e.DsEmail)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NrCodigo)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TbEsqueciSenha)
                    .HasForeignKey(d => d.IdLogin)
                    .HasConstraintName("tb_esqueci_senha_ibfk_1");
            });

            modelBuilder.Entity<TbLogin>(entity =>
            {
                entity.HasKey(e => e.IdLogin)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsEmail)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsSenha)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbQuadro>(entity =>
            {
                entity.HasKey(e => e.IdQuadro)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("id_usuario");

                entity.Property(e => e.NmQuadro)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbQuadro)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("tb_quadro_ibfk_1");
            });

            modelBuilder.Entity<TbTime>(entity =>
            {
                entity.HasKey(e => e.IdTime)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdQuadro)
                    .HasName("id_quadro");

                entity.Property(e => e.DsLinkConvite)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsTime)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmTime)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdQuadroNavigation)
                    .WithMany(p => p.TbTime)
                    .HasForeignKey(d => d.IdQuadro)
                    .HasConstraintName("tb_time_ibfk_1");
            });

            modelBuilder.Entity<TbTimeIntegrante>(entity =>
            {
                entity.HasKey(e => e.IdIntegrante)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdTime)
                    .HasName("id_time");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("id_usuario");

                entity.Property(e => e.DsPermissao)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdTimeNavigation)
                    .WithMany(p => p.TbTimeIntegrante)
                    .HasForeignKey(d => d.IdTime)
                    .HasConstraintName("tb_time_integrante_ibfk_2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbTimeIntegrante)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("tb_time_integrante_ibfk_1");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdLogin)
                    .HasName("id_login");

                entity.Property(e => e.DsFoto)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmPerfil)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmUsuario)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TbUsuario)
                    .HasForeignKey(d => d.IdLogin)
                    .HasConstraintName("tb_usuario_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
