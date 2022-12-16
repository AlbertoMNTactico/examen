namespace encuesta.Models
{
    //en esta clase obtenemos los elementos que vamos a observar en el swagger
    public class difEncuestas
    {
        public long IdEncuesta { get; set; }

        public string? nombreEncuesta { get; set; }

        public bool categoriaEncuesta { get; set; }

        public string? estatusEncuesta { get; set; }

    }
}
