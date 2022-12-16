using Microsoft.EntityFrameworkCore;
namespace encuesta.Models
{
    //aqui hacemos la conexion con la memoria / base de datos
    public class encuestaContext : DbContext
    {
        public encuestaContext(DbContextOptions<encuestaContext>options) 
            : base(options) 
        { 

        }
        public DbSet<difEncuestas> difEncuestas { get; set; } = null!;
    }
}
