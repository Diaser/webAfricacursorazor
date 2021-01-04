using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webAfricacursorazor.Models;

namespace webAfricacursorazor.Pages.ListaCursos
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [TempData]
        public string Mensaje { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Curso Curso { get; set; }
        public void OnGet()
        {
        }
        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Add(Curso);
            await _db.SaveChangesAsync();
            Mensaje = "Curso creado correctamente";
            return RedirectToPage("Index");
        }
    }
}
