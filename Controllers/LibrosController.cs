using Microsoft.AspNetCore.Mvc;
using ProyectoG19.Models;
namespace ProyectoG19.Controllers
{
    public class LibrosController : Controller
    {
        private static List<Libro> libros = new List<Libro>();  // Asegúrate de que la lista esté inicializada

        private static int idContador = 1;  // Variable estática para contar los ids

        // Acción para mostrar la lista de libros
        public IActionResult Index()
        {
            return View(libros);  // Debería pasar la lista correctamente
        }

        // Acción que muestra la vista para agregar un nuevo libro
        public IActionResult Agregar()
        {
            return View();
        }

        // Acción que guarda un nuevo libro
        [HttpPost]
        public IActionResult Agregar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                libro.Id = libros.Count + 1;  // Asignamos un Id único
                libros.Add(libro);  // Agregamos el libro a la lista
                return RedirectToAction("Index");  // Redirigimos a la lista de libros
            }
            return View(libro);  // Si el modelo no es válido, mostramos el formulario nuevamente
        }


        // Acción para mostrar un libro en la vista de modificación
        public IActionResult Modificar(int id)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);
            if (libro == null)
            {
                return NotFound();  // Si no se encuentra el libro, devolver un error 404
            }

            return View(libro);  // Pasar el libro encontrado a la vista
        }

        // Acción para guardar los cambios del libro
        [HttpPost]
        public IActionResult Modificar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                var libroExistente = libros.FirstOrDefault(l => l.Id == libro.Id);
                if (libroExistente != null)
                {
                    libroExistente.Titulo = libro.Titulo;
                    libroExistente.Autor = libro.Autor;
                }

                return RedirectToAction("Index");  // Redirigimos a la lista de libros
            }
            return View(libro);  // Si el modelo no es válido, mostramos el formulario nuevamente
        }

        // Acción para eliminar un libro
        public IActionResult Eliminar(int id)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);
            if (libro != null)
            {
                libros.Remove(libro);  // Eliminamos el libro de la lista
            }

            return RedirectToAction("Index");  // Redirigimos a la lista de libros
        }
    }








}

