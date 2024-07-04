using Microsoft.EntityFrameworkCore;
namespace MinimalEF.Models;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get; set;}
}