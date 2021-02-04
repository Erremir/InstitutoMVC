using InstitutoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoMVC.Controllers
{
    public class ProfesoresController : Controller
    {
        public List<Profesor> Profesores = new List<Profesor>();
        
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear([Bind("Nombre, Apellido, DNI, Email, FechaNacimiento, Domicilio, Telefono")] Profesor profesor)
        {

            profesor.Id = Guid.NewGuid();

            Profesores.Add(profesor);

            return View("Detalle", profesor);
        }

        public IActionResult Actualizar(Guid id)
        {
            Profesor profesor = Profesores.Find(a => a.Id == id);

            return View(profesor);
        }

        [HttpPut]
        public IActionResult Actualizar([Bind("Id, Nombre, Apellido, DNI, Email, FechaNacimiento, Domicilio, Telefono, legajo")] Profesor profesor)
        {
            Profesor oldProfesor = Profesores.Find(a => a.Id == profesor.Id);
            Profesores.Remove(oldProfesor);
            Profesores.Add(profesor);

            return View("Detalle", profesor);
        }

        public IActionResult Listar()
        {
            return View(Profesores);
        }

    }
}
