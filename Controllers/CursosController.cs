using InstitutoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoMVC.Controllers
{
    public class CursosController : Controller
    {

        public List<Curso> Cursos = new List<Curso>();
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear([Bind("Denominacion")] Curso curso)
        {

            curso.Id = Guid.NewGuid();

            Cursos.Add(curso);

            return View("Detalle", curso);
        }

        public IActionResult Actualizar(Guid id)
        {
            Curso curso = Cursos.Find(a => a.Id == id);

            return View(curso);
        }

        [HttpPut]
        public IActionResult Actualizar([Bind("Id, Denominacion")] Curso curso)
        {
            Curso oldCurso = Cursos.Find(a => a.Id == curso.Id);
            Cursos.Remove(oldCurso);
            Cursos.Add(curso);

            return View("Detalle", curso);
        }

        public IActionResult Listar()
        {
            return View(Cursos);
        }
    }
}
