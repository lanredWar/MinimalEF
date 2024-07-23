using Microsoft.EntityFrameworkCore;
using MinimalEF.Migrations;
namespace MinimalEF.Models;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get; set;}
    public DbSet<Tarea> Tareas {get; set;}
    public TareasContext(DbContextOptions<TareasContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        
        //Coleccion de datos iniciales a "Categoria"
        categoriasInit.Add(new Categoria()
        {
            CategoriaId = Guid.Parse("588afe2f-48ba-4051-8c09-ff756b1c151f"),
            Nombre = "Actividades Pendientes",
            Peso = 20
        });

        categoriasInit.Add(new Categoria()
        {
            CategoriaId = Guid.Parse("588afe2f-48ba-4051-8c08-ff756b1c159e"),
            Nombre = "Actividades Personales",
            Peso = 50
        });

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=>p.CategoriaId);
            categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Descripcion).IsRequired(false);
            categoria.Property(p=> p.Peso);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();

        //Coleccion de datos iniciales a "Categoria"        
        tareasInit.Add(new Tarea(){
             TareaId = Guid.Parse("588afe2f-48ba-3000-8c09-ff756b1c151f")
            ,CategoriaId = Guid.Parse("588afe2f-48ba-4051-8c09-ff756b1c151f")
            ,PrioridadTarea = Prioridad.Media
            ,Titulo = "Pago de servicios publicos"
            ,FechaCreacion = DateTime.Now
        });

        tareasInit.Add(new Tarea(){
             TareaId = Guid.Parse("588afe2f-48ba-4000-8c08-ff756b1c159e")
            ,CategoriaId = Guid.Parse("588afe2f-48ba-4051-8c08-ff756b1c159e")
            ,PrioridadTarea = Prioridad.Baja
            ,Titulo = "Terminar de ver peliculas en Netflix"
            ,FechaCreacion = DateTime.Now
        });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.TareaId);
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=>p.CategoriaId);
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=> p.Descripcion).IsRequired(false);
            tarea.Property(p=> p.PrioridadTarea);
            tarea.Property(p=> p.FechaCreacion);
            tarea.Ignore(p=> p.Resumen);
            tarea.Property(p=> p.Secuencia);
            tarea.HasData(tareasInit);
        });
    }
}