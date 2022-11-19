using entitiyframework.Models;
using Microsoft.EntityFrameworkCore;

namespace entitiyframework
{
    public class TareasContext : DbContext
    {
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        // Sobreescritura del método OnModelCreating
        // Validaciones que estaban en entidades ahora están en el contexto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Validaciones de las tablas, se quitan de las entidades
            // Creación de la tabla Tareas
            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(50);
                tarea.Property(p => p.Descripcion);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                tarea.HasOne(p => p.Categoria)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(p => p.CategoriaId)
                    .HasConstraintName("FK_Tarea_Categoria");
                // Not mapped
                tarea.Ignore(p => p.Resumen);

            });
            // Creación de la tabla Categorias
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(50);
                categoria.Property(p => p.Descripcion);
            });
        }
    }
}