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

        private readonly InstitutoContext _context;

        public CursosController(InstitutoContext context)
        {
            _context = context;
        }

        public ActionResult Crear()
        {
            ViewBag.profesores = _context.Profesores;
            return View();
        }

        [HttpPost]
        public IActionResult Crear([Bind("Denominacion, ProfesorId")] Curso curso)
        {

            curso.Id = Guid.NewGuid();

            Profesor profesor = _context.Profesores.Find(curso.ProfesorId);
            curso.Profesor = profesor;

            _context.Cursos.Add(curso);
            _context.SaveChanges();

            return View("Detalle", curso);
        }

        public IActionResult Actualizar(Guid id)
        {
            ViewBag.profesores = _context.Profesores;
            Curso curso = _context.Cursos.Find(id);
            
            return View(curso);
        }

        [HttpPost]
        public IActionResult Actualizar([Bind("Id, Denominacion, ProfesorId")] Curso curso)
        {

            Profesor profesor = _context.Profesores.Find(curso.ProfesorId);
            curso.Profesor = profesor;

            _context.Cursos.Update(curso);
            _context.SaveChanges();

            return View("Detalle", curso);
        }

        public IActionResult Listar()
        {
            List<Curso> Cursos = _context.Cursos.ToList();
            foreach (Curso curso in Cursos)
            {
                Profesor profesor = _context.Profesores.Find(curso.ProfesorId);
                curso.Profesor = profesor;
            }
            return View(Cursos);
        }
    }
}
