using System;
using System.Collections.Generic;
using Gestion_de_Eventos.EventosMosdels;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Eventos.Data;

public partial class EventosContext : DbContext
{
    public EventosContext()
    {
    }

    public EventosContext(DbContextOptions<EventosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencias { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<EventosFavorito> EventosFavoritos { get; set; }

    public virtual DbSet<HistorialUsurario> HistorialUsurarios { get; set; }

    public virtual DbSet<InicioDeSecion> InicioDeSecions { get; set; }

    public virtual DbSet<Organizadore> Organizadores { get; set; }

    public virtual DbSet<Preguntum> Pregunta { get; set; }

    public virtual DbSet<SeguirOrganizadore> SeguirOrganizadores { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=eventos;uid=root;pwd=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.19-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia).HasName("PRIMARY");

            entity.ToTable("asistencias");

            entity.HasIndex(e => new { e.IdAsistencia, e.IdUsuario, e.IdEvento }, "id_asistencia").IsUnique();

            entity.HasIndex(e => e.IdEvento, "id_evento");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdAsistencia).HasColumnName("id_asistencia");
            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("asistencias_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("asistencias_ibfk_1");
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PRIMARY");

            entity.ToTable("comentarios");

            entity.HasIndex(e => e.IdOrganizador, "id_organizador");

            entity.HasIndex(e => new { e.IdUsuario, e.IdOrganizador }, "id_usuario").IsUnique();

            entity.Property(e => e.IdComentario).HasColumnName("id_comentario");
            entity.Property(e => e.Comentario1)
                .HasMaxLength(50)
                .HasColumnName("comentario");
            entity.Property(e => e.IdOrganizador).HasColumnName("id_organizador");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdOrganizadorNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdOrganizador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comentarios_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comentarios_ibfk_1");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.IdEvento).HasName("PRIMARY");

            entity.ToTable("eventos");

            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.CapacidadMax).HasColumnName("capacidad_max");
            entity.Property(e => e.Costo).HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasColumnType("time")
                .HasColumnName("hora");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<EventosFavorito>(entity =>
        {
            entity.HasKey(e => e.IdFavorito).HasName("PRIMARY");

            entity.ToTable("eventos_favoritos");

            entity.HasIndex(e => e.IdEvento, "id_evento");

            entity.HasIndex(e => new { e.IdUsuario, e.IdEvento }, "id_usuario").IsUnique();

            entity.Property(e => e.IdFavorito).HasColumnName("id_favorito");
            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.EventosFavoritos)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("eventos_favoritos_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.EventosFavoritos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("eventos_favoritos_ibfk_1");
        });

        modelBuilder.Entity<HistorialUsurario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("historial_usurario");

            entity.HasIndex(e => e.IdAsistencia, "id_asistencia");

            entity.HasIndex(e => e.IdEvento, "id_evento");

            entity.HasIndex(e => new { e.IdUsuario, e.IdEvento }, "id_usuario").IsUnique();

            entity.Property(e => e.IdAsistencia).HasColumnName("id_asistencia");
            entity.Property(e => e.IdEvento).HasColumnName("id_evento");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdAsistenciaNavigation).WithMany()
                .HasForeignKey(d => d.IdAsistencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("historial_usurario_ibfk_3");

            entity.HasOne(d => d.IdEventoNavigation).WithMany()
                .HasForeignKey(d => d.IdEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("historial_usurario_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("historial_usurario_ibfk_1");
        });

        modelBuilder.Entity<InicioDeSecion>(entity =>
        {
            entity.HasKey(e => e.IdInicioSecion).HasName("PRIMARY");

            entity.ToTable("inicio_de_secion");

            entity.HasIndex(e => e.Correo, "correo").IsUnique();

            entity.HasIndex(e => e.OrganizadorId, "organizador_id");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.IdInicioSecion).HasColumnName("id_inicioSecion");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(10)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.OrganizadorId).HasColumnName("organizador_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Organizador).WithMany(p => p.InicioDeSecions)
                .HasForeignKey(d => d.OrganizadorId)
                .HasConstraintName("inicio_de_secion_ibfk_2");

            entity.HasOne(d => d.Usuario).WithMany(p => p.InicioDeSecions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("inicio_de_secion_ibfk_1");
        });

        modelBuilder.Entity<Organizadore>(entity =>
        {
            entity.HasKey(e => e.IdOrganizador).HasName("PRIMARY");

            entity.ToTable("organizadores");

            entity.HasIndex(e => e.IdOrganizador, "id_organizador").IsUnique();

            entity.Property(e => e.IdOrganizador).HasColumnName("id_organizador");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .HasColumnName("nombre_usuario");
        });

        modelBuilder.Entity<Preguntum>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PRIMARY");

            entity.ToTable("pregunta");

            entity.HasIndex(e => e.IdOrganizador, "id_organizador");

            entity.HasIndex(e => new { e.IdUsuario, e.IdOrganizador }, "id_usuario").IsUnique();

            entity.Property(e => e.IdPregunta).HasColumnName("id_pregunta");
            entity.Property(e => e.IdOrganizador).HasColumnName("id_organizador");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Pregunta)
                .HasMaxLength(50)
                .HasColumnName("pregunta");

            entity.HasOne(d => d.IdOrganizadorNavigation).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.IdOrganizador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pregunta_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pregunta_ibfk_1");
        });

        modelBuilder.Entity<SeguirOrganizadore>(entity =>
        {
            entity.HasKey(e => e.IdSeguidor).HasName("PRIMARY");

            entity.ToTable("seguir_organizadores");

            entity.HasIndex(e => e.IdOrganizador, "id_organizador");

            entity.HasIndex(e => new { e.IdUsuario, e.IdOrganizador }, "id_usuario").IsUnique();

            entity.Property(e => e.IdSeguidor).HasColumnName("id_seguidor");
            entity.Property(e => e.IdOrganizador).HasColumnName("id_organizador");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdOrganizadorNavigation).WithMany(p => p.SeguirOrganizadores)
                .HasForeignKey(d => d.IdOrganizador)
                .HasConstraintName("seguir_organizadores_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.SeguirOrganizadores)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("seguir_organizadores_ibfk_1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.IdUsuario, "id_usuario").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.MetodoDePago)
                .HasMaxLength(50)
                .HasColumnName("metodo_de_pago");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .HasColumnName("nombre_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
