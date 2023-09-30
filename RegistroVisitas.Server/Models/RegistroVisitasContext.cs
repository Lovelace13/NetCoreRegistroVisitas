using System;
using System.Collections.Generic;


namespace RegistroVisitas.Server.Models;

public partial class RegistroVisitasContext : DbContext
{
    public RegistroVisitasContext()
    {
    }

    public RegistroVisitasContext(DbContextOptions<RegistroVisitasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthUser> AuthUsers { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Visitante> Visitantes { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer(); //"Name=ConnectionStrings:RegistroVisitas"

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("authUser");

            entity.Property(e => e.Contraseña)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDep).HasName("PK__departam__3E4145035B4037C6");

            entity.ToTable("departamentos");

            entity.Property(e => e.IdDep)
                .ValueGeneratedNever()
                .HasColumnName("idDep");
            entity.Property(e => e.CodDep)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("codDep");
            entity.Property(e => e.NombreDep)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreDep");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => new { e.Iduser, e.Correo }).HasName("PK__usuarios__98F5772EC94171B5");

            entity.ToTable("usuarios");

            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Lastname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Rol)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rol");
        });

        modelBuilder.Entity<Visitante>(entity =>
        {
            entity.HasKey(e => e.Idvisita).HasName("PK__visitant__4F5411D59E015E13");

            entity.ToTable("visitantes");

            entity.Property(e => e.Idvisita)
                .ValueGeneratedNever()
                .HasColumnName("idvisita");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Departamento)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("departamento");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fechaingreso)
                .HasColumnType("date")
                .HasColumnName("fechaingreso");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.Motivo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("motivo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Novedad)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("novedad");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
