using Academico.Data;
using Academico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Academico.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AcademicoContext _context;

        public AlunoController(AcademicoContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome", "Email", "Telefone", "Endereco", "Complemento", "Bairro", "Municipio", "Uf", "Cep")] Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    return RedirectToAction("Index");
                }
                return View(aluno);
            }
            catch(Exception ex)
            {
                ViewData["Erro"] = ex.Message;
                return View(aluno);
            }
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Alunos.OrderBy(a => a.Nome).ToListAsync());
        }
    }
}
