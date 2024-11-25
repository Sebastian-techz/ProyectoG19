namespace ProyectoG19.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        public string Autor { get; set; }
    }


}
