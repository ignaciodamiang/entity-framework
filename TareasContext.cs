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
            // Lista de categorias iniciales
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria() { CategoriaId= Guid.Parse("40d79cef-73f1-4fe8-8a6c-168d99e4260a"), Nombre = "Trabajo", Descripcion = "Tareas de trabajo", Peso = 1 });
            categoriasInit.Add(new Categoria() { CategoriaId= Guid.Parse("40d79cef-73f1-4fe8-8a6c-168d99e426bc"), Nombre = "Personal", Descripcion = "Tareas personales", Peso = 2 });

            // Lista de tareas iniciales
            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("40d79cef-73f1-4fe8-8a6c-168d99e4260b"), CategoriaId = Guid.Parse("40d79cef-73f1-4fe8-8a6c-168d99e4260a"), Titulo = "Tarea 1", Descripcion = "Tarea 1 de trabajo", PrioridadTarea = Prioridad.Baja, FechaCreacion = DateTime.Now });
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("40d79cef-73f1-4fe8-8a6c-168d99e4260c"), CategoriaId = Guid.Parse("40d79cef-73f1-4fe8-8a6c-168d99e426bc"), Titulo = "Tarea 2", Descripcion = "Tarea 2 personal", PrioridadTarea = Prioridad.Media, FechaCreacion = DateTime.Now });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(50);
                tarea.Property(p => p.Descripcion).IsRequired(false);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                tarea.HasOne(p => p.Categoria)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(p => p.CategoriaId)
                    .HasConstraintName("FK_Tarea_Categoria");
                tarea.Ignore(p => p.Resumen);
                tarea.HasData(tareasInit);

            });
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(50);
                categoria.Property(p => p.Descripcion).IsRequired(false);
                categoria.Property(p => p.Peso);
                // Inicializacion de datos, se agrega lista de categorias
                categoria.HasData(categoriasInit);
            });
        }
    }
}