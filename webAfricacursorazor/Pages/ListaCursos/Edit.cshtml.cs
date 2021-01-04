using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webAfricacursorazor.Models;

namespace webAfricacursorazor.Pages.ListaCursos
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Curso Curso { get; set; }
        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet(int id)
        {
            Curso = await _db.Curso.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CursoDesdeDB = await _db.Curso.FindAsync(Curso.Id);
                CursoDesdeDB.NombreCurso = Curso.NombreCurso;
                CursoDesdeDB.CantidadClases = Curso.CantidadClases;
                CursoDesdeDB.Precio = Curso.Precio;

                await _db.SaveChangesAsync();
                Mensaje = "Editado correctamente";
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
